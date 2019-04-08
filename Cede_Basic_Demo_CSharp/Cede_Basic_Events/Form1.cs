using Cede_Basic_Events.Data;
using Cede_Basic_Events.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cede_Basic_Events
{
    public partial class Form1 : Form
    {
        
        public Guid IdEditing { get; set; } = Guid.Empty;
        public EventManagerFile EventManager { get; set; } = new EventManagerFile();
        public PersonalDataDB personalDataDB { get; set; } = new PersonalDataDB();

        public Form1()
        {             
            InitializeComponent();
            //gridEvents.DataSource = EventManager.Events;
            cboPersonal.DataSource = personalDataDB.GetPersonals();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region local functions 

            void ClearValues()
            {
                txtName.Text = "";
                txtDescription.Text = string.Empty;
                dtpDate.Value = DateTime.Now;
            }

            void ClearName() => txtName.Text = string.Empty;

            #endregion

            //opcion 1
            //if (txtName.Text == "" || txtName.Text==null)
            //{
            //    MessageBox.Show("El campo nombre es requerido");
            //}

            ////opcion 2 MessageBox
            //if (string.IsNullOrEmpty(txtName.Text) ||
            //    string.IsNullOrEmpty(txtDescription.Text))
            //{
            //    MessageBox.Show("Todos los campos son requeridos");
            //    return;
            //}

            //opcion 3 label
            if (string.IsNullOrEmpty(txtName.Text) ||
            string.IsNullOrEmpty(txtDescription.Text))
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Nombre y descripcion son requeridos";
                return;
            }

            //opcion 1
            //Event objevent = new Event();
            var objevent = new Event();           
            objevent.Name = txtName.Text;
            objevent.Description = txtDescription.Text;
            objevent.EventDate = dtpDate.Value;
            objevent.PersonalId = Guid.Parse(cboPersonal.SelectedValue.ToString());
            string checkString = chkPrivate.Checked.ToString();

            //bool boolIsPrivate = false;
            bool.TryParse(checkString, out var boolIsPrivate);

            objevent.IsPrivate = boolIsPrivate;

            //arrays
            //Event[] events = { objevent };

            //dictionaries
            //Dictionary<string, Event> dictionary = new Dictionary<string, Event>();
            //dictionary.Add(objevent.Name, objevent);
            //error duplicated
            //dictionary.Add(objevent.Name, objevent);


            if (IdEditing== Guid.Empty)
            {
                objevent.EventId = Guid.NewGuid();
                EventManager.AddEvent(objevent);
            }
            else
            {
                objevent.EventId = IdEditing;
                EventManager.EditEvent(IdEditing, objevent);
            }
           

            ClearValues();
            ClearAllValues();

            gridEvents.DataSource = EventManager.Events.ToList();

            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = "Registro guardado";

        }

        //private method related to the class 
        private void ClearAllValues()
        {            
            txtName.Text = "";
            txtDescription.Text = string.Empty;
            dtpDate.Value = DateTime.Now;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string textSearch = txtSearch.Text.ToLower();

            if (string.IsNullOrEmpty(textSearch)) return;

            var result = EventManager.Events.
                         Where(p => p.Name.ToLower().Contains(textSearch) || 
                                    p.Description.ToLower().Contains(textSearch)).ToList();

            gridResults.DataSource = result;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
        }

        private void btnEdit_MouseClick(object sender, MouseEventArgs e)
        {
            if (gridEvents.SelectedRows.Count > 0)
            {
                var Item = (Event)gridEvents.SelectedRows[0].DataBoundItem;
                txtName.Text = Item.Name;
                txtDescription.Text = Item.Description;
                dtpDate.Value = Item.EventDate;
                chkPrivate.Checked = Item.IsPrivate;
                IdEditing = Item.EventId;
                cboPersonal.SelectedValue = Item.PersonalId;

                lblMessage.ForeColor = Color.DarkBlue;
                lblMessage.Text = $@"Se esta editando el registro: 
                                   {Item.Name}";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAllValues();
            IdEditing = Guid.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridEvents.SelectedRows.Count > 0)
            {
                var dialogResult = MessageBox.Show("¿Esta seguro que desea eliminar el registro?","Confirmación", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes ||
                    dialogResult.ToString().Equals("Yes"))
                {
                    var Item = (Event)gridEvents.SelectedRows[0].DataBoundItem;
                    EventManager.DeleteEvent(Item.EventId);
                    gridEvents.DataSource = EventManager.Events.ToList();
                    lblMessage.Text = "Registro Eliminado";
                }               
            }
        }
    }
}

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
        List<Event> listEvent { get; set; } = new List<Event>();

        public Form1()
        {            
            InitializeComponent();
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

            #endregion

            //opcion 1
            //if (txtName.Text == "" || txtName.Text==null)
            //{
            //    MessageBox.Show("El campo nombre es requerido");
            //}

            //opcion 2
            if (string.IsNullOrEmpty(txtName.Text) ||
                string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Todos los campos son requeridos");
                return;
            }

            //opcion 1
            //Event objevent = new Event();
            var objevent = new Event();

            objevent.Name = txtName.Text;
            objevent.Description = txtDescription.Text;
            objevent.Date = dtpDate.Value;

            //arrays
            Event[] events = { objevent };

            //dictionaries
            Dictionary<string, Event> dictionary = new Dictionary<string, Event>();
            dictionary.Add(objevent.Name, objevent);
            //error duplicated
            //dictionary.Add(objevent.Name, objevent);

            listEvent.Add(objevent);

            ClearValues();
            ClearAllValues();

            gridEvents.DataSource = listEvent;
            gridEvents.Refresh();
            gridEvents.Update();

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

            var result = listEvent.
                         Where(p => p.Name.ToLower().Contains(textSearch) || 
                                    p.Description.ToLower().Contains(textSearch)).ToList();

            gridResults.DataSource = result;
        }
    }
}

using Cede_Basic_Events.Models;
using Cede_Basic_Events_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cede_Basic_Events.Data
{
    public class PersonalDataDB
    {
        public List<Personal> GetPersonals()
        {
            List<Personal> personals = new List<Personal>();

            Connection con = new Connection();

            var datatable = con.GetData("SELECT * FROM Personal");

            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                Personal personal = new Personal();
                personal.PersonalId = Guid.Parse(datatable.Rows[i]["PersonalId"].ToString());
                personal.Name = datatable.Rows[i]["Name"].ToString();
                personal.LastName = datatable.Rows[i]["LastName"].ToString();
                personal.Phone = datatable.Rows[i]["Phone"].ToString();
                personal.Email = datatable.Rows[i]["Email"].ToString();
                personal.IsDeleted = bool.Parse(datatable.Rows[i]["IsDeleted"].ToString());

                personals.Add(personal);

            }


            return personals;
        }
    }
}

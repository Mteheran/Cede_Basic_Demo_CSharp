using Cede_Basic_Events.Data.Interfaces;
using Cede_Basic_Events.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cede_Basic_Events.Data
{
    public class PersonalDataFile: IPersonalData
    {
        private List<Personal> Personals { get; set; } = new List<Personal>();

        public List<Personal> GetPersonals()
        {
            Personals = new List<Personal>();
            Personals.Add(new Personal() { PersonalId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Anderson", LastName = "Zapata", IsDeleted = false });
            Personals.Add(new Personal() { PersonalId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Laura", LastName = "Arbelaez", IsDeleted = false });

            return Personals;
        }
    }
}

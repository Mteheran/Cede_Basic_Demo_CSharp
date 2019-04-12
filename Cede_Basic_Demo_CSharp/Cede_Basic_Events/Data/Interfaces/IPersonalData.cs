using Cede_Basic_Events.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cede_Basic_Events.Data.Interfaces
{
    public interface IPersonalData
    {
        List<Personal> GetPersonals();
    }
}

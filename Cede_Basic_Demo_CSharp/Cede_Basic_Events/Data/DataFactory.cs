using Cede_Basic_Events.Data.Interfaces;
using Cede_Basic_Events.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cede_Basic_Events.Data
{
    public static class DataFactory
    {
        public static IEventData CreateEventData(SourceData sourceData)
        {
            switch (sourceData)
            {
                case SourceData.DataBase:
                    return new EventDataDB();
                    break;
                case SourceData.Memory:
                    return new EventDataFile();
                    break;
                default:
                    return null;
                    break;
            }
        }

        public static IPersonalData CreatePersonalData(SourceData sourceData)
        {
            switch (sourceData)
            {
                case SourceData.DataBase:
                    return new PersonalDataDB();
                    break;
                case SourceData.Memory:
                    return new PersonalDataFile();
                    break;
                default:
                    return null;
                    break;
            }
        }
    }
}

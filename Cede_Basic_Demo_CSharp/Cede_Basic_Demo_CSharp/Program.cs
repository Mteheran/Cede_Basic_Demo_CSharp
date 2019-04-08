using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cede_Basic_Demo_CSharp
{
    class Program
    {
        public const long BillionsAndBillions = 100_000_000_000;
        public const double BillionsAndBillions2 = 100_000_000_000.22_22_22;

        static void Main(string[] args)
        {
            Console.WriteLine("Hola clase");

            int number1 = 0;
            string stringMessage = "Hola";

            number1 = 1;
              
            if (number1 > 0)
            {
                if (stringMessage == "Hola")
                {
                    Console.WriteLine("Number1 mayor que 0");
                }              
            }

            int count = 0;
            for (int i = 1; i <= 5; i++)
            {   
                Console.WriteLine(string.Format("Numero: {0} {1} {2}", ++count,1,2,3,3,3));
                Console.WriteLine($"Numero: {count--} {Math.Cos(50)}");
            }

            int? countNullable = 2;
            DateTime? dateTime = null;
            string stringNullable = null;

            if (countNullable != null)
            {
                if (countNullable.ToString() == "2")
                {
                    Console.WriteLine("countNullable es 2");
                }
            }

            if (countNullable?.ToString() == "2")
            {
                Console.WriteLine("countNullable es 2");
            }

            if (string.IsNullOrEmpty(stringNullable))
            {
                Console.WriteLine("stringNullable es vacio");
            }

            string message = "La fecha actual es";

            
            message = AddDate(message);

            AddDate(ref message);

            Console.WriteLine(message);

            //var name = (first: "one", second: "two");
            //name.first
            //name.second




            Console.ReadKey();
        }

        private static void AddDate(ref string Parameter)
        {
            Parameter = $"{Parameter} - {DateTime.Now.ToString("yyyyMMdd")}";
        }

        private static string AddDate(string Parameter)
        {
            return $"{Parameter} - {DateTime.Now.ToString("yyyyMMdd")}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cede_Basic_Demo_CSharp
{
    class Program
    {
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



            Console.ReadKey();
        }
    }
}

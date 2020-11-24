using System;
using System.Collections.Generic;
using System.IO;

namespace linqConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==== LINQ ====");

            string FirstName = "Mario";

            var LastName = "Rossi"; //assegnamento implicito

            List<Employee> data = new List<Employee>{  };
            foreach(var value in data)
                Console.WriteLine(value.Name);

            //Definisco un anonymous type 
            var persona = new { a = 1, b = 2 };
            var persona2 = new { aa = 2, bb = 1 };
            //Il compilatore non riconosce che sono la stessa cosa, sono diverse.
            //In memoria come classe, indirizzo nello stack, il corpo nell'heap.
            //Non ho dichiarato un tipo -> NON POSSONO ESSERE DELLO STESSO TIPO
            //Indicati come 'a entrambi, qualsiasi prop abbiano
            //Non posso instanziarli
            string hello = "20.01";
            double a =hello.ToDouble();
            //ToDouble è della classe stringExtension
            //La uso con le string
            // L'intellegence riconosce la classe e riconosce come extension
            
        }
    }
    #region Generics
    internal class Employee
    {
        //internal = visibile solo nell'assembly corrente.
        public string Name { get; set; }

      
    }
    internal class Employee<T>
    { 
        public T ID { get; set; }
        public string Name { get; set; }
    }

    internal class EmployeeInt
    {
       public int ID { get; set; }
        public string Name { get; set; }
    }

    internal class EmployeeString
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    #endregion



}

using System;
using System.Collections.Generic;
using System.IO;

namespace linqConsole
{
    class Program
    {
        public delegate int Sum(int val1, int val2);
        //il delegate è la firma di una funzione 
        //Posso assegnargli una qualunque funzoone che prende due int e return un int
        public static int PrimaSomma(int val1, int val2)
        {
            return val1 + val2;
        }
        static void Main(string[] args)
        {
            var process = new BusinessProcess();
            process.Started += Process_Started;
            process.Started += Process_Started1;
            process.StartedCore += Process_StartedCore;
            //process_started è l'event handler, sti facendo la subscription
            //quando sollevo l'evento Process_started è in ascolto 
            //Process_started fa qualcosa quando sollevo l'evento
            process.Completed += Process_Completed;
            process.CompletedCore += Process_CompletedCore;
            process.ProcessDATA();

            Sum LamiaSomma = PrimaSomma;
            //Ho assegnato ad una variabile di tipo SUM il metodo Prima Somma

            #region STEP ONE
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
            #endregion

            
        }

        private static void Process_CompletedCore(object sender, BusinessProcess.ProcessEndEventArgs e)
        {
            Console.WriteLine("Ciao, sono l'handler di CompletedCore, la durata del processo è {0} ms", e.Duration);
        }

        private static void Process_StartedCore(object sender, EventArgs e)
        {
            Console.WriteLine("Ciao, sono l'handler del delegate non creato, il processo è iniziato.");
        }

        private static void Process_Completed(int duration)
        {
            Console.WriteLine("Ciao, sono l'handler di process Completed, il processo ha impiegato {0} ms", duration);
        }

        private static void Process_Started1()
        {
            Console.WriteLine("Ciao, sono il secondo handler, il processo è iniziato.");
        }

        private static void Process_Started()
        {
            Console.WriteLine("Ciao, sono il primo handler, il processo è iniziato.");
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

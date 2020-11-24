using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace linqConsole
{
    public delegate void ProcessStarting();
    public delegate void ProcessCompleted(int duration);
    //funzione che non riceve niente in input non restituisce nulla
    //metodo che gestirà l'evento
    class BusinessProcess
    {
        public event ProcessStarting Started;
        public event ProcessCompleted Completed;

        public event EventHandler StartedCore;
        public event EventHandler<ProcessEndEventArgs> CompletedCore;
        //il generic mi serve per dirgli che voglio creare una classe per gli event args.
        public void ProcessDATA()
        {
            Console.WriteLine("=== Starting Process ===");
            Thread.Sleep(2000);
            Console.WriteLine("=== Process Started ===");
           //sollevo l'evento started, lo comunico ai subscribed
           //cosa succede non è affare di BusinessProcess
           if(Started != null)
                Started();
            if (StartedCore != null)
                StartedCore(this, new EventArgs());
           Thread.Sleep(2000);
           Console.WriteLine("=== Process Completed ===");
            if (Completed!= null)
                Completed(5000);
            if (CompletedCore != null)
                CompletedCore(this, new ProcessEndEventArgs { Duration = 4500 });
            //se non ho handler non sollevo l'evento
            //altrimenti il programma termina.

        }
        public class ProcessEndEventArgs:EventArgs
        { 
            public int Duration { get; set; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Timers;


namespace TimerTest
{
    class Program
    {
        private static Timer timer;

        static void Main(string[] args)
        {

            timer = new System.Timers.Timer();
            timer.Interval = 5000;  // 5 seconds

            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;

            Console.WriteLine("Press enter key to exit... ");
            Console.ReadLine();

        }

        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("Raised: {0}", e.SignalTime);
        }


    }
}

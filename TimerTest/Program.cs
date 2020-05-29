using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Timers;
using System.IO;

namespace TimerTest
{
    class Program
    {
        private static Timer timer;
        static DateTime checktime = DateTime.Now.AddSeconds(30);

        static void Main(string[] args)
        {

            timer = new System.Timers.Timer();
            timer.Interval = 5000;  // 5 seconds

            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;

            Run();

            Console.WriteLine("Press enter key to exit... ");
            Console.ReadLine();



        }

        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {

            var xx = DateTime.Now.ToShortTimeString();


            Console.WriteLine($"Raised: {e.SignalTime} ");


            if (  DateTime.Now > checktime)
            {
                Console.WriteLine($"\nTHE TIME {DateTime.Now} IS PAST  {checktime} ");

                checktime = checktime.AddMinutes(2);

            }

        }



        private static void Run()
        {
            string[] args = Environment.GetCommandLineArgs();


            var path = @"C:\temp\";

            Console.WriteLine($"Watching {path}");

            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = path;

                watcher.NotifyFilter = NotifyFilters.LastAccess
                                     | NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName;

                watcher.Filter = "*.txt";

                watcher.Changed += OnChanged;
                watcher.Created += OnChanged;
                watcher.Deleted += OnChanged;
                watcher.Renamed += OnRenamed;

                watcher.EnableRaisingEvents = true;

                Console.WriteLine("Press 'q' to quit the sample.");
                while (Console.Read() != 'q') ;
            }
        }

        private static void OnChanged(object source, FileSystemEventArgs e) =>
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");

        private static void OnRenamed(object source, RenamedEventArgs e) =>
            Console.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");

    }


}


using System;
using System.Threading;

namespace Task2
{
    class MyMonitor
    {
        private bool isStarted = false;
        public long AlertMemoryLevel { get; set; }
                
        public void StartMonitor(int timeout)
        {
            if (AlertMemoryLevel <= 0)
            {
                Console.WriteLine($"Alert memory level shold be more than 0");
            } else
            {
                isStarted = true;
                new Thread(WaitForStopMonitorKey).Start();
                while (isStarted)
                {                    
                    if (GetCurrentMemory() >= AlertMemoryLevel)
                    {
                        ShowAllertMessage();
                        Thread.Sleep(timeout);
                    }
                    Console.WriteLine(GetCurrentMemory());
                }
            }
        }

        private void ShowAllertMessage()
        {
            Console.WriteLine($"Alert memory level is more than {AlertMemoryLevel}");
        }

        private long GetCurrentMemory()
        {
            return GC.GetTotalMemory(false);
        }

        private void WaitForStopMonitorKey()
        {
            while (true)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Q)
                {
                    isStarted = false;
                    Console.WriteLine("Monitor stopped");
                    break;
                }
                Thread.Sleep(500);
            }
        }
    }
}

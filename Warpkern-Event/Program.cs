using System;

namespace WarpkernEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Warpkern!");

            Warpkern wk = new Warpkern();
            WarpkernConsole wkc = new WarpkernConsole();
            wk.TemperaturÄnderungEvent += wkc.OnTemperaturÄnderung;
            wk.TemperaturAlarmEvent += wkc.OnTemperaturAlarm;

            for (int i = 0; i < 100; i++) {
                wk.ÄndereTemperatur();
            }
            

            Console.ReadLine();

        }
    }
}

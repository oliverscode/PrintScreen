using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using PrintScreen;

namespace test
{
    internal class Program
    {
        [DllImport("SHCore.dll", SetLastError = true)]
        private static extern bool SetProcessDpiAwareness(int awareness);

        public static void Main(string[] args)
        {
            SetProcessDpiAwareness(2);

            var state = new CStage(10, new Point(0, 0), new Size(800, 600));

            var labal = new CString("hello world");
            labal.Color = Color.Red;
            state.AddChild(labal);


            var line = new CLine();
            state.AddChild(line);

            var x = 0;
            var y = 0;
            while (true)
            {
                x = (x + 1) % 100;
                line.Point1 = new Point(x, 0);
                line.Point2 = new Point(x, 600);
                Thread.Sleep(1000 / 60);
            }


            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
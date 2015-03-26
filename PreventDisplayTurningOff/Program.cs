using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Runtime.InteropServices;

namespace PreventDisplayTurningOff
{
    class Program
    {
        public static ConsoleColor oldClr;

        static void Main(string[] args)
        {
            char[] progress = { '|', '/', '-', '\\' };

            oldClr = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("This program will prevent the display from turning off.");
            Console.WriteLine("Press ctrl + c to close this program..");


            Console.CancelKeyPress += new ConsoleCancelEventHandler(OnConsoleCancelKeyPress);

            PreventSleep.PreventMachineFromSleeping();
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();

            int top = Console.CursorTop;
            int left = Console.CursorLeft;
            
            int idx = 0;
            int midx = 0;
            while (true)
            {
                Thread.Sleep(200);

                midx = progress.Length - (idx + 1);
                Console.Write(" [ " + progress[idx] + " ]");
                Console.WriteLine(" [ " + progress[midx] + " ]");

                Console.SetCursorPosition(left, top);

                idx = (++idx) % progress.Length;
            }
        }

        static void OnConsoleCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Console.ForegroundColor = oldClr;
            PreventSleep.RestoreSetting();
        }
    }
}

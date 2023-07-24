using System.Drawing;
using System.Runtime.InteropServices;

namespace AntiIdle
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            int i = 0;
            bool sendBack = false;
            do
            {
                while (!Console.KeyAvailable)
                {
                    await Task.Delay(1);
                    ProcessIValue(ref i, ref sendBack);
                    SetCursorPos(i, i);
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        private static void ProcessIValue(ref int i, ref bool sendBack)
        {
            if (i > 500)
            {
                sendBack = true;
            }
            else if (i < 1)
            {
                sendBack = false;
            }

            i = sendBack ? i - 1 : i + 1;
        }

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);
    }
}
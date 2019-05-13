using System;
using System.Runtime.InteropServices;

namespace NativeLibLoader
{
    class Program
    {
#if WINDOWS
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);
#elif LINUX
        [DllImport("libSystem.dylib")]
        private static extern int getpid();
#endif


        static void Main(string[] args)
        {
#if WINDOWS
            MessageBox(IntPtr.Zero, $"This is a windows application.", "Win Msg Box", 0);
#elif LINUX
            int pid = getpid();
            Console.WriteLine($"Process ID: {pid}");
#endif
            Console.ReadLine();
        }
    }
}

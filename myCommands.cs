// (C) Copyright 2024 by
// from www.lisp.vn
using Autodesk.AutoCAD.Runtime;
using System;
using System.Runtime.InteropServices;

[assembly: CommandClass(typeof(AJS_Console.MyCommands))]

namespace AJS_Console
{
    public class MyCommands
    {
        [DllImport("kernel32.dll")]
        private static extern void FreeConsole();

        [DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int dwProcessId);

        private const int ATTACH_PARENT_PROCESS = -1;

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();

        [CommandMethod("AJSGetConsole", CommandFlags.Modal)]
        public void cmd_AJSGetConsole()
        {
            if (!AttachConsole(ATTACH_PARENT_PROCESS))
                AllocConsole();
        }

        [CommandMethod("AJSPrintSomeThing", CommandFlags.Modal)]
        public void cmd_AJSPrintSomeThing_To_Console()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("---------------------");
            Console.WriteLine("Current times is: " + DateTime.Now.ToUniversalTime());
            Console.WriteLine("Nhập chuỗi ký tự: ");
            var str = Console.ReadLine();
            Console.WriteLine("Chuỗi ký tự nhập: " + str);
            Console.WriteLine("PrintSomeThing Done");
            Console.WriteLine("By www.lisp.vn");
            Console.WriteLine("---------------------");
        }
    }
}
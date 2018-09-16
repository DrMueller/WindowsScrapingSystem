

using System;
using System.Diagnostics;
using System.Windows.Forms;
using Mmu.Wss.Application.Areas.Initialization;
using Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Services.Implementation;

namespace Mmu.Wss.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializationService.Initialize(typeof(Program).Assembly);
            //var tra = new KeyHookService();
            //tra.KeyDown += Tra_KeyDown;
            //tra.Hook();
            System.Windows.Forms.Application.Run();
        }

        //private static void Tra_KeyDown(object sender, Application.Infrastructure.WindowsNative.EventArguments.KeyHandlerEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

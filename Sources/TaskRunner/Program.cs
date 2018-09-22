using System;
using Mmu.Wss.Application.Areas.Initialization;

namespace Mmu.Wss.TaskRunner
{
    internal class Program
    {
        [STAThread]
        private static void Main()
        {
            BootstrapService.Start(typeof(Program).Assembly);
            System.Windows.Forms.Application.Run();
        }
    }
}
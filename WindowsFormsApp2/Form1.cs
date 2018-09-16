using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Services.Implementation;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            //Mmu.Wss.Application.Areas.Initialization.InitializationService.Initialize(typeof(Form1).Assembly);

            var tra = new KeyHookService();
            tra.KeyDown += Tra_KeyDown;
            tra.Hook();
        }

        private void Tra_KeyDown(object sender, Mmu.Wss.Application.Infrastructure.WindowsNative.EventArguments.KeyHandlerEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

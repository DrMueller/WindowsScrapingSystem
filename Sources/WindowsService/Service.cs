using System.ServiceProcess;
using Mmu.Wss.Application.Areas.Initialization;

namespace Mmu.Wss.WindowsService
{
    public partial class Service : ServiceBase
    {
        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            InitializationService.Initialize(typeof(Service).Assembly);
        }

        protected override void OnStop()
        {
        }
    }
}
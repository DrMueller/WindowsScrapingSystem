using System.Text;
using System.Threading.Tasks;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models;
using Mmu.Wss.Application.Areas.EventReceiving.Services;

namespace Mmu.Wss.TestListener
{
    public class Test2KeyboardReceiver : IKeyboardEventReceiver
    {
        public Task ReceiveAsync(KeyboardInput input)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Test2KeyboardReceiver");
            sb.AppendLine(input.CreateOverview());

            FileWriter.Write(sb.ToString());

            return Task.CompletedTask;
        }
    }
}
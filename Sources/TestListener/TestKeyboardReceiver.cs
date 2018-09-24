using System.Text;
using System.Threading.Tasks;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models;
using Mmu.Wss.Application.Areas.EventReceiving.Services;

namespace Mmu.Wss.TestListener
{
    public class TestKeyboardReceiver : IKeyboardEventReceiver
    {
        public Task ReceiveAsync(KeyboardInput input)
        {
            var sb = new StringBuilder();
            sb.AppendLine("TestKeyboardReceiver");
            sb.AppendLine(input.CreateOverview());
            FileWriter.Write(sb.ToString());

            return Task.CompletedTask;
        }
    }
}
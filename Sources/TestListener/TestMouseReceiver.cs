using System.Text;
using System.Threading.Tasks;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models;
using Mmu.Wss.Application.Areas.EventReceiving.Services;

namespace Mmu.Wss.TestListener
{
    public class TestMouseReceiver : IMouseEventReceiver
    {
        public Task ReceiveAsync(MouseInput input)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Key: {input.InputKey}");
            sb.AppendLine($"Direction: {input.Direction}");

            FileWriter.Write(sb.ToString());

            return Task.CompletedTask;
        }
    }
}
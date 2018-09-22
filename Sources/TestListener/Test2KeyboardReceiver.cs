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
            sb.AppendLine($"Key: {input.InputKey}");
            sb.AppendLine($"Direction: {input.Direction}");
            sb.AppendLine($"Modifier Shift: {input.ModifierOptions.IsShiftPressed}");
            sb.AppendLine($"Modifier Ctrl: {input.ModifierOptions.IsCtrlPressed}");
            sb.AppendLine($"Modifier Alt: {input.ModifierOptions.IsAltPressed}");
            sb.AppendLine($"Lock Caps: {input.LockOptions.IsCapsLockActive}");
            sb.AppendLine($"Lock Num: {input.LockOptions.IsNumLockActive}");
            sb.AppendLine($"Lock Scroll: {input.LockOptions.IsScrollLockActive}");

            FileWriter.Write(sb.ToString());

            return Task.CompletedTask;
        }
    }
}
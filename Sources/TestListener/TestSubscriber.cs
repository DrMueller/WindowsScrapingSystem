using System.Diagnostics;
using System.Threading.Tasks;
using Mmu.Wss.Application.Areas.EventPublishing.Models;
using Mmu.Wss.Application.Areas.EventPublishing.Services;
using Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Models;

namespace Mmu.Wss.TestListener
{
    public class TestSubscriber : IEventSubscriber
    {
        public NotificationConfiguration NotificationConfiguration { get; } = new
            NotificationConfiguration(
                KeyboardInputKey.A,
                new ModifierConfiguration(
                    Option.CreateApplicible(true),
                    Option.CreateApplicible(false),
                    Option.CreateNotApplicable()));

        public Task Receive(KeyboardInputNotification notification)
        {
            Debug.WriteLine($"Received {notification.Input.InputKey}.");
            return Task.CompletedTask;
        }
    }
}
﻿using System.Diagnostics.CodeAnalysis;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models;

namespace Mmu.Wss.Application.Areas.EventReceiving.Services
{
    [SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces", Justification = "Marker Interface")]
    public interface IMouseEventReceiver : IEventReceiver<MouseInput>
    {
    }
}
using System;
using NServiceBus;

namespace OrderService.Messages
{
    public interface OrderLine : IMessage
    {
        Guid ProductId { get; set; }
        float Quantity { get; set; }
    }
}

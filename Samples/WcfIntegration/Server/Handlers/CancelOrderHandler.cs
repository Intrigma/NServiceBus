using Messages;
using NServiceBus;

namespace Server.Handlers
{
    public class CancelOrderHandler : IHandleMessages<CancelOrder>
    {
        private readonly IBus bus;

        public CancelOrderHandler(IBus bus)
        {
            this.bus = bus;
        }

        public void Handle(CancelOrder message)
        {
            if (message.OrderId % 2 == 0)
            {
                this.bus.Return((int) ErrorCodes.Fail);
            }
            else
            {
                this.bus.Return((int) ErrorCodes.None);
            }
        }
    }
}
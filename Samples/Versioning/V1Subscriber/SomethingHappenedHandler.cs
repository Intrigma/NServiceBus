using System;
using NServiceBus;
using V1.Messages;

namespace V1Subscriber
{
    public class SomethingHappenedHandler : IMessageHandler<SomethingHappened>
    {
        #region IMessageHandler<SomethingHappened> Members

        public void Handle(SomethingHappened message)
        {
            Console.WriteLine("Something happened with some data {0} and no more info", message.SomeData);
        }

        #endregion
    }
}

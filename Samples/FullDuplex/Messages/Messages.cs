using NServiceBus;
using System;

namespace Messages
{
    [Serializable]
    public class RequestDataMessage : IMessage
    {
        public Guid DataId { get; set; }
        public string String { get; set; }
    }

    [Serializable]
    public class DataResponseMessage : IMessage
    {
        public Guid DataId { get; set; }
        public string String { get; set; }

        // other data
    }
}

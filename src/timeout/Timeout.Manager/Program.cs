using System;
using NServiceBus;
using Common.Logging;
using NServiceBus.Grid.MessageHandlers;
using Timeout.MessageHandlers;

namespace Timeout.Manager
{
    class Program
    {
        static void Main()
        {
            LogManager.GetLogger("hello").Debug("Started.");

            try
            {
                string nameSpace = System.Configuration.ConfigurationManager.AppSettings["NameSpace"];
                string serialization = System.Configuration.ConfigurationManager.AppSettings["Serialization"];

                Func<Configure, Configure> func;

                switch (serialization)
                {
                    case "xml":
                        func = cfg => cfg.XmlSerializer(nameSpace);
                        break;
                    case "binary":
                        func = cfg => cfg.BinarySerializer();
                        break;
                    default:
                        throw new ConfigurationException("Serialization can only be one of 'interfaces', 'xml', or 'binary'.");
                }

                var bus = func(NServiceBus.Configure.With()
                    .SpringBuilder())
                    .MsmqTransport()
                        .IsTransactional(true)
                        .PurgeOnStartup(false)
                    .UnicastBus()
                        .ImpersonateSender(false)
                        .LoadMessageHandlers(
                            First<GridInterceptingMessageHandler>
                                .Then<TimeoutMessageHandler>()
                        )
                    .CreateBus();

                bus.Start();
            }
            catch (Exception e)
            {
                LogManager.GetLogger("hello").Fatal("Exiting", e);
            }
            finally
            {
                Console.Read();
            }
        }
    }
}

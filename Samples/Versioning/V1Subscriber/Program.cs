﻿using System;
using NServiceBus;
using Common.Logging;

namespace V1Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            LogManager.GetLogger("hello").Debug("Started.");

            var bus = NServiceBus.Configure.With()
                .SpringBuilder()
                .XmlSerializer()
                .MsmqTransport()
                    .IsTransactional(false)
                    .PurgeOnStartup(false)
                .UnicastBus()
                    .ImpersonateSender(false)
                    .LoadMessageHandlers()
                .CreateBus()
                .Start();

            Console.WriteLine("Listening for events. To exit, press 'q' and then 'Enter'.");
            while (Console.ReadLine().ToLower() != "q")
            {
            }
        }
    }
}

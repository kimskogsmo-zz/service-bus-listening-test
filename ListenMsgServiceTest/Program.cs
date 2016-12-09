using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace ListenMsgServiceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Endpoint=sb://kimspace.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=hNXAPUssGofW9TxU9WUEJe975/+Mcwbh+gv9afNdHls=";
            const string queueName = "testqueue";

            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);

            client.OnMessage(message =>
            {
                Console.WriteLine(String.Format("Message body: {0}", message.GetBody<String>()));
                Console.WriteLine(String.Format("Message id: {0}", message.MessageId));
                Console.WriteLine("");
            });

            Console.ReadLine();
        }
    }
}

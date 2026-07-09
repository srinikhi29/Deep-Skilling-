using Confluent.Kafka;

namespace KafkaChatConsole
{
    class Producer
    {
        public static async Task RunProducer()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };

            using var producer = new ProducerBuilder<Null, string>(config).Build();

            Console.WriteLine("=== Chat Producer Started ===");
            Console.WriteLine("Type your message and press Enter (type 'exit' to quit):");

            while (true)
            {
                string message = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(message))
                    continue;

                if (message.ToLower() == "exit")
                    break;

                try
                {
                    var result = await producer.ProduceAsync("chat-topic",
                        new Message<Null, string> { Value = message });

                    Console.WriteLine($"Sent: '{result.Value}' to partition {result.Partition}, offset {result.Offset}");
                }
                catch (ProduceException<Null, string> e)
                {
                    Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                }
            }

            Console.WriteLine("Producer stopped.");
        }
    }
}
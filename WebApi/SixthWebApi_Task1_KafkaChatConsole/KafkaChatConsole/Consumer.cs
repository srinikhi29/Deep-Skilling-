using Confluent.Kafka;

namespace KafkaChatConsole
{
    class Consumer
    {
        public static void RunConsumer()
        {
            var config = new ConsumerConfig
            {
                GroupId = "chat-group",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            consumer.Subscribe("chat-topic");

            Console.WriteLine("=== Chat Consumer Started ===");
            Console.WriteLine("Waiting for messages... (Ctrl+C to exit)");

            try
            {
                while (true)
                {
                    var cr = consumer.Consume();
                    Console.WriteLine($"Received: {cr.Message.Value}  (partition {cr.Partition}, offset {cr.Offset})");
                }
            }
            catch (OperationCanceledException)
            {
                consumer.Close();
                Console.WriteLine("Consumer stopped.");
            }
        }
    }
}
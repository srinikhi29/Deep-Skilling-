using KafkaChatConsole;

Console.WriteLine("Run as (P)roducer or (C)onsumer?");
var choice = Console.ReadLine()?.Trim().ToUpper();

if (choice == "P")
{
    await Producer.RunProducer();
}
else if (choice == "C")
{
    Consumer.RunConsumer();
}
else
{
    Console.WriteLine("Invalid choice. Please enter P or C.");
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();
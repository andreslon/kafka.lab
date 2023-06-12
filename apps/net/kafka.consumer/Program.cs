using Confluent.Kafka;

var config = new ConsumerConfig
{
    BootstrapServers = "localhost:9092", // Dirección y puerto de los brokers de Kafka
    GroupId = "my-consumer-group",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
{
    string topic = "lab-topic";

    consumer.Subscribe(topic);

    CancellationTokenSource cts = new CancellationTokenSource();
    Console.CancelKeyPress += (_, e) =>
    {
        e.Cancel = true;
        cts.Cancel();
    };

    try
    {
        while (true)
        {
            var consumeResult = consumer.Consume(cts.Token);
            Console.WriteLine($"Mensaje recibido: {consumeResult.Message.Value}");
        }
    }
    catch (OperationCanceledException)
    {
        // El consumidor se detuvo mediante una cancelación
    }
    finally
    {
        consumer.Close();
    }
}
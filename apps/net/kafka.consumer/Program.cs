using Confluent.Kafka;

var config = new ConsumerConfig
{
    // BootstrapServers = "localhost:9092", // Dirección y puerto de los brokers de Kafka
    GroupId = "consumer-group-andres",
     BootstrapServers = "pkc-56d1g.eastus.azure.confluent.cloud:9092", // Dirección y puerto de los brokers de Kafka
    SecurityProtocol= SecurityProtocol.SaslSsl,
    SaslMechanism= SaslMechanism.Plain,
    SaslUsername="NUVO7A4A3VURIXYX",
    SaslPassword="0nGK5ZhpgAZQnhyem16DSE1zGhQH/ybH81YcHTXBPS4AGdnLdie29UtSCiC8dOVC",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
{
    string topic = "topic1";

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
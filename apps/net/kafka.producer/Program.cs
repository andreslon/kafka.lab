using Confluent.Kafka;

var config = new ProducerConfig
{
    BootstrapServers = "pkc-56d1g.eastus.azure.confluent.cloud:9092", // Dirección y puerto de los brokers de Kafka
    SecurityProtocol= SecurityProtocol.SaslSsl,
    SaslMechanism= SaslMechanism.Plain,
    SaslUsername="NUVO7A4A3VURIXYX",
    SaslPassword="0nGK5ZhpgAZQnhyem16DSE1zGhQH/ybH81YcHTXBPS4AGdnLdie29UtSCiC8dOVC"
};

using (var producer = new ProducerBuilder<Null, string>(config).Build())
{
    string topic = "topic1";
    int i = 0;
    while (true)
    {

        string message = $"Andrés Londoño-Mensaje enviado desde .Net: {i}";

        var deliveryReport = producer.ProduceAsync(topic, new Message<Null, string>
        {
            Value = message
        });

        Console.WriteLine($"Mensaje enviado desde .Net: {message}");

        // Esperar a que se confirme el envío
        var result = deliveryReport.GetAwaiter().GetResult();
        Console.WriteLine($"Partición: {result.Partition}, Offset: {result.Offset}");
        i++;
        await Task.Delay(TimeSpan.FromSeconds(1));
    }

    // Asegurarse de que todos los mensajes se envíen antes de cerrar el productor
    producer.Flush(TimeSpan.FromSeconds(10));
}
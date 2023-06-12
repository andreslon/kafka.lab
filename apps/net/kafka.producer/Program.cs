using Confluent.Kafka;

var config = new ProducerConfig
{
    BootstrapServers = "localhost:9092", // Dirección y puerto de los brokers de Kafka
    ClientId = "my-producer"
};

using (var producer = new ProducerBuilder<Null, string>(config).Build())
{
    string topic = "lab-topic";

    for (int i = 0; i < 10; i++)
    {
        string message = $"Mensaje {i}";

        var deliveryReport = producer.ProduceAsync(topic, new Message<Null, string>
        {
            Value = message
        });

        Console.WriteLine($"Mensaje enviado: {message}");

        // Esperar a que se confirme el envío
        var result = deliveryReport.GetAwaiter().GetResult();
        Console.WriteLine($"Partición: {result.Partition}, Offset: {result.Offset}");
    }

    // Asegurarse de que todos los mensajes se envíen antes de cerrar el productor
    producer.Flush(TimeSpan.FromSeconds(10));
}
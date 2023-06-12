using Confluent.Kafka;

var config = new ProducerConfig
{
    BootstrapServers = "localhost:9092", // Dirección y puerto de los brokers de Kafka
    // ClientId = "my-producer"
};

using (var producer = new ProducerBuilder<Null, string>(config).Build())
{
    string topic = "lab-topic";
    int i = 0;
    while (true)
    {

        string message = $"Mensaje enviado desde .Net: {i}";

        var deliveryReport = producer.ProduceAsync(topic, new Message<Null, string>
        {
            Value = message
        });

        Console.WriteLine($"Mensaje enviado desde .Net: {message}");

        // Esperar a que se confirme el envío
        var result = deliveryReport.GetAwaiter().GetResult();
        Console.WriteLine($"Partición: {result.Partition}, Offset: {result.Offset}");
        i++;
        await Task.Delay(TimeSpan.FromSeconds(2));
    }

    // Asegurarse de que todos los mensajes se envíen antes de cerrar el productor
    producer.Flush(TimeSpan.FromSeconds(10));
}
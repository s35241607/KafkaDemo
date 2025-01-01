using Confluent.Kafka;

namespace KafkaDemo.Api.Services;

public class KafkaProducerService
{
    private readonly string _bootstrapServers = "kafka:9092";
    private readonly string _topic = "kafka-demo-test";
    public async Task SendMessageAsync(string message)
    {
        var config = new ProducerConfig { BootstrapServers = _bootstrapServers };

        using var producer = new ProducerBuilder<Null, string>(config).Build();

        try
        {
            var deliveryResult = await producer.ProduceAsync(_topic, new Message<Null, string> { Value = message });
            Console.WriteLine($"Message sent to {deliveryResult.TopicPartitionOffset}");
        }
        catch (ProduceException<Null, string> e)
        {
            Console.WriteLine($"Error producing message: {e.Error.Reason}");
        }
    }
}

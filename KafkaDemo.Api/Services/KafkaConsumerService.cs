using Confluent.Kafka;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KafkaDemo.Api.Services;

public class KafkaConsumerService
{
    private readonly string _bootstrapServers = "kafka:9092";
    private readonly string _topic = "kafka-demo-test";
    public void StartConsumer(CancellationToken cancellationToken)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = _bootstrapServers,
            GroupId = "my_consumer_group",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
        consumer.Subscribe(_topic);

        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var consumeResult = consumer.Consume(cancellationToken);
                Console.WriteLine($"Message consumed: {consumeResult.Message.Value}");
            }
        }
        catch (ConsumeException e)
        {
            Console.WriteLine($"Error consuming message: {e.Error.Reason}");
        }
    }
}

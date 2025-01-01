using KafkaDemo.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace KafkaDemo.Api.Controllers;

[Route("api/kafka")]
[ApiController]
public class KafkaController(KafkaProducerService producerService) : ControllerBase
{

    [HttpPost("send")]
    public async Task<IActionResult> SendMessage([FromBody] string message)
    {
        await producerService.SendMessageAsync(message);
        return Ok("Message sent to Kafka.");
    }
}

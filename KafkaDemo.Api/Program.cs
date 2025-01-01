using KafkaDemo.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// 註冊 Kafka 服務
builder.Services.AddSingleton<KafkaProducerService>();
builder.Services.AddSingleton<KafkaConsumerService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


// 使用 background service 啟動 Kafka 消費者
var consumerService = app.Services.GetRequiredService<KafkaConsumerService>();
var cancellationTokenSource = new CancellationTokenSource();
Task.Run(() => consumerService.StartConsumer(cancellationTokenSource.Token));

app.MapControllers();

app.Run();

using Adapter.Kafka;
using Adapter.PostgreSQL;
using Core.AddBookRead;
using Microsoft.Extensions.DependencyInjection;

var api = new ApiAdapter(args, options =>
{
    options.AddScoped<IBookReadStore, PostgreBookReadStore>();
    options.AddScoped<IBookReadPublisher, KafkaBookReadPublisher>();
});

api.StartAsync();


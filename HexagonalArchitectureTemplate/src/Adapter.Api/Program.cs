using Core.AddBookRead;
using System.Runtime.CompilerServices;

public class ApiAdapter
{
    private readonly WebApplication _app;

    public ApiAdapter(string[] args, Action<IServiceCollection> options)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        options.Invoke(builder.Services);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        _app = builder.Build();

        // Configure the HTTP request pipeline.
        if (_app.Environment.IsDevelopment())
        {
            _app.UseSwagger();
            _app.UseSwaggerUI();
        }

        _app.UseHttpsRedirection();

        _app.UseAuthorization();

        _app.MapControllers();

        _app.MapPost("/reads/get", (IAddBookRead read, string isbn) => read.AddReadAsync(1, isbn));
    }

    public Task StartAsync() => _app.RunAsync();
}


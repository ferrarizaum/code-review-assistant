using CodeReviewAssistant.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add support for controllers
builder.Services.AddControllers();

builder.Services.AddScoped<ICodeReviewService, CodeReviewService>();
//builder.Services.AddScoped<IAIReviewEngine, OpenAIReviewEngine>();

builder.Services.AddScoped<IAIReviewEngine, OpenAIReviewEngine>(provider =>
{
    var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY"); // Get the API key from configuration.
    return new OpenAIReviewEngine(); // Pass the API key to the constructor.
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
       // c.RoutePrefix = string.Empty; // This makes Swagger available at the app root (e.g., localhost:5000)
    });
app.UseHttpsRedirection();

// Ensure that controllers are mapped
app.MapControllers();

app.Run();

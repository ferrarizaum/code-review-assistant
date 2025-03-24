using CodeReviewService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<ICodeReviewService, ReviewService>();
builder.Services.AddScoped<IQueueService, QueueService>();
//builder.Services.AddScoped<IAIReviewEngine, OpenAIReviewEngine>();
/*
builder.Services.AddScoped<IAIReviewEngine, OpenAIReviewEngine>(provider =>
{
    var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY"); 
    return new OpenAIReviewEngine(); 
});
*/
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{});
app.UseHttpsRedirection();

app.MapControllers();

app.Run();

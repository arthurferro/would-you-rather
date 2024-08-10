using WouldYouRatherApi.Models;
using WouldYouRatherApi.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(
    options =>
    {
        options.AddPolicy("AllowAll",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
        });
    }
);
builder.Services.AddSwaggerGen();
builder.Services.Configure<WouldYouRatherDatabaseSettings>(builder.Configuration.GetSection("WouldYouRatherDatabase"));
builder.Services.AddSingleton<QuestionService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
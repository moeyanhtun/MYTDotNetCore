using MYTDotNetCore.Shared2;
using Serilog;
using Serilog.Sinks.MSSqlServer;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/MYTDotNetCore.txt_");

//Log.Logger = new LoggerConfiguration()
//    .WriteTo.Console()
//    .WriteTo.File("logs/MYTDotNetCore.txt_", rollingInterval: RollingInterval.Hour)
//    .CreateLogger();
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();
var connection = configuration.GetConnectionString("DbConnection");
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.MSSqlServer(
        connectionString: connection,
        sinkOptions: new MSSqlServerSinkOptions
        {
            TableName = "LogEvents",
            AutoCreateSqlTable = true
        }
    )
    .CreateLogger();
try
{
    Log.Information("Starting web application");

    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(
            name: MyAllowSpecificOrigins,
            policy =>
            {
                policy
                    .WithOrigins("https://localhost:7273", "http://localhost:5140")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                ;
            }
        );
    });
    builder.Services.AddSerilog(); // <-- Add this line

    // Add services to the container.

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
    app.UseCors(MyAllowSpecificOrigins);

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

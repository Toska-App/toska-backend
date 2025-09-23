using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using Toska.Data;
using Toska.Models.User;
using Toska.Services.Users;

var builder = WebApplication.CreateBuilder(args);


//...
// Get the real connection string from secrets.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


//...
// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .WriteTo.MSSqlServer(
        connectionString: connectionString,
        sinkOptions: new MSSqlServerSinkOptions
        {
            TableName = "AppLogs",
            AutoCreateSqlTable = false
        },
        restrictedToMinimumLevel: LogEventLevel.Information
    )
    .CreateLogger();


//...
// Replace default logger
builder.Host.UseSerilog();




// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//...
// Add MVC/Web API controllers
builder.Services.AddControllers();


//...
//Register DbContext with SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));


//...
// Register password hasher
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();


//...
builder.Services.AddScoped<IUserService, UserService>();


//...
// Register automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());





var app = builder.Build();




//...
// Register error handling middleware
app.UseMiddleware<Toska.Middlewares.ErrorHandlingMiddleware>();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




app.UseHttpsRedirection();

//...
// Enable attribute-routed controllers
app.MapControllers();

app.Run();

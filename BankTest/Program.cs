using BankTest.ConfigureServices;
using WarehousingPrj.ConfigureServices;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
string redisConnectionString = builder.Configuration.GetConnectionString("RedisConn")!;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add database config
ContextManagementConfigure.Configure(builder.Services, connectionString);
//Add AutoMapper Config
AutoMapperManagementConfigure.Configure(services: builder.Services);
//Add Dependency Injection Config
DIManagementConfigure.Configure(services: builder.Services);
//Add Redis Config
RedisManagementConfigure.Configure(builder.Services,redisConnectionString);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

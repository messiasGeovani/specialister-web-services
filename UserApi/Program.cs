using IoC;
using UserApi.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
DependencyInjectionConfig.ResolveDependencies(builder.Services, builder.Configuration);

builder.Services.AddControllers();

AppConfig.ConfigureServices(builder.Services, builder.Configuration);

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

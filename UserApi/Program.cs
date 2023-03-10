using IoC;
using UserApi.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
AutomapperConfig.Setup(builder.Services);
DependencyInjectionConfig.ResolveDependencies(builder.Services, builder.Configuration);

builder.Services.AddControllers();

AuthenticationConfig.Setup(builder.Services, builder.Configuration);
AuthorizationConfig.Setup(builder.Services);

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

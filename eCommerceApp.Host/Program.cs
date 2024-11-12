using eCommerceApp.Infrastructure.Dependency;
using eCommerceApp.Application.Dependency;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureService(builder.Configuration);

builder.Services.AddApplicationService();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseInfrastructureService();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

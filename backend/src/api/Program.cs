
using Application.Interfaces.PilotInterfaces;
using Application.Services.Pilots;
using Application.UseCase.Pilot;
using Domain.Interfaces.PilotRepository;
using Infra;
using Infra.Repository.PilotRepository;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

// Repository
builder.Services.AddScoped<IPilotRepository, PilotRepository>();

// Service
builder.Services.AddScoped<IPilotService, PilotService>();

// UseCase
builder.Services.AddScoped<GetAllUseCase>();

builder.Configuration.AddUserSecrets<Program>(optional: true);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
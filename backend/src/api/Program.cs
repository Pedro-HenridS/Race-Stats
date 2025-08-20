
using Api.Filters;
using Application.Interfaces.PilotInterfaces;
using Application.Interfaces.TeamInterfaces;
using Application.Services.Pilots;
using Application.Services.Teams;
using Application.UseCase.Pilot;
using Application.UseCase.Team;
using Domain.Interfaces.PilotRepository;
using Domain.Interfaces.TeamRepository;
using Infra;
using Infra.Repository.PilotRepository;
using Infra.Repository.TeamRepository;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddUserSecrets<Program>(optional: true);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ExceptionFilter>();
});

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// Repository
builder.Services.AddScoped<IPilotRepository, PilotRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();

// Service
builder.Services.AddScoped<IPilotGetService, PilotGetService>();
builder.Services.AddScoped<IPilotUpdateService, PilotUpdateService>();
builder.Services.AddScoped<ITeamGetService, TeamGetService>();

// UseCase
builder.Services.AddScoped<GetAllUseCase>();
builder.Services.AddScoped<UpdateUseCase>();
builder.Services.AddScoped<GetAllTeamsUseCase>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("CorsPolicy");


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
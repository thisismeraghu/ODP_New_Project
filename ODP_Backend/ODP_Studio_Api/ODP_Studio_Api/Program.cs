using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ODP_Studio_Api.Api.Middlewares;
using ODP_Studio_Api.Application.CommandHandlers;
using ODP_Studio_Api.Application.DTOs.RequestDTOs;
using ODP_Studio_Api.Application.DTOs.ResponseDTOs;
using ODP_Studio_Api.Application.Mapping;
using ODP_Studio_Api.Application.Queries;
using ODP_Studio_Api.Application.QueryHandlers;
using ODP_Studio_Api.Application.Validators;
using ODP_Studio_Api.Domain.Interfaces;
using ODP_Studio_Api.Infrastructure.Persistence.Context;
using ODP_Studio_Api.Infrastructure.Persistence.Repository;
using ODP_Studio_Api.Infrastructure.Services;
using ODP_Studio_Api.Validators;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // The URL of your React app
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// Use Serilog as the logging provider
builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllers();

// Fluient validator register 
builder.Services.AddScoped<IValidator<LoginRequestDto>, LoginDTOValidator>();
builder.Services.AddScoped<IValidator<LoginResponseDto>, LoginResponseDtoValidator>();
builder.Services.AddScoped<IValidator<CreateOrphanRequestDto>, CreateOrphanDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateOrphanRequestDto>, UpdateOrphanRequestDtoValidator>();
builder.Services.AddScoped<IValidator<GetOrgByIdRequestDto>,GetOrgByIdRequestValidator>();
builder.Services.AddScoped<IValidator<CreateOrgRequestDto>, CreateOrgRequestDtoValidators>();
builder.Services.AddScoped<IValidator<UpdateOrgRequestDto>, UpdateOrgRequestDtoValidator>();

//builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Infrastructure services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrphanRepository, OrphanRepository>();
builder.Services.AddScoped<IOrgRepository, OrgRepository>();

builder.Services.AddScoped<IPasswordHasher, PasswordHasherService>();
builder.Services.AddScoped<ITokenService, JwtTokenService>();

// Register other services here...
builder.Services.AddAutoMapper(cfg=> { },typeof(MappingProfile).Assembly);
builder.Services.AddMediatR(cfg =>
{
    // command register 
    cfg.RegisterServicesFromAssemblyContaining<LoginUserCommandHandler>();
    cfg.RegisterServicesFromAssemblyContaining<CreateOrphanCommandHandler>();
    cfg.RegisterServicesFromAssemblyContaining<UpdateOrphanCommandHandler>();
    cfg.RegisterServicesFromAssemblyContaining<UpdateOrgCommandHandler>();

    // Query register 
    cfg.RegisterServicesFromAssemblyContaining<GetOrphanByOrphanIdQueryHandler>();
    cfg.RegisterServicesFromAssemblyContaining<GetAllOrphansByOrgIdQuery>();
    cfg.RegisterServicesFromAssemblyContaining<GetOrgByOrdIdQuery>();
    cfg.RegisterServicesFromAssemblyContaining<GetAllOrphansByOrgIdQueryHandler>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowReactApp");
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

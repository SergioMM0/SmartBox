using Application.DTOs;
using AutoMapper;
using Domain;
using FluentValidation;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

//Setting up the mapper 
var mapper = new MapperConfiguration(config =>
{
    //Any time we add another DTO we have to map it, so we add it down below :)
    config.CreateMap<PostBoxDTO, Box>();
    config.CreateMap<PostUserDTO, User>();
    config.CreateMap<PutUserDTO, User>();
    config.CreateMap<User, PutUserDTO>();
    config.CreateMap<OrderDTO, Order>();
}).CreateMapper();
builder.Services.AddSingleton(mapper);

//Conn to the DB
builder.Services.AddDbContext<SmartBoxContext>(options => options.UseSqlite(
    "Data source=db.db"
));

//Registering Application layer and infrastructure layer with dependency resolver
Application
    .DependencyResolver
    .DependencyResolverService
    .RegisterApplicationLayer(builder.Services);
Infrastructure
    .DependencyResolver
    .DependencyResolverService
    .RegisterInfrastructureLayer(builder.Services);

//adding the cors to the builder
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    //This line allow us to send httpRequest from our frontend when is in development
    app.UseCors(options =>
    {
        options.AllowAnyHeader();
        options.AllowAnyOrigin();
        options.AllowAnyMethod();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
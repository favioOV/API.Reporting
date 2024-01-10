using API.Application.GraphQL.Queries;
using API.Application.Services;
using API.Infrastructure;
using API.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

// Add services to the container.

//builder.Services.AddScoped<GraphClientTestController>();
builder.Services.AddGraphQLServer().AddQueryType<PersonQuery>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add scopeds
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();

//DB Context
builder.Services.AddDbContext<ReportContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ReportConnection")));

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

app.MapGraphQL("/graphql");

app.Run();

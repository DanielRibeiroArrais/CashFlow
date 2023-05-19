using Autofac;
using Autofac.Extensions.DependencyInjection;
using CashFlow.Infrastructure.CrossCutting.IOC;
using CashFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog.Sinks.Elasticsearch;
using Serilog;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new ModuleIOC()));
builder.Services.AddDbContext<CashFlowDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddMemoryCache();


var logger = new LoggerConfiguration()
              .Enrich.FromLogContext()
              .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(builder.Configuration.GetSection("ELASTIC_HOST").Value))
              {
                  AutoRegisterTemplate = true,
              })
          .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();






var app = builder.Build();

//app.UseHealthChecks("/health");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
scope.ServiceProvider
    .GetRequiredService<CashFlowDbContext>()
    .Database
    .Migrate();

app.Run();

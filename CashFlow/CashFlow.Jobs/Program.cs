using Autofac;
using Autofac.Extensions.DependencyInjection;
using CashFlow.Application.Interfaces;
using CashFlow.Infrastructure.CrossCutting.IOC;
using CashFlow.Infrastructure.Data;
using Hangfire;
using HangfireBasicAuthenticationFilter;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.Elasticsearch;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHangfire(x => x.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHangfireServer();

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


var app = builder.Build();

app.UseHangfireServer();
app.UseHangfireDashboard("", new DashboardOptions()
{
    AppPath = null,
    DashboardTitle = "Hangfire Dashboard - CashFlow",
    Authorization = new[]{
        new HangfireCustomBasicAuthenticationFilter{
            User = builder.Configuration.GetSection("HangfireCredentials:UserName").Value,
            Pass = builder.Configuration.GetSection("HangfireCredentials:Password").Value
        }
    },
});

RecurringJob.AddOrUpdate<IApplicationServiceConsolidated>(
    "CashFlowConsolidate", (x) => x.CashFlowConsolidateAsync(), Cron.Minutely());

app.Run();
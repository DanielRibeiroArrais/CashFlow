using Autofac;
using CashFlow.Application.Interfaces;
using CashFlow.Application.Service;
using CashFlow.Domain.Core.Interfaces.Repositorys;
using CashFlow.Domain.Core.Interfaces.Services;
using CashFlow.Domain.Services.Services;
using CashFlow.Infrastructure.CrossCutting.Adapter.Interfaces;
using CashFlow.Infrastructure.CrossCutting.Adapter.Map;
using CashFlow.Infrastructure.Repository.Repositorys;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace CashFlow.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region Registra IOC

            #region IOC Application
            builder.RegisterType<ApplicationServiceConsolidated>().As<IApplicationServiceConsolidated>();
            builder.RegisterType<ApplicationServiceMovements>().As<IApplicationServiceMovements>();
            #endregion

            #region IOC Services
            builder.RegisterType<ServiceConsolidated>().As<IServiceConsolidated>();
            builder.RegisterType<ServiceMovements>().As<IServiceMovements>();
            #endregion

            #region IOC Repositorys SQL
            builder.RegisterType<RepositoryConsolidated>().As<IRepositoryConsolidated>();
            builder.RegisterType<RepositoryMovements>().As<IRepositoryMovements>();
            #endregion

            #region IOC Mapper
            builder.RegisterType<MapperConsolidated>().As<IMapperConsolidated>();
            builder.RegisterType<MapperMovements>().As<IMapperMovements>();
            #endregion

            #endregion
        }
    }
}
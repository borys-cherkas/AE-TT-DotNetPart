using AutoMapper;
using TransactionalSystem.Data.Dtos;
using TransactionalSystem.Infrastructure;
using TransactionalSystem.Services.Models;
using TransactionalSystem.Services.Models.CreateTransaction;

namespace TransactionalSystem.Services.Infrastructure
{
    public static class SAutoMapperInitializer
    {
        public static void Init(IMapperConfigurationExpression configuration)
        {
            DAAutoMapperInitializer.Init(configuration);
            
            configuration.CreateMap<CreateTransactionModel, TransactionDto>();

            configuration.CreateMap<TransactionDto, TransactionDetailsModel>();
        }
    }
}

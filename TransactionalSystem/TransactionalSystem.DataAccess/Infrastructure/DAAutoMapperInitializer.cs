using AutoMapper;
using TransactionalSystem.Data.Dtos;
using TransactionalSystem.Data.Entities;

namespace TransactionalSystem.Infrastructure
{
    public static class DAAutoMapperInitializer
    {
        public static void Init(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<TransactionDto, TransactionEntity>()
                .ReverseMap();
        }
    }
}

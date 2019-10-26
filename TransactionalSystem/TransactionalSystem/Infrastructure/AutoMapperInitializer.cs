using AutoMapper;
using TransactionalSystem.Models.Transactions;
using TransactionalSystem.Services.Infrastructure;
using TransactionalSystem.Services.Models;
using TransactionalSystem.Services.Models.CreateTransaction;

namespace TransactionalSystem.Infrastructure
{
    public static class AutoMapperInitializer
    {
        public static void Init(IMapperConfigurationExpression configuration)
        {
            SAutoMapperInitializer.Init(configuration);


            configuration.CreateMap<CreateTransactionRequest, CreateTransactionModel>();

            configuration.CreateMap<TransactionDetailsModel, TransactionItem>()
                .ForMember(dest => dest.EffectiveDate, opt => opt.MapFrom(src => src.Occured))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString().ToLower()));
        }
    }
}

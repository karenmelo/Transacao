using AutoMapper;
using Newtonsoft.Json;
using Pagamento.App.ViewModels;
using Pagamento.Business.Integracao;
using Pagamento.Business.Integracao.Model;
using Pagamento.Business.Integracao.Model.Request;
using Pagamento.Business.Integracao.Model.Response;
using Pagamento.Business.Models;

namespace Pagamento.App.Mapper
{
    public class TransacaoMapper : Profile
    {
        public TransacaoMapper()
        {
            CreateMap<TransacaoPostRequest, TransacaoViewModel>()
                .ForMember(dest => dest.CardNumber, opt => opt.MapFrom(src => src.Payment.CreditCard.CardNumber))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Payment.CreditCard.Brand))
                .ForMember(dest => dest.Cvv, opt => opt.MapFrom(src => src.Payment.CreditCard.SecurityCode))
                .ForMember(dest => dest.ExpirationDate, opt => opt.MapFrom(src => src.Payment.CreditCard.ExpirationDate))                
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Payment.CreditCard.Holder))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Customer.Name))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Payment.Type))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Payment.Amount))
                .ForMember(dest => dest.Installments, opt => opt.MapFrom(src => src.Payment.Installments))
                .ReverseMap();

            CreateMap<TransactionPutRequest, TransacaoViewModel>()
               .ForMember(dest => dest.PaymentId, opt => opt.MapFrom(src => src.PaymentId))
               .ForMember(dest => dest.ServiceTaxAmount, opt => opt.MapFrom(src => src.ServiceTaxAmount))
               .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))         
               .ReverseMap();

            CreateMap<ResponseAPI, ObjetoRetorno<TransactionModel>>()
                .ForMember(dest => dest.Objeto, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<TransactionModel>(src.Response)))
                .ReverseMap();

            CreateMap<ResponseAPI, ObjetoRetorno<PaymentModel>>()
                .ForMember(dest => dest.Objeto, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<PaymentModel>(src.Response)))
                .ReverseMap();

            CreateMap<Transaction, TransactionModel>()
                .ReverseMap();

            CreateMap<Customer, CustomerModel>()
                .ReverseMap();

            CreateMap<Payment, PaymentModel>()
                .ReverseMap();

            CreateMap<CreditCard, CreditCardModel>()
                .ReverseMap();

            CreateMap<Link, LinkModel>()
                .ReverseMap();

            CreateMap<Transaction, TransacaoViewModel>()
                .ForMember(dest => dest.PaymentId, opt => opt.MapFrom(src => src.PaymentId))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Payment.CreditCard.Brand))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Payment.Amount))
                .ForMember(dest => dest.Installments, opt => opt.MapFrom(src => src.Payment.Installments))
                .ForMember(dest => dest.ReturnCode, opt => opt.MapFrom(src => src.Payment.ReturnCode))
                .ReverseMap();

        }
    }

}

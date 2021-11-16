using AutoMapper;
using Pagamento.App.ViewModels;
using Pagamento.Business.Models;

namespace Pagamento.App.Mapper
{
    public class TransacaoMapper : Profile
    {
        public TransacaoMapper()
        {
            CreateMap<Transacao, TransacaoViewModel>()              
                .ReverseMap();
        }
    }
}

using AutoMapper;
using Newtonsoft.Json;
using Pagamento.Business.Integracao.Model;

namespace Pagamento.Business.Integracao.Mapper
{
    public class TransacaoProfile : Profile
    {
        public TransacaoProfile()
        {
            CreateMap<ResponseAPI, ObjetoRetorno<TransacaoModel>>()
           .ForMember(dest => dest.Objeto, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<TransacaoModel>(src.Response)))
           .ReverseMap();
        }
    }
}

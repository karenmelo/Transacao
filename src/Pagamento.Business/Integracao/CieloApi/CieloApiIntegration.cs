using Pagamento.Business.Integracao.Model;
using Pagamento.Business.Integracao.Service;
using Pagamento.Business.Models;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Pagamento.Business.Integracao.Interface;
using System.Collections.Generic;

namespace Pagamento.Business.Integracao.CieloApi
{
    public class CieloApiIntegration : ICieloApiIntegration
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly Dictionary<string, string> header = new Dictionary<string, string>();
        public CieloApiIntegration(IConfiguration configuration, AutoMapper.IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
            header.Add("MerchantId", "7a5181c8-841d-4144-b938-b129f2ecb3aa");
            header.Add("MerchantKey", "MMAYENXSARFSKOSOMTTKOISTDYCVGBQVOZAXJRSR");
        }


        public ObjetoRetorno<TransacaoModel> Criar(Transacao request)
        {
            var response = ApiRest.PostJson(_configuration.GetSection("ApiCielo:Requisicao").Value, request, header);
            var retorno = _mapper.Map<ObjetoRetorno<TransacaoModel>>(response);
            return retorno;
        }

        public ObjetoRetorno<TransacaoModel> Capturar(Transacao request)
        {

            var response = ApiRest.PutJson(_configuration.GetSection("ApiCielo:Requisicao").Value, request, header);
            var retorno = _mapper.Map<ObjetoRetorno<TransacaoModel>>(response);
            return retorno;
        }

        public ObjetoRetorno<TransacaoModel> Cancelar(Transacao request)
        {
            var response = ApiRest.PutJson(_configuration.GetSection("ApiCielo:Requisicao").Value, request, header);
            var retorno = _mapper.Map<ObjetoRetorno<TransacaoModel>>(response);
            return retorno;
        }
    }
}

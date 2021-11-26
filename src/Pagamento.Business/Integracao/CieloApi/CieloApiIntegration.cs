using AutoMapper;
using Microsoft.Extensions.Configuration;
using Pagamento.Business.Integracao.Interface;
using Pagamento.Business.Integracao.Model.Request;
using Pagamento.Business.Integracao.Model.Response;
using Pagamento.Business.Integracao.Service;
using System;
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

        public ObjetoRetorno<TransactionModel> Criar(TransacaoPostRequest request)
        {
            request.MerchantOrderId = new Random().Next(0, 9999999).ToString();
            var response = ApiRest.Post(_configuration.GetSection("ApiCielo:Requisicao").Value, request, header);            
            var retorno = _mapper.Map<ObjetoRetorno<TransactionModel>>(response);
            return retorno;

        }

        public ObjetoRetorno<PaymentModel> Capturar(TransactionPutRequest request)
        {
            var endPoint = string.Format("{0}{1}/capture", _configuration.GetSection("ApiCielo:Requisicao").Value, request.PaymentId);
            var response = ApiRest.Put(endPoint, request, header);            
            var retorno = _mapper.Map<ObjetoRetorno<PaymentModel>>(response);
            return retorno;
        }

        public ObjetoRetorno<PaymentModel> Cancelar(TransactionPutRequest request)
        {
            var endPoint = string.Format("{0}{1}/void?amount={2}", _configuration.GetSection("ApiCielo:Requisicao").Value, request.PaymentId, request.Amount);
            var response = ApiRest.Put(endPoint, request, header);
            var retorno = _mapper.Map<ObjetoRetorno<PaymentModel>>(response);
            return retorno;
        }
    }
}

using Leaf.xNet;
using Newtonsoft.Json;
using Pagamento.Business.Integracao.Interface;
using Pagamento.Business.Integracao.Model;
using Pagamento.Business.Integracao.Model.Response;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pagamento.Business.Integracao.Service
{
    public class ApiRest
    {
        public static IResponseAPI Post(string endPoint, object body,
                                       Dictionary<string, string> headers = null,
                                       Dictionary<string, string> queryParameter = null,
                                       Dictionary<string, string> parameters = null)
        {
            var client = new RestClient(endPoint);
            var Rsrequest = new RestRequest(Method.POST);

            if (headers != null)
            {
                foreach (var header in headers)
                    Rsrequest.AddHeader(header.Key, header.Value);
            }

            if (queryParameter != null)
            {
                foreach (var parameter in queryParameter)
                    Rsrequest.AddQueryParameter(parameter.Key, parameter.Value);
            }

            string parametros = string.Empty;
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                    Rsrequest.AddParameter(parameter.Key, parameter.Value);

                parametros = string.Join("|", parameters.Select(kvp => $"{kvp.Key}={kvp.Value}"));
            }

            Rsrequest.AddJsonBody(body);

            try
            {
                var Rsresponse = client.Execute(Rsrequest);
                return new ResponseAPI((int)Rsresponse.StatusCode, parametros, Rsresponse.Content);
            }
            catch (HttpException erro)
            {
                return new ResponseAPI { Erro = erro.Message.ToString() };
            }
        }

        public static IResponseAPI Put(string endPoint, object body,
                                       Dictionary<string, string> headers = null,
                                       Dictionary<string, string> queryParameter = null,
                                       Dictionary<string, string> parameters = null)
        {
            var client = new RestClient(endPoint);
            var Rsrequest = new RestRequest(Method.PUT);

            if (headers != null)
            {
                foreach (var header in headers)
                    Rsrequest.AddHeader(header.Key, header.Value);
            }

            if (queryParameter != null)
            {
                foreach (var parameter in queryParameter)
                    Rsrequest.AddQueryParameter(parameter.Key, parameter.Value);
            }

            string parametros = string.Empty;
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                    Rsrequest.AddParameter(parameter.Key, parameter.Value);

                parametros = string.Join("|", parameters.Select(kvp => $"{kvp.Key}={kvp.Value}"));
            }

            Rsrequest.AddJsonBody(body);

            try
            {
                var Rsresponse = client.Execute(Rsrequest);
                return new ResponseAPI((int)Rsresponse.StatusCode, parametros, Rsresponse.Content);
            }
            catch (HttpException erro)
            {
                return new ResponseAPI { Erro = erro.Message.ToString() };
            }

        }
    }
}

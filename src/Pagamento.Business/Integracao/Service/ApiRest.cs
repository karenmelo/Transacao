using Leaf.xNet;
using Newtonsoft.Json;
using Pagamento.Business.Integracao.Interface;
using Pagamento.Business.Integracao.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pagamento.Business.Integracao.Service
{
    public class ApiRest
    {        
        public static IResponseAPI PostJson(string endPoint, object body,
                                           Dictionary<string, string> headers,
                                           Dictionary<string, string> queryParameters = null)
        {
            ResponseAPI response = null;
            
            try
            {
                if (queryParameters != null)
                    endPoint = $"{endPoint}?{string.Join("&", queryParameters.Select(kvp => $"{kvp.Key}={kvp.Value}"))}";

                using (var httpRequest = new HttpRequest())
                {
                    if (headers != null)
                    {
                        foreach (var header in headers)
                            httpRequest.AddHeader(header.Key, header.Value);
                    }

                    var dataAsString = JsonConvert.SerializeObject(body);

                    try
                    {
                        httpRequest.Post(endPoint, dataAsString, "application/json").ToString();
                    }
                    catch (HttpException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                                   
                    response = new ResponseAPI((int)httpRequest.Response.StatusCode, dataAsString, httpRequest.Response.ToString());
                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public static IResponseAPI PutJson(string endPoint, object body,
                                           Dictionary<string, string> headers,
                                           Dictionary<string, string> queryParameters = null)
        {
            ResponseAPI response = null;

            try
            {
                if (queryParameters != null)
                    endPoint = $"{endPoint}?{string.Join("&", queryParameters.Select(kvp => $"{kvp.Key}={kvp.Value}"))}";

                using (var httpRequest = new HttpRequest())
                {
                    if (headers != null)
                    {
                        foreach (var header in headers)
                            httpRequest.AddHeader(header.Key, header.Value);
                    }

                    var dataAsString = JsonConvert.SerializeObject(body);

                    try
                    {
                        httpRequest.Put(endPoint, dataAsString, "application/json").ToString();
                    }
                    catch (HttpException ex)
                    {
                        throw new Exception(ex.Message);
                    }

                    response = new ResponseAPI((int)httpRequest.Response.StatusCode, dataAsString, httpRequest.Response.ToString());
                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }


}

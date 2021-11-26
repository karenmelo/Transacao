using Pagamento.Business.Integracao.Interface;

namespace Pagamento.Business.Integracao.Model.Response
{
    public class ResponseAPI : IResponseAPI
    {
        public ResponseAPI()
        {
        }

        public ResponseAPI(int statusCode, string request, string response)
        {
            StatusCode = statusCode;
            Request = request;
            Response = response;
        }

        public int StatusCode { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public string Erro { get; set; }
    }
}

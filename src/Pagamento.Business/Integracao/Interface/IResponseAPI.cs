namespace Pagamento.Business.Integracao.Interface
{
    public interface IResponseAPI
    {
        public int StatusCode { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
    }
}

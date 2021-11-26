namespace Pagamento.Business.Integracao.Model.Response
{
    public class ObjetoRetorno<T>
    {
        public int StatusCode { get; set; }
        public T Objeto { get; set; }
        public string Erro { get; set; }
    }
}

using Pagamento.Business.Integracao.Model.Request;
using Pagamento.Business.Integracao.Model.Response;

namespace Pagamento.Business.Integracao.Interface
{
    public interface ICieloApiIntegration
    {
        public ObjetoRetorno<TransactionModel> Criar(TransacaoPostRequest request);
        public ObjetoRetorno<PaymentModel> Capturar(TransactionPutRequest request);
        public ObjetoRetorno<PaymentModel> Cancelar(TransactionPutRequest request);
    }
}

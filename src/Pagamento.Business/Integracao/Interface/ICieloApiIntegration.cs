using Pagamento.Business.Integracao.Model;
using Pagamento.Business.Models;

namespace Pagamento.Business.Integracao.Interface
{
    public interface ICieloApiIntegration
    {
        public ObjetoRetorno<TransacaoModel> Criar(Transacao request);
        public ObjetoRetorno<TransacaoModel> Capturar(Transacao request);
        public ObjetoRetorno<TransacaoModel> Cancelar(Transacao request);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamento.Business.Integracao.Model
{
    public class ObjetoRetorno<T>
    {
        public int StatusCode { get; set; }
        public T Objeto { get; set; }
        public string Erro { get; set; }
    }
}

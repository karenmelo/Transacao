using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamento.Business.Integracao.Interface
{
    public interface INlogConfig
    {
        public ILogger logger { get; set; }
        bool TraceAtivado { get; set; }
    }
}

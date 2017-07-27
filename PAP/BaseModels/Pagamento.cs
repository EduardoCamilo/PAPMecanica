using BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModels
{
    class Pagamento
    {
        public int PagamentoID { get; set; }
        public double ValorTotal { get; set; }
        public string FormaPagamento { get; set; }

        //Relacionamente Produto --> Embalagem
        [ForeignKey("_CondicaoPagamentoes")]
        public int CondicaoPagamentoesID { get; set; }
        public virtual ICollection<CondicaoPagamento> _CondicaoPagamentoes { get; set; }
    }
}

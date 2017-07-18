using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModels
{
    public class CondicaoPagamento
    {
        public int CondicaoPagamentoID { get; set; }
        public string NomeCondicaoPagamento { get; set; }
        public string CodigoCondicaoPagamento { get; set; }
        public string DescricaoCondicaoPagamento { get; set; }
        public double DescontoCondicaoPagamento { get; set; }
        public double AcrescimoCondicaoPagamento { get; set; }

    }
}

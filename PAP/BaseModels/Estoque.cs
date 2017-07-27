using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModels
{
    public class Estoque
    {
        public int EstoqueID { get; set; }
        public int QuantidadeEstoque { get; set; }
        public double MargemSeguranca { get; set; }
        public string EnderecoRua { get; set; }
        public string EnderecoBloco { get; set; }
        public string EnderecoPratileira { get; set; }

        //Relacionamente Estoque --> Produto 
        [ForeignKey("_Produto")]
        public int ProdutoID { get; set; }
        public virtual Produto _Produto { get; set; }

    }
}

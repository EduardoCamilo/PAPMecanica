using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModels
{
    class Produto
    {
        public int ProdutoID { get; set; }
        public int CodigoBarras { get; set; }
        public string DescricaoProduto { get; set; }
        public double PrecoProduto { get; set; }
        public double PesoBruto { get; set; }
        public double PesoLiquido { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string EnderecoRua { get; set; }
        public string EnderecoBloco { get; set; }
        public string EnderecoPratileira { get; set; }

        //Relacionamente Produto --> Embalagem
        [ForeignKey("_Embalagem")]
        public int EmbalagemID { get; set; }
        public virtual Embalagem _Embalagem { get; set; }

        //Relacionamente Produto --> Embalagem
        [ForeignKey("_Categoria")]
        public int CategoriaID { get; set; }
        public virtual Categoria _Categoria { get; set; }
    }
}

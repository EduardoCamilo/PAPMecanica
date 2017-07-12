using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModels
{
    class Embalagem
    {
        public int EmbalagemID { get; set; }
        public string DescricaoEmbalagem { get; set; }
        public int CodigoEmbalagem { get; set; }
        public int QuantidadeProdutoEmbalagem { get; set; }
        public string TipoEmbalagem { get; set; }

        //Relacionamente Embalagem --> Produto 
        [ForeignKey("_Produto")]
        public int ProdutoID { get; set; }
        public virtual Produto _Produto { get; set; }
    }
}

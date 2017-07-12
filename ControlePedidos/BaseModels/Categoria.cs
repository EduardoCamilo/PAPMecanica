using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModels
{
    class Categoria
    {
        public int CategoriaID { get; set; }
        public string DescricaoCategoria { get; set; }


        //Relacionamente Categoria --> Produto 
        [ForeignKey("_Produto")]
        public int ProdutoID { get; set; }
        public virtual Produto _Produto { get; set; }

    }
}

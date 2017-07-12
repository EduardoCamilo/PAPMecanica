using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RelatorioMVC.Models
{
    public class Produto
    {
        public int ProdutoID  { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        public int CategoriaID { get; set; }
        public decimal Preco { get; set; }
        public virtual Categoria  _Categoria { get; set; }

    }
}
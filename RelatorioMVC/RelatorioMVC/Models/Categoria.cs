using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RelatorioMVC.Models
{
    public class Categoria
    {
        public int CategoriaID { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}
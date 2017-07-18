using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModels
{
    public class Categoria
    {
        public int CategoriaID { get; set; }
        public string DescricaoCategoria { get; set; }

    }
}

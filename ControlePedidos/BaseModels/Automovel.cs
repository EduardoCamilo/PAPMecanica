using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModels
{
    public class Automovel
    {
        public int AutomovelID { get; set; }
        [Required]
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public int Cor { get; set; }
        public int Ano { get; set; }
        public string Observacao{ get; set; }


    }
}

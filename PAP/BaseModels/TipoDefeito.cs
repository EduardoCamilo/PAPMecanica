using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModels
{
    public class TipoDefeito
    {
        public int TipoDefeitoID { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Descricao { get; set; }

    }
}

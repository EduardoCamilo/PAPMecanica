using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModels
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        [Required]
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone{ get; set; }

        //Relacionamento Cliente --> Automovel

        public ICollection<Automovel> Automoveis { get; set; }

}
}

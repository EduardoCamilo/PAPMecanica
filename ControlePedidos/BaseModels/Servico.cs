using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModels
{
    public class Servico
    {
        public int ServicoID { get; set; }
        [Required]
        public string Descricao { get; set; }

        //Relacionamente Veiculo --> Serviço
        [ForeignKey("_Automovel")]
        public int VeiculoID { get; set; }
        public virtual Automovel _Automovel { get; set; }


        //Relacionamento Defeito --> Serviço
        [ForeignKey("_TipoDefeito")]
        public int TipoDefeitoID { get; set; }
        public virtual TipoDefeito _TipoDefeito { get; set; }
    }
}

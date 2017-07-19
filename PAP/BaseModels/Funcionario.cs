using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModels
{
    public class Funcionario
    {
        public int FuncionarioID { get; set; }
        [Required]
        public string NomeFuncionario { get; set; }
        public string SobreNomeFuncionario { get; set; }
        public string CpfFuncionario { get; set; }
        public string TelefoneFuncionario { get; set; }
        public string LoginFuncionario { get; set; }
        public string SenhaFuncionario { get; set; }
        public string TipoFuncionario { get; set; }

    }
}

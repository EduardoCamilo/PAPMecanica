﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModels
{
    class Venda
    {
        public int VendaID { get; set; }

        public DateTime DataDaVenda { get; set; }

        //Relacionamente Venda --> Cliente 
        [ForeignKey("_Cliente")]
        public int ClienteID { get; set; }
        public virtual Cliente _Cliente { get; set; }

        //Relacionamente Venda --> Vendedor
        [ForeignKey("_Vendedor")]
        public int VendedorID { get; set; }
        public virtual Funcionario _Vendedor { get; set; }

        //Relacionamente Venda --> CondicaoPagamento
        [ForeignKey("_CondicaoPagamento")]
        public int CondicaoPagamentoID { get; set; }
        public virtual CondicaoPagamento _CondicaoPagamento { get; set; }

        //Relacionamente Venda --> ItemVenda
        [ForeignKey("_ItemVenda")]
        public int ItemVendaID { get; set; }
        public virtual ItemVenda _ItemVenda { get; set; }

    }
}
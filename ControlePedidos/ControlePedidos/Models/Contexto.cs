using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ControlePedidos.Models
{
    public class Contexto : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Contexto() : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<BaseModels.Servico> Servicoes { get; set; }

        public System.Data.Entity.DbSet<BaseModels.Automovel> Automovels { get; set; }

        public System.Data.Entity.DbSet<BaseModels.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<BaseModels.TipoDefeito> TipoDefeitoes { get; set; }
    }
}

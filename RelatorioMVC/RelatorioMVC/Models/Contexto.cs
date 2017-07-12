using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RelatorioMVC.Models
{
    public class Contexto : DbContext
    {
        public Contexto() : base("strConn")
        {
            //Default
            //Database.SetInitializer<Contexto>(
            //    new CreateDatabaseIfNotExists<Contexto>()
            //    );

            //Database.SetInitializer<Contexto>(
            //    new DropCreateDatabaseAlways<Contexto>()
            //    );

            Database.SetInitializer<Contexto>(
                new DropCreateDatabaseIfModelChanges<Contexto>()
                );

            
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

    }
}
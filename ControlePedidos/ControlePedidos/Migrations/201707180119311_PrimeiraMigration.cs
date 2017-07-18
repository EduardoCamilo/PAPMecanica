namespace ControlePedidos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeiraMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TipoDefeitoes", "Servico_ServicoID", "dbo.Servicoes");
            DropForeignKey("dbo.Automovels", "Cliente_ClienteID", "dbo.Clientes");
            DropIndex("dbo.Automovels", new[] { "Cliente_ClienteID" });
            DropIndex("dbo.TipoDefeitoes", new[] { "Servico_ServicoID" });
            RenameColumn(table: "dbo.Automovels", name: "Cliente_ClienteID", newName: "ClienteID");
            AddColumn("dbo.Clientes", "SobreNome", c => c.String());
            AddColumn("dbo.Servicoes", "TipoDefeitoID", c => c.Int(nullable: false));
            AlterColumn("dbo.Automovels", "ClienteID", c => c.Int(nullable: false));
            CreateIndex("dbo.Automovels", "ClienteID");
            CreateIndex("dbo.Servicoes", "TipoDefeitoID");
            AddForeignKey("dbo.Servicoes", "TipoDefeitoID", "dbo.TipoDefeitoes", "TipoDefeitoID", cascadeDelete: true);
            AddForeignKey("dbo.Automovels", "ClienteID", "dbo.Clientes", "ClienteID", cascadeDelete: true);
            DropColumn("dbo.TipoDefeitoes", "Servico_ServicoID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TipoDefeitoes", "Servico_ServicoID", c => c.Int());
            DropForeignKey("dbo.Automovels", "ClienteID", "dbo.Clientes");
            DropForeignKey("dbo.Servicoes", "TipoDefeitoID", "dbo.TipoDefeitoes");
            DropIndex("dbo.Servicoes", new[] { "TipoDefeitoID" });
            DropIndex("dbo.Automovels", new[] { "ClienteID" });
            AlterColumn("dbo.Automovels", "ClienteID", c => c.Int());
            DropColumn("dbo.Servicoes", "TipoDefeitoID");
            DropColumn("dbo.Clientes", "SobreNome");
            RenameColumn(table: "dbo.Automovels", name: "ClienteID", newName: "Cliente_ClienteID");
            CreateIndex("dbo.TipoDefeitoes", "Servico_ServicoID");
            CreateIndex("dbo.Automovels", "Cliente_ClienteID");
            AddForeignKey("dbo.Automovels", "Cliente_ClienteID", "dbo.Clientes", "ClienteID");
            AddForeignKey("dbo.TipoDefeitoes", "Servico_ServicoID", "dbo.Servicoes", "ServicoID");
        }
    }
}

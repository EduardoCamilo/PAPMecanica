namespace ControlePedidos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SegundoMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TipoDefeitoes", "Servico_ServicoID", "dbo.Servicoes");
            DropIndex("dbo.TipoDefeitoes", new[] { "Servico_ServicoID" });
            AddColumn("dbo.Servicoes", "TipoDefeitoID", c => c.Int(nullable: false));
            CreateIndex("dbo.Servicoes", "TipoDefeitoID");
            AddForeignKey("dbo.Servicoes", "TipoDefeitoID", "dbo.TipoDefeitoes", "TipoDefeitoID", cascadeDelete: true);
            DropColumn("dbo.TipoDefeitoes", "Servico_ServicoID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TipoDefeitoes", "Servico_ServicoID", c => c.Int());
            DropForeignKey("dbo.Servicoes", "TipoDefeitoID", "dbo.TipoDefeitoes");
            DropIndex("dbo.Servicoes", new[] { "TipoDefeitoID" });
            DropColumn("dbo.Servicoes", "TipoDefeitoID");
            CreateIndex("dbo.TipoDefeitoes", "Servico_ServicoID");
            AddForeignKey("dbo.TipoDefeitoes", "Servico_ServicoID", "dbo.Servicoes", "ServicoID");
        }
    }
}

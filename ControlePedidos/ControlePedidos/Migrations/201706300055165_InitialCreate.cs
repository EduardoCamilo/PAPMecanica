namespace ControlePedidos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Automovels",
                c => new
                    {
                        AutomovelID = c.Int(nullable: false, identity: true),
                        Modelo = c.String(nullable: false),
                        Placa = c.String(),
                        Cor = c.String(),
                        Ano = c.Int(nullable: false),
                        Observacao = c.String(),
                        Cliente_ClienteID = c.Int(),
                    })
                .PrimaryKey(t => t.AutomovelID)
                .ForeignKey("dbo.Clientes", t => t.Cliente_ClienteID)
                .Index(t => t.Cliente_ClienteID);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        CPF = c.String(),
                        Telefone = c.String(),
                    })
                .PrimaryKey(t => t.ClienteID);
            
            CreateTable(
                "dbo.Servicoes",
                c => new
                    {
                        ServicoID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false),
                        VeiculoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServicoID)
                .ForeignKey("dbo.Automovels", t => t.VeiculoID, cascadeDelete: true)
                .Index(t => t.VeiculoID);
            
            CreateTable(
                "dbo.TipoDefeitoes",
                c => new
                    {
                        TipoDefeitoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(),
                        Servico_ServicoID = c.Int(),
                    })
                .PrimaryKey(t => t.TipoDefeitoID)
                .ForeignKey("dbo.Servicoes", t => t.Servico_ServicoID)
                .Index(t => t.Servico_ServicoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TipoDefeitoes", "Servico_ServicoID", "dbo.Servicoes");
            DropForeignKey("dbo.Servicoes", "VeiculoID", "dbo.Automovels");
            DropForeignKey("dbo.Automovels", "Cliente_ClienteID", "dbo.Clientes");
            DropIndex("dbo.TipoDefeitoes", new[] { "Servico_ServicoID" });
            DropIndex("dbo.Servicoes", new[] { "VeiculoID" });
            DropIndex("dbo.Automovels", new[] { "Cliente_ClienteID" });
            DropTable("dbo.TipoDefeitoes");
            DropTable("dbo.Servicoes");
            DropTable("dbo.Clientes");
            DropTable("dbo.Automovels");
        }
    }
}

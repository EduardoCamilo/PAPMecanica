namespace PAP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Segundo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vendas", "ItemVendaID", "dbo.ItemVendas");
            DropIndex("dbo.Vendas", new[] { "ItemVendaID" });
            AddColumn("dbo.ItemVendas", "VendaID", c => c.Int(nullable: false));
            CreateIndex("dbo.ItemVendas", "VendaID");
            AddForeignKey("dbo.ItemVendas", "VendaID", "dbo.Vendas", "VendaID", cascadeDelete: true);
            DropColumn("dbo.ItemVendas", "VendaAtualID");
            DropColumn("dbo.Vendas", "ItemVendaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vendas", "ItemVendaID", c => c.Int(nullable: false));
            AddColumn("dbo.ItemVendas", "VendaAtualID", c => c.Int(nullable: false));
            DropForeignKey("dbo.ItemVendas", "VendaID", "dbo.Vendas");
            DropIndex("dbo.ItemVendas", new[] { "VendaID" });
            DropColumn("dbo.ItemVendas", "VendaID");
            CreateIndex("dbo.Vendas", "ItemVendaID");
            AddForeignKey("dbo.Vendas", "ItemVendaID", "dbo.ItemVendas", "ItemVendaID", cascadeDelete: true);
        }
    }
}

namespace ControlePedidos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeiraMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Automovels", "Cliente_ClienteID", "dbo.Clientes");
            DropIndex("dbo.Automovels", new[] { "Cliente_ClienteID" });
            RenameColumn(table: "dbo.Automovels", name: "Cliente_ClienteID", newName: "ClienteID");
            AlterColumn("dbo.Automovels", "ClienteID", c => c.Int(nullable: false));
            CreateIndex("dbo.Automovels", "ClienteID");
            AddForeignKey("dbo.Automovels", "ClienteID", "dbo.Clientes", "ClienteID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Automovels", "ClienteID", "dbo.Clientes");
            DropIndex("dbo.Automovels", new[] { "ClienteID" });
            AlterColumn("dbo.Automovels", "ClienteID", c => c.Int());
            RenameColumn(table: "dbo.Automovels", name: "ClienteID", newName: "Cliente_ClienteID");
            CreateIndex("dbo.Automovels", "Cliente_ClienteID");
            AddForeignKey("dbo.Automovels", "Cliente_ClienteID", "dbo.Clientes", "ClienteID");
        }
    }
}

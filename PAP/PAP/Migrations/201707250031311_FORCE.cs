namespace PAP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FORCE : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Estoques", "EnderecoRua", c => c.String());
            AddColumn("dbo.Estoques", "EnderecoBloco", c => c.String());
            AddColumn("dbo.Estoques", "EnderecoPratileira", c => c.String());
            AddColumn("dbo.Produtoes", "PrecoCusto", c => c.Double(nullable: false));
            AddColumn("dbo.ItemVendas", "VendaAtualID", c => c.Int(nullable: false));
            DropColumn("dbo.Estoques", "MyProperty");
            DropColumn("dbo.Produtoes", "QuantidadeEstoque");
            DropColumn("dbo.Produtoes", "EnderecoRua");
            DropColumn("dbo.Produtoes", "EnderecoBloco");
            DropColumn("dbo.Produtoes", "EnderecoPratileira");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produtoes", "EnderecoPratileira", c => c.String());
            AddColumn("dbo.Produtoes", "EnderecoBloco", c => c.String());
            AddColumn("dbo.Produtoes", "EnderecoRua", c => c.String());
            AddColumn("dbo.Produtoes", "QuantidadeEstoque", c => c.Int(nullable: false));
            AddColumn("dbo.Estoques", "MyProperty", c => c.Int(nullable: false));
            DropColumn("dbo.ItemVendas", "VendaAtualID");
            DropColumn("dbo.Produtoes", "PrecoCusto");
            DropColumn("dbo.Estoques", "EnderecoPratileira");
            DropColumn("dbo.Estoques", "EnderecoBloco");
            DropColumn("dbo.Estoques", "EnderecoRua");
        }
    }
}

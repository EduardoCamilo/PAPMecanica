namespace PAP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Primeiro : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        DescricaoCategoria = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
            CreateTable(
                "dbo.CondicaoPagamentoes",
                c => new
                    {
                        CondicaoPagamentoID = c.Int(nullable: false, identity: true),
                        NomeCondicaoPagamento = c.String(),
                        CodigoCondicaoPagamento = c.String(),
                        DescricaoCondicaoPagamento = c.String(),
                        DescontoCondicaoPagamento = c.Double(nullable: false),
                        AcrescimoCondicaoPagamento = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CondicaoPagamentoID);
            
            CreateTable(
                "dbo.Embalagems",
                c => new
                    {
                        EmbalagemID = c.Int(nullable: false, identity: true),
                        DescricaoEmbalagem = c.String(),
                        CodigoEmbalagem = c.Int(nullable: false),
                        QuantidadeProdutoEmbalagem = c.Int(nullable: false),
                        TipoEmbalagem = c.String(),
                    })
                .PrimaryKey(t => t.EmbalagemID);
            
            CreateTable(
                "dbo.Estoques",
                c => new
                    {
                        EstoqueID = c.Int(nullable: false, identity: true),
                        QuantidadeEstoque = c.Int(nullable: false),
                        MargemSeguranca = c.Double(nullable: false),
                        MyProperty = c.Int(nullable: false),
                        ProdutoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EstoqueID)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoID, cascadeDelete: true)
                .Index(t => t.ProdutoID);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        ProdutoID = c.Int(nullable: false, identity: true),
                        CodigoBarras = c.Int(nullable: false),
                        DescricaoProduto = c.String(),
                        PrecoProduto = c.Double(nullable: false),
                        PesoBruto = c.Double(nullable: false),
                        PesoLiquido = c.Double(nullable: false),
                        QuantidadeEstoque = c.Int(nullable: false),
                        EnderecoRua = c.String(),
                        EnderecoBloco = c.String(),
                        EnderecoPratileira = c.String(),
                        EmbalagemID = c.Int(nullable: false),
                        CategoriaID = c.Int(nullable: false),
                        ItemVenda_ItemVendaID = c.Int(),
                    })
                .PrimaryKey(t => t.ProdutoID)
                .ForeignKey("dbo.Categorias", t => t.CategoriaID, cascadeDelete: true)
                .ForeignKey("dbo.Embalagems", t => t.EmbalagemID, cascadeDelete: true)
                .ForeignKey("dbo.ItemVendas", t => t.ItemVenda_ItemVendaID)
                .Index(t => t.EmbalagemID)
                .Index(t => t.CategoriaID)
                .Index(t => t.ItemVenda_ItemVendaID);
            
            CreateTable(
                "dbo.Funcionarios",
                c => new
                    {
                        FuncionarioID = c.Int(nullable: false, identity: true),
                        NomeFuncionario = c.String(nullable: false),
                        SobreNomeFuncionario = c.String(),
                        CpfFuncionario = c.String(),
                        TelefoneFuncionario = c.String(),
                        LoginFuncionario = c.String(),
                        SenhaFuncionario = c.String(),
                        TipoFuncionario = c.String(),
                        AtivoFuncionario = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FuncionarioID);
            
            CreateTable(
                "dbo.ItemVendas",
                c => new
                    {
                        ItemVendaID = c.Int(nullable: false, identity: true),
                        QuantidadeItemVenda = c.Int(nullable: false),
                        QuantidadeEstoqueAtual = c.Int(nullable: false),
                        PrecoUnitario = c.Double(nullable: false),
                        ProdutoID = c.Int(nullable: false),
                        EmbalagemID = c.Int(nullable: false),
                        CategoriaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemVendaID)
                .ForeignKey("dbo.Categorias", t => t.CategoriaID, cascadeDelete: true)
                .ForeignKey("dbo.Embalagems", t => t.EmbalagemID, cascadeDelete: true)
                .Index(t => t.EmbalagemID)
                .Index(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Servicoes",
                c => new
                    {
                        ServicoID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false),
                        VeiculoID = c.Int(nullable: false),
                        TipoDefeitoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServicoID)
                .ForeignKey("dbo.Automovels", t => t.VeiculoID, cascadeDelete: true)
                .ForeignKey("dbo.TipoDefeitoes", t => t.TipoDefeitoID, cascadeDelete: true)
                .Index(t => t.VeiculoID)
                .Index(t => t.TipoDefeitoID);
            
            CreateTable(
                "dbo.TipoDefeitoes",
                c => new
                    {
                        TipoDefeitoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.TipoDefeitoID);
            
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        VendaID = c.Int(nullable: false, identity: true),
                        DataDaVenda = c.DateTime(nullable: false),
                        ClienteID = c.Int(nullable: false),
                        VendedorID = c.Int(nullable: false),
                        CondicaoPagamentoID = c.Int(nullable: false),
                        ItemVendaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VendaID)
                .ForeignKey("dbo.Clientes", t => t.ClienteID, cascadeDelete: true)
                .ForeignKey("dbo.CondicaoPagamentoes", t => t.CondicaoPagamentoID, cascadeDelete: true)
                .ForeignKey("dbo.Funcionarios", t => t.VendedorID, cascadeDelete: true)
                .ForeignKey("dbo.ItemVendas", t => t.ItemVendaID, cascadeDelete: true)
                .Index(t => t.ClienteID)
                .Index(t => t.VendedorID)
                .Index(t => t.CondicaoPagamentoID)
                .Index(t => t.ItemVendaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendas", "ItemVendaID", "dbo.ItemVendas");
            DropForeignKey("dbo.Vendas", "VendedorID", "dbo.Funcionarios");
            DropForeignKey("dbo.Vendas", "CondicaoPagamentoID", "dbo.CondicaoPagamentoes");
            DropForeignKey("dbo.Vendas", "ClienteID", "dbo.Clientes");
            DropForeignKey("dbo.Servicoes", "TipoDefeitoID", "dbo.TipoDefeitoes");
            DropForeignKey("dbo.Servicoes", "VeiculoID", "dbo.Automovels");
            DropForeignKey("dbo.Produtoes", "ItemVenda_ItemVendaID", "dbo.ItemVendas");
            DropForeignKey("dbo.ItemVendas", "EmbalagemID", "dbo.Embalagems");
            DropForeignKey("dbo.ItemVendas", "CategoriaID", "dbo.Categorias");
            DropForeignKey("dbo.Estoques", "ProdutoID", "dbo.Produtoes");
            DropForeignKey("dbo.Produtoes", "EmbalagemID", "dbo.Embalagems");
            DropForeignKey("dbo.Produtoes", "CategoriaID", "dbo.Categorias");
            DropIndex("dbo.Vendas", new[] { "ItemVendaID" });
            DropIndex("dbo.Vendas", new[] { "CondicaoPagamentoID" });
            DropIndex("dbo.Vendas", new[] { "VendedorID" });
            DropIndex("dbo.Vendas", new[] { "ClienteID" });
            DropIndex("dbo.Servicoes", new[] { "TipoDefeitoID" });
            DropIndex("dbo.Servicoes", new[] { "VeiculoID" });
            DropIndex("dbo.ItemVendas", new[] { "CategoriaID" });
            DropIndex("dbo.ItemVendas", new[] { "EmbalagemID" });
            DropIndex("dbo.Produtoes", new[] { "ItemVenda_ItemVendaID" });
            DropIndex("dbo.Produtoes", new[] { "CategoriaID" });
            DropIndex("dbo.Produtoes", new[] { "EmbalagemID" });
            DropIndex("dbo.Estoques", new[] { "ProdutoID" });
            DropTable("dbo.Vendas");
            DropTable("dbo.TipoDefeitoes");
            DropTable("dbo.Servicoes");
            DropTable("dbo.ItemVendas");
            DropTable("dbo.Funcionarios");
            DropTable("dbo.Produtoes");
            DropTable("dbo.Estoques");
            DropTable("dbo.Embalagems");
            DropTable("dbo.CondicaoPagamentoes");
            DropTable("dbo.Categorias");
        }
    }
}

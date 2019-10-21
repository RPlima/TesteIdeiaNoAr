namespace EcommerceIdeia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carrinho",
                c => new
                    {
                        idCarrinho = c.Int(nullable: false, identity: true),
                        carrinhoGuid = c.String(),
                        valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        quantidade = c.Int(nullable: false),
                        Pedido_idPedido = c.Int(),
                        Produto_idProduto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idCarrinho)
                .ForeignKey("dbo.Produto", t => t.Produto_idProduto, cascadeDelete: true)
                .Index(t => t.Pedido_idPedido)
                .Index(t => t.Produto_idProduto);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        idPedido = c.Int(nullable: false, identity: true),
                        valorTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.idPedido);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        idProduto = c.Int(nullable: false, identity: true),
                        nomeProduto = c.String(nullable: false, maxLength: 45, unicode: false),
                        preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.idProduto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carrinho", "Produto_idProduto", "dbo.Produto");
            DropForeignKey("dbo.Carrinho", "Pedido_idPedido", "dbo.Pedido");
            DropIndex("dbo.Carrinho", new[] { "Produto_idProduto" });
            DropIndex("dbo.Carrinho", new[] { "Pedido_idPedido" });
            DropTable("dbo.Produto");
            DropTable("dbo.Pedido");
            DropTable("dbo.Carrinho");
        }
    }
}

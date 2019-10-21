namespace EcommerceIdeia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GuidCarrinhoPedido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedido", "CarrinhoGuid", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedido", "CarrinhoGuid");
        }
    }
}

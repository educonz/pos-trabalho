namespace TrabalhoPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Four : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pessoa", "EnderecoId", "dbo.Endereco");
            DropIndex("dbo.Pessoa", new[] { "EnderecoId" });
            AlterColumn("dbo.Pessoa", "EnderecoId", c => c.Int());
            CreateIndex("dbo.Pessoa", "EnderecoId");
            AddForeignKey("dbo.Pessoa", "EnderecoId", "dbo.Endereco", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pessoa", "EnderecoId", "dbo.Endereco");
            DropIndex("dbo.Pessoa", new[] { "EnderecoId" });
            AlterColumn("dbo.Pessoa", "EnderecoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pessoa", "EnderecoId");
            AddForeignKey("dbo.Pessoa", "EnderecoId", "dbo.Endereco", "Id", cascadeDelete: true);
        }
    }
}

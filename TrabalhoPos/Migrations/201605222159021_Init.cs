namespace TrabalhoPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Pessoas", name: "Endereco_Id", newName: "EnderecoId");
            RenameIndex(table: "dbo.Pessoas", name: "IX_Endereco_Id", newName: "IX_EnderecoId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Pessoas", name: "IX_EnderecoId", newName: "IX_Endereco_Id");
            RenameColumn(table: "dbo.Pessoas", name: "EnderecoId", newName: "Endereco_Id");
        }
    }
}

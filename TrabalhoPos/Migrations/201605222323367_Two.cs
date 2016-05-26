namespace TrabalhoPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Two : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Enderecoes", newName: "Endereco");
            RenameTable(name: "dbo.Pessoas", newName: "Pessoa");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Pessoa", newName: "Pessoas");
            RenameTable(name: "dbo.Endereco", newName: "Enderecoes");
        }
    }
}

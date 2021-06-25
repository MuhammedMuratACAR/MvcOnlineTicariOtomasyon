namespace OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUrunModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Uruns", "Kategori_KategoriID", "dbo.Kategoris");
            DropIndex("dbo.Uruns", new[] { "Kategori_KategoriID" });
            RenameColumn(table: "dbo.Uruns", name: "Kategori_KategoriID", newName: "KategoriID");
            AlterColumn("dbo.Uruns", "KategoriID", c => c.Int(nullable: false));
            CreateIndex("dbo.Uruns", "KategoriID");
            AddForeignKey("dbo.Uruns", "KategoriID", "dbo.Kategoris", "KategoriID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Uruns", "KategoriID", "dbo.Kategoris");
            DropIndex("dbo.Uruns", new[] { "KategoriID" });
            AlterColumn("dbo.Uruns", "KategoriID", c => c.Int());
            RenameColumn(table: "dbo.Uruns", name: "KategoriID", newName: "Kategori_KategoriID");
            CreateIndex("dbo.Uruns", "Kategori_KategoriID");
            AddForeignKey("dbo.Uruns", "Kategori_KategoriID", "dbo.Kategoris", "KategoriID");
        }
    }
}

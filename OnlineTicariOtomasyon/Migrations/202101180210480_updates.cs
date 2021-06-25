namespace OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updates : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SatisHarekets", "PersonelID", "dbo.Personels");
            DropForeignKey("dbo.SatisHarekets", "UrunID", "dbo.Uruns");
            DropIndex("dbo.SatisHarekets", new[] { "UrunID" });
            DropIndex("dbo.SatisHarekets", new[] { "PersonelID" });
            RenameColumn(table: "dbo.SatisHarekets", name: "PersonelID", newName: "Personel_PersonelID");
            RenameColumn(table: "dbo.SatisHarekets", name: "UrunID", newName: "Urun_UrunID");
            AlterColumn("dbo.SatisHarekets", "Urun_UrunID", c => c.Int());
            AlterColumn("dbo.SatisHarekets", "Personel_PersonelID", c => c.Int());
            CreateIndex("dbo.SatisHarekets", "Personel_PersonelID");
            CreateIndex("dbo.SatisHarekets", "Urun_UrunID");
            AddForeignKey("dbo.SatisHarekets", "Personel_PersonelID", "dbo.Personels", "PersonelID");
            AddForeignKey("dbo.SatisHarekets", "Urun_UrunID", "dbo.Uruns", "UrunID");
            DropColumn("dbo.SatisHarekets", "CarilerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SatisHarekets", "CarilerID", c => c.Int(nullable: false));
            DropForeignKey("dbo.SatisHarekets", "Urun_UrunID", "dbo.Uruns");
            DropForeignKey("dbo.SatisHarekets", "Personel_PersonelID", "dbo.Personels");
            DropIndex("dbo.SatisHarekets", new[] { "Urun_UrunID" });
            DropIndex("dbo.SatisHarekets", new[] { "Personel_PersonelID" });
            AlterColumn("dbo.SatisHarekets", "Personel_PersonelID", c => c.Int(nullable: false));
            AlterColumn("dbo.SatisHarekets", "Urun_UrunID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.SatisHarekets", name: "Urun_UrunID", newName: "UrunID");
            RenameColumn(table: "dbo.SatisHarekets", name: "Personel_PersonelID", newName: "PersonelID");
            CreateIndex("dbo.SatisHarekets", "PersonelID");
            CreateIndex("dbo.SatisHarekets", "UrunID");
            AddForeignKey("dbo.SatisHarekets", "UrunID", "dbo.Uruns", "UrunID", cascadeDelete: true);
            AddForeignKey("dbo.SatisHarekets", "PersonelID", "dbo.Personels", "PersonelID", cascadeDelete: true);
        }
    }
}

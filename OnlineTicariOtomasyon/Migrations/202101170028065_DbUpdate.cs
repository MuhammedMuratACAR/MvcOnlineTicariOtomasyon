namespace OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carilers", "SatisHareket_SatisID", "dbo.SatisHarekets");
            DropForeignKey("dbo.Personels", "SatisHareket_SatisID", "dbo.SatisHarekets");
            DropForeignKey("dbo.Uruns", "SatisHareket_SatisID", "dbo.SatisHarekets");
            DropIndex("dbo.Carilers", new[] { "SatisHareket_SatisID" });
            DropIndex("dbo.Personels", new[] { "SatisHareket_SatisID" });
            DropIndex("dbo.Uruns", new[] { "SatisHareket_SatisID" });
            AddColumn("dbo.SatisHarekets", "Cariler_CariID", c => c.Int());
            AddColumn("dbo.SatisHarekets", "Personel_PersonelID", c => c.Int());
            AddColumn("dbo.SatisHarekets", "Urun_UrunID", c => c.Int());
            CreateIndex("dbo.SatisHarekets", "Cariler_CariID");
            CreateIndex("dbo.SatisHarekets", "Personel_PersonelID");
            CreateIndex("dbo.SatisHarekets", "Urun_UrunID");
            AddForeignKey("dbo.SatisHarekets", "Cariler_CariID", "dbo.Carilers", "CariID");
            AddForeignKey("dbo.SatisHarekets", "Personel_PersonelID", "dbo.Personels", "PersonelID");
            AddForeignKey("dbo.SatisHarekets", "Urun_UrunID", "dbo.Uruns", "UrunID");
            DropColumn("dbo.Carilers", "SatisHareket_SatisID");
            DropColumn("dbo.Personels", "SatisHareket_SatisID");
            DropColumn("dbo.Uruns", "SatisHareket_SatisID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Uruns", "SatisHareket_SatisID", c => c.Int());
            AddColumn("dbo.Personels", "SatisHareket_SatisID", c => c.Int());
            AddColumn("dbo.Carilers", "SatisHareket_SatisID", c => c.Int());
            DropForeignKey("dbo.SatisHarekets", "Urun_UrunID", "dbo.Uruns");
            DropForeignKey("dbo.SatisHarekets", "Personel_PersonelID", "dbo.Personels");
            DropForeignKey("dbo.SatisHarekets", "Cariler_CariID", "dbo.Carilers");
            DropIndex("dbo.SatisHarekets", new[] { "Urun_UrunID" });
            DropIndex("dbo.SatisHarekets", new[] { "Personel_PersonelID" });
            DropIndex("dbo.SatisHarekets", new[] { "Cariler_CariID" });
            DropColumn("dbo.SatisHarekets", "Urun_UrunID");
            DropColumn("dbo.SatisHarekets", "Personel_PersonelID");
            DropColumn("dbo.SatisHarekets", "Cariler_CariID");
            CreateIndex("dbo.Uruns", "SatisHareket_SatisID");
            CreateIndex("dbo.Personels", "SatisHareket_SatisID");
            CreateIndex("dbo.Carilers", "SatisHareket_SatisID");
            AddForeignKey("dbo.Uruns", "SatisHareket_SatisID", "dbo.SatisHarekets", "SatisID");
            AddForeignKey("dbo.Personels", "SatisHareket_SatisID", "dbo.SatisHarekets", "SatisID");
            AddForeignKey("dbo.Carilers", "SatisHareket_SatisID", "dbo.SatisHarekets", "SatisID");
        }
    }
}

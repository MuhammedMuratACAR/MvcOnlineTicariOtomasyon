namespace OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sons : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SatisHarekets", "Cariler_CariID", "dbo.Carilers");
            DropForeignKey("dbo.SatisHarekets", "Personel_PersonelID", "dbo.Personels");
            DropForeignKey("dbo.SatisHarekets", "Urun_UrunID", "dbo.Uruns");
            DropIndex("dbo.SatisHarekets", new[] { "Cariler_CariID" });
            DropIndex("dbo.SatisHarekets", new[] { "Personel_PersonelID" });
            DropIndex("dbo.SatisHarekets", new[] { "Urun_UrunID" });
            RenameColumn(table: "dbo.SatisHarekets", name: "Cariler_CariID", newName: "CariID");
            RenameColumn(table: "dbo.SatisHarekets", name: "Personel_PersonelID", newName: "PersonelID");
            RenameColumn(table: "dbo.SatisHarekets", name: "Urun_UrunID", newName: "UrunID");
            AlterColumn("dbo.SatisHarekets", "CariID", c => c.Int(nullable: false));
            AlterColumn("dbo.SatisHarekets", "PersonelID", c => c.Int(nullable: false));
            AlterColumn("dbo.SatisHarekets", "UrunID", c => c.Int(nullable: false));
            CreateIndex("dbo.SatisHarekets", "UrunID");
            CreateIndex("dbo.SatisHarekets", "CariID");
            CreateIndex("dbo.SatisHarekets", "PersonelID");
            AddForeignKey("dbo.SatisHarekets", "CariID", "dbo.Carilers", "CariID", cascadeDelete: true);
            AddForeignKey("dbo.SatisHarekets", "PersonelID", "dbo.Personels", "PersonelID", cascadeDelete: true);
            AddForeignKey("dbo.SatisHarekets", "UrunID", "dbo.Uruns", "UrunID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SatisHarekets", "UrunID", "dbo.Uruns");
            DropForeignKey("dbo.SatisHarekets", "PersonelID", "dbo.Personels");
            DropForeignKey("dbo.SatisHarekets", "CariID", "dbo.Carilers");
            DropIndex("dbo.SatisHarekets", new[] { "PersonelID" });
            DropIndex("dbo.SatisHarekets", new[] { "CariID" });
            DropIndex("dbo.SatisHarekets", new[] { "UrunID" });
            AlterColumn("dbo.SatisHarekets", "UrunID", c => c.Int());
            AlterColumn("dbo.SatisHarekets", "PersonelID", c => c.Int());
            AlterColumn("dbo.SatisHarekets", "CariID", c => c.Int());
            RenameColumn(table: "dbo.SatisHarekets", name: "UrunID", newName: "Urun_UrunID");
            RenameColumn(table: "dbo.SatisHarekets", name: "PersonelID", newName: "Personel_PersonelID");
            RenameColumn(table: "dbo.SatisHarekets", name: "CariID", newName: "Cariler_CariID");
            CreateIndex("dbo.SatisHarekets", "Urun_UrunID");
            CreateIndex("dbo.SatisHarekets", "Personel_PersonelID");
            CreateIndex("dbo.SatisHarekets", "Cariler_CariID");
            AddForeignKey("dbo.SatisHarekets", "Urun_UrunID", "dbo.Uruns", "UrunID");
            AddForeignKey("dbo.SatisHarekets", "Personel_PersonelID", "dbo.Personels", "PersonelID");
            AddForeignKey("dbo.SatisHarekets", "Cariler_CariID", "dbo.Carilers", "CariID");
        }
    }
}

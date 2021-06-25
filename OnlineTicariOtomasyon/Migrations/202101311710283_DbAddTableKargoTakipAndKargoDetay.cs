namespace OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbAddTableKargoTakipAndKargoDetay : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KargoDetays",
                c => new
                    {
                        KargoDetayID = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(maxLength: 300, unicode: false),
                        TakipKodu = c.String(maxLength: 10, unicode: false),
                        Alici = c.String(maxLength: 50, unicode: false),
                        Tarih = c.DateTime(nullable: false, storeType: "date"),
                        PersonelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KargoDetayID)
                .ForeignKey("dbo.Personels", t => t.PersonelID, cascadeDelete: true)
                .Index(t => t.PersonelID);
            
            CreateTable(
                "dbo.KargoTakips",
                c => new
                    {
                        KargoTakipID = c.Int(nullable: false, identity: true),
                        TakipKodu = c.String(maxLength: 10, unicode: false),
                        Aciklama = c.String(maxLength: 100, unicode: false),
                        TarihZaman = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.KargoTakipID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KargoDetays", "PersonelID", "dbo.Personels");
            DropIndex("dbo.KargoDetays", new[] { "PersonelID" });
            DropTable("dbo.KargoTakips");
            DropTable("dbo.KargoDetays");
        }
    }
}

namespace TelefonRehberi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBLDEPARTMAN",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DepartmanAd = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TBLPERSONEL",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AD = c.String(nullable: false, maxLength: 50),
                        SOYAD = c.String(nullable: false, maxLength: 50),
                        TELEFON = c.String(nullable: false, maxLength: 11),
                        DETAY = c.String(maxLength: 1000),
                        YONETICI = c.Int(nullable: false),
                        YONETICIAD = c.String(),
                        DepartmanID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TBLDEPARTMAN", t => t.DepartmanID, cascadeDelete: true)
                .Index(t => t.DepartmanID);
            
            CreateTable(
                "dbo.TBLADMİN",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KULLANICIADI = c.String(nullable: false, maxLength: 50),
                        SIFRE = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBLPERSONEL", "DepartmanID", "dbo.TBLDEPARTMAN");
            DropIndex("dbo.TBLPERSONEL", new[] { "DepartmanID" });
            DropTable("dbo.TBLADMİN");
            DropTable("dbo.TBLPERSONEL");
            DropTable("dbo.TBLDEPARTMAN");
        }
    }
}

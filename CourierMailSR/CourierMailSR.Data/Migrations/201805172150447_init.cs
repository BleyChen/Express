namespace CourierMailSR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExpressReceiveInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReceiveTime = c.DateTime(nullable: false, precision: 0),
                        Signtime = c.DateTime(nullable: false, precision: 0),
                        Signer = c.String(unicode: false),
                        Status = c.Int(nullable: false),
                        ExpressNo = c.String(unicode: false),
                        Name = c.String(unicode: false),
                        Phone = c.String(unicode: false),
                        MailType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExpressSendInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReceiveTime = c.DateTime(nullable: false, precision: 0),
                        SendTime = c.DateTime(nullable: false, precision: 0),
                        Status = c.Int(nullable: false),
                        ExpressNo = c.String(unicode: false),
                        Name = c.String(unicode: false),
                        Phone = c.String(unicode: false),
                        MailType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ExpressSendInfoes");
            DropTable("dbo.ExpressReceiveInfoes");
        }
    }
}

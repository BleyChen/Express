namespace CourierMailSR.DataClient.Migrations
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
                        ReceiveTime = c.DateTime(nullable: false),
                        Signtime = c.DateTime(),
                        Signer = c.String(),
                        Status = c.Int(nullable: false),
                        ExpressNo = c.String(),
                        Name = c.String(),
                        Phone = c.String(),
                        MailType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExpressSendInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReceiveTime = c.DateTime(nullable: false),
                        SendTime = c.DateTime(),
                        Status = c.Int(nullable: false),
                        ExpressNo = c.String(),
                        Name = c.String(),
                        Phone = c.String(),
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

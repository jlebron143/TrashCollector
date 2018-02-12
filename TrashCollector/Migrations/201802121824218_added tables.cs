namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerViewModels",
                c => new
                    {
                        CustomersID = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        pickUpDay = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        StreetAddress = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Zip = c.String(nullable: false),
                        Schedule_ScheduleID = c.Int(),
                    })
                .PrimaryKey(t => t.CustomersID)
                .ForeignKey("dbo.Schedules", t => t.Schedule_ScheduleID)
                .Index(t => t.Schedule_ScheduleID);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleID = c.Int(nullable: false, identity: true),
                        PickUpDays = c.Int(nullable: false),
                        ScheduledDays = c.String(),
                        AdditionalDay = c.String(),
                        TrashCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VacationModeStart = c.DateTime(),
                        VacationModeEnd = c.DateTime(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ScheduleID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.MapPickupModels",
                c => new
                    {
                        LastName = c.String(nullable: false, maxLength: 128),
                        Address = c.String(),
                        Day = c.String(),
                        Zip = c.String(),
                        Lat = c.String(),
                        Lng = c.String(),
                    })
                .PrimaryKey(t => t.LastName);
            
            CreateTable(
                "dbo.Pricings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Service = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        WorkerID = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                        Email = c.String(),
                        URLReturn = c.String(),
                    })
                .PrimaryKey(t => t.WorkerID);
            
            AddColumn("dbo.AspNetUsers", "RoleId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Zip", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Pickupday", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "EnrollDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "EndDate", c => c.DateTime(nullable: false));
            DropTable("dbo.Customers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        userNameID = c.String(nullable: false, maxLength: 128),
                        pickUpDay = c.String(),
                    })
                .PrimaryKey(t => t.userNameID);
            
            DropForeignKey("dbo.CustomerViewModels", "Schedule_ScheduleID", "dbo.Schedules");
            DropForeignKey("dbo.Schedules", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Schedules", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.CustomerViewModels", new[] { "Schedule_ScheduleID" });
            DropColumn("dbo.AspNetUsers", "EndDate");
            DropColumn("dbo.AspNetUsers", "StartDate");
            DropColumn("dbo.AspNetUsers", "EnrollDate");
            DropColumn("dbo.AspNetUsers", "Pickupday");
            DropColumn("dbo.AspNetUsers", "Zip");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "RoleId");
            DropTable("dbo.Workers");
            DropTable("dbo.Pricings");
            DropTable("dbo.MapPickupModels");
            DropTable("dbo.Schedules");
            DropTable("dbo.CustomerViewModels");
        }
    }
}

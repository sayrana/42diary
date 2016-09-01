namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BiometricInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HeartRate = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.BiometricMetadatas",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Weight = c.Double(nullable: false),
                        Waist = c.Double(nullable: false),
                        Hips = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BiometricInfoes", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrainingTemplates",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trainings", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Trainings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TrainingTypes", t => t.Type_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.TrainingMetadatas",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Distance = c.Double(nullable: false),
                        Time = c.Time(nullable: false, precision: 7),
                        Intensity = c.Int(nullable: false),
                        AverageSpeed = c.Double(nullable: false),
                        AverageTempo = c.Double(nullable: false),
                        AverageHeartRate = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trainings", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.TrainingTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainingTemplates", "Id", "dbo.Trainings");
            DropForeignKey("dbo.Trainings", "Type_Id", "dbo.TrainingTypes");
            DropForeignKey("dbo.TrainingMetadatas", "Id", "dbo.Trainings");
            DropForeignKey("dbo.BiometricInfoes", "User_Id", "dbo.Users");
            DropForeignKey("dbo.BiometricMetadatas", "Id", "dbo.BiometricInfoes");
            DropIndex("dbo.TrainingMetadatas", new[] { "Id" });
            DropIndex("dbo.Trainings", new[] { "Type_Id" });
            DropIndex("dbo.TrainingTemplates", new[] { "Id" });
            DropIndex("dbo.BiometricMetadatas", new[] { "Id" });
            DropIndex("dbo.BiometricInfoes", new[] { "User_Id" });
            DropTable("dbo.TrainingTypes");
            DropTable("dbo.TrainingMetadatas");
            DropTable("dbo.Trainings");
            DropTable("dbo.TrainingTemplates");
            DropTable("dbo.Users");
            DropTable("dbo.BiometricMetadatas");
            DropTable("dbo.BiometricInfoes");
        }
    }
}

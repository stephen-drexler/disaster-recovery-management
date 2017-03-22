namespace VM.DisasterRecovery.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDisasterLocationContraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Disasters", "Location", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Disasters", "Location", c => c.String());
        }
    }
}

namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembeshipTypes : DbMigration
    {
        public override void Up()
        {
            
            Sql("INSERT INTO MEMBERSHIPTYPES (Id , SignUpFee , DurationInMonths , DiscoutRate) VALUES (1 , 0, 0,0)");
            Sql("INSERT INTO MEMBERSHIPTYPES (Id , SignUpFee , DurationInMonths , DiscoutRate) VALUES (2 , 30, 1,10)");
            Sql("INSERT INTO MEMBERSHIPTYPES (Id , SignUpFee , DurationInMonths , DiscoutRate) VALUES (3 , 90, 3,15)");
            Sql("INSERT INTO MEMBERSHIPTYPES (Id , SignUpFee , DurationInMonths , DiscoutRate) VALUES (4 , 300, 15,20)");
        }
        
        public override void Down()
        {
        }
    }
}

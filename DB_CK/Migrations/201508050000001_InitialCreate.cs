namespace DB_CK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            SqlFile("SqlScript/201508050000001_InitialCreate.sql");    
        
            //增加系统管理员账户
            Sql("INSERT INTO [dbo].[TUser]" +
           "([dengluming],[mima],[yonghuming],[juese],[beizhu],[zhuangtai],[charushijian],[xiugaishijian])" +
            "VALUES('admin','7a57a5a743894a0e','系统管理员',1,'',1,getdate(),getdate())");            
        }
        
        public override void Down()
        {
            
        }
    }
}

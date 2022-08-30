namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_MaxLength_Changed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Abouts", "AboutImage", c => c.String(maxLength: 250));
            AlterColumn("dbo.Abouts", "AboutImage2", c => c.String(maxLength: 250));
            AlterColumn("dbo.Admins", "AdminUsername", c => c.String(maxLength: 250));
            AlterColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 250));
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(maxLength: 250));
            AlterColumn("dbo.Headings", "HeadingName", c => c.String(maxLength: 250));
            AlterColumn("dbo.Writers", "WriterName", c => c.String(maxLength: 250));
            AlterColumn("dbo.Writers", "WriterSurname", c => c.String(maxLength: 250));
            AlterColumn("dbo.Writers", "WriterAbout", c => c.String(maxLength: 250));
            AlterColumn("dbo.Writers", "WriterMail", c => c.String(maxLength: 250));
            AlterColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 250));
            AlterColumn("dbo.Writers", "WriterTitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.Contacts", "UserName", c => c.String(maxLength: 250));
            AlterColumn("dbo.Contacts", "UserMail", c => c.String(maxLength: 250));
            AlterColumn("dbo.Contacts", "Subject", c => c.String(maxLength: 250));
            AlterColumn("dbo.ImageFiles", "ImageName", c => c.String(maxLength: 250));
            AlterColumn("dbo.Messages", "SenderMail", c => c.String(maxLength: 250));
            AlterColumn("dbo.Messages", "ReceiverMail", c => c.String(maxLength: 250));
            AlterColumn("dbo.Messages", "Subject", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "Subject", c => c.String(maxLength: 100));
            AlterColumn("dbo.Messages", "ReceiverMail", c => c.String(maxLength: 50));
            AlterColumn("dbo.Messages", "SenderMail", c => c.String(maxLength: 50));
            AlterColumn("dbo.ImageFiles", "ImageName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Contacts", "Subject", c => c.String(maxLength: 50));
            AlterColumn("dbo.Contacts", "UserMail", c => c.String(maxLength: 50));
            AlterColumn("dbo.Contacts", "UserName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Writers", "WriterTitle", c => c.String(maxLength: 50));
            AlterColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 200));
            AlterColumn("dbo.Writers", "WriterMail", c => c.String(maxLength: 200));
            AlterColumn("dbo.Writers", "WriterAbout", c => c.String(maxLength: 100));
            AlterColumn("dbo.Writers", "WriterSurname", c => c.String(maxLength: 50));
            AlterColumn("dbo.Writers", "WriterName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Headings", "HeadingName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 50));
            AlterColumn("dbo.Admins", "AdminUsername", c => c.String(maxLength: 50));
            AlterColumn("dbo.Abouts", "AboutImage2", c => c.String(maxLength: 100));
            AlterColumn("dbo.Abouts", "AboutImage", c => c.String(maxLength: 100));
        }
    }
}

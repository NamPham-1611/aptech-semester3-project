namespace EnvironmentalSurveyPortal.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Collections.Generic;

    public class SurveyDB : DbContext
    {
        public SurveyDB() : base("name=eProject3DB")
        {
        }

        public virtual DbSet<User> tbUser { get; set; }
        public virtual DbSet<Survey> tbSurvey { get; set; }
        public virtual DbSet<Feedback> tbFeedback { get; set; }
        public virtual DbSet<FAQ> tbFAQ { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    public class DBInit : DropCreateDatabaseIfModelChanges<SurveyDB>
    {
        protected override void Seed(SurveyDB context)
        {
            List<User> userList = new List<User>
            {
                new User { UserID = "admin", Name="Admin", Password="123", Role="Admin" },
                new User { UserID = "ST1099153", Name="Vu Van Ninh", Password="123", Class="T1.1803.M1", Role="Student" },
                new User { UserID = "ST1093700", Name="Vo Duy Cuong", Password="123", Class="T1.1803.M1", Role="Student" },
                new User { UserID = "ST1098850", Name="Pham Phuong Nam", Password="123", Class="T1.1803.M1", Role="Student" },
                new User { UserID = "ST1098221", Name="Pham Tan Nam Thanh", Password="123", Class="T1.1803.M1", Role="Student" }
            };

            userList.ForEach(item => context.tbUser.Add(item));
            context.SaveChanges();
        }
    }
}
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
        public virtual DbSet<Prize> tbPrize { get; set; }
        public virtual DbSet<Feedback> tbFeedback { get; set; }
        public virtual DbSet<Support> tbSupport { get; set; }
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
            /*----------------------------------
            Init User Data
            -----------------------------------*/
            List<User> userList = new List<User>
            {
                new User { UID = "ST1099153", Name="Vu Van Ninh", Password="123", Class="T1.1803.M1", isActive=true },
                new User { UID = "ST1093700", Name="Vo Duy Cuong", Password="123", Class="T1.1803.M1" },
                new User { UID = "ST1098850", Name="Pham Phuong Nam", Password="123", Class="T1.1803.M1" },
                new User { UID = "ST1098221", Name="Pham Tan Nam Thanh", Password="123", Class="T1.1803.M1" }
            };

            userList.ForEach(item => context.tbUser.Add(item));

            /*----------------------------------
            Init Survey Data
            -----------------------------------*/
            List<Survey> surveyList = new List<Survey>
            {
                new Survey {Name="Lorem ipsum dolor sit amet", Content="Abc Abc Abc Abc. Abc Abc Abc Abc. ", Participants="Student", NumOfParticipants=10, StartDate = new DateTime(2019,2,9), EndDate = new DateTime(2019,9,9), CreateDate = new DateTime(2019,1,9) },

                new Survey {Name="Consectetur adipiscing", Content="Abc Abc Abc Abc. Abc Abc Abc Abc. ", Participants="All",NumOfParticipants=11, StartDate = new DateTime(2019,2,9),EndDate = new DateTime(2019,9,9), CreateDate = new DateTime(2019,1,9) },

                new Survey {Name="Ut enim ad minim veniam", Content="Abc Abc Abc Abc. Abc Abc Abc Abc. ", Participants="Faculty/Staff", NumOfParticipants=12, StartDate = new DateTime(2019,2,9),EndDate = new DateTime(2019,9,9), CreateDate = new DateTime(2019,1,9) },

                new Survey {Name="Quis nostrud exercitation", Content="Abc Abc Abc Abc. Abc Abc Abc Abc. ", Participants="Student", NumOfParticipants=13, StartDate = new DateTime(2019,2,9), EndDate = new DateTime(2019,9,9), CreateDate = new DateTime(2019,1,9) }
            };

            surveyList.ForEach(item => context.tbSurvey.Add(item));

            /*----------------------------------
            Init Prize Data
            -----------------------------------*/
            List<Prize> prizeList = new List<Prize>
            {
                new Prize{PrizeID=1,UserID="ST1098221",StudentName="Pham Tan Nam Thanh",SurveyID=1,SurveyName="Survey 1"},
                new Prize{PrizeID=1,UserID="ST1098221",StudentName="Pham Phuong Nam",SurveyID=2,SurveyName="Survey 2"},
                new Prize{PrizeID=1,UserID="ST1098221",StudentName="Pham Tan Nam Thanh",SurveyID=3,SurveyName="Survey 3"},
            };

            prizeList.ForEach(item => context.tbPrize.Add(item));

            /*----------------------------------
            Init Support Data
            -----------------------------------*/
            List<Support> supportList = new List<Support>
            {
                new Support{ Address = "590 CMT8, Ward 11, County 3, Ho Chi Minh 723564"
                    , Email ="aptech.hcm@fpt.com.vn", Phone="02838460846", Website="http://aptech.fpt.edu.vn/"
                }

            };
            supportList.ForEach(item => context.tbSupport.Add(item));
            context.SaveChanges();
        }
    }
}
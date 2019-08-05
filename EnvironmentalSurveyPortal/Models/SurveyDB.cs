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
        public virtual DbSet<SurveyQuestion> tbQuestion { get; set; }
        public virtual DbSet<SurveyAnswer> tbAnswer { get; set; }
        public virtual DbSet<Prize> tbPrize { get; set; }
        public virtual DbSet<Feedback> tbFeedback { get; set; }
        public virtual DbSet<FeedbackAnswer> tbFeedbackAnswer { get; set; }
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
                new Survey {
                    Name ="The Formosa Environmental Disaster",
                    For ="Student",
                    StartDate = new DateTime(2019,2,9),
                    EndDate = new DateTime(2019,9,9),
                    Image ="/Images/news-img1.jpg" },

                new Survey {Name="Consectetur adipiscing", For="All", StartDate = new DateTime(2019,2,9),EndDate = new DateTime(2019,9,9), CreateDate = new DateTime(2019,1,9), Image="/Images/news-img1.jpg" },

                new Survey {Name="Ut enim ad minim veniam", For="Faculty/Staff", StartDate = new DateTime(2019,2,9),EndDate = new DateTime(2019,9,9), CreateDate = new DateTime(2019,2,9), Image="/Images/news-img1.jpg" },

                new Survey {Name="Quis nostrud exercitation", For="Student", StartDate = new DateTime(2019,2,9), EndDate = new DateTime(2019,9,9), CreateDate = new DateTime(2019,3,9), Image="/Images/news-img1.jpg" },

                new Survey {Name="Lorem ipsum dolor sit amet", For="Student", StartDate = new DateTime(2019,2,9), EndDate = new DateTime(2019,9,9), CreateDate = new DateTime(2019,4,9), Image="/Images/news-img1.jpg" },

                new Survey {Name="Consectetur adipiscing", For="All", StartDate = new DateTime(2019,2,9),EndDate = new DateTime(2019,9,9), CreateDate = new DateTime(2019,5,9), Image="/Images/news-img1.jpg" },

                new Survey {Name="Ut enim ad minim veniam", For="Faculty/Staff", StartDate = new DateTime(2019,2,9),EndDate = new DateTime(2019,9,9), CreateDate = new DateTime(2019,6,9), Image="/Images/news-img1.jpg" },

                new Survey {Name="Quis nostrud exercitation", For="Student", StartDate = new DateTime(2019,2,9), EndDate = new DateTime(2019,9,9), CreateDate = new DateTime(2019,7,9), Image="/Images/news-img1.jpg" }
            };

            surveyList.ForEach(item => context.tbSurvey.Add(item));

            /*----------------------------------
            Init Questions Data
            -----------------------------------*/
            List<SurveyQuestion> questionList = new List<SurveyQuestion>
            {
                new SurveyQuestion { Content=" How concerned are you about air pollution?", Survey=surveyList[0] },
                new SurveyQuestion { Content="How concerned are you about the extinction of endangered animals?", Survey=surveyList[0] },
                new SurveyQuestion { Content="Should the United States government's laws restricting pollution be more strict, less strict, or about as strict as they are now?", Survey=surveyList[0] },
                new SurveyQuestion { Content="The term 'global warming' is often used to refer to the idea that the world's average temperature may be about 5 degrees Fahrenheit higher in 75 years than it is now. Do you think global warming is good or bad?", Survey=surveyList[0] }
            };

            questionList.ForEach(item => context.tbQuestion.Add(item));

            /*----------------------------------
            Init Answers Data
            -----------------------------------*/
            List<SurveyAnswer> answerList = new List<SurveyAnswer>
            {
                new SurveyAnswer { Content="Extremely concerned", Question=questionList[0] },
                new SurveyAnswer { Content="Very concerned", Question=questionList[0] },
                new SurveyAnswer { Content="Moderately concerned", Question=questionList[0] },
                new SurveyAnswer { Content="Slightly concerned", Question=questionList[0] },
                new SurveyAnswer { Content="Not at all concerned", Question=questionList[0] },

                new SurveyAnswer { Content="Extremely concerned", Question=questionList[1] },
                new SurveyAnswer { Content="Very concerned", Question=questionList[1] },
                new SurveyAnswer { Content="Moderately concerned", Question=questionList[1] },
                new SurveyAnswer { Content="Slightly concerned", Question=questionList[1] },
                new SurveyAnswer { Content="Not at all concerned", Question=questionList[1] },

                new SurveyAnswer { Content="Much more strict", Question=questionList[2] },
                new SurveyAnswer { Content="Somewhat more strict", Question=questionList[2] },
                new SurveyAnswer { Content="Slightly less strict", Question=questionList[2] },
                new SurveyAnswer { Content="Slightly more strict", Question=questionList[2] },
                new SurveyAnswer { Content="Somewhat less strict", Question=questionList[2] },
                new SurveyAnswer { Content="Much less strict", Question=questionList[2] },
                new SurveyAnswer { Content="About as strict as they are now", Question=questionList[2] },

                new SurveyAnswer { Content="Very good", Question=questionList[3] },
                new SurveyAnswer { Content="Good", Question=questionList[3] },
                new SurveyAnswer { Content="Neither good nor bad", Question=questionList[3] },
                new SurveyAnswer { Content="Bad", Question=questionList[3] },
                new SurveyAnswer { Content="Very Bad", Question=questionList[3] },
            };

            answerList.ForEach(item => context.tbAnswer.Add(item));

            /*----------------------------------
            Init Feedback Data
            -----------------------------------*/
            List<Feedback> feedbackList = new List<Feedback>
            {
                new Feedback {
                    User = userList[0],
                    Survey =surveyList[0],
                    Answers=new List<FeedbackAnswer>
                    {
                        new FeedbackAnswer { Question=questionList[0], Answer=answerList[0] },
                        new FeedbackAnswer { Question=questionList[1], Answer=answerList[7] },
                        new FeedbackAnswer { Question=questionList[2], Answer=answerList[12] },
                        new FeedbackAnswer { Question=questionList[3], Answer=answerList[18] }
                    }
                }
            };

            feedbackList.ForEach(item => context.tbFeedback.Add(item));

            /*----------------------------------
            Init Prize Data
            -----------------------------------*/
            List<Prize> prizeList = new List<Prize>
            {
                new Prize{User=userList[0], Survey=surveyList[0]},
                new Prize{User=userList[1], Survey=surveyList[1]},
                new Prize{User=userList[2], Survey=surveyList[2]}
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
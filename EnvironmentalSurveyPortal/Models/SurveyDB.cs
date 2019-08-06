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
        public virtual DbSet<Competition> tbCompetition { get; set; }
        public virtual DbSet<Post> tbPost { get; set; }
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

    public class DBInit : DropCreateDatabaseAlways<SurveyDB>
    {
        protected override void Seed(SurveyDB context)
        {
            /*----------------------------------
            Init User Data
            -----------------------------------*/
            List<User> userList = new List<User>
            {
                new User { UID = "admin", Name="Adminstrator", Password="123", Role="Admin", isActive=true },
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
               new Survey { Name ="Survey Demo One", For ="Student", StartDate = new DateTime(2019,2,9), EndDate = new DateTime(2019,9,9), Image ="/Images/news-img1.jpg" },

               new Survey {Name="Survey Demo Two", For="Faculty/Staff", StartDate = new DateTime(2018,2,9),EndDate = new DateTime(2018,9,9), CreateDate = new DateTime(2019,1,9), Image="/Images/news-img1.jpg" },

               new Survey {Name="Survey Demo Three", For="Student", StartDate = new DateTime(2018,1,10),EndDate = new DateTime(2018,9,9), CreateDate = new DateTime(2018,12,10), Image="/Images/news-img1.jpg" },

               new Survey {Name="Survey Demo Four", For="Faculty/Staff", StartDate = new DateTime(2019,1,1),EndDate = new DateTime(2019,8,1), CreateDate = new DateTime(2018,12,10), Image="/Images/news-img1.jpg" },

               new Survey {Name="Survey Demo Five", For="Student", StartDate = new DateTime(2019,6,1),EndDate = new DateTime(2019,10,1), CreateDate = new DateTime(2018,12,10), Image="/Images/news-img1.jpg" }
            };

            surveyList.ForEach(item => context.tbSurvey.Add(item));

            /*----------------------------------
            Init Questions Data
            -----------------------------------*/
            List<SurveyQuestion> questionList = new List<SurveyQuestion>
            {
                new SurveyQuestion { Content="How concerned are you about air pollution?", Survey=surveyList[0] },
                new SurveyQuestion { Content="How concerned are you about the extinction of endangered animals?", Survey=surveyList[0] },
                new SurveyQuestion { Content="Should the United States government's laws restricting pollution be more strict, less strict, or about as strict as they are now?", Survey=surveyList[0] },
                new SurveyQuestion { Content="The term 'global warming' is often used to refer to the idea that the world's average temperature may be about 5 degrees Fahrenheit higher in 75 years than it is now. Do you think global warming is good or bad?", Survey=surveyList[0] },

                new SurveyQuestion { Content="Is the United States government spending too much time trying to reduce global warming, too little time, or about the right amount of time?", Survey=surveyList[1] },
                new SurveyQuestion { Content="Is reducing global warming more important than improving the economy, less important than improving the economy, or about as important as improving the economy?", Survey=surveyList[1] },
                new SurveyQuestion { Content="When people get involved in trying to solve environmental problems, how often do you think they make things better?", Survey=surveyList[1] },
                new SurveyQuestion { Content="How well do you think the environment can recover on its own from problems caused by humans?", Survey=surveyList[1] },
                new SurveyQuestion { Content="How safe would you feel if a nuclear energy plant were built near where you live?", Survey=surveyList[1] },

                new SurveyQuestion { Content="Which of the following alternative energy sources do you think will be MOST important in the next 10 years?", Survey=surveyList[2] },
                new SurveyQuestion { Content="Should the government provide more money or less money to support alternative energy?", Survey=surveyList[2] },
                new SurveyQuestion { Content="How often do you recycle?", Survey=surveyList[2] },
                new SurveyQuestion { Content="How willing are you to change your lifestyle to reduce the damage you cause to the environment?", Survey=surveyList[2] },
                new SurveyQuestion { Content="How likely are you to buy a more expensive product if its packaging is more environmentally-friendly than its competitor's product?", Survey=surveyList[2] },

                new SurveyQuestion { Content="Which of the following do you feel is the worst environmental problem facing the planet?", Survey=surveyList[3] },
                new SurveyQuestion { Content="Who are the worst polluters?", Survey=surveyList[3] },
                new SurveyQuestion { Content="Who should be responsible for making sure we have a healthy environment?", Survey=surveyList[3] },
                new SurveyQuestion { Content="Given the current concern about the environment, how would you describe your future?", Survey=surveyList[3] },
                new SurveyQuestion { Content="The single most important thing that will make sure the environment is healthy for future generations is if:", Survey=surveyList[3] },

                new SurveyQuestion { Content="How concerned are you about preservation?", Survey=surveyList[4] },
                new SurveyQuestion { Content="How often do you recycle?", Survey=surveyList[4] },
                new SurveyQuestion { Content="Which source of alternative energy sounds the most promising?", Survey=surveyList[4] },
                new SurveyQuestion { Content="What is the state of environmental laws in your country?", Survey=surveyList[4] },
                new SurveyQuestion { Content="Are you satisfied with the environmental laws in your country?", Survey=surveyList[4] }


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

                new SurveyAnswer { Content="Much too much", Question=questionList[4] },
                new SurveyAnswer { Content="Slightly too little", Question=questionList[4] },
                new SurveyAnswer { Content="Somewhat too much", Question=questionList[4] },
                new SurveyAnswer { Content="Somewhat too little", Question=questionList[4] },
                new SurveyAnswer { Content="Slightly too much", Question=questionList[4] },
                new SurveyAnswer { Content="Much too little", Question=questionList[4] },
                new SurveyAnswer { Content="About the right amount", Question=questionList[4] },

                new SurveyAnswer { Content="Much more important", Question=questionList[5] },
                new SurveyAnswer { Content="Somewhat less important", Question=questionList[5] },
                new SurveyAnswer { Content="Somewhat more important", Question=questionList[5] },
                new SurveyAnswer { Content="Much less important", Question=questionList[5] },
                new SurveyAnswer { Content="About as important", Question=questionList[5] },

                new SurveyAnswer { Content="Always", Question=questionList[6] },
                new SurveyAnswer { Content="Once in a while", Question=questionList[6] },
                new SurveyAnswer { Content="Most of the time", Question=questionList[6] },
                new SurveyAnswer { Content="Never", Question=questionList[6] },
                new SurveyAnswer { Content="About half the time", Question=questionList[6] },

                new SurveyAnswer { Content="Extremely well", Question=questionList[7] },
                new SurveyAnswer { Content="Not so well", Question=questionList[7] },
                new SurveyAnswer { Content="Very well", Question=questionList[7] },
                new SurveyAnswer { Content="Not at all well", Question=questionList[7] },
                new SurveyAnswer { Content="Somewhat well", Question=questionList[7] },

                new SurveyAnswer { Content="Extremely safe", Question=questionList[8] },
                new SurveyAnswer { Content="Slightly safe", Question=questionList[8] },
                new SurveyAnswer { Content="Very safe", Question=questionList[8] },
                new SurveyAnswer { Content="Not at all safe", Question=questionList[8] },
                new SurveyAnswer { Content="Moderately safe", Question=questionList[8] },

                new SurveyAnswer { Content="Wind", Question=questionList[9] },
                new SurveyAnswer { Content="Ethanol", Question=questionList[9] },
                new SurveyAnswer { Content="Solar", Question=questionList[9] },
                new SurveyAnswer { Content="Natural gas", Question=questionList[9] },
                new SurveyAnswer { Content="Nuclear", Question=questionList[9] },
                new SurveyAnswer { Content="Coal", Question=questionList[9] },

                new SurveyAnswer { Content="Much more money", Question=questionList[10] },
                new SurveyAnswer { Content="Slightly less money", Question=questionList[10] },
                new SurveyAnswer { Content="Somewhat more money", Question=questionList[10] },
                new SurveyAnswer { Content="Somewhat less money", Question=questionList[10] },
                new SurveyAnswer { Content="Slightly more moneyr", Question=questionList[10] },
                new SurveyAnswer { Content="Much less money", Question=questionList[10] },
                new SurveyAnswer { Content="About the same amount of money", Question=questionList[10] },

                new SurveyAnswer { Content="Always", Question=questionList[11] },
                new SurveyAnswer { Content="Once in a while", Question=questionList[11] },
                new SurveyAnswer { Content="Most of the time", Question=questionList[11] },
                new SurveyAnswer { Content="Never", Question=questionList[11] },
                new SurveyAnswer { Content="About half the time", Question=questionList[11] },

                new SurveyAnswer { Content="Extremely willing", Question=questionList[12] },
                new SurveyAnswer { Content="Not so willing", Question=questionList[12] },
                new SurveyAnswer { Content="Very willing", Question=questionList[12] },
                new SurveyAnswer { Content="Not at all willing", Question=questionList[12] },
                new SurveyAnswer { Content="Somewhat willing", Question=questionList[12] },

                new SurveyAnswer { Content="Extremely likely", Question=questionList[13] },
                new SurveyAnswer { Content="Slightly likely", Question=questionList[13] },
                new SurveyAnswer { Content="Very likely", Question=questionList[13] },
                new SurveyAnswer { Content="Not at all likely", Question=questionList[13] },
                new SurveyAnswer { Content="Moderately likely", Question=questionList[13] },

                new SurveyAnswer { Content="Ozone depletion", Question=questionList[14] },
                new SurveyAnswer { Content="Toxic waste", Question=questionList[14] },
                new SurveyAnswer { Content="Global wanning", Question=questionList[14] },
                new SurveyAnswer { Content="Water pollution", Question=questionList[14] },
                new SurveyAnswer { Content="Air pollution", Question=questionList[14] },
                new SurveyAnswer { Content="Deforestation", Question=questionList[14] },

                new SurveyAnswer { Content="Industries", Question=questionList[15] },
                new SurveyAnswer { Content="Governments", Question=questionList[15] },
                new SurveyAnswer { Content="Individual people", Question=questionList[15] },

                new SurveyAnswer { Content="Industry", Question=questionList[16] },
                new SurveyAnswer { Content="Government", Question=questionList[16] },
                new SurveyAnswer { Content="Environmental groups", Question=questionList[16] },
                new SurveyAnswer { Content="Individuals", Question=questionList[16] },

                new SurveyAnswer { Content="Bright and hopeful", Question=questionList[17] },
                new SurveyAnswer { Content="Challenging", Question=questionList[17] },
                new SurveyAnswer { Content="Depressing", Question=questionList[17] },
                new SurveyAnswer { Content="Uncertain", Question=questionList[17] },

                new SurveyAnswer { Content="The polluting industries shut down, even if people lose their jobs", Question=questionList[18] },
                new SurveyAnswer { Content="New technologies can be found to solve our problems", Question=questionList[18] },
                new SurveyAnswer { Content="People learn to live with less and be more efficient users of energy and materials", Question=questionList[18] },
                new SurveyAnswer { Content="We find a way to have economic development continue in a way that minimizes pollution", Question=questionList[18] },

                new SurveyAnswer { Content="Not at all", Question=questionList[19] },
                new SurveyAnswer { Content="Slightly", Question=questionList[19] },
                new SurveyAnswer { Content="Moderately", Question=questionList[19] },
                new SurveyAnswer { Content="Very", Question=questionList[19] },
                new SurveyAnswer { Content="Extremely", Question=questionList[19] },

                new SurveyAnswer { Content="Never", Question=questionList[20] },
                new SurveyAnswer { Content="Rarely", Question=questionList[20] },
                new SurveyAnswer { Content="Monthly", Question=questionList[20] },
                new SurveyAnswer { Content="Weekly", Question=questionList[20] },
                new SurveyAnswer { Content="Daily", Question=questionList[20] },

                new SurveyAnswer { Content="Wind", Question=questionList[21] },
                new SurveyAnswer { Content="Solar", Question=questionList[21] },
                new SurveyAnswer { Content="Nuclear", Question=questionList[21] },
                new SurveyAnswer { Content="Ethanol", Question=questionList[21] },
                new SurveyAnswer { Content="Natural gas", Question=questionList[21] },
                new SurveyAnswer { Content="Coal", Question=questionList[21] },
                new SurveyAnswer { Content="Other", Question=questionList[21] },

                new SurveyAnswer { Content="Unsatisfactory", Question=questionList[22] },
                new SurveyAnswer { Content="Poor", Question=questionList[22] },
                new SurveyAnswer { Content="Fair", Question=questionList[22] },
                new SurveyAnswer { Content="Good", Question=questionList[22] },
                new SurveyAnswer { Content="Excellent", Question=questionList[22] },

                new SurveyAnswer { Content="Very dissatisfied", Question=questionList[23] },
                new SurveyAnswer { Content="Dissatisfied", Question=questionList[23] },
                new SurveyAnswer { Content="Neutral", Question=questionList[23] },
                new SurveyAnswer { Content="Satisfied", Question=questionList[23] },
                new SurveyAnswer { Content="Very satisfied", Question=questionList[23] }
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
            Init Competition Data
            -----------------------------------*/
            List<Competition> competitionList = new List<Competition>
            {
                new Competition { Name="Competition Demo One", Content="This i an content", For="Student", StartDate=new DateTime(2019,8,5), EndDate=new DateTime(2019,8,20), Image="/Images/news-img1.jpg" },
                new Competition { Name="Competition Demo Two", Content="This i an content", For="Faculty/Staff", StartDate=new DateTime(2019,8,5), EndDate=new DateTime(2019,8,20), Image="/Images/news-img1.jpg" },
                new Competition { Name="Competition Demo Three", Content="This i an content", For="Student", StartDate=new DateTime(2019,8,5), EndDate=new DateTime(2019,8,20), Image="/Images/news-img1.jpg" },
            };

            competitionList.ForEach(item => context.tbCompetition.Add(item));

            /*----------------------------------
            Init Prize Data
            -----------------------------------*/
            List<Prize> prizeList = new List<Prize>
            {
                new Prize{User=userList[0], Competition=competitionList[0]},
                new Prize{User=userList[1], Competition=competitionList[0]},
                new Prize{User=userList[2], Competition=competitionList[0]},

                new Prize{User=userList[0], Competition=competitionList[1]},
                new Prize{User=userList[1], Competition=competitionList[1]},
                new Prize{User=userList[2], Competition=competitionList[1]},

                new Prize{User=userList[0], Competition=competitionList[2]},
                new Prize{User=userList[1], Competition=competitionList[2]},
                new Prize{User=userList[2], Competition=competitionList[2]}
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
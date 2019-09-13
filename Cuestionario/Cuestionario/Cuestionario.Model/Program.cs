using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using System.Net.Http;

namespace Cuestionario.Model
{
    class Program
    {
        static HttpClient client = new HttpClient();
        //static async Task<RootObject> GetQuestionsAsync(string path)
        //{
        //    RootObject question = null;
        //    HttpResponseMessage response = await client.GetAsync(path);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        question = await response.Content.ReadAsAsync<RootObject>();
        //    }

        //    return question;
        //}
        static void Main(string[] args)
        {
            //Task<RootObject> q = GetQuestionsAsync("https://opentdb.com/api.php?amount=10");

            var sessionFactory = NHibernateHelper.CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                //using (var transaction = session.BeginTransaction())
                //{
                //    //Prueba de alta

                //    Category pCategory = new Category { Description = "prueba" };
                //    session.Save(pCategory);

                //    Difficulty pDifficulty = new Difficulty { Description = "prueba" };
                //    session.Save(pDifficulty);

                //    Question pQuestion = new Question { Description = "prueba", Category = pCategory, Difficulty = pDifficulty };
                //    session.Save(pQuestion);

                //    Answer pAnswer = new Answer { Description = "prueba", Question = pQuestion, Correct = true };
                //    session.Save(pAnswer);

                //    AnswerSession pAnswerSession = new AnswerSession { Username = "prueba", AnswerTime = 20, Category = pCategory, Date = DateTime.Now.Date, Difficulty = pDifficulty, Score = 10 };
                //    session.Save(pAnswerSession);

                //    UserAnswer pUserAnswer = new UserAnswer { AnswerSession = pAnswerSession, AnswerStatus = true, ChosenAnswer = pAnswer, Question = pQuestion };
                //    session.Save(pUserAnswer);

                //    session.Transaction.Commit();

                //    Console.Write("FIN de alta");
                //    Console.ReadKey();   
                //}

                //Prueba de consulta
                //using (session.BeginTransaction())
                //{
                //    IList<Category> categories =
                //        session.Query<Category>()
                //            .ToList();

                //    IList<Difficulty> difficulties =
                //        session.Query<Difficulty>()
                //            .ToList();

                //    IList<Question> questions =
                //        session.Query<Question>()
                //            .ToList();

                //    IList<Answer> answers =
                //        session.Query<Answer>()
                //            .ToList();

                //    IList<AnswerSession> answerSessions =
                //        session.Query<AnswerSession>()
                //            .ToList();

                //    IList<UserAnswer> userAnswers =
                //        session.Query<UserAnswer>()
                //            .ToList();

                //    Console.Write("FIN de consulta");
                //    Console.ReadKey();
                //}
            }
        }
    }
}


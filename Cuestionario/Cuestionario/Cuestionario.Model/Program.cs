using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;

namespace Cuestionario.Model
{
    class Program
    {
        static void Main(string[] args)
        {
            var sessionFactory = NHibernateHelper.CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    //Prueba de alta

                    {
                        Category pCategory = new Category { Description = "prueba" };
                        session.Save(pCategory);

                        Difficulty pDifficulty = new Difficulty { Description = "prueba" };
                        session.Save(pDifficulty);

                        Question pQuestion = new Question { Description = "prueba", Category = pCategory, Difficulty = pDifficulty };
                        session.Save(pQuestion);

                        Answer pAnswer = new Answer { Description = "prueba", Question = pQuestion, Correct = true };
                        session.Save(pAnswer);

                        AnswerSession pAnswerSession = new AnswerSession { Username = "prueba", AnswerTime = 20, Category = pCategory, Date = DateTime.Now.Date, Difficulty = pDifficulty, Score = 10 };
                        session.Save(pAnswerSession);

                        UserAnswer pUserAnswer = new UserAnswer { AnswerSession = pAnswerSession, AnswerStatus = true, ChosenAnswer = pAnswer, Question = pQuestion };
                        session.Save(pUserAnswer);

                        session.Transaction.Commit();

                        Console.Write("FIN de alta");
                        Console.ReadKey();
                    }

                    //Prueba de consulta
                    //using (session.BeginTransaction())
                    //{
                    //    IList<Category> categories =

                    //        session.Query<Category>()
                    //            .FetchMany(c => c.Questions)
                    //            .Where(c => c.Description == "prueba")
                    //            .ToList();

                    //IList<Answer> answers =

                    //    session.Query<Answer>()

                    //        .Where(c => c.Description == "prueba")
                    //        .ToList();

                    //Console.Write("FIN de consulta");
                      //  Console.ReadKey();
                    }
                }
            }            
        }
    }

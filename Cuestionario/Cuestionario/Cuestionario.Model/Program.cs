using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace Cuestionario.Model
{
    class Program
    {
        static void Main(string[] args)
        {
            ISession session = NHibernateHelper.GetCurrentSession();

            using (session.BeginTransaction())
            {
                UserAnswer aux = new UserAnswer { pQuestionId = 1, pAnswerSessionId = 1, pAnswerStatus = false, pChosenAnswerId = 1};
                session.Save(aux);

                session.Transaction.Commit();
            }
            Console.Write("FIN");
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.Model;
using Cuestionario.Services.DTO;
using NHibernate;
using Cuestionario.Services.Interfaces;

namespace Cuestionario.Services
{
    public class QuestionServices : IQuestionServices
    {
        private ISession iSession;

        private ICategoryServices iCategoryServices;

        private IDifficultyServices iDifficultyServices;

        public QuestionServices(
            ISession pSession,
            ICategoryServices pCategoryServices,
            IDifficultyServices pDifficcultyServices)
        {
            iSession = pSession;
            iCategoryServices = pCategoryServices;
            iDifficultyServices = pDifficcultyServices;
        }

        public Question Create(QuestionCreationData pQuestionData)
        {
            Answer CreateAnswer(AnswerCreationData pAnswerCreationData)
            {
                var lAnswer = new Answer
                {
                    Description = pAnswerCreationData.Description,
                };

                return lAnswer;
            }

            var lCategory = iCategoryServices.GetById(pQuestionData.Category.Id);

            var lDifficulty = iDifficultyServices.GetById(pQuestionData.Difficulty.Id);

            Question lQuestion = new Question
            {
                Description = pQuestionData.Description,
                Category = lCategory,
                Difficulty = lDifficulty,
                QuestionType = pQuestionData.QuestionType,
            };
            
            iSession.Save(lQuestion);

            var lCorrectAnswer = CreateAnswer(pQuestionData.CorrectAnswer);

            lQuestion.CorrectAnswer = lCorrectAnswer;

            foreach (var lAnswerData in pQuestionData.Answers.Where(x => x != pQuestionData.CorrectAnswer))
            {
                var lAnswer = CreateAnswer(lAnswerData);
                lQuestion.AddAnswer(lAnswer);
            }

            iSession.Save(lQuestion);

            return lQuestion;
        }

        public void Delete(long pId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Question> GetAll()
        {
            IQueryable<Question> lQuestions =
                iSession.Query<Question>();

            return lQuestions;
        }         

        public Question GetById(long pQuestionId)
        {
            var lQuestion = GetAll()
                .FirstOrDefault(x => x.Id == pQuestionId);

            if (lQuestion == null)
            {
                throw new ArgumentException($"Question with Id {pQuestionId} was not found");
            }

            return lQuestion;
        }

        public Question Update(long pId, QuestionData pUpdateQuestion)
        {
            throw new NotImplementedException();
        }


        public Answer GetAnswerById(long pAnswerId)
        {
            var lAnswer = iSession.Query<Answer>()
                .FirstOrDefault(x => x.Id == pAnswerId);

            if (lAnswer == null)
            {
                throw new ArgumentException($"Answer with Id {lAnswer} was not found");
            }

            return lAnswer;
        }

        public IList<Question> GetQuestionsForSession(AnswerSessionStartData pAnswerSessionStartData)
        {
            var lQuestions = this.GetAll()
               .Where(x => x.Category == iCategoryServices.GetById(pAnswerSessionStartData.CategoryId))
               .Where(x => x.Difficulty == iDifficultyServices.GetById(pAnswerSessionStartData.DifficultyId)); //esto creo se puede escribir de otra manera

            Random lRandomNumber = new Random();
            int lQuestionIndex;
            var lSessionQuestions = new List<Question>();

            if (lQuestions.Count() < pAnswerSessionStartData.QuestionsCount)
            {
                while (lSessionQuestions.Count < lQuestions.Count())
                {
                    lQuestionIndex = lRandomNumber.Next(lQuestions.Count());
                    if (!lSessionQuestions.Contains(lQuestions.ToList().ElementAt(lQuestionIndex)))
                    {
                        lSessionQuestions.Add(lQuestions.ToList().ElementAt(lQuestionIndex));
                    }
                }
            }
            else
            {
                while (lSessionQuestions.Count < pAnswerSessionStartData.QuestionsCount)
                {
                    lQuestionIndex = lRandomNumber.Next(pAnswerSessionStartData.QuestionsCount);
                    if (!lSessionQuestions.Contains(lQuestions.ToList().ElementAt(lQuestionIndex)))
                    {
                        lSessionQuestions.Add(lQuestions.ToList().ElementAt(lQuestionIndex));
                    }
                }
            }

            return lSessionQuestions;
        }
    }
}

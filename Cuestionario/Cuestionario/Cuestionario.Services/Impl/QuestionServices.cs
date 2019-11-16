using Questionnaire.Model;
using Questionnaire.Persistence.Repository;
using Questionnaire.Services.DTO;
using Questionnaire.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire.Services.Impl
{
    public class QuestionServices : IQuestionServices
    {
        private readonly IRepository<Question> iQuestionRepository;
        private readonly IRepository<Answer> iAnswerRepository;
        private readonly ICategoryServices iCategoryServices;
        private readonly IDifficultyServices iDifficultyServices;

        public QuestionServices(
            IRepository<Question> pQuestionRepository,
            IRepository<Answer> pAnswerRepository,
            ICategoryServices pCategoryServices,
            IDifficultyServices pDifficcultyServices)
        {
            this.iQuestionRepository = pQuestionRepository;
            this.iAnswerRepository = pAnswerRepository;
            this.iCategoryServices = pCategoryServices;
            this.iDifficultyServices = pDifficcultyServices;
        }

        public async Task<Question> CreateAsync(QuestionCreationData pQuestionData)
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

            var lQuestion = new Question
            {
                Description = pQuestionData.Description,
                Category = lCategory,
                Difficulty = lDifficulty,
                QuestionType = pQuestionData.QuestionType,
            };
            

            lQuestion.CorrectAnswer = CreateAnswer(pQuestionData.CorrectAnswer);
            await this.iQuestionRepository.AddAsync(lQuestion);

            foreach (var lAnswerData in pQuestionData.Answers.Where(x => x != pQuestionData.CorrectAnswer))
            {
                var lAnswer = CreateAnswer(lAnswerData);
                lQuestion.AddAnswer(lAnswer);
            }

            await this.iQuestionRepository.UpdateAsync(lQuestion);

            return lQuestion;
        }

        public void Delete(long pId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Question> GetAll()
        {
            // TODO RAR: IQueryables should be gone...
            return this.iQuestionRepository.GetAll();
        }         

        public async Task<Question> GetByIdAsync(long pQuestionId)
        {
            var lQuestion = await this.iQuestionRepository.GetByIdAsync(pQuestionId);

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

        public async Task<Answer> GetAnswerByIdAsync(long pAnswerId)
        {
            var lAnswer = await this.iAnswerRepository.GetByIdAsync(pAnswerId);

            if (lAnswer == null)
            {
                throw new ArgumentException($"Answer with Id {lAnswer} was not found");
            }

            return lAnswer;
        }

        public IList<Question> GetQuestionsForSession(AnswerSessionStartData pAnswerSessionStartData)
        {
            var lQuestions = this.GetAll()
               .Where(x => x.Category.Id == pAnswerSessionStartData.CategoryId)
               .Where(x => x.Difficulty.Id == pAnswerSessionStartData.DifficultyId);

            var lRandomNumber = new Random();
            int lQuestionIndex;
            var lSessionQuestions = new List<Question>();

            // TODO RAR this has to be rewritten, we are potentially hitting the DB many many times.
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

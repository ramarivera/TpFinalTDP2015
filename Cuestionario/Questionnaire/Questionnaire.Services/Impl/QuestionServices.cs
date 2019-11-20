using Questionnaire.Model;
using Questionnaire.Persistence.Repository;
using Questionnaire.Services.DTO;
using Questionnaire.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Questionnaire.Services.Impl
{
    /// <summary>
    /// Contains all business logic related to <see cref="Question"/> model class
    /// </summary>
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

        /// <summary>
        /// Creates a new <see cref="Question"/>, and its asociated <see cref="Answer"/>, that will be stored in the database
        /// </summary>
        /// <param name="pQuestionData">New <see cref="Question"/> data</param>
        /// <returns>Created <see cref="Question"/></returns>
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

            var lQuestion = new Question
            {
                Description = pQuestionData.Description,
                Category = lCategory,
                Difficulty = lDifficulty,
                QuestionType = pQuestionData.QuestionType,
            };
            
            this.iQuestionRepository.Add(lQuestion);

            lQuestion.CorrectAnswer = CreateAnswer(pQuestionData.CorrectAnswer);

            foreach (var lAnswerData in pQuestionData.Answers.Where(x => x != pQuestionData.CorrectAnswer))
            {
                var lAnswer = CreateAnswer(lAnswerData);
                lQuestion.AddAnswer(lAnswer);
            }

            this.iQuestionRepository.Update(lQuestion);

            return lQuestion;
        }

        public void Delete(long pId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all stored <see cref="Question"/>
        /// </summary>
        /// <returns>A list of <see cref="Question"/></returns>
        public IEnumerable<Question> GetAll()
        {
            return this.iQuestionRepository.GetAll();
        }

        /// <summary>
        /// Gets a specific <see cref="Question"/>
        /// </summary>
        /// <param name="pQuestionId">Specific <see cref="Question"/> Id</param>
        /// <returns>A <see cref="Question"/></returns>
        public Question GetById(long pQuestionId)
        {
            var lQuestion = this.iQuestionRepository.GetById(pQuestionId);

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

        /// <summary>
        /// Gets a specific <see cref="Answer"/>
        /// </summary>
        /// <param name="pQuestionId">Specific <see cref="Answer"/> Id</param>
        /// <returns>An <see cref="Answer"/></returns>
        public Answer GetAnswerById(long pAnswerId)
        {
            var lAnswer = this.iAnswerRepository.GetById(pAnswerId);

            if (lAnswer == null)
            {
                throw new ArgumentException($"Answer with Id {lAnswer} was not found");
            }

            return lAnswer;
        }

        /// <summary>
        /// Gets a list of <see cref="Question"/> for Questionnaire's <see cref="AnswerSession"/>, according its data
        /// </summary>
        /// <param name="pAnswerSessionStartData"> <see cref="AnswerSession"/> data</param>
        /// <returns>A list of <see cref="Question"/> according <see cref="AnswerSession"/> data</returns>
        public IList<Question> GetQuestionsForSession(AnswerSessionStartData pAnswerSessionStartData)
        {
            var lQuestions = this.GetAll()
               .Where(x => x.Category.Id == pAnswerSessionStartData.CategoryId).ToList()
               .Where(x => x.Difficulty.Id == pAnswerSessionStartData.DifficultyId).ToList();

            var lRandomNumber = new Random();
            int lQuestionIndex;
            var lSessionQuestions = new List<Question>();

            // TODO this algorithm might be reviewed
            if (lQuestions.Count() < pAnswerSessionStartData.QuestionsCount)
            {
                while (lSessionQuestions.Count < lQuestions.Count())
                {
                    lQuestionIndex = lRandomNumber.Next(lQuestions.Count());
                    
                    if (!lSessionQuestions.Contains(lQuestions.ElementAt(lQuestionIndex)))
                    {
                        lSessionQuestions.Add(lQuestions.ElementAt(lQuestionIndex));
                    }
                }
            }
            else
            {
                while (lSessionQuestions.Count < pAnswerSessionStartData.QuestionsCount)
                {
                    lQuestionIndex = lRandomNumber.Next(pAnswerSessionStartData.QuestionsCount);

                    if (!lSessionQuestions.Contains(lQuestions.ElementAt(lQuestionIndex)))
                    {
                        lSessionQuestions.Add(lQuestions.ElementAt(lQuestionIndex));
                    }
                }
            }

            return lSessionQuestions;
        }
    }
}

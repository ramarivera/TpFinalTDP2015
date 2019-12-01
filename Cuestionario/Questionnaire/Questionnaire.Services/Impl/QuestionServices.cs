using Questionnaire.Model;
using Questionnaire.Persistence.Repository;
using Questionnaire.Services.DTO;
using Questionnaire.Services.Interfaces;
using Questionnaire.Services.Specifications.Questions;
using Questionnaire.Utilities;
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
        /// Creates a new <see cref="Question"/>, and its associated <see cref="Answer"/>, that will be stored in the database
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
                Source = pQuestionData.Source
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

        /// <summary>
        /// Gets all stored <see cref="Question"/>
        /// </summary>
        /// <returns>A list of <see cref="Question"/></returns>
        public IEnumerable<Question> GetAll()
        {
            return this.iQuestionRepository.ToList();
        }

        /// <summary>
        /// Gets a specific <see cref="Question"/>
        /// </summary>
        /// <param name="pQuestionId">Specific <see cref="Question"/> Id</param>
        /// <returns>A <see cref="Question"/></returns>
        public Question GetById(int pQuestionId)
        {
            var lQuestion = this.iQuestionRepository.FindById(pQuestionId);

            if (lQuestion == null)
            {
                throw new ArgumentException($"Question with Id {pQuestionId} was not found");
            }

            return lQuestion;
        }

        /// <summary>
        /// Gets a specific <see cref="Answer"/>
        /// </summary>
        /// <param name="pQuestionId">Specific <see cref="Answer"/> Id</param>
        /// <returns>An <see cref="Answer"/></returns>
        public Answer GetAnswerById(int pAnswerId)
        {
            var lAnswer = this.iAnswerRepository.FindById(pAnswerId);

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
        public IEnumerable<Question> GetQuestionsForSession(AnswerSessionStartData pAnswerSessionStartData)
        {
            var lQuestions = this.iQuestionRepository
                .FindBy(new QuestionsByCategoryAndDifficultySpecification(pAnswerSessionStartData.CategoryId, pAnswerSessionStartData.DifficultyId));

            return lQuestions.Shuffle();
        }
    }
}

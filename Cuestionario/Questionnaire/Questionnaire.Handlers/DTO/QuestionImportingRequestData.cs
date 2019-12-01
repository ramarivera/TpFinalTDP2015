using Questionnaire.Model.Enums;

namespace Questionnaire.Handlers.DTO
{
    public class QuestionImportingRequestData
    {
        public static QuestionImportingRequestData ForSourceAndAmount(QuestionSource pSource, int pAmount)
        {
            return new QuestionImportingRequestData
            {
                Source = pSource,
                Amount = pAmount
            };
        }

        public virtual QuestionSource Source { get; set; }

        public virtual int Amount { get; set; }
    }
}

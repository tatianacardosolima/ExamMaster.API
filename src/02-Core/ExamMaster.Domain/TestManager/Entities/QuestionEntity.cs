using ExamMaster.Shared.Abstractions;

namespace ExamMaster.Domain.TestManager.Entities
{
    public enum QuestionType
    {
        SingleOption,
        MultipleOption
    }
    public class QuestionEntity : EntityBase
    {
        public string QuestionPrompt { get; set; }
        public QuestionType QuestionType { get; set; }

        public IEnumerable<AnswerOptionEntity> Questions { get; set; }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}

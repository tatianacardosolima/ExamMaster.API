using ExamMaster.Shared.Abstractions;
using ExamMaster.Shared.Extensions;

namespace ExamMaster.Domain.TestManager.Entities
{
    public enum QuestionType
    {
        SingleOption,
        MultipleOption
    }
    public class QuestionEntity : EntityBase
    {
        public string QuestionPrompt { get; private set; }
        public QuestionType QuestionType { get; private  set; }

        public IEnumerable<AnswerOptionEntity> Answers { get; set; }

        public QuestionEntity()
        {
            Answers = new List<AnswerOptionEntity>();
        }

        public QuestionEntity(string prompt, QuestionType type)
        {
            QuestionPrompt = prompt;
            QuestionType = type;
            Answers = new List<AnswerOptionEntity>();
        }

        public void ChangePrompt(string newPrompt)
        { 
            if (QuestionPrompt.HasBeenChanged(newPrompt)) 
            { 
            
            }
        }


        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}

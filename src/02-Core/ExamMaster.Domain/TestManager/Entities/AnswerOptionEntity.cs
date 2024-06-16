using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.TestManager.Entities
{
    public class AnswerOptionEntity
    {
        public AnswerOptionEntity() { }

        public AnswerOptionEntity(string description, bool isCorrectAnswer)
        {
            Description = description;
            IsCorrectAnswer = isCorrectAnswer;
        }

        public string Description { get; private set; }
        public bool IsCorrectAnswer { get; private set; }
    }
}

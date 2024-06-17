using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamMaster.Domain.TestManager.ValueObjects;

namespace ExamMaster.Domain.TestManager.Requests
{
    public class TestManagerRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public EffectivePeriodValueObject EffectivePeriod { get; set; }

        public List<QuestionRequest> Questions{ get; set; }
    }
}

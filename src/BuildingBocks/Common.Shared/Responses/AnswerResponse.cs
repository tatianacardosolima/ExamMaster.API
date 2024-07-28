using Common.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Shared.Responses
{
    public class AnswerResponse: ResponseBase<long>
    {
        public long Id { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
    }
}

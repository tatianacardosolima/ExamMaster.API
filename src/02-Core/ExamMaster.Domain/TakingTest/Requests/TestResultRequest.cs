using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.TakingTest.Requests
{
    public class TestResultRequest
    {
        public Guid TestManagerId { get; set; }
        public Guid UserId { get; set; }
    }
}

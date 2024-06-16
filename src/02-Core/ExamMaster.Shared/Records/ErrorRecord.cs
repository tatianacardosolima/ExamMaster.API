using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Shared.Records
{
    public record ErrorRecord(string Code, string Message)
    {
    }
}

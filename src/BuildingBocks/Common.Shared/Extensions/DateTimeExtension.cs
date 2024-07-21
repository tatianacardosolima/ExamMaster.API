using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Shared.Extensions
{
    namespace ExamMaster.Shared.Extensions
    {
        public static class DateTimeExtension
        {
            public static bool HasBeenChanged(this DateTime date, DateTime otherDate)
            {
                return date != otherDate;
            }


        }
    }
}

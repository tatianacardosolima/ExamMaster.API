using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.Shared.Extensions
{
    public static class StringExtension
    {
        public static string Truncate(this string text, int maxWord)
        {
            if (text == null) return null;
            if (text.Length > maxWord)
                return text.Substring(0, maxWord);
            else
                return text;
        }
        public static bool IsValidEmail(this string email)
        {

            if (email == null || email == "") return false;
            string pattern = @"^(?!\.)[a-zA-Z0-9._%+-]+@(?:[a-zA-Z0-9-]+\.)+[a-zA-Z]{2,}$";

            return Regex.IsMatch(email, pattern);
        }
    }
}

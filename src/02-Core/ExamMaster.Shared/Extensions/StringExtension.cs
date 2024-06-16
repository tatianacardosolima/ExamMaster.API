using System.Text;
using System.Text.RegularExpressions;
using XSystem.Security.Cryptography;

namespace ExamMaster.Shared.Extensions
{
    public static class StringExtension
    {
        public static bool HasBeenChanged(this string text, string otherText)
        {
            return text != otherText;
        }

        public static string Truncate(this string text, int maxWord)
        {
            if (text == null) return null;
            if (text.Length>maxWord)
                return text.Substring(0, maxWord);
            else 
                return text;
        }
        public static string RemoveCharacters(this string text)
        {
            return Regex.Replace(text, @"[^\d]", string.Empty);
        }

        public static string UrlFriendly(this string text)
        {
            return Regex.Replace(text, @"[^A-Za-z0-9_\.~]+", "-").ToLower();
        }

        public static string ReplaceX(this string text, params object[] parameters)
        {
            return string.Format(text, parameters);
        }

        public static string PasswordHash(this string plainTextPassword)
        {
            var crypt = new SHA256Managed();
            var hash = System.String.Empty;
            var crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(plainTextPassword));

            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }

            return hash;
        }

        public static string FirstCharToLowerCase(this string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsLower(str[0]))
                return str;

            return char.ToLower(str[0]) + str.Substring(1);
        }
    }
}

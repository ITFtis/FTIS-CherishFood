using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using TemplateEngine.Docx;

namespace Tool
{
    public static class PwdStrengthHelper
    {
        /// <summary>
        /// 密碼強度檢視-4選3
        /// </summary>
        /// <returns></returns>
        /// <param name="pwdValue"></param>
        public static bool StrongPassword(string pwdValue)
        {
            return !(pwdValue.Any(x => IsSymbol(x)) || pwdValue.All(Char.IsDigit) || pwdValue.All(Char.IsLetter) || pwdValue.Length < 8 || pwdValue.Length > 12);
        }

        public static bool IsBigLetter(char c)
        {
            return (c >= 'A' && c <= 'Z');
        }

        public static bool IsSmallLetter(char c)
        {
            return (c >= 'a' && c <= 'z');
        }

        public static bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        public static bool IsSymbol(char c)
        {
            return c > 32 && c < 127 && !IsDigit(c) && !IsBigLetter(c) && !IsSmallLetter(c);
        }
    }
}
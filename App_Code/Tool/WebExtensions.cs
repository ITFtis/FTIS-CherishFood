using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tool
{

    public static class Extension
    {
        private const string SKey = "AxzGEhDcESZDVJeCnFPGuxzaiB7NLQM5";
        private const string SIv = "cbsdinfo123=";
        public static bool IsNull(this object source)
        {
            return source == null;
        }

        public static string FormatString(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        public static bool Match(this string value, string pattern)
        {
            Regex regex = new Regex(pattern);
            return regex.IsMatch(value);
        }

        public static void Raise(this EventHandler eventHandler,
            object sender, EventArgs e)
        {
            if (eventHandler != null)
            {
                eventHandler(sender, e);
            }
        }

        public static void Raise<T>(this EventHandler<T> eventHandler,
            object sender, T e)
            where T : EventArgs
        {
            if (eventHandler != null)
            {
                eventHandler(sender, e);
            }
        }

        public static short ToInt8(this string value)
        {
            short result = 0;
            if (!string.IsNullOrEmpty(value))
                short.TryParse(value, out result);
            return result;
        }

        public static int ToInt16(this string value)
        {
            Int16 result = 0;

            if (!string.IsNullOrEmpty(value))
                Int16.TryParse(value, out result);

            return result;
        }



        public static int ToInt32(this object value)
        {
            Int32 result = 0;

            if (!string.IsNullOrEmpty(value.ToString()))
                Int32.TryParse(value.ToString(), out result);

            return result;
        }

        public static long ToInt64(this string value)
        {
            Int64 result = 0;

            if (!string.IsNullOrEmpty(value))
                Int64.TryParse(value, out result);

            return result;
        }

        public static SortedDictionary<string, object> MValues = new SortedDictionary<string, object>();

        public static void SetValue(string key, object value)
        {
            MValues[key] = value;
        }

        public static string ToUrl(bool containempty = false)
        {
            var buff = "";
            foreach (var pair in MValues)
            {
                if (!containempty)//值为空不带入字符串
                {
                    if (pair.Key != "sign" && pair.Value != null && pair.Value.ToString() != "")
                    {
                        buff += pair.Key + "=" + pair.Value + "&";
                    }
                }
                else//值为空带入字符串
                {
                    if (pair.Key != "sign" && pair.Value != null)
                    {
                        buff += pair.Key + "=" + pair.Value + "&";
                    }
                }

            }
            buff = buff.Trim('&');
            return buff;
        }


        public static DateTime? ToDateTime(this string value)
        {
            DateTime? dt = null;
            DateTime d2;
            bool success = DateTime.TryParse(value, out d2);
            if (success) dt = d2;
            return dt;
        }

        public static string ToDateTimeString(this DateTime? value)
        {
            string result = "";
            if (value.HasValue)
            {
                result = value.Value.ToString("yyyy-MM-dd");
            }
            return result;
        }
        public static string ToDateTimeString(this DateTime value)
        {
            string result;
            result = value.ToString("yyyy-MM-dd");
            return result;
        }
        public static string Truncate(this string source, int length)
        {
            if (source.Length > length)
            {
                source = source.Substring(0, length) + "...";
            }
            return source;
        }
        public static string EvalTrimmed(this ListViewItem container, string expression, int maxLength)
        {
            var value = DataBinder.Eval(container, expression) as string;
            if (value == null)
            {
                return null;
            }
            if (value.Length > maxLength)
                value = value.Substring(0, maxLength) + "...";

            return value;
        }
  
        public static decimal ToDecimal(this string value)
        {
            decimal result = 0;

            if (!string.IsNullOrEmpty(value))
                decimal.TryParse(value, out result);

            return result;
        }
        public static bool ToBoolean(this string value)
        {
            var result = true;

            if (!string.IsNullOrEmpty(value))
                bool.TryParse(value, out result);

            return result;
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {

            foreach (var item in source)
            {
                action(item);
            }
        }

        //public static IQueryable<T> Like<T>(this IQueryable<T> source, string propertyName, string keyword)
        //{
        //    var type = typeof(T);
        //    var property = type.GetProperty(propertyName);
        //    var parameter = Expression.Parameter(type, "p");
        //    var propertyAccess = Expression.MakeMemberAccess(parameter, property);
        //    var constant = Expression.Constant("%" + keyword + "%");
        //    var methodExp = Expression.Call(null, typeof(SqlMethods).GetMethod("Like", new Type[] { typeof(string), typeof(string) }), propertyAccess, constant);
        //    var lambda = Expression.Lambda<Func<T, bool>>(methodExp, parameter);
        //    return source.Where(lambda);
        //}

        #region String
        /// <summary>
        /// true, if is valid email address
        /// from http://www.davidhayden.com/blog/dave/
        /// archive/2006/11/30/ExtensionMethodsCSharp.aspx
        /// </summary>
        /// <param name="s">email address to test</param>
        /// <returns>true, if is valid email address</returns>
        public static bool IsValidEmailAddress(this string s)
        {
            return new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,6}$").IsMatch(s);
        }

        /// <summary>
        /// Checks if url is valid. 
        /// from http://www.osix.net/modules/article/?id=586 and changed to match http://localhost
        /// 
        /// complete (not only http) url regex can be found 
        /// at http://internet.ls-la.net/folklore/url-regexpr.html
        /// </summary>
        /// <returns></returns>
        public static bool IsValidUrl(this string url)
        {
            const string strRegex = "^(https?://)"
                                    + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" //user@
                                    + @"(([0-9]{1,3}\.){3}[0-9]{1,3}" // IP- 199.194.52.184
                                    + "|" // allows either IP or domain
                                    + @"([0-9a-z_!~*'()-]+\.)*" // tertiary domain(s)- www.
                                    + @"([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]" // second level domain
                                    + @"(\.[a-z]{2,6})?)" // first level domain- .com or .museum is optional
                                    + "(:[0-9]{1,5})?" // port number- :80
                                    + "((/?)|" // a slash isn't required if there is no file name
                                    + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";
            return new Regex(strRegex).IsMatch(url);
        }

        /// <summary>
        /// 檢查url（http）是否可用。
        /// </summary>
        /// <param name="httpUrl"></param>
        /// <example>
        /// string url = "www.codeproject.com;
        /// if( !url.UrlAvailable())
        ///     ...codeproject is not available
        /// </example>
        /// <returns>true if available</returns>
        public static bool UrlAvailable(this string httpUrl)
        {
            if (!httpUrl.StartsWith("http://") || !httpUrl.StartsWith("https://"))
                httpUrl = "http://" + httpUrl;
            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(httpUrl);
                myRequest.Method = "GET";
                myRequest.ContentType = "application/x-www-form-urlencoded";
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myRequest.GetResponse();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 反转字符串
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Reverse(this string input)
        {
            var chars = input.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }


        /// <summary>
        /// 將字符串縮減為較短的預覽，可選地以某個字符串（...）結尾
        /// </summary>
        /// <param name="s">string to reduce</param>
        /// <param name="count">Length of returned string including endings.</param>
        /// <param name="endings">optional edings of reduced text</param>
        /// <example>
        /// string description = "This is very long description of something";
        /// string preview = description.Reduce(20,"...");
        /// produce -> "This is very long..."
        /// </example>
        /// <returns></returns>
        public static string Reduce(this string s, int count, string endings)
        {
            if (count < endings.Length)
                throw new Exception("Failed to reduce to less then endings length.");
            var sLength = s.Length;
            var len = sLength;
            len += endings.Length;
            if (count > sLength)
                return s; //it's too short to reduce
            s = s.Substring(0, sLength - len + count);
            s += endings;
            return s;
        }

        /// <summary>
        /// 刪除空白，而不是行結束
        /// Useful when parsing user input such phone,
        /// price int.Parse("1 000 000".RemoveSpaces(),.....
        /// </summary>
        /// <param name="s"></param>
        public static string RemoveSpaces(this string s)
        {
            return s.Replace(" ", "");
        }

        /// <summary>
        /// 如果該字符串可以解析為Double，則分別為Int32
        /// Spaces are not considred.
        /// </summary>
        /// <param name="s">input string</param>
        /// <param name="floatpoint">true, if Double is considered,
        /// otherwhise Int32 is considered.</param>
        /// <returns>true, if the string contains only digits or float-point</returns>
        public static bool IsNumber(this string s, bool floatpoint)
        {
            int i;
            double d;
            var withoutWhiteSpace = RemoveSpaces(s);
            if (floatpoint)
                return double.TryParse(withoutWhiteSpace, NumberStyles.Any,
                    Thread.CurrentThread.CurrentUICulture, out d);
            else
                return int.TryParse(withoutWhiteSpace, out i);
        }

        /// <summary>
        /// 如果字符串只包含數字或浮點，則為true。
        /// Spaces are not considred.
        /// </summary>
        /// <param name="s">input string</param>
        /// <param name="floatpoint">true, if float-point is considered</param>
        /// <returns>true, if the string contains only digits or float-point</returns>
        public static bool IsNumberOnly(this string s, bool floatpoint)
        {
            s = s.Trim();
            return s.Length != 0 && s.Where(c => !char.IsDigit(c)).All(c => floatpoint && (c == '.' || c == ','));
        }

        /// <summary>
        /// 從字符串中刪除口音
        /// </summary>
        /// <example>
        ///  input:  "Příliš žluťoučký kůň úpěl ďábelské ódy."
        ///  result: "Prilis zlutoucky kun upel dabelske ody."
        /// </example>
        /// <param name="s"></param>
        /// <remarks>founded at http://stackoverflow.com/questions/249087/
        /// how-do-i-remove-diacritics-accents-from-a-string-in-net</remarks>
        /// <returns>string without accents</returns>
        public static string RemoveDiacritics(this string s)
        {
            var stFormD = s.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (var t in stFormD)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(t);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(t);
                }
            }
            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }

        /// <summary>
        /// 用<br />替換\ r \ n或\ n
        /// from http://weblogs.asp.net/gunnarpeipman/archive/2007/11/18/c-extension-methods.aspx
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Nl2Br(this string s)
        {
            return s.Replace("\r\n", "<br />").Replace("\n", "<br />");
        }


        /// <summary>
        /// 所有参数参与加密,RPCA使用
        /// </summary>
        /// <param name="poststr"></param>
        /// <returns></returns>
        public static string Md5Hash(this string poststr)
        {
            var s = GetArraySort(poststr);
            var data = Encoding.GetEncoding("utf-8").GetBytes(s);
            MD5 md5 = new MD5CryptoServiceProvider();
            var outBytes = md5.ComputeHash(data);
            var outstring = outBytes.Aggregate("", (current, t) => current + t.ToString("x2"));
            return outstring.ToUpper();
        }

        /// <summary>
        /// 所有参数参与加密,RPCA使用
        /// </summary>
        /// <param name="poststr"></param>
        /// <returns></returns>
        public static string GetArraySort(this string poststr)
        {
            var arr = poststr.Split('&');
            Array.Sort(arr, StringComparer.Ordinal);
            var s = arr.Where(pair => pair.Contains("=") && !pair.StartsWith("sign=")).Where(pair => !string.IsNullOrWhiteSpace(pair.Substring(pair.IndexOf('=') + 1))).Aggregate("", (current, pair) => current + (pair + "&"));
            s = s.Trim('&') ;
            return s;
        }


        //des加密
        public static string EncryptString(string value)
        {
            SymmetricAlgorithm mCsp = new TripleDESCryptoServiceProvider();
            try
            {
                mCsp.Key = Convert.FromBase64String(SKey);
                mCsp.IV = Convert.FromBase64String(SIv);
                //指定加密的运算模式
                mCsp.Mode = CipherMode.ECB;
                //获取或设置加密算法的填充模式
                mCsp.Padding = PaddingMode.PKCS7;
                var ct = mCsp.CreateEncryptor(mCsp.Key, mCsp.IV);
                var byt = Encoding.UTF8.GetBytes(value);
                var ms = new MemoryStream();
                var cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
                cs.Write(byt, 0, byt.Length);
                cs.FlushFinalBlock();
                cs.Close();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "出现异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ("Error in Encrypting " + ex.Message);
            }

        }
        //des解密
        public static string DecryptString(this string value)
        {
      
            SymmetricAlgorithm mCsp = new TripleDESCryptoServiceProvider();
            try
            {
                //將3DES的密鑰轉換成byte 
                mCsp.Key = Convert.FromBase64String(SKey);
                //將3DES的向量轉換成byte 
                mCsp.IV = Convert.FromBase64String(SIv);
                mCsp.Mode = CipherMode.ECB;
                mCsp.Padding = PaddingMode.PKCS7;
                var ct = mCsp.CreateDecryptor(mCsp.Key, mCsp.IV);
                var byt = Convert.FromBase64String(value);
                var ms = new MemoryStream();
                var cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
                cs.Write(byt, 0, byt.Length);
                cs.FlushFinalBlock();
                cs.Close();
                return Encoding.UTF8.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "出現異常", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                return ("Error in Decrypting " + ex.Message);
            }


        }
        #endregion
    }
}


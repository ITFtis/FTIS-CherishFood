using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// WebUtil 的摘要描述
/// </summary>
public class WebUtil
{
    public WebUtil()
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //
    }

    #region 字串跟日期轉換
    /// <summary>
    /// 轉換字串yyyy/mm/dd日期至日期格式，若字串為空則傳回null
    /// </summary>
    /// <param name="dateStr">日期的字串型態</param>
    /// <returns>回傳日期</returns>
    public static DateTime? StrToDate(string dateStr)
    {
        return string.IsNullOrEmpty(dateStr) ? (DateTime?) null : ToDateTime(dateStr);
    }
    public static string StrToDateStr(string dateStr)
    {
        var dt = StrToDate(dateStr);
        return dt == null ? null : DateToStr(dt.Value);
    }
    /// <summary>
    /// 將日期轉為yyyy/mm/dd的格式
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static string DateToStr(DateTime? date)
    {
        return date == null ? "" : DateToShortDateStr(date);
    }
    /// <summary>
    /// 將日期轉為yyyy/mm/dd hh:mm:ss的格式
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static string DateToAllStr(DateTime? date)
    {
        return date == null ? "" : DateToShortDateStr(date.Value) + " " + DateToShortTimeStr(date.Value);
    }
    /// <summary>
    /// 將日期轉為yyyy/mm/dd的字串
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static string DateToShortDateStr(DateTime? date)
    {
        return DateToShortDateStr(date, "/");
    }
    /// <summary>
    /// 將日期轉為yyyy/mm/dd的字串
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static string DateToShortDateStr(DateTime? date, string separator)
    {
        return date == null ? "" : (string.Format(date.Value.ToString("yyyy{0}MM{1}dd"), separator, separator));
    }
    /// <summary>
    /// 將日期轉為hh/mm/ss的時間
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static string DateToShortTimeStr(DateTime? date)
    {
        return date?.ToString("HH:mm:ss") ?? "";
    }
    /// <summary>
    /// 將yyyy/mm/dd轉換為Datetime格式
    /// </summary>
    /// <param name="dateTimeStr"></param>
    /// <returns></returns>
    public static DateTime ToDateTime(string dateTimeStr)
    {
        DateTime sd;//供判斷暫存之用
        if (String.IsNullOrEmpty(dateTimeStr) || !DateTime.TryParse(dateTimeStr, out sd))
        {
            return Convert.ToDateTime("1911/01/01");
        }
        return Convert.ToDateTime(dateTimeStr);
    }
    /// <summary>
    /// 將yyyy/mm/dd轉換為Datetime格式
    /// </summary>
    /// <param name="dateTimeStr"></param>
    /// <returns></returns>
    public static DateTime ToDateTime(string dateTimeStr, char separator)
    {
        string[] strArray = dateTimeStr.Split(separator);
        if (strArray[2].Length > 2) { strArray[2] = strArray[2].Remove(2); }
        DateTime d = new DateTime(Convert.ToInt32(strArray[0]), Convert.ToInt32(strArray[1]), Convert.ToInt32(strArray[2]));
        return d;
    }
    /// <summary>
    /// 轉換成完整的日期字串 yyyy/mm/dd hh:MM:ss
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static string ToShortDateTimeStr(DateTime? date)
    {
        if (date.HasValue)
        {
            DateTime tmp = date.Value;
            return DateToShortDateStr(tmp) + " " + DateToShortTimeStr(tmp);
        }
        else
        {
            return "";
        }
    }
    /// <summary>
    /// 傳回當天日期最後的時間例如1月1日23:59:59
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static DateTime ToDateTimeMax(DateTime dateTime)
    {
        DateTime tmp = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59);
        return tmp;
    }
    /// <summary>
    /// 傳回當天日期最早的時間例如1月1日00:00:00
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static DateTime ToDateTimeMin(DateTime dateTime)
    {
        DateTime tmp = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
        return tmp;
    }
    /// <summary>
    /// 將日期格式(西元年)轉為日期格式(民國年)
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns>string</returns>
    public static string ToDateTw(DateTime dateTime)
    {
        return dateTime.AddYears(-1911).ToShortDateString();
    }
    public static string ToDateTw(string dateTime)
    {
        DateTime? dt = StrToDate(dateTime);
        if (dt == null)
        {
            return null;
        }
        else
        {
            return ToDateTw(dt.Value);
        }
    }
    public static string ToDateTw(DateTime? date)
    {
        if (date == null)
        {
            return null;
        }
        else
        {
            return ToDateTw(date.Value);
        }
    }
    /// <summary>
    ///  將日期格式(民國年)轉為日期格式(西元年)
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    /// 
    public static DateTime ToDateTimeEn(string dateTime)
    {
        string[] strArray = dateTime.Split('/');
        DateTime d = new DateTime(Convert.ToInt32(strArray[0]) + 1911, Convert.ToInt32(strArray[1]), Convert.ToInt32(strArray[2]));
        return d;
    }
    #endregion

    #region 字串跟數字轉換
    /// <summary>
    /// 判斷是否為數字
    /// </summary>
    /// <param name="strNumber">數字日期的字串型態</param>
    /// <returns>回傳Bool</returns>
    /// 
    public static bool IsNumber(string strNumber)
    {
        //看要用哪種規則判斷，自行修改strValue即可

        //strValue = @"^\d+[.]?\d*$";//非負數字
        string strValue = @"^\d+(\.)?\d*$";//數字
                                           //strValue = @"^\d+$";//非負整數
                                           // strValue = @"^-?\d+$";//整數
                                           //strValue = @"^-[0-9]*[1-9][0-9]*$";//負整數
                                           //strValue = @"^[0-9]*[1-9][0-9]*$";//正整數
                                           //strValue = @"^((-\d+)|(0+))$";//非正整數

        System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(strValue);
        return r.IsMatch(strNumber);
    }
    public static bool IsNumber(int i, string strNumber)
    {



        string strValue = "";
        //看要用哪種規則判斷，自行修改strValue即可
        switch (i)
        {
            case 1:
                strValue = @"^\\d+$";  //非負整數（正整數 + 0）
                break;
            case 2:
                strValue = @"^[0-9]*[1-9][0-9]*$";  //正整數
                break;
            case 3:
                strValue = @"^((-\\d+)|(0+))$";  //非正整數（負整數 + 0）

                break;
            case 4:
                strValue = @"^-[0-9]*[1-9][0-9]*$";  //負整數

                break;
            case 5:
                strValue = @"^-?\\d+$";   //整數

                break;
            case 6:
                strValue = @"^\\d+(\\.\\d+)?$";  //非負浮點數（正浮點數 + 0）
                break;
            case 7:
                strValue = @"^(([0-9]+\\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\\.[0-9]+)|([0-9]*[1-9][0-9]*))$";//正浮點數
                break;
            case 8:
                strValue = @"^((-\\d+(\\.\\d+)?)|(0+(\\.0+)?))$"; //非正浮點數（負浮點數 + 0）
                break;
            case 9:
                strValue = @"^(-(([0-9]+\\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\\.[0-9]+)|([0-9]*[1-9][0-9]*)))$";//負浮點數
                break;
            case 10:
                strValue = @"^(-?\\d+)(\\.\\d+)?$";  //浮點數
                break;
            case 11:
                strValue = "^[A-Za-z]+$";  //由26個英文字母組成的字符串
                break;
            case 12:
                strValue = @"^[A-Z]+$";  //由26個英文字母的大寫組成的字符串
                break;
            case 13:
                strValue = @"^[a-z]+$";  //由26個英文字母的小寫組成的字符串
                break;
            case 14:
                strValue = @"^[A-Za-z0-9]+$";  //由數字和26個英文字母組成的字符串
                break;
            case 15:
                strValue = @"^\\w+$";  //由數字、26個英文字母或者下劃線組成的字符串
                break;
            case 16:
                strValue = @"^[\\w-]+(\\.[\\w-]+)*@[\\w-]+(\\.[\\w-]+)+$";    //email地址
                break;
            case 17:
                strValue = @"^[a-zA-z]+://(\\w+(-\\w+)*)(\\.(\\w+(-\\w+)*))*(\\?\\S*)?$";  //url
                break;
        }
        System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(strValue);
        return r.IsMatch(strNumber);
    }
    /// <summary>
    /// 將字串轉為數字，若null則傳回0
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public static int ConvertStringToInt(string p)
    {
        int n = 0;
        try
        {
            n = Convert.ToInt32(p);
        }
        catch (Exception)
        {

        }
        return n;
    }
    /// <summary>
    /// 無條件捨去取整個
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public static int Floor(double p)
    {
        return ((int)Math.Floor(Convert.ToDouble(p.ToString())));
    }
    /// <summary>
    /// 無條件捨去取整個
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public static int ToInt32(string p)
    {
        if (!string.IsNullOrEmpty(p) && IsNumber(p))
        {
            return Convert.ToInt32(p);
        }
        else
        {
            return 0;
        }
    }
    public static double ToDouble(string p)
    {

        double B;
        bool aa = double.TryParse(p, out B);
        if (!string.IsNullOrEmpty(p) && aa)
        {
            return Convert.ToDouble(p);
        }
        else
        {
            return 0;
        }
    }
    /// <summary>
    /// 四捨五入取至整數
    /// </summary>
    /// <param name="noTaxNum"></param>
    /// <returns></returns>
    public static int ToRoundInt(double num)
    {

        return (Convert.ToInt32(Math.Round(num, 0, MidpointRounding.AwayFromZero)));
    }
    /// <summary>
    /// 四捨五入取至整數然後以#,##0格式呈現
    /// </summary>
    /// <param name="noTaxNum"></param>
    /// <returns></returns>
    public static string ToRoundIntStr(double num)
    {
        return ToRoundInt(num).ToString("#,##0");
    }

    #endregion

    #region Decimal跟數字轉換
    /// <summary>
    /// Decimal 轉 Int
    /// </summary>
    /// <param name="d">Decimal型態</param>
    /// <returns>回傳Int</returns>
    public static int ConvertDecimalToInt(Decimal d)
    {

        int a = (int)d;
        return a;
    }
    /// <summary>
    /// Decimal 轉 String
    /// </summary>
    /// <param name="d">Decimal型態</param>
    /// <returns>回傳String</returns>
    public static string ConvertDecimalToIntStr(Decimal d)
    {
        int a = (int)d;

        return a.ToString();
    }
    #endregion

    #region 檢查字串
    public static bool IsIntFormat(string StrInt)
    {
        int i;
        if (int.TryParse(StrInt, out i))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool IsDecimalFormat(string StrDecimal)
    {
        decimal i;
        if (decimal.TryParse(StrDecimal, out i))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool IsDateFormat(string StrDate)
    {
        DateTime dtDate;
        if (DateTime.TryParse(StrDate, out dtDate))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion

    #region 轉換時間格式(字串)
    /// <summary>
    /// DateTime時間格式轉換成 MM/dd 格式
    /// </summary>
    /// <param name="DateTime">日期時間</param>
    /// <returns>輸出 MM/dd 格式</returns>
    public static string DateTimeToStrDay(object DateTime1)
    {
        string StrDate = "";
        if (DateTime1 != null)
        {
            if (!string.IsNullOrEmpty(DateTime1.ToString()))
            {
                DateTime dt = new DateTime();
                if (!DateTime.TryParse(DateTime1.ToString(), out dt))
                {
                    StrDate = "";
                }
                else
                {
                    StrDate = Convert.ToDateTime(DateTime1).ToString("MM/dd");
                }
            }
        }
        return StrDate;
    }
    /// <summary>
    /// DateTime時間格式轉換成 yyy/MM/dd 格式
    /// </summary>
    /// <param name="DateTime">日期時間</param>
    /// <returns>輸出 yyyy/MM/dd 格式</returns>
    public static string DateTimeToStrDate(object DateTime1)
    {
        string StrDate = "";
        if (DateTime1 != null)
        {
            if (!string.IsNullOrEmpty(DateTime1.ToString()))
            {
                DateTime dt = new DateTime();
                if (!DateTime.TryParse(DateTime1.ToString(), out dt))
                {
                    StrDate = "";
                }
                else
                {
                    StrDate = Convert.ToDateTime(DateTime1).ToString("yyyy/MM/dd");
                }
            }
        }
        return StrDate;
    }
    /// <summary>
    /// DateTime時間格式轉換成 YMD 格式
    /// </summary>
    /// <param name="DateTime1">日期時間</param>
    /// <param name="YMD">需求格式</param>
    /// <returns>輸出 YMD 格式</returns>
    public static string DateTimeToStrDate(object DateTime1, string YMD)
    {
        string StrDate = "";
        if (DateTime1 != null)
        {
            if (!string.IsNullOrEmpty(DateTime1.ToString()))
            {
                DateTime dt = new DateTime();
                if (!DateTime.TryParse(DateTime1.ToString(), out dt))
                {
                    StrDate = "";
                }
                else
                {
                    StrDate = Convert.ToDateTime(DateTime1).ToString(YMD);
                }
            }
        }
        return StrDate;
    }
    /// <summary>
    /// DateTime時間格式轉換成 hh:mm:ss 格式
    /// </summary>
    /// <param name="DateTime1">日期時間</param>
    /// <param name="MSFlag">true 的話增加毫秒.fffff</param>
    /// <returns>輸出 hh:mm:ss 格式</returns>
    public static string DateTimeToStrTime(object DateTime1, bool MSFlag)
    {
        string StrDate = "";
        if (DateTime1 != null)
        {
            if (!string.IsNullOrEmpty(DateTime1.ToString()))
            {
                DateTime dt = new DateTime();
                if (!DateTime.TryParse(DateTime1.ToString(), out dt))
                {
                    StrDate = "";
                }
                else
                {
                    string StrTime = "hh:mm:ss";
                    if (MSFlag) StrTime = "hh:mm:ss.fffff";
                    StrDate = Convert.ToDateTime(DateTime1).ToString(StrTime);
                }
            }
        }
        return StrDate;
    }
    /// <summary>
    /// DateTime時間格式轉換成 hms 格式
    /// </summary>
    /// <param name="DateTime1">日期時間</param>
    /// <param name="hms">需求格式</param>
    /// <returns>輸出 hms 格式</returns>
    public static string DateTimeToStrTime(object DateTime1, string hms)
    {
        string StrDate = "";
        if (DateTime1 != null)
        {
            if (!string.IsNullOrEmpty(DateTime1.ToString()))
            {
                DateTime dt = new DateTime();
                if (!DateTime.TryParse(DateTime1.ToString(), out dt))
                {
                    StrDate = "";
                }
                else
                {
                    StrDate = Convert.ToDateTime(DateTime1).ToString(hms);
                }
            }
        }
        return StrDate;
    }
    #endregion

    public static bool Tobool(string p)
    {

        bool B;
        bool aa = bool.TryParse(p, out B);
        if (!string.IsNullOrEmpty(p) && aa)
        {
            return Convert.ToBoolean(p);
        }
        return false;
    }

    public static string CheckStr(object strCheck, int? number = null)
    {
        var str = "";
        if (strCheck != null)
        {
            str = strCheck.ToString();
            var no = number ?? 40;
            if (str.Length > no)
            {
                str = str.Substring(0, no) + "...";
            }
        }
        return str;
    }

}
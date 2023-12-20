using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) return;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (CheckIdno(TextBox1.Text))
        {
            Literal1.Text = "符合";
        }
        else Literal1.Text = "不符合";
    }

    public bool CheckIdno(string str)
    {
        string sex = "";
        string nationality = "";
        if (str == null || string.IsNullOrWhiteSpace(str) || str.Length != 10)
        {
            return false;
        }
        char[] pidCharArray = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        str = str.ToUpper(); // 轉換大寫
        char[] strArr = str.ToCharArray(); // 字串轉成char陣列
        int verifyNum = 0;

        string pat = @"[A-Z]{1}[1-2]{1}[0-9]{8}";
        // Instantiate the regular expression object.
        Regex rTaiwan = new Regex(pat, RegexOptions.IgnoreCase);
        // Match the regular expression pattern against a text string.
        Match mTaiwan = rTaiwan.Match(str);
        // 檢查身分證字號
        if (mTaiwan.Success)
        {
            // 原身分證英文字應轉換為10~33，這裡直接作個位數*9+10
            int[] pidIDInt = { 1, 10, 19, 28, 37, 46, 55, 64, 39, 73, 82, 2, 11, 20, 48, 29, 38, 47, 56, 65, 74, 83, 21, 3, 12, 30 };
            // 第一碼
            verifyNum = verifyNum + pidIDInt[Array.BinarySearch(pidCharArray, strArr[0])];
            // 第二~九碼
            for (int i = 1, j = 8; i < 9; i++, j--)
            {
                verifyNum += Convert.ToInt32(strArr[i].ToString(), 10) * j;
            }
            // 檢查碼
            verifyNum = (10 - (verifyNum % 10)) % 10;
            bool ok = verifyNum == Convert.ToInt32(strArr[9].ToString(), 10);
            if (ok)
            {
                // 判斷性別 & 國籍
                sex = "男";
                if (strArr[1] == '2') sex = "女";
                nationality = "本國籍";
            }
            return ok;
        }

        // 檢查統一證號(居留證)
        verifyNum = 0;
        pat = @"[A-Z]{1}[A-D]{1}[0-9]{8}";
        // Instantiate the regular expression object.
        Regex rForeign = new Regex(pat, RegexOptions.IgnoreCase);
        // Match the regular expression pattern against a text string.
        Match mForeign = rForeign.Match(str);
        if (mForeign.Success)
        {
            // 原居留證第一碼英文字應轉換為10~33，十位數*1，個位數*9，這裡直接作[(十位數*1) mod 10] + [(個位數*9) mod 10]
            int[] pidResidentFirstInt = { 1, 10, 9, 8, 7, 6, 5, 4, 9, 3, 2, 2, 11, 10, 8, 9, 8, 7, 6, 5, 4, 3, 11, 3, 12, 10 };
            // 第一碼
            verifyNum += pidResidentFirstInt[Array.BinarySearch(pidCharArray, strArr[0])];
            // 原居留證第二碼英文字應轉換為10~33，並僅取個位數*6，這裡直接取[(個位數*6) mod 10]
            int[] pidResidentSecondInt = { 0, 8, 6, 4, 2, 0, 8, 6, 2, 4, 2, 0, 8, 6, 0, 4, 2, 0, 8, 6, 4, 2, 6, 0, 8, 4 };
            // 第二碼
            verifyNum += pidResidentSecondInt[Array.BinarySearch(pidCharArray, strArr[1])];
            // 第三~八碼
            for (int i = 2, j = 7; i < 9; i++, j--)
            {
                verifyNum += Convert.ToInt32(strArr[i].ToString(), 10) * j;
            }
            // 檢查碼
            verifyNum = (10 - (verifyNum % 10)) % 10;
            bool ok = verifyNum == Convert.ToInt32(strArr[9].ToString(), 10);
            if (ok)
            {
                // 判斷性別 & 國籍
                sex = "男";
                if (strArr[1] == 'B' || strArr[1] == 'D') sex = "女";
                nationality = "外籍人士";
                if (strArr[1] == 'A' || strArr[1] == 'B') nationality += "(臺灣地區無戶籍國民、大陸地區人民、港澳居民)";
            }
            return ok;
        }
        return false;
    }
}
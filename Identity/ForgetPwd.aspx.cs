using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class Identity_ForgetPwd : System.Web.UI.Page
{
    DataClassesDataContext _db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack) return;
    }
    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        var userResult = _db.e_Employees.FirstOrDefault(x => x.Account == txtAccount.Text);
        if (userResult != null)
        {
            if (userResult.Status == 2 || userResult.Status == 3)
            {
                Response.Write(JavascriptHelper.ErrorMsg("帳號已遭停用"));
                return;
            }

            if (!string.IsNullOrEmpty(userResult.Address))
            {
                var mailTitle = "112 年首惜廚師甄選活動甄選-忘記密碼(後台帳號)";
                var htmlContents = new System.Text.StringBuilder();
                htmlContents.Append($"您好<br/>");
                htmlContents.Append($"<a target='_blank' href='{HttpContext.Current.Request.Url.Scheme}://{HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath?.TrimEnd('/')}/Identity/SetNewPwd.aspx?acc={txtAccount.Text}'>請按此連結變更密碼</a><br/>");
                var mailContent = htmlContents.ToString();
                SendMailHelper.SendMail(mailTitle, mailContent, userResult.Address);
                ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJsAndRedirect("密碼變更信件已寄出，請按照步驟進行變更", "Login.aspx"));
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJsAndRedirect("未設定信箱，請聯絡系統管理員進行設定", "Login.aspx"));
            }
        }
        else
        {
            Response.Write(JavascriptHelper.ErrorMsg("無此帳號"));
        }
    }
}
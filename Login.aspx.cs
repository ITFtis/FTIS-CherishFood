using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class Login : System.Web.UI.Page
{
    DataClassesDataContext _db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "登入|首惜廚師甄選活動";
        if (IsPostBack) return;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!reCAPTCHAHelper.Validate(hidtoken.Value) && !Request.Url.Host.Contains("localhost"))
        {
            ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJs("驗證錯誤!"));
        }
        else
        {
            var checkAcc = _db.CompetitionGroup.FirstOrDefault(x => x.Account == txtAccount.Text && x.LoginPass == txtPassword.Text);
            if (checkAcc != null)
            {
                HttpCookie cookie = new HttpCookie("ChiefChef");
                cookie.Value = Server.UrlEncode(checkAcc.Account);
                cookie.Expires = DateTime.Now.AddHours(1);
                Response.Cookies.Add(cookie);

                ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJsAndRedirect("登入成功", "Preliminary.aspx"));
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJs("帳號密碼錯誤"));
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class Forget : System.Web.UI.Page
{
    DataClassesDataContext _db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "忘記密碼|首惜廚師甄選活動";
        if (IsPostBack) return;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        var getAccount = _db.CompetitionGroup.Where(x => x.Account == txtAccount.Text).ToList();
        if(getAccount.Any())
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            int updLength = 8;//密碼長度
            string resetToken = "";
            Random rd = new Random();

            for (int i = 0; i < updLength; i++)
            {
                //allowedChars -> 這個String ，隨機取得一個字，丟給chars[i]
                resetToken += allowedChars[rd.Next(0, allowedChars.Length)];
            }

            var mailTitle = "首惜廚師甄選活動-密碼重設信件";
            var htmlContents = new System.Text.StringBuilder();
            htmlContents.Append($"{getAccount.FirstOrDefault().CompetitionGroupMember.FirstOrDefault(x => x.IsLeader).Name} 您好<br/>");
            htmlContents.Append($"請點擊下方連結重設密碼<br/>");
            htmlContents.Append($"<a href='{HttpContext.Current.Request.Url.Scheme}://{HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath?.TrimEnd('/')}/ResetPwd.aspx?rToken={resetToken}'>前往重設密碼</a><br/>");
            var mailContent = htmlContents.ToString();
            SendMailHelper.SendMail(mailTitle, mailContent, getAccount.FirstOrDefault().CompetitionGroupMember.FirstOrDefault(x => x.IsLeader).Mail);

            foreach (var item in getAccount)
            {
                item.ResetToken = resetToken;
                item.ExpireDate = DateTime.Now.AddMinutes(30);
            }
            _db.SubmitChanges();
        }
        else
            ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJs("無此帳號"));
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class Identity_SetNewPwd : System.Web.UI.Page
{
    DataClassesDataContext _db = new DataClassesDataContext();
    private string _accout => Request.QueryString["acc"] ?? "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        var checkAcc = _db.e_Employees.FirstOrDefault(x => x.Account == _accout && x.Status < 2);
        if (checkAcc == null) Response.Redirect("Login.aspx");
    }

    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        if (txtPassword.Text != txtPasswordConfirm.Text)
        {
            ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJs("兩次密碼輸入不相同"));
            return;
        }
        if (!PwdStrengthHelper.StrongPassword(txtPassword.Text))
        {
            ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJs("密碼不符合規則(限8~12碼且混合數字與大小寫英文)"));
            return;
        }

        var checkAcc = _db.e_Employees.FirstOrDefault(x => x.Account == _accout);
        if (checkAcc != null)
        {
            var oldPwdList = (checkAcc.PwdChangeLog ?? "").Split(',').ToList();
            if (oldPwdList.Contains(txtPassword.Text))
            {
                ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJs("密碼不可與前三次相同"));
                return;
            }
            oldPwdList.Add(txtPassword.Text);
            var pwdLog = oldPwdList;
            if (oldPwdList.Count > 3) pwdLog = oldPwdList.Skip(oldPwdList.Count - 3).ToList();
            checkAcc.PwdChangeDate = DateTime.Now;
            checkAcc.PwdChangeLog = string.Join(",", pwdLog);
            checkAcc.Status = 1;
            checkAcc.Password = txtPassword.Text;
            _db.SubmitChanges();
            ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJsAndRedirect("密碼已重設，請使用新密碼進行登入", "Login.aspx"));
        }
        Response.Redirect("Login.aspx");
    }
}
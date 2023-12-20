using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class ResetPwd : System.Web.UI.Page
{
    DataClassesDataContext _db = new DataClassesDataContext();
    private string rToken => Request.QueryString["rToken"];
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "重設密碼|首惜廚師甄選活動";
        if (IsPostBack) return;

        var checkToken = _db.CompetitionGroup.FirstOrDefault(x => x.ResetToken == rToken);
        if (checkToken == null || checkToken?.ExpireDate < DateTime.Now)
        {
            ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJsAndRedirect("重設密碼逾時，請重新操作", "Login.aspx"));
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        var getAccount = _db.CompetitionGroup.Where(x => x.ResetToken == rToken).ToList();
        if (txtNewPwd.Text != txtConfirmPwd.Text)
        {
            ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJs("兩次密碼輸入不相同"));
            return;
        }
        if (!PwdStrengthHelper.StrongPassword(txtNewPwd.Text))
        {
            ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJs("密碼不符合規則(限8~12碼且混合數字與大小寫英文)"));
            return;
        }
        foreach (var item in getAccount)
        {
            item.LoginPass = txtNewPwd.Text;
            _db.SubmitChanges();
        }
        ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJsAndRedirect("密碼修改成功，請使用新密碼登入","Login.aspx"));
    }
}
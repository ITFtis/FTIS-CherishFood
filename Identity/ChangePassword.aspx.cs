using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class Admin_ChangePassword : System.Web.UI.Page
{
    private int Id => (Request.QueryString["id"] ?? "0").ToInt16();
    private readonly DataClassesDataContext _db = new DataClassesDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Id != 0)
            {
                var result = _db.e_Employees.FirstOrDefault(x=>x.EmployeeId==Id);
                if (result != null)
                {
                    txtAccount.Text = result.Account;
                    txtAccount.Enabled = false;
                }
            }
        }
    }

    protected void btnResetPassword_OnClick(object sender, EventArgs e)
    {

        if (Id != 0)
        {
            var newRow = _db.e_Employees.FirstOrDefault(x => x.EmployeeId == Id);
            if (newRow != null)
            {
                newRow.Password = txtPassword.Text;
                newRow.Status = 0;
                _db.SubmitChanges();
                ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.FancyboxClose());
            }
        }
    }
}
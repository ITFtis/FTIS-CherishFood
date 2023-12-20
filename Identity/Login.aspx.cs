using Antlr.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Providers.Entities;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class Admin_Login : System.Web.UI.Page
{
    private readonly DataClassesDataContext _db = new DataClassesDataContext();
    private int reset => (Request.QueryString["reset"] ?? "0").ToInt16();
    private static string AccountSecretKey { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (reset == 1)
            {
                _db.e_Employee_RolePremission_Mapping.DeleteAllOnSubmit(_db.e_Employee_RolePremission_Mapping.Where(x => x.RoleId == 1));
                _db.SubmitChanges();
                foreach (var p in _db.e_EmployeePermission)
                {
                    e_Employee_RolePremission_Mapping _new = new e_Employee_RolePremission_Mapping();
                    _new.RoleId = 1;
                    _new.PermissionId = p.EmployeePermissionId;
                    _db.e_Employee_RolePremission_Mapping.InsertOnSubmit(_new);
                    _db.SubmitChanges();
                }
            }

        }
    }
    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        if (Session["USER_Fail_Time"] != null)
        {
            var failTime = DateTime.Parse(Session["USER_Fail_Time"].ToString());
            if (failTime >= DateTime.Now)
            {
                ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJs("錯誤已達三次，暫停登入至 " + failTime.ToString("MM-dd HH:mm")));
                return ;
            }
        }
        var userResult = _db.e_Employees.FirstOrDefault(x => x.Account == txtAccount.Text && x.Password == txtPassword.Text);
        if (userResult != null)
        {
            var sysLog = new SysLog()
            {
                Action = "login",
                Account = userResult.Account,
                IPsource = GetIP(),
                CreateDate = DateTime.Now,
                IsSuccess = true,
            };
            _db.SysLog.InsertOnSubmit(sysLog);
            _db.SubmitChanges();
            if (userResult.Status == 2 || userResult.Status == 3)
            {
                Response.Write(JavascriptHelper.ErrorMsg("帳號已遭停用"));
                return;
            }
            else if(userResult.Status == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJsAndRedirect("首次登入需變更密碼", "SetNewPwd.aspx?acc=" + txtAccount.Text));
                return;
            }
            Session["AdminId"] = userResult.EmployeeId;
            Response.Redirect("index.aspx");
        }
        else
        {
            var sysLog = new SysLog()
            {
                Action = "login",
                Account = txtAccount.Text,
                IPsource = GetIP(),
                CreateDate = DateTime.Now,
                IsSuccess = false,
            };
            _db.SysLog.InsertOnSubmit(sysLog);
            _db.SubmitChanges();

            if (Session["USER_Fail"] == null)
            {
                Session["USER_Fail"] = "1";
            }
            else
            {
                var errorCount = int.Parse(Session["USER_Fail"].ToString()) + 1;
                Session["USER_Fail"] = errorCount.ToString();
                if (errorCount >= 3)
                {
                    Session["USER_Fail_Time"] = DateTime.Now.AddMinutes(15);
                    Response.Write(JavascriptHelper.ErrorMsg("錯誤達三次，暫停登入15分鐘"));
                }
                else
                {
                    Response.Write(JavascriptHelper.ErrorMsg("帳號密碼錯誤"));
                }
            }
        }
    }
    private string GetIP()
    {
        string[] CustomerIP;
        string IPaa = HttpContext.Current.Request.UserHostAddress;
        if (Context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
        {
            CustomerIP = Context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Split('.');
            return Context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        }
        else
        {
            CustomerIP = Context.Request.ServerVariables["REMOTE_ADDR"].Split('.');
            return Context.Request.ServerVariables["REMOTE_ADDR"];
        }
    }
}
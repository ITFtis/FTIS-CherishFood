using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class Admin_EmployeeRoleList : System.Web.UI.Page
{

    private readonly DataClassesDataContext _db = new DataClassesDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ListViewBind();
        }
    }

    public void ListViewBind()
    {
        var userResult = _db.e_EmployeeRole;
        ListView1.DataSource = userResult;
        ListView1.DataBind();
    }
    protected void btn_OnCommand(object sender, CommandEventArgs e)
    {
        string Action = "EmployeeRole";
        switch (e.CommandName)
        {
            case "GoAdd":
                Response.Redirect(Action + "Add.aspx");
                break;
            case "GoEdit":
                Response.Redirect(Action + "Edit.aspx?Id=" + e.CommandArgument);
                break;
            case "GoDelete":
                _db.e_EmployeeRole.DeleteOnSubmit(_db.e_EmployeeRole.FirstOrDefault(x => x.EmployeeRoleId == e.CommandArgument.ToString().ToInt16()));
                _db.SubmitChanges();
                AlertMsg.Text = JavascriptHelper.SuccessMsg("刪除成功");
                ListViewBind();
                break;
        }
    }
}
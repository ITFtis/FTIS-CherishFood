using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class Admin_EmployeeList : System.Web.UI.Page
{

    private int Nid => (Request.QueryString["nid"] ?? "0").ToInt16();
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
        var userResult = _db.e_Employees.AsEnumerable().Where(x => x.Account != "admin").Select(x => new
        {
            ReportTo = x.e_Employees1 != null ? (x.e_Employees1.Name) : "",
            x.Account,
            x.Name,
            x.Title,
            x.HireDate,
            x.Phone,
            x.EmployeeId,
            x.Status,
            btnCss = ((x.Status == 0 || x.Status == 1) ? "btn btn-danger" : "btn btn-success"),
            alertWord = ((x.Status == 0 || x.Status == 1) ? "return confirm('確定停用？')" : "return confirm('確定啟用？')"),
            EmployeeRolesName = string.Join(",", x.e_EmployeeRole_Mapping.Select(y => y.e_EmployeeRole.Name).ToList())
        });
        ListView1.DataSource = userResult.ToList();
        ListView1.DataBind();
    }
    protected void btn_OnCommand(object sender, CommandEventArgs e)
    {
        string Action = "Employee";
        switch (e.CommandName)
        {
            case "GoAdd":
                Response.Redirect(Action + "Add.aspx?nid=" + Nid);
                break;
            case "GoEdit":
                Response.Redirect(Action + "Edit.aspx?Id=" + e.CommandArgument + "&nid=" + Nid);
                break;
            case "GoDelete":
                _db.e_Employees.DeleteOnSubmit(_db.e_Employees.FirstOrDefault(x => x.EmployeeId == e.CommandArgument.ToString().ToInt16()));
                _db.SubmitChanges();
                AlertMsg.Text = JavascriptHelper.SuccessMsg("刪除成功");
                ListViewBind();
                break;
            case "GoStatus":
                var employees = _db.e_Employees.FirstOrDefault(x => x.EmployeeId == e.CommandArgument.ToString().ToInt16());
                var alertWord = (employees.Status == 0 || employees.Status == 1) ? "停用":"啟用";
                employees.Status = (employees.Status == 0 ? 2 : (employees.Status == 1 ? 3 : (employees.Status == 2 ? 0 : 1)));
                _db.SubmitChanges();
                AlertMsg.Text = JavascriptHelper.SuccessMsg($"{alertWord}成功");
                ListViewBind();
                break;
        }
    }

  
}
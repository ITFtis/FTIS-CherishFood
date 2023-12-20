using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class Identity_ActivityList : System.Web.UI.Page
{
    private int Nid => (Request.QueryString["nid"] ?? "0").ToInt32();
    DataClassesDataContext _db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            e_Employees employee = null;
            if (Session["AdminId"] != null)
            {
                hidAdminId.Value = Session["AdminId"].ToString();
                employee = _db.e_Employees.FirstOrDefault(x => x.EmployeeId == hidAdminId.Value.ToInt32());
            }
            ListViewBind();

            var allCity = JsonHelper.GetLocal<List<County>>(("TaiwanCountyData.json"));
            if (employee != null && employee.e_EmployeeRole_Mapping.Any(y => y.RoleId == 2))
            {
                allCity = allCity.Where(x => x.CityCode == employee.City).ToList();
            }

            //縣市別
            ddlCounty.Items.Clear();
            if (allCity.Count > 1) ddlCounty.Items.Add(new ListItem("--請選擇--", ""));
            ddlCounty.Items.AddRange(allCity.Select(x => new ListItem(x.CityName, x.CityCode)).ToArray());

            var actResult = _db.Activity.Where(x => true);
            if (employee != null && employee.e_EmployeeRole_Mapping.Any(y => y.RoleId == 2))
            {
                actResult = actResult.Where(x => x.County == employee.City);
            }
            btnGoadd.Visible = actResult.Select(x => x.County).Distinct().Count() < allCity.Count();
        }
    }
    public List<Activity> GetData()
    {
        var userResult = _db.Activity.Where(x => true);
        if (!string.IsNullOrEmpty(ddlCounty.SelectedValue))
        {
            userResult = userResult.Where(x => x.County == ddlCounty.SelectedValue);
        }

        var employee = _db.e_Employees.FirstOrDefault(x => x.EmployeeId == hidAdminId.Value.ToInt32());
        if (employee != null && employee.e_EmployeeRole_Mapping.Any(y => y.RoleId == 2))
        {
            userResult = userResult.Where(x => x.County == employee.City);
        }

        return userResult.OrderBy(x => x.County).ToList();
    }
    public void ListViewBind()
    {
        var userResult = GetData();
        ListView1.DataSource = userResult;
        ListView1.DataBind();
    }
    public string GetDisPic(object obj)
    {
        var p = "";
        if (!string.IsNullOrEmpty(obj.ToString()))
        {
            var files = obj.ToString().Split(',');
            p = "<img src='../WPContent/" + files.FirstOrDefault() + "' width='120' />";
        }
        return p;
    }
    protected void btn_OnCommand(object sender, CommandEventArgs e)
    {
        const string action = "Activity";
        switch (e.CommandName)
        {
            case "GoAdd":
                Response.Redirect(action + "Edit.aspx?nid=" + Nid);
                break;
            case "GoEdit":
                Response.Redirect(action + "Edit.aspx?CountyCode=" + e.CommandArgument + "&nid=" + Nid);
                break;
            case "GoDelete":
                var delId = e.CommandArgument.ToInt32();
                var delResult = _db.Activity.FirstOrDefault(x => x.Id == delId);
                if (delResult != null)
                {
                    _db.Activity.DeleteOnSubmit(delResult);
                    _db.SubmitChanges();
                    ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJs("刪除成功"));
                    ListViewBind();
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJs("刪除失敗"));
                    ListViewBind();
                }
                break;
            case "GoSearch":
                ListViewBind();
                break;
        }
    }
}
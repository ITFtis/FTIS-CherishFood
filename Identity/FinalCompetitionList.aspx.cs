using ICSharpCode.SharpZipLib.Zip;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class Identity_FinalCompetitionList : System.Web.UI.Page
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

            var allCity = JsonHelper.GetLocal<List<County>>(("TaiwanCountyData.json"));
            if (employee != null && employee.e_EmployeeRole_Mapping.Any(y => y.RoleId == 2))
            {
                allCity = allCity.Where(x => x.CityCode == employee.City).ToList();
            }
            //縣市別
            ddlCounty.Items.Clear();
            if (allCity.Count > 1) ddlCounty.Items.Add(new ListItem("--請選擇--", ""));
            ddlCounty.Items.AddRange(allCity.Select(x => new ListItem(x.CityName, x.CityCode)).ToArray());

            ListViewBind();

            var allCount = _db.FinalCompetition.Where(x => x.CompetitionGroup.TeamTypeId == 1);
            if (employee != null && employee.e_EmployeeRole_Mapping.Any(y => y.RoleId == 2))
            {
                allCount = allCount.Where(x => x.County == employee.City);
            }
            btnGoadd.Visible = allCount.Count() < allCity.Count * 3;
        }
    }
    public void ListViewBind()
    {
        var userResult = _db.FinalCompetition.Where(x => x.CompetitionGroup.TeamTypeId == 1).Select(x => new
        {
            x.Id,
            x.CountySort,
            x.County,
            x.CompetitionGroup.CountyName,
            x.CompetitionGroup.ContestCode,
            x.WorkFile,
            x.IntroduceFile,
            x.AuthorizeFile,
            x.RepresentativeConsent,
            MemberName = x.CompetitionGroup.CompetitionGroupMember.FirstOrDefault(o => o.IsLeader).Name,
        });

        if (!string.IsNullOrEmpty(ddlCounty.SelectedValue))
        {
            userResult = userResult.Where(x => x.County == ddlCounty.SelectedValue);
        }

        if (!string.IsNullOrEmpty(txtKey.Text))
        {
            userResult = userResult.Where(x => x.ContestCode.Contains(txtKey.Text));
        }

        var employee = _db.e_Employees.FirstOrDefault(x => x.EmployeeId == hidAdminId.Value.ToInt32());
        if (employee != null && employee.e_EmployeeRole_Mapping.Any(y => y.RoleId == 2))
        {
            userResult = userResult.Where(x => x.County == employee.City);
        }


        ListView1.DataSource = userResult.OrderBy(x => x.Id).ToList();
        ListView1.DataBind();
    }
    protected void btn_OnCommand(object sender, CommandEventArgs e)
    {
        const string action = "FinalCompetition";
        switch (e.CommandName)
        {
            case "GoAdd":
                Response.Redirect(action + "Edit.aspx?&nid=" + Nid);
                break;
            case "GoEdit":
                Response.Redirect(action + "Edit.aspx?id=" + e.CommandArgument + "&nid=" + Nid);
                break;
            case "GoSearch":
                ListViewBind();
                break;
            case "GoExcel":
                OutputExcel();
                break;
        }
    }

    private void OutputExcel()
    {
        string ExcelName = "食譜組決賽資料_" + DateTime.Today.ToString("yyyyMMdd");
        var userResult = _db.FinalCompetition.Where(x => x.CompetitionGroup.TeamTypeId == 1);

        if (!string.IsNullOrEmpty(ddlCounty.SelectedValue))
        {
            userResult = userResult.Where(x => x.CompetitionGroup.County == ddlCounty.SelectedValue);
        }

        if (!string.IsNullOrEmpty(txtKey.Text))
        {
            userResult = userResult.Where(x => x.CompetitionGroup.ContestCode.Contains(txtKey.Text));
        }

        var employee = _db.e_Employees.FirstOrDefault(x => x.EmployeeId == hidAdminId.Value.ToInt32());
        if (employee != null && employee.e_EmployeeRole_Mapping.Any(y => y.RoleId == 2))
        {
            userResult = userResult.Where(x => x.CompetitionGroup.County == employee.City);
        }

        var outputResult = userResult.ToList().AsEnumerable().
            Select(x => new
            {
                縣市 = x.CompetitionGroup.CountyName,
                組別 = GetGroup(x.CountySort),
                參賽編號 = x.CompetitionGroup.ContestCode,
                參賽者名稱 = x.CompetitionGroup.CompetitionGroupMember.FirstOrDefault(o => o.IsLeader).Name,
                參賽者身分證號 = x.CompetitionGroup.CompetitionGroupMember.FirstOrDefault(o => o.IsLeader).IdentityNo,
                參賽者生日 = x.CompetitionGroup.CompetitionGroupMember.FirstOrDefault(o => o.IsLeader).Birthday,
                參賽者電話 = x.CompetitionGroup.CompetitionGroupMember.FirstOrDefault(o => o.IsLeader).Phone,
                參賽者信箱 = x.CompetitionGroup.CompetitionGroupMember.FirstOrDefault(o => o.IsLeader).Mail,
                參賽者單位 = x.CompetitionGroup.CompetitionGroupMember.FirstOrDefault(o => o.IsLeader).UnitName,
                參賽者職稱年級 = x.CompetitionGroup.CompetitionGroupMember.FirstOrDefault(o => o.IsLeader).JobTitle,
            }).OrderByDescending(x => x.參賽編號);

        var excelData = ExcelHelper.LinqToDataTable(userResult);
        excelData.Columns["參賽者單位"].ColumnName = "參賽者單位/學校";
        excelData.Columns["參賽者職稱年級"].ColumnName = "參賽者職稱/年級";

        // 產生 Excel 資料流。 
        Response.Clear();
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        MemoryStream ms = ExcelHelper.RenderDataTableToExcel(excelData) as MemoryStream;
        // 設定強制下載標頭。 
        Response.AddHeader("Content-Disposition", string.Format("attachment; filename=" + ExcelName + ".xlsx"));
        // 輸出檔案。 
        Response.BinaryWrite(ms.ToArray());
        ms.Close();
        ms.Dispose();
        Response.Flush();
        Response.End();
    }

    public string GetFile(object obj)
    {
        var p = "";
        if (!string.IsNullOrEmpty(obj?.ToString()))
        {
            var files = obj.ToString().Split(',');
            p = $"<a href='../WPContent/{obj.ToString()}' target=\"_blank\" download class=\"btn btn-primary\">檔案</a>";
        }
        return p;
    }
    public string GetGroup(object obj)
    {
        var p = "";
        if (obj != null)
        {
            switch (obj.ToString().ToInt32())
            {
                case 1:
                    p = "決賽代表";
                    break;
                case 2:
                    p = "備取一";
                    break;
                case 3:
                    p = "備取二";
                    break;
            }
        }
        return p;
    }
}
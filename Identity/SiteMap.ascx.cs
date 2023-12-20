using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class Identity_SiteMap : System.Web.UI.UserControl
{
    private int Nid => (Request.QueryString["nid"] ?? "0").ToInt16();
    private int Id => (Request.QueryString["id"] ?? "0").ToInt16();
    private readonly DataClassesDataContext _db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Nid == 0) return;
        var nodeRow = _db.e_EmployeePermission.FirstOrDefault(x=>x.EmployeePermissionId==Nid);
        if (nodeRow == null) return;
        var siteString = new List<string>();
        Literal1.Text = nodeRow.Name;
        var fileName = System.IO.Path.GetFileName(Request.PhysicalPath);
        var method = "";
        if (fileName != null && fileName.Contains("Add"))
        {
            method = "新增";
        }
        else if (fileName != null && fileName.Contains("List"))
        {
            method = "列表";
        }
        else if (fileName != null && fileName.Contains("Edit"))
        {
            method = Id == 0 ? "新增" : "修改";
        }
        else if (fileName != null && fileName.Contains("Detail"))
        {
            method = "詳細資料";
        }
        siteString.Add($"<li class='active'>{method}</li>");
        siteString.Add($"<li ><a href='#'>{nodeRow.Name}</a></li>");
        var parentId = nodeRow.ParentId;
        while (parentId != 0)
        {
            var nodeParentRow = _db.e_EmployeePermission.FirstOrDefault(x=>x.EmployeePermissionId== parentId);
            if (nodeParentRow == null) continue;
            siteString.Add($"<li ><a href='#'>{nodeParentRow.Name}</a></li>");
            parentId = nodeParentRow.ParentId;
        }
        siteString.Add($"<li ><a href='index.aspx'><i class='fa fa-dashboard'></i>首頁</a></li>");
        siteString.Reverse();
        Literal2.Text = string.Join("", siteString);
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class Admin_MasterPage : System.Web.UI.MasterPage
{
    private int nid => (Request.QueryString["nid"] ?? "0").ToInt16();
    private readonly DataClassesDataContext _db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["AdminId"] != null)
            {
                var html = new StringBuilder();
                var employeeId = (int)Session["AdminId"];

                var user = _db.e_Employees.FirstOrDefault(x => x.EmployeeId == employeeId);
                if (user == null) return;
                LitUserName.Text = user.Name;
                Image1.Visible = false;
                if (!string.IsNullOrEmpty(user.PhotoPath))
                {
                    Image1.Visible = true;
                    Image1.ImageUrl = FileUploadHelper.WebPath + user.PhotoPath;
                }
                var menuResult = _db.e_EmployeeRole.Where(x => x.e_EmployeeRole_Mapping.Any(o => o.EmployeeId == employeeId)).SelectMany(x => x.e_Employee_RolePremission_Mapping.Select(o => o.e_EmployeePermission)).Distinct().ToList();
                foreach (var item in menuResult.Where(x => x.ParentId == 0).OrderBy(x => x.Sort))
                {
                    var secMenuResult = menuResult.Where(x => x.ParentId == item.EmployeePermissionId && x.e_Employee_RolePremission_Mapping.Any(o => o.e_EmployeeRole.e_EmployeeRole_Mapping.Any(p => p.EmployeeId == employeeId))).ToList();
                    html.Append($"<li class='{(secMenuResult.Any() ? "treeview" : "")}'>");
                    html.Append(!string.Equals(item.Links, "#")
                        ? $"<a href='{item.Links}{(item.Links.Contains('?') ? "&" : "?")}nid={item.EmployeePermissionId}'  class='" + (nid == item.EmployeePermissionId ? "onopen" : "unopen") + "' >"
                        : $"<a href='{item.Links}' >");
                    html.Append($"<i class='{(string.IsNullOrEmpty(item.Icon) ? item.Icon : "fa fa-odnoklassniki")}'></i><span>{item.Name}</span>");
                    if (secMenuResult.Any())
                    {
                        html.Append("<span class='pull-right-container'>");
                        html.Append("<i class='fa fa-angle-left pull-right'></i>");
                        html.Append("</span>");
                    }
                    html.Append("</a>");

                    if (secMenuResult.Any())
                    {
                        html.Append("<ul class='treeview-menu'>");
                        foreach (var sitem in secMenuResult.OrderBy(x => x.Sort))
                        {
                            var threeMenuResult = menuResult.Where(x => x.ParentId == sitem.EmployeePermissionId).ToList();
                            html.Append($"<li class='{(threeMenuResult.Any() ? "treeview" : "")}'>");
                            html.Append(!string.Equals(sitem.Links, "#")
                                ? $"<a href='{sitem.Links}{(sitem.Links.Contains('?') ? "&" : "?")}nid={sitem.EmployeePermissionId}'  class='" + (nid == sitem.EmployeePermissionId ? "onopen" : "unopen") + "' >"
                                : $"<a href='{sitem.Links}' >");
                            html.Append($"<i class='{(string.IsNullOrEmpty(sitem.Icon) ? sitem.Icon : "fa fa-odnoklassniki")}'></i><span>{sitem.Name}</span>");
                            if (threeMenuResult.Any())
                            {
                                html.Append("<span class='pull-right-container'>");
                                html.Append("<i class='fa fa-angle-left pull-right'></i>");
                                html.Append("</span>");
                            }
                            html.Append("</a>");
                            if (threeMenuResult.Any())
                            {
                                html.Append("<ul class='treeview-menu'>");
                                foreach (var titem in threeMenuResult.OrderBy(x => x.Sort))
                                {
                                    var fourMenuResult = menuResult.Where(x => x.ParentId == titem.EmployeePermissionId).ToList();
                                    html.Append($"<li class='{(fourMenuResult.Any() ? "treeview" : "")}'>");
                                    html.Append(!string.Equals(titem.Links, "#")
                                        ? $"<a href='{titem.Links}{(titem.Links.Contains('?') ? "&" : "?")}nid={titem.EmployeePermissionId}'  class='" + (nid == titem.EmployeePermissionId ? "onopen" : "unopen") + "' >"
                                        : $"<a href='{titem.Links}' >");
                                    html.Append($"<i class='{(string.IsNullOrEmpty(titem.Icon) ? titem.Icon : "fa fa-odnoklassniki")}'></i><span>{titem.Name}</span>");
                                    if (fourMenuResult.Any())
                                    {
                                        html.Append("<span class='pull-right-container'>");
                                        html.Append("<i class='fa fa-angle-left pull-right'></i>");
                                        html.Append("</span>");
                                    }
                                    html.Append("</a>");

                                }
                                html.Append("</ul>");
                            }
                        }
                        html.Append("</ul>");
                    }
                    html.Append("</li>");
                }
                litMenu.Text = html.ToString();
            }
            else
            {
                //Response.Redirect("Login.aspx?url=" + HttpUtility.UrlEncode(Request.Url.ToString()));
                Response.Redirect("Login.aspx");
            }
        }
    }


    protected void btnSignOut_OnClick(object sender, EventArgs e)
    {
        if (Session["AdminId"] != null)
        {
            var employeeId = (int)Session["AdminId"];
            var user = _db.e_Employees.FirstOrDefault(x => x.EmployeeId == employeeId);
            if (user == null) return;

            var sysLog = new SysLog()
            {
                Action = "logout",
                Account= user.Account,
                IPsource = GetIP(),
                CreateDate= DateTime.Now,
                IsSuccess=true,
            };
            _db.SysLog.InsertOnSubmit(sysLog);
            _db.SubmitChanges();
        }
            Session.Clear();
        Response.Redirect("Login.aspx");
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class Identity_BannerList : System.Web.UI.Page
{
    private int Nid => (Request.QueryString["nid"] ?? "0").ToInt32();
    DataClassesDataContext _db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ListViewBind();
        }
    }
    public List<Banner> GetData()
    {
        var userResult = _db.Banner.Where(x => true);

        if (!string.IsNullOrEmpty(txtSearchKey.Text))
        {
            userResult = userResult.Where(x => x.Title.Contains(txtSearchKey.Text));
        }
        return userResult.OrderBy(x => x.Sort).ThenByDescending(x => x.CreateDate).ToList();
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
        const string action = "Banner";

        switch (e.CommandName)
        {
            case "GoAdd":
                Response.Redirect(action + "Edit.aspx?nid=" + Nid);
                break;
            case "GoEdit":
                Response.Redirect(action + "Edit.aspx?Id=" + e.CommandArgument + "&nid=" + Nid);
                break;
            case "GoDelete":
                var delId = e.CommandArgument.ToString().ToInt16();
                var delResult = _db.Banner.FirstOrDefault(x => x.Id == delId);
                if (delResult != null)
                {
                    _db.Banner.DeleteOnSubmit(delResult);
                    _db.SubmitChanges();
                    ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJs("刪除成功"));
                    ListViewBind();
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJs("刪除失敗"));
                }
                break;
            case "GoSearch":
                ListViewBind();
                break;
            case "GoBack":
                Response.Redirect("indexList.aspx");
                break;
        }
    }
}
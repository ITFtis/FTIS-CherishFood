using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class Identity_BannerEdit : System.Web.UI.Page
{
    private int Nid => (Request.QueryString["nid"] ?? "0").ToInt32();
    private int Id => (Request.QueryString["Id"] ?? "0").ToInt16();

    DataClassesDataContext _db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        if (Session["AdminId"] != null)
        {
            hidAdminId.Value = Session["AdminId"].ToString();
        }

        if (Id == 0) return;
        var result = _db.Banner.FirstOrDefault(x => x.Id == Id);
        if (result == null) return;

        txtTitle.Text = result.Title;
        txtSort.Text = result.Sort.ToString();
        txtLinks.Text = result.UrlLink;
        txtPcPic.Text = result.PcPic;
        txtMobilePic.Text = result.MobilePic;
    }

    protected void btn_OnCommand(object sender, CommandEventArgs e)
    {
        var adminid = hidAdminId.Value;
        var action = "Banner";
        switch (e.CommandName)
        {
            case "Save":
                var newRow = _db.Banner.FirstOrDefault(x => x.Id == Id);
                if (newRow != null)
                {
                    newRow.Title = txtTitle.Text;
                    newRow.Sort = txtSort.Text.ToInt16();
                    newRow.UrlLink = txtLinks.Text;
                    newRow.PcPic = txtPcPic.Text;
                    newRow.MobilePic = txtMobilePic.Text;

                    newRow.ModifyDate = DateTime.Now;
                    newRow.ModifyUser = adminid;
                    _db.SubmitChanges();

                    JavascriptHelper.ShowMessage(Page, "更新成功", JavascriptHelper.MessageType.Success, action + "List.aspx?nid=" + Nid);
                }
                else
                {
                    newRow = new Banner();

                    newRow.Title = txtTitle.Text;
                    newRow.Sort = txtSort.Text.ToInt16();
                    newRow.UrlLink = txtLinks.Text;
                    newRow.PcPic = txtPcPic.Text;
                    newRow.MobilePic = txtMobilePic.Text;

                    newRow.CreateDate = DateTime.Now;
                    newRow.CreateUser = adminid;
                    newRow.ModifyDate = DateTime.Now;
                    newRow.ModifyUser = adminid;

                    _db.Banner.InsertOnSubmit(newRow);
                    _db.SubmitChanges();


                    JavascriptHelper.ShowMessage(Page, "新增成功", JavascriptHelper.MessageType.Success, action + "List.aspx?nid=" + Nid);
                }

                break;
            case "GoCancel":
                Response.Redirect(action + "List.aspx?nid=" + Nid);
                break;
        }
    }
}
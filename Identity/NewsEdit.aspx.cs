using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class Identity_NewsEdit : System.Web.UI.Page
{
    private int Nid => (Request.QueryString["nid"] ?? "0").ToInt32();
    private int Id => (Request.QueryString["Id"] ?? "0").ToInt32();
    DataClassesDataContext _db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        //類別
        // ddlBind();
        if (Session["AdminId"] != null)
        {
            hidAdminId.Value = Session["AdminId"].ToString();
        }

        if (Id == 0) return;
        var result = _db.News.FirstOrDefault(x => x.Id == Id);
        if (result == null) return;

        txtTitle.Text = result.Title;
        txtReleaseDate.Text = result.ReleaseDate.ToDateTimeString();
        txtContents.Text = result.Contents;
        txtSummary.Text = result.Summary;
        txtVideoUrl.Text = result.VideoUrl;
        txtMainPic.Text = result.MainPic;
    }

    protected void btn_OnCommand(object sender, CommandEventArgs e)
    {
        var adminid = hidAdminId.Value;
        var action = "News";
        switch (e.CommandName)
        {
            case "Save":
                if (Id != 0)
                {
                    var newRow = _db.News.FirstOrDefault(x => x.Id == Id);
                    if (newRow != null)
                    {
                        newRow.Title = txtTitle.Text;
                        newRow.Summary = txtSummary.Text;
                        newRow.ReleaseDate = txtReleaseDate.Text.ToDateTime().Value;
                        newRow.Contents = txtContents.Text;
                        newRow.VideoUrl = txtVideoUrl.Text;
                        newRow.MainPic = txtMainPic.Text;

                        newRow.ModifyDate = DateTime.Now;
                        newRow.ModifyUser = adminid;

                        _db.SubmitChanges();

                        JavascriptHelper.ShowMessage(Page, "更新成功", JavascriptHelper.MessageType.Success, action + "List.aspx?nid=" + Nid);
                    }

                }
                else
                {
                    var newRow = new News();
                    newRow.Title = txtTitle.Text;
                    newRow.ReleaseDate = txtReleaseDate.Text.ToDateTime().Value;
                    newRow.Contents = txtContents.Text;
                    newRow.Summary = txtSummary.Text;
                    newRow.VideoUrl = txtVideoUrl.Text;
                    newRow.MainPic = txtMainPic.Text;

                    newRow.CreateDate = DateTime.Now;
                    newRow.CreateUser = adminid;
                    newRow.ModifyDate = DateTime.Now;
                    newRow.ModifyUser = adminid;

                    _db.News.InsertOnSubmit(newRow);
                    _db.SubmitChanges();

                    JavascriptHelper.ShowMessage(Page, "新增成功", JavascriptHelper.MessageType.Success, action + "List.aspx?nid=" + Nid);
                }

                break;
            case "GoCancel":
                Response.Redirect(action + "List.aspx?nid=" + Nid);
                break;
        }
    }
    private string GetYoutubeUrl(string galleryUrl)
    {
        var _response = "https://www.youtube.com/embed/" + (galleryUrl.Split('/')[galleryUrl.Split('/').Count() - 1]).Split('=')[(galleryUrl.Split('/')[galleryUrl.Split('/').Count() - 1]).Split('=').Count() - 1];
        return _response;
    }
}
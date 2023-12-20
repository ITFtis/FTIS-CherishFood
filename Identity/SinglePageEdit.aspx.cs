using Antlr.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class Identity_SinglePageEdit : System.Web.UI.Page
{
    private int Nid => (Request.QueryString["nid"] ?? "0").ToInt32();
    private string _title => Request.QueryString["title"];
    DataClassesDataContext _db = new DataClassesDataContext();
    List<string> allowList = new List<string>() { "finals", "workshop", "contactus" };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        if (Session["AdminId"] != null)
        {
            hidAdminId.Value = Session["AdminId"].ToString();
        }

        if (!allowList.Contains(_title))
        {
            JavascriptHelper.ShowMessage(Page, "代碼錯誤", JavascriptHelper.MessageType.Error, "index.aspx");
            return;
        }
        else
        {
            var result = _db.SinglePage.FirstOrDefault(x => x.Title == _title);
            if (result == null) return;

            txtContents.Text = result.Contents;
        }
    }
    protected void btn_OnCommand(object sender, CommandEventArgs e)
    {
        var adminid = hidAdminId.Value;
        switch (e.CommandName)
        {
            case "Save":
                var newRow = _db.SinglePage.FirstOrDefault(x => x.Title == _title);
                if (newRow != null)
                {
                    newRow.Contents = txtContents.Text;
                    newRow.ModifyDate = DateTime.Now;
                    newRow.ModifyUser = adminid;

                    _db.SubmitChanges();
                    JavascriptHelper.ShowMessage(Page, "更新成功", JavascriptHelper.MessageType.Success, $"SinglePageEdit.aspx?title={_title}&nid={Nid}");
                }
                else
                {
                    newRow = new SinglePage();
                    newRow.Title = _title;
                    newRow.Contents = txtContents.Text;

                    newRow.CreateDate = DateTime.Now;
                    newRow.CreateUser = adminid;
                    newRow.ModifyDate = DateTime.Now;
                    newRow.ModifyUser = adminid;

                    _db.SinglePage.InsertOnSubmit(newRow);
                    _db.SubmitChanges();

                    JavascriptHelper.ShowMessage(Page, "更新成功", JavascriptHelper.MessageType.Success, $"SinglePageEdit.aspx?title={_title}&nid={Nid}");
                }

                break;
        }
    }
}
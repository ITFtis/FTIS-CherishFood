using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class Identity_SystemSettingEdit : System.Web.UI.Page
{
    private int nid => (Request.QueryString["nid"] ?? "0").ToInt32();
    private DataClassesDataContext _db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        if (Session["AdminId"] != null)
        {
            hidAdminId.Value = Session["AdminId"].ToString();
        }
        var result = _db.SystemSetting.FirstOrDefault(x => x.Title == "Header");
        if (result != null)
        {
            txtContents.Text = result.Contents;
        }
        var result2 = _db.SystemSetting.FirstOrDefault(x => x.Title == "GoogleAnalyticId");
        if (result2 != null)
        {
            txtGoogleAnalyticId.Text = result2.Contents;
        }
        //var result3 = _db.SystemSetting.FirstOrDefault(x => x.Id == "FacebookPixelId");
        //if (result3 != null)
        //{
        //    txtFacebookPixelId.Text = result3.Contents;
        //}
        //var result4 = _db.SystemSetting.FirstOrDefault(x => x.Id == "FacebookFanPage");
        //if (result4 != null)
        //{
        //    txtFacebookFanPage.Text = result4.Contents;
        //}
        //var result5 = _db.SystemSetting.FirstOrDefault(x => x.Id == "FacebookFanPageName");
        //if (result5 != null)
        //{
        //    txtFacebookFanPageName.Text = result5.Contents;
        //}
        //var result6 = _db.SystemSetting.FirstOrDefault(x => x.Id == "LineAccountId");
        //if (result6 != null)
        //{
        //    txtLineAccountId.Text = result6.Contents;
        //}
        //var result7 = _db.SystemSetting.FirstOrDefault(x => x.Id == "ServicePhone");
        //if (result7 != null)
        //{
        //    txtServicePhone.Text = result7.Contents;
        //}
    }
    protected void btn_OnCommand(object sender, CommandEventArgs e)
    {
        string Action = "SystemSettingEdit";
        int Id = e.CommandArgument.ToString().ToInt16();
        switch (e.CommandName)
        {
            case "GoSave":
                InsertOrUpdate();
                JavascriptHelper.ShowMessage(Page, "儲存成功", JavascriptHelper.MessageType.Success, Action + ".aspx?nid=" + nid);
                break;

        }
    }
    public void InsertOrUpdate()
    {
        var adminid = hidAdminId.Value;
        var result = _db.SystemSetting.FirstOrDefault(x => x.Title == "Header");
        if (result != null)
        {
            result.Contents = txtContents.Text;
            result.ModifyDate = DateTime.Now;
            result.ModifyUser = adminid;

            _db.SubmitChanges();

        }
        else
        {
            SystemSetting _systemSetting = new SystemSetting();
            _systemSetting.Title = "Header";
            _systemSetting.Contents = txtContents.Text;
            _systemSetting.CreateDate = DateTime.Now;
            _systemSetting.CreateUser = adminid;
            _systemSetting.ModifyDate = DateTime.Now;
            _systemSetting.ModifyUser = adminid;

            _db.SystemSetting.InsertOnSubmit(_systemSetting);
            _db.SubmitChanges();
        }

        var result2 = _db.SystemSetting.FirstOrDefault(x => x.Title == "GoogleAnalyticId");
        if (result2 != null)
        {
            result2.Contents = txtGoogleAnalyticId.Text;
            result2.ModifyDate = DateTime.Now;
            result2.ModifyUser = adminid;

            _db.SubmitChanges();

        }
        else
        {
            SystemSetting _systemSetting = new SystemSetting();
            _systemSetting.Title = "GoogleAnalyticId";
            _systemSetting.Contents = txtGoogleAnalyticId.Text;
            _systemSetting.CreateDate = DateTime.Now;
            _systemSetting.CreateUser = adminid;
            _systemSetting.ModifyDate = DateTime.Now;
            _systemSetting.ModifyUser = adminid;

            _db.SystemSetting.InsertOnSubmit(_systemSetting);
            _db.SubmitChanges();
        }

        //var result3 = _db.SystemSetting.FirstOrDefault(x => x.Title == "FacebookPixelId");
        //if (result3 != null)
        //{
        //    result3.Contents = txtFacebookPixelId.Text;
        //    _db.SubmitChanges();

        //}
        //else
        //{
        //    SystemSetting _systemSetting = new SystemSetting();
        //    _systemSetting.Title = "FacebookPixelId";
        //    _systemSetting.Contents = txtFacebookPixelId.Text;
        //    _db.SystemSetting.InsertOnSubmit(_systemSetting);
        //    _db.SubmitChanges();
        //}

        //var result4 = _db.SystemSetting.FirstOrDefault(x => x.Title == "FacebookFanPage");
        //if (result4 != null)
        //{
        //    result4.Contents = txtFacebookFanPage.Text;
        //    _db.SubmitChanges();

        //}
        //else
        //{
        //    SystemSetting _systemSetting = new SystemSetting();
        //    _systemSetting.Title = "FacebookFanPage";
        //    _systemSetting.Contents = txtFacebookFanPage.Text;
        //    _db.SystemSetting.InsertOnSubmit(_systemSetting);
        //    _db.SubmitChanges();
        //}

        //var result5 = _db.SystemSetting.FirstOrDefault(x => x.Title == "FacebookFanPageName");
        //if (result5 != null)
        //{
        //    result5.Contents = txtFacebookFanPageName.Text;
        //    _db.SubmitChanges();

        //}
        //else
        //{
        //    SystemSetting _systemSetting = new SystemSetting();
        //    _systemSetting.Title = "FacebookFanPageName";
        //    _systemSetting.Contents = txtFacebookFanPageName.Text;
        //    _db.SystemSetting.InsertOnSubmit(_systemSetting);
        //    _db.SubmitChanges();
        //}

        //var result6 = _db.SystemSetting.FirstOrDefault(x => x.Title == "LineAccountId");
        //if (result6 != null)
        //{
        //    result6.Contents = txtLineAccountId.Text;
        //    _db.SubmitChanges();

        //}
        //else
        //{
        //    SystemSetting _systemSetting = new SystemSetting();
        //    _systemSetting.Title = "LineAccountId";
        //    _systemSetting.Contents = txtLineAccountId.Text;
        //    _db.SystemSetting.InsertOnSubmit(_systemSetting);
        //    _db.SubmitChanges();
        //}

        //var result7 = _db.SystemSetting.FirstOrDefault(x => x.Title == "ServicePhone");
        //if (result7 != null)
        //{
        //    result7.Contents = txtServicePhone.Text;
        //    _db.SubmitChanges();

        //}
        //else
        //{
        //    SystemSetting _systemSetting = new SystemSetting();
        //    _systemSetting.Title = "ServicePhone";
        //    _systemSetting.Contents = txtServicePhone.Text;
        //    _db.SystemSetting.InsertOnSubmit(_systemSetting);
        //    _db.SubmitChanges();
        //}
    }
}
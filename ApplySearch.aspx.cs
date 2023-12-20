using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class ApplySearch : System.Web.UI.Page
{
    private int id => (Request.QueryString["Id"] ?? "0").ToInt32();
    DataClassesDataContext _db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        Page.Title = "各縣市初賽-我要報名-報名完成|首惜廚師甄選活動";

        var getActivity = _db.Activity.FirstOrDefault(x => x.Id == id);
        if (getActivity != null)
        {
            litCounty.Text = getActivity.CountyName;
            litSignRange.Text = $"{getActivity.SignupStartDate.ToString("MM/dd")}~{getActivity.SignupEndDate.ToString("MM/dd")}";
            litContactUser.Text = string.Join("<br/>", getActivity.ActivityContactUser.Select(o => $"{o.ContactName} {o.ContactPhone}"));

            litIntroduceFile.Text = GetFile(getActivity.IntroduceFile, 1);
            litOdtFile.Text = GetFile(getActivity.OdtFile, 4);
            litPreliminaryAwardFile.Text = GetFile(getActivity.PreliminaryAwardFile, 2);
            litPics.Text = GetFile(getActivity.Pics, 3);
            litApply.Text = $"<a href=\"Apply.aspx?Id={id}\" class=\"k-btn-apply\">我要報名</a>";

            rb_CheckedChanged(null, null);
        }
        else Response.Redirect("Preliminary.aspx");
    }
    public string GetFile(object filePath, int type)
    {
        var _filePath = "";
        if (filePath != null) _filePath = $"/WPContent/{filePath.ToString()}";

        var fileExist = false;
        if (!string.IsNullOrEmpty(_filePath)) fileExist = File.Exists(Server.MapPath(_filePath));

        switch (type)
        {
            case 1:
                if (fileExist) return $"<a href=\"{_filePath}\" class=\"k-btn-apply\" download target=\"_blank\">活動簡章</a>";
                else return "<a href=\"#\" class=\"k-btn-apply disabled\">活動簡章</a>";
            case 2:
                if (fileExist) return $"<a href=\"{_filePath}\" class=\"k-btn-apply k-btn-sm\" download target=\"_blank\">初賽<br>得獎名單</a>";
                else return "<a href=\"#\" class=\"k-btn-apply k-btn-sm disabled\">初賽<br>得獎名單</a>";
            case 3:
                if (fileExist) return $"<img src=\"{_filePath}\" alt=\"\">";
                else return "<img src=\"images/first_coming soon.png\" alt=\"\">";
            case 4:
                if (fileExist) return $"<a href=\"{_filePath}\" class=\"k-btn-apply\" download target=\"_blank\">活動簡章odt</a>";
                else return "<a href=\"#\" class=\"k-btn-apply disabled\">活動簡章odt</a>";
        }
        return "";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!rbCookbook.Checked && !rbLessonPlan.Checked)
        {
            ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJs("請選擇查詢組別"));
            return;
        }
        PlaceHolderSearch.Visible = false;
        PlaceHolderResult.Visible = true;

        var getActivity = _db.Activity.FirstOrDefault(x => x.Id == id);
        if (getActivity != null)
        {
            var teamType = rbCookbook.Checked ? 1 : 2;
            var checkRegist = _db.CompetitionGroupMember.FirstOrDefault(x => x.Name == txtName.Text && x.IdentityNo == txtIdmo.Text && x.CompetitionGroup.TeamTypeId == teamType && x.CompetitionGroup.County == getActivity.County);

            litMsg.Text = checkRegist != null ? "~您已報名成功~" : "查無報名資料";
            rbCookbook.Checked = false; 
            rbLessonPlan.Checked = false;
            txtName.Text = "";
            txtIdmo.Text = "";
        }
    }

    protected void rb_CheckedChanged(object sender, EventArgs e)
    {
        PlaceHolderSearch.Visible = true;
        PlaceHolderResult.Visible = false;
    }
}
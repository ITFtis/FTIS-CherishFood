using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class ApplyFinish : System.Web.UI.Page
{
    private int id => (Request.QueryString["Id"] ?? "0").ToInt32();
    DataClassesDataContext _db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        Page.Title = "各縣市初賽-我要報名-報名完成|首惜廚師甄選活動";

        var getRegist = _db.CompetitionGroup.FirstOrDefault(g => g.Id == id);
        if (getRegist != null)
        {
            var getActivity = _db.Activity.FirstOrDefault(x => x.County == getRegist.County);
            if (getActivity != null)
            {
                litCounty.Text = getActivity.CountyName;
                litSignRange.Text = $"{getActivity.SignupStartDate.ToString("MM/dd")}~{getActivity.SignupEndDate.ToString("MM/dd")}";
                litContactUser.Text = string.Join("<br/>", getActivity.ActivityContactUser.Select(o => $"{o.ContactName} {o.ContactPhone}"));

                litIntroduceFile.Text = GetFile(getActivity.IntroduceFile, 1);
                litOdtFile.Text = GetFile(getActivity.OdtFile, 4);
                litPreliminaryAwardFile.Text = GetFile(getActivity.PreliminaryAwardFile, 2);
                litPics.Text = GetFile(getActivity.Pics, 3);
                litApplySearch.Text = $"<a href=\"ApplySearch.aspx?Id={id}\" class=\"k-btn-apply\">報名查詢</a>";

                //rbCookbook.Checked = getRegist.TeamTypeId == 1;
                //rbLessonPlan.Checked = getRegist.TeamTypeId == 2;
                if (getRegist.TeamTypeId == 1)
                {
                    litGroupName.Text = "惜食料理食譜組";
                }
                if (getRegist.TeamTypeId == 2)
                {
                    litGroupName.Text = "惜食教案組";
                }

                litContestCode.Text = getRegist.ContestCode;
            }
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
}
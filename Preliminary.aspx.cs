using Model;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class Preliminary : System.Web.UI.Page
{
    DataClassesDataContext _db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "各縣市初賽|首惜廚師甄選活動";
        if (!IsPostBack)
        {
            ListViewBind();
        }
    }

    private void ListViewBind()
    {
        var allCity = JsonHelper.GetLocal<List<County>>(("TaiwanCountyData.json"));
        var activityList = (from ac in allCity
                            join _activity in _db.Activity.Where(x => true)
                            on ac.CityCode equals _activity.County into temp
                            from _activity in temp.DefaultIfEmpty()
                            select new
                            {
                                County = ac.CityCode,
                                CountyName = ac.CityName,
                                CountySort = ac.Sort,
                                _activity?.Id,
                                _activity?.Pics,
                                _activity?.SignupStartDate,
                                _activity?.SignupEndDate,
                                ContactUser = _activity != null ? string.Join("<br/>", _activity?.ActivityContactUser.Select(o => $"{o?.ContactName} {o?.ContactPhone}")) : "",
                                CanSign = _activity?.SignupStartDate <= DateTime.Now && DateTime.Now.Date <= _activity?.SignupEndDate,
                                _activity?.IntroduceFile,
                                _activity?.PreliminaryAwardFile,
                                _activity?.FileUploadDate
                            }).OrderByDescending(x => !string.IsNullOrEmpty(x.IntroduceFile)).ThenBy(x =>x.FileUploadDate ?? DateTime.MaxValue).ThenBy(x => x.CountySort).ToList();

        //var activityList = _db.Activity.Where(x => true).AsEnumerable().Select(x => new
        //{
        //    x.Id,
        //    x.Pics,
        //    x.County,
        //    x.CountyName,
        //    x.SignupStartDate,
        //    x.SignupEndDate,
        //    ContactUser = string.Join("<br/>", x.ActivityContactUser.Select(o => $"{o.ContactName} {o.ContactPhone}")),
        //    CanSign = x.SignupStartDate <= DateTime.Now && DateTime.Now.Date <= x.SignupEndDate,
        //    x.IntroduceFile,
        //    x.PreliminaryAwardFile,
        //}).ToList();

        ListViewCounty.DataSource = activityList;
        ListViewCounty.DataBind();
    }

    public string GetSign(object Id, object signupStartDate, object signupEndDate)
    {
        if (signupStartDate == null || signupEndDate == null) return "<a href=\"#\" class=\"k-btn-apply k-btn-sm  disabled\">尚未開放<br/>報名</a>";
        var _sStartDate = signupStartDate.ToString().ToDateTime().Value;
        var _sEndDate = signupEndDate.ToString().ToDateTime().Value;

        if (_sStartDate <= DateTime.Now && DateTime.Now.Date <= _sEndDate)
        {
            return $"<a href=\"Apply.aspx?Id={Id}\" class=\"k-btn-apply\">我要報名</a>";
        }
        else
        {
            if (DateTime.Now < _sStartDate) return $"<a href=\"#\" class=\"k-btn-apply k-btn-sm  disabled\">尚未開放<br/>報名</a>";
            if (_sEndDate < DateTime.Now.Date) return $"<a href=\"#\" class=\"k-btn-apply disabled\">報名截止</a>";
            return $"<a href=\"#\" class=\"k-btn-apply disabled\">我要報名</a>";
        }
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
        }
        return "";
    }
}
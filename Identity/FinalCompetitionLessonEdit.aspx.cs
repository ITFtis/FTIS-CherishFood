using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class Identity_FinalCompetitionLessonEdit : System.Web.UI.Page
{
    private int Nid => (Request.QueryString["nid"] ?? "0").ToInt32();
    private int id => (Request.QueryString["id"] ?? "0").ToInt32();

    DataClassesDataContext _db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            e_Employees employee = null;
            if (Session["AdminId"] != null)
            {
                hidAdminId.Value = Session["AdminId"].ToString();
                employee = _db.e_Employees.FirstOrDefault(x => x.EmployeeId == hidAdminId.Value.ToInt32());
            }

            ddlContestCodeBind(employee);

            var getAllCompetition = _db.FinalCompetition.FirstOrDefault(x => x.Id == id && x.CompetitionGroup.TeamTypeId == 2);
            if (getAllCompetition != null)
            {
                ddlContestCode.SelectedValue = getAllCompetition.CompetitionGroup.ContestCode;
                ddlContestCode_SelectedIndexChanged(null, null);
            }
        }
    }

    private void ddlContestCodeBind(e_Employees employee)
    {
        var getAllCompetition = _db.CompetitionGroup.Where(x => x.TeamTypeId == 2 && x.SignupStatus == true);
        if (employee != null && employee.e_EmployeeRole_Mapping.Any(y => y.RoleId == 2))
        {
            getAllCompetition = getAllCompetition.Where(x => x.County == employee.City);
        }

        ddlContestCode.Items.Clear();
        ddlContestCode.Items.Add(new ListItem("--請選擇--", ""));
        ddlContestCode.Items.AddRange(getAllCompetition.OrderBy(x => x.County).ThenBy(x => x.ContestCode).Select(x => new ListItem(x.ContestCode)).ToArray());
    }

    protected void btn_OnCommand(object sender, CommandEventArgs e)
    {
        var adminid = hidAdminId.Value;
        var action = "FinalCompetitionLesson";
        switch (e.CommandName)
        {
            case "Save":
                var _competition = _db.CompetitionGroup.FirstOrDefault(x => x.TeamTypeId == 2 && x.ContestCode == ddlContestCode.SelectedValue);
                var getAllCountyCompetition = _db.FinalCompetition.Where(x => x.CompetitionGroup.County == _competition.County && x.CompetitionGroup.TeamTypeId == 2).ToList();
                if (getAllCountyCompetition.Count == 3 && !getAllCountyCompetition.Any(x => x.CompetitionGroup.ContestCode == _competition.ContestCode))
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJsAndRedirect("資料已異動，該縣市已無法新增任何決賽組別", action + "List.aspx?nid=" + Nid));
                    return;
                }
                if (getAllCountyCompetition.Any(x => x.CountySort == ddlFinalGroup.SelectedValue.ToInt32()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJs($"資料已異動，該縣市已無法新增決賽組別 {ddlFinalGroup.SelectedItem.Text}"));
                    ddlContestCode_SelectedIndexChanged(null, null);
                    return;
                }
                if (string.IsNullOrEmpty(ddlFinalGroup.SelectedValue))
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJs($"請選擇決賽組別"));
                    return;
                }
                var finalCompetition = _db.FinalCompetition.FirstOrDefault(x => x.CompetitionGroup.ContestCode == ddlContestCode.SelectedValue);
                if (finalCompetition != null)
                {
                    finalCompetition.CountySort = ddlFinalGroup.SelectedValue.ToInt32();
                    finalCompetition.Title = txtTitle.Text;
                    finalCompetition.WorkFile = txtFinalWorkFile.Text;
                    finalCompetition.AuthorizeFile = txtFinalAuthorizeFile.Text;
                    finalCompetition.IntroduceFile = txtFinalIntroduceFile.Text;
                    finalCompetition.RepresentativeConsent = txtFinalRepresentativeConsent.Text;
                    finalCompetition.TeachingFile = txtTeachingFile.Text;
                    finalCompetition.TeachingVideoFile = txtTeachingVideoFile.Text;

                    finalCompetition.ModifyDate = DateTime.Now;
                    finalCompetition.ModifyUser = hidAdminId.Value;
                }
                else
                {
                    finalCompetition = new FinalCompetition();

                    finalCompetition.CompetitionId = _competition.Id;
                    finalCompetition.County = _competition.County;
                    finalCompetition.CountySort = ddlFinalGroup.SelectedValue.ToInt32();
                    finalCompetition.Title = txtTitle.Text;
                    finalCompetition.WorkFile = txtFinalWorkFile.Text;

                    finalCompetition.AuthorizeFile = txtFinalAuthorizeFile.Text;
                    finalCompetition.IntroduceFile = txtFinalIntroduceFile.Text;
                    finalCompetition.RepresentativeConsent = txtFinalRepresentativeConsent.Text;
                    finalCompetition.TeachingFile = txtTeachingFile.Text;
                    finalCompetition.TeachingVideoFile = txtTeachingVideoFile.Text;

                    finalCompetition.CreateDate = DateTime.Now;
                    finalCompetition.CreateUser = hidAdminId.Value;
                    finalCompetition.ModifyDate = DateTime.Now;
                    finalCompetition.ModifyUser = hidAdminId.Value;
                    _db.FinalCompetition.InsertOnSubmit(finalCompetition);
                }
                _db.SubmitChanges();
                JavascriptHelper.ShowMessage(Page, "更新成功", JavascriptHelper.MessageType.Success, action + "List.aspx?nid=" + Nid);
                break;
            case "GoCancel":
                Response.Redirect(action + "List.aspx?nid=" + Nid);
                break;
        }
    }

    protected void ddlContestCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        var getCompetition = _db.CompetitionGroup.FirstOrDefault(x => x.TeamTypeId == 2 && x.ContestCode == ddlContestCode.SelectedValue);

        var memberData = getCompetition.CompetitionGroupMember.AsEnumerable().Select(x => new
        {
            x.Name,
            x.IdentityNo,
            x.Birthday,
            x.Phone,
            x.Mail,
            x.UnitName,
            x.JobTitle,
            MemberTitle = x.IsLeader ? "隊長資料" : "隊員資料",
            x.SignArea,
            Sort = x.IsLeader ? 0 : x.Id,
        }).ToList();
        ListView1.DataSource = memberData;
        ListView1.DataBind();

        ddlFinalGroupBind(getCompetition);

        var finalData = getCompetition.FinalCompetition.FirstOrDefault();
        if (finalData != null)
        {
            txtTitle.Text = finalData.Title;
            txtFinalWorkFile.Text = finalData.WorkFile;
            txtFinalIntroduceFile.Text = finalData.IntroduceFile;
            txtFinalAuthorizeFile.Text = finalData.AuthorizeFile;
            txtFinalRepresentativeConsent.Text = finalData.RepresentativeConsent;
            txtTeachingFile.Text = finalData.TeachingFile;
            txtTeachingVideoFile.Text = finalData.TeachingVideoFile;
        }
    }

    private void ddlFinalGroupBind(CompetitionGroup _competition)
    {
        ddlFinalGroup.Items.Clear();
        var finalGroup = new List<ListItem>()
        {
            new ListItem("決賽代表","1"),
            new ListItem("備取一","2"),
            new ListItem("備取二","3"),
        };

        var getAllCountyCompetition = _db.FinalCompetition.Where(x => x.CompetitionGroup.County == _competition.County && x.CompetitionGroup.TeamTypeId == 2).ToList();
        if (getAllCountyCompetition.Count == 3 && !getAllCountyCompetition.Any(x => x.CompetitionGroup.ContestCode == _competition.ContestCode))
        {
            ddlFinalGroup.Items.Add(new ListItem("該縣市已無組別可選", ""));
            ddlFinalGroup.Enabled = false;
        }
        else
        {
            var otherCompetition = getAllCountyCompetition.Where(x => x.CompetitionGroup.ContestCode != _competition.ContestCode).ToList();
            if (otherCompetition.Any()) finalGroup = finalGroup.Where(x => !otherCompetition.Select(o => o.CountySort.ToString()).Contains(x.Value)).ToList();

            ddlFinalGroup.Items.AddRange(finalGroup.ToArray());
            ddlFinalGroup.Enabled = true;
        }
    }

    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        var thisItem = e.Item;
        var hidSignArea = (HiddenField)thisItem.FindControl("hidSignArea");
        var listSignArea = (ListBox)thisItem.FindControl("listSignArea");

        if (hidSignArea != null && listSignArea != null)
        {
            var signArea = (hidSignArea.Value ?? "").Split(',').ToList();
            foreach (ListItem ro in listSignArea.Items)
            {
                ro.Selected = signArea.Contains(ro.Value);
            }
        }
    }
}
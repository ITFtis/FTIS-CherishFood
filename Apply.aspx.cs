using Antlr.Runtime.Misc;
using Microsoft.AspNetCore.Http;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Tool;

public partial class Apply : System.Web.UI.Page
{
    private int id => (Request.QueryString["Id"] ?? "0").ToInt32();
    DataClassesDataContext _db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        Page.Title = "各縣市初賽-我要報名|首惜廚師甄選活動";

        var getActivity = _db.Activity.FirstOrDefault(x => x.Id == id);
        if (getActivity != null)
        {
            if (DateTime.Now < getActivity.SignupStartDate)
                ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJsAndRedirect("尚未開放報名", "Preliminary.aspx"));
            if (getActivity.SignupEndDate < DateTime.Now.Date)
                ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJsAndRedirect("報名已截止", "Preliminary.aspx"));

            var loginAccount = Request.Cookies["ChiefChef"];
            if (loginAccount != null && loginAccount.Value != null)
            {
                var checkAcc = _db.CompetitionGroup.FirstOrDefault(x => x.Account == loginAccount.Value);
                if (checkAcc.County != getActivity.County)
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJsAndRedirect($"您已報名{checkAcc.CountyName}比賽，無法報名其他縣市", "Preliminary.aspx"));
                }
            }

            litCounty.Text = getActivity.CountyName;
            litSignRange.Text = $"{getActivity.SignupStartDate.ToString("MM/dd")}~{getActivity.SignupEndDate.ToString("MM/dd")}";
            litContactUser.Text = string.Join("<br/>", getActivity.ActivityContactUser.Select(o => $"{o.ContactName} {o.ContactPhone}"));


            litIntroduceFile.Text = GetFile(getActivity.IntroduceFile, 1);
            litOdtFile.Text = GetFile(getActivity.OdtFile, 4);
            litPreliminaryAwardFile.Text = GetFile(getActivity.PreliminaryAwardFile, 2);
            litPics.Text = GetFile(getActivity.Pics, 3);
            litApplySearch.Text = $"<a href=\"ApplySearch.aspx?Id={id}\" class=\"k-btn-apply\">報名查詢</a>";

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

    protected void rb_CheckedChanged(object sender, EventArgs e)
    {
        PlaceHolderCookBookMember.Visible = rbCookbook.Checked;

        PlaceHolderPlanNum.Visible = !rbCookbook.Checked;
        //PlaceHolderTeachingFile.Visible = !rbCookbook.Checked;
        PlaceHolderTeachingFile.Visible = false;
        PlaceHolderPlanMember.Visible = !rbCookbook.Checked;

        var loginAccount = Request.Cookies["ChiefChef"];
        if (loginAccount != null && loginAccount.Value != null)
        {
            PlaceHolderLogin.Visible = !_db.CompetitionGroup.Any(x => x.Account == loginAccount.Value);
        }

        txtTitle.Text = "";
        litWorkFile.Text = "";
        litAuthorizeFile.Text = "";
        litTeachingFile.Text = "";
        litRepresentativeConsent.Text = "";


        if (rbCookbook.Checked)
        {
            litGroupName.Text = "惜食料理食譜組";
            litWorkFileTitle.Text = "初賽食譜表";

            txtCbName.Text = "";
            txtCbIdno.Text = "";
            txtCbPhone.Text = "";
            txtCbEmail.Text = "";
            txtCbBirthDay.Text = "";
            txtCbUnit.Text = "";
            txtCbJobTitle.Text = "";
            txtCbName.Text = "";

            if (loginAccount != null && loginAccount.Value != null)
            {
                var getAcc = _db.CompetitionGroup.FirstOrDefault(x => x.Account == loginAccount.Value && x.TeamTypeId == 1);
                if (getAcc != null && getAcc.CompetitionGroupMember.Any())
                {
                    txtTitle.Text = getAcc.Title;
                    litWorkFile.Text = $"<a href='/WPContent/{getAcc.WorkFile}' target='_blank' download>{getAcc.WorkFile.Split('/')[(getAcc.WorkFile.Split('/').Count() - 1)]}</a>";
                    litAuthorizeFile.Text = $"<a href='/WPContent/{getAcc.AuthorizeFile}' target='_blank' download>{getAcc.AuthorizeFile.Split('/')[(getAcc.AuthorizeFile.Split('/').Count() - 1)]}</a>";
                    if (!string.IsNullOrEmpty(getAcc.RepresentativeConsent)) litRepresentativeConsent.Text = $"<a href='/WPContent/{getAcc.RepresentativeConsent}' target='_blank' download>{getAcc.RepresentativeConsent.Split('/')[(getAcc.RepresentativeConsent.Split('/').Count() - 1)]}</a>";

                    SetLeaderIdno(getAcc.Account);
                    var cbData = getAcc.CompetitionGroupMember.FirstOrDefault();
                    txtCbName.Text = cbData.Name;
                    txtCbPhone.Text = cbData.Phone;
                    txtCbEmail.Text = cbData.Mail;
                    txtCbBirthDay.Text = cbData.Birthday.ToString("yyyy-MM-dd");
                    txtCbUnit.Text = cbData.UnitName;
                    txtCbJobTitle.Text = cbData.JobTitle;
                    var signArea = (cbData.SignArea ?? "").Split(',').ToList();
                    foreach (ListItem ro in listCbSignArea.Items)
                    {
                        ro.Selected = signArea.Contains(ro.Value);
                    }

                    SetEnable(getAcc.SignupStatus != true);
                }
                else
                {
                    getAcc = _db.CompetitionGroup.FirstOrDefault(x => x.Account == loginAccount.Value && x.TeamTypeId == 2);
                    if (getAcc != null)
                    {
                        SetLeaderIdno(getAcc.Account);
                        if (getAcc.CompetitionGroupMember.Any(x => x.IsLeader))
                        {
                            var cbData = getAcc.CompetitionGroupMember.FirstOrDefault(x => x.IsLeader);
                            txtCbName.Text = cbData.Name;
                            txtCbPhone.Text = cbData.Phone;
                            txtCbEmail.Text = cbData.Mail;
                            txtCbBirthDay.Text = cbData.Birthday.ToString("yyyy-MM-dd");
                            txtCbUnit.Text = cbData.UnitName;
                            txtCbJobTitle.Text = cbData.JobTitle;
                            var signArea = (cbData.SignArea ?? "").Split(',').ToList();
                            foreach (ListItem ro in listCbSignArea.Items)
                            {
                                ro.Selected = signArea.Contains(ro.Value);
                            }
                        }
                    }
                    SetEnable(true);
                }
            }
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "InitFiles", "<script>setSelect2()</script>", false);
        }
        if (rbLessonPlan.Checked)
        {
            litGroupName.Text = "惜食教案組";
            litWorkFileTitle.Text = "初賽教案表";

            if (loginAccount != null && loginAccount.Value != null)
            {
                var getAcc = _db.CompetitionGroup.FirstOrDefault(x => x.Account == loginAccount.Value && x.TeamTypeId == 2);
                if (getAcc != null && getAcc.CompetitionGroupMember.Any())
                {
                    SetLeaderIdno(getAcc.Account);
                    txtTitle.Text = getAcc.Title;
                    litWorkFile.Text = $"<a href='/WPContent/{getAcc.WorkFile}' target='_blank' download>{getAcc.WorkFile.Split('/')[(getAcc.WorkFile.Split('/').Count() - 1)]}</a>";
                    litAuthorizeFile.Text = $"<a href='/WPContent/{getAcc.AuthorizeFile}' target='_blank' download>{getAcc.AuthorizeFile.Split('/')[(getAcc.AuthorizeFile.Split('/').Count() - 1)]}</a>";
                    litTeachingFile.Text = $"<a href='/WPContent/{getAcc.TeachingFile}' target='_blank' download>{getAcc.TeachingFile.Split('/')[(getAcc.TeachingFile.Split('/').Count() - 1)]}</a>";
                    if (!string.IsNullOrEmpty(getAcc.RepresentativeConsent)) litRepresentativeConsent.Text = $"<a href='/WPContent/{getAcc.RepresentativeConsent}' target='_blank' download>{getAcc.RepresentativeConsent.Split('/')[(getAcc.RepresentativeConsent.Split('/').Count() - 1)]}</a>";

                    rbPlanNumOne.Checked = getAcc.CompetitionGroupMember.Count == 1;
                    rbPlanNumTwo.Checked = getAcc.CompetitionGroupMember.Count == 2;
                    rbPlanNumThree.Checked = getAcc.CompetitionGroupMember.Count == 3;

                    var leaderData = getAcc.CompetitionGroupMember.FirstOrDefault(x => x.IsLeader);
                    txtPmLeaderName.Text = leaderData.Name;
                    txtPmLeaderPhone.Text = leaderData.Phone;
                    txtPmLeaderEmail.Text = leaderData.Mail;
                    txtPmLeaderBirthday.Text = leaderData.Birthday.ToString("yyyy-MM-dd");
                    txtPmLeaderUnit.Text = leaderData.UnitName;
                    txtPmLeaderJobTitle.Text = leaderData.JobTitle;
                    var signArea = (leaderData.SignArea ?? "").Split(',').ToList();
                    foreach (ListItem ro in listPmLeaderSignArea.Items)
                    {
                        ro.Selected = signArea.Contains(ro.Value);
                    }

                    if (getAcc.CompetitionGroupMember.Count > 1)
                    {
                        var memberOneData = getAcc.CompetitionGroupMember.Where(x => !x.IsLeader).OrderBy(x => x.Id).FirstOrDefault();
                        txtPmFirstName.Text = memberOneData.Name;
                        txtPmFirstIdno.Text = memberOneData.IdentityNo;
                        txtPmFirstPhone.Text = memberOneData.Phone;
                        txtPmFirstEmail.Text = memberOneData.Mail;
                        txtPmFirstBirthday.Text = memberOneData.Birthday.ToString("yyyy-MM-dd");
                        txtPmFirstUnit.Text = memberOneData.UnitName;
                        txtPmFirstJobTitle.Text = memberOneData.JobTitle;
                        txtPmFirstIdno_TextChanged(null, null);
                    }
                    if (getAcc.CompetitionGroupMember.Count > 2)
                    {
                        var memberTwoData = getAcc.CompetitionGroupMember.Where(x => !x.IsLeader).OrderBy(x => x.Id).Skip(1).FirstOrDefault();
                        txtPmSecondName.Text = memberTwoData.Name;
                        txtPmSecondIdno.Text = memberTwoData.IdentityNo;
                        txtPmSecondPhone.Text = memberTwoData.Phone;
                        txtPmSecondEmail.Text = memberTwoData.Mail;
                        txtPmSecondBirthday.Text = memberTwoData.Birthday.ToString("yyyy-MM-dd");
                        txtPmSecondUnit.Text = memberTwoData.UnitName;
                        txtPmSecondJobTitle.Text = memberTwoData.JobTitle;
                        txtPmSecondIdno_TextChanged(null, null);
                    }

                    SetEnable(getAcc.SignupStatus != true);
                }
                else
                {
                    getAcc = _db.CompetitionGroup.FirstOrDefault(x => x.Account == loginAccount.Value && x.TeamTypeId == 1);
                    if (getAcc != null)
                    {
                        SetLeaderIdno(getAcc.Account);
                        if (getAcc.CompetitionGroupMember.Any(x => x.IsLeader))
                        {
                            var leaderData = getAcc.CompetitionGroupMember.FirstOrDefault(x => x.IsLeader);
                            txtPmLeaderName.Text = leaderData.Name;
                            txtPmLeaderPhone.Text = leaderData.Phone;
                            txtPmLeaderEmail.Text = leaderData.Mail;
                            txtPmLeaderBirthday.Text = leaderData.Birthday.ToString("yyyy-MM-dd");
                            txtPmLeaderUnit.Text = leaderData.UnitName;
                            txtPmLeaderJobTitle.Text = leaderData.JobTitle;
                            var signArea = (leaderData.SignArea ?? "").Split(',').ToList();
                            foreach (ListItem ro in listPmLeaderSignArea.Items)
                            {
                                ro.Selected = signArea.Contains(ro.Value);
                            }
                        }
                    }
                    SetEnable(true);
                }
            }

            rbPlanNum_CheckedChanged(null, null);
        }
    }

    public void SetEnable(bool _enabled)
    {
        if (rbCookbook.Checked)
        {
            txtCbName.Enabled = _enabled;
            txtCbIdno.Enabled = _enabled;
            txtCbPhone.Enabled = _enabled;
            txtCbEmail.Enabled = _enabled;
            txtCbBirthDay.Enabled = _enabled;
            txtCbUnit.Enabled = _enabled;
            txtCbJobTitle.Enabled = _enabled;
            if(_enabled) listCbSignArea.Attributes.Remove("disabled"); 
            else listCbSignArea.Attributes.Add("disabled", "");

            txtTitle.Enabled = _enabled;
            FileUploadWorkFile.Enabled = _enabled;
            FileUploadAuthorizeFile.Enabled = _enabled;
            FileUploadRepresentativeConsent.Enabled = _enabled;

            PlaceHolderCheck.Visible = _enabled;
            Button1.Visible = _enabled;
        }
        if (rbLessonPlan.Checked)
        {
            txtPmLeaderName.Enabled = _enabled;
            txtPmLeaderIdno.Enabled = _enabled;
            txtPmLeaderPhone.Enabled = _enabled;
            txtPmLeaderEmail.Enabled = _enabled;
            txtPmLeaderBirthday.Enabled = _enabled;
            txtPmLeaderUnit.Enabled = _enabled;
            txtPmLeaderJobTitle.Enabled = _enabled;
            if (_enabled) listPmLeaderSignArea.Attributes.Remove("disabled"); 
            else listPmLeaderSignArea.Attributes.Add("disabled", "");

            txtPmFirstName.Enabled = _enabled;
            txtPmFirstIdno.Enabled = _enabled;
            txtPmFirstPhone.Enabled = _enabled;
            txtPmFirstEmail.Enabled = _enabled;
            txtPmFirstBirthday.Enabled = _enabled;
            txtPmFirstUnit.Enabled = _enabled;
            txtPmFirstJobTitle.Enabled = _enabled;

            txtPmSecondName.Enabled = _enabled;
            txtPmSecondIdno.Enabled = _enabled;
            txtPmSecondPhone.Enabled = _enabled;
            txtPmSecondEmail.Enabled = _enabled;
            txtPmSecondBirthday.Enabled = _enabled;
            txtPmSecondUnit.Enabled = _enabled;
            txtPmSecondJobTitle.Enabled = _enabled;

            rbPlanNumOne.Enabled = _enabled;
            rbPlanNumTwo.Enabled = _enabled;
            rbPlanNumThree.Enabled = _enabled;

            txtTitle.Enabled = _enabled;
            FileUploadWorkFile.Enabled = _enabled;
            FileUploadAuthorizeFile.Enabled = _enabled;
            FileUploadTeachingFile.Enabled = _enabled;
            FileUploadRepresentativeConsent.Enabled = _enabled;

            PlaceHolderCheck.Visible = _enabled;
            Button1.Visible = _enabled;
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        var getActivity = _db.Activity.FirstOrDefault(x => x.Id == id);
        if (getActivity != null)
        {
            if (DateTime.Now < getActivity.SignupStartDate)
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "InitFiles", JavascriptHelper.AlertJsAndRedirect("尚未開放報名", "Preliminary.aspx"), false);
                return;
            }
            if (getActivity.SignupEndDate < DateTime.Now.Date)
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "InitFiles", JavascriptHelper.AlertJsAndRedirect("報名已截止", "Preliminary.aspx"), false);
                return;
            }
        }
        else Response.Redirect("Preliminary.aspx");
        if (!chbKnowAll.Checked || !chbDataCollect.Checked || !chbDataUser.Checked)
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "InitFiles", JavascriptHelper.AlertJs("請確認個資同意事項"), false);
            return;
        }
        if (PlaceHolderLogin.Visible)
        {
            if (txtPassword.Text != txtPasswordConfirm.Text)
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "InitFiles", JavascriptHelper.AlertJs("兩次密碼輸入不相同"), false);
                return;
            }
            if (!PwdStrengthHelper.StrongPassword(txtPassword.Text))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "InitFiles", JavascriptHelper.AlertJs("密碼不符合規則(限8~12碼且混合數字與大小寫英文)"), false);
                return;
            }
        }
        var checkFile = true;
        var memberAcc = "";
        var loginAccount = Request.Cookies["ChiefChef"];
        if (loginAccount != null && loginAccount.Value != null)
        {
            memberAcc = loginAccount.Value;
            if (rbCookbook.Checked) checkFile = !_db.CompetitionGroup.Any(x => x.Account == loginAccount.Value && x.TeamTypeId == 1);
            if (rbLessonPlan.Checked) checkFile = !_db.CompetitionGroup.Any(x => x.Account == loginAccount.Value && x.TeamTypeId == 2);
        }
        if (checkFile)
        {
            var _checkAge = CheckAgeFile();
            if (!FileUploadWorkFile.HasFile || !FileUploadAuthorizeFile.HasFile || (!FileUploadTeachingFile.HasFile && PlaceHolderTeachingFile.Visible) || !_checkAge)
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "InitFiles", JavascriptHelper.AlertJs($"請確認所有檔案皆已上傳{(!_checkAge ? "(若有未滿18歲成員需上傳法定代理人同意書)" : "")}"), false);
                return;
            }
        }

        if (!CheckAllIdno())
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "InitFiles", JavascriptHelper.AlertJs("身分證/居留證號不正確"), false);
            return;
        }
        var errMsg = CheckAllRegist(getActivity.County);
        if (!string.IsNullOrEmpty(errMsg))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "InitFiles", JavascriptHelper.AlertJs(errMsg), false);
            return;
        }

        if (rbCookbook.Checked)
        {
            var registData = _db.CompetitionGroup.FirstOrDefault(x => x.Account == memberAcc && x.TeamTypeId == 1);
            if (!PlaceHolderLogin.Visible && registData != null)
            {
                int serialNum = registData.ContestCode.Substring(2, 3).ToInt32();
                var _contestCode = registData.ContestCode;

                var _workFileName = registData.WorkFile;
                var _authorizeFileName = registData.AuthorizeFile;
                var _representativeConsentName = registData.RepresentativeConsent;

                if (FileUploadWorkFile.HasFile) _workFileName = UploadFile(FileUploadWorkFile, $"C{_contestCode}{serialNum.ToString("00")}.pdf", "CookBookWorkFile");
                if (FileUploadAuthorizeFile.HasFile) _authorizeFileName = UploadFile(FileUploadAuthorizeFile, $"W{_contestCode}{serialNum.ToString("00")}.pdf", "CookBookAuthorizeFile");
                if (FileUploadRepresentativeConsent.HasFile) _representativeConsentName = UploadFile(FileUploadRepresentativeConsent, $"A{_contestCode}{serialNum.ToString("00")}.pdf", "CookBookRepresentativeConsent");

                registData.SignupStatus = null;
                registData.WorkFile = _workFileName;
                registData.AuthorizeFile = _authorizeFileName;
                registData.RepresentativeConsent = _representativeConsentName;
                registData.ModifyDate = DateTime.Now;
                registData.ModifyUser = txtCbName.Text;

                var memberData = registData.CompetitionGroupMember.FirstOrDefault();
                memberData.Name = txtCbName.Text;
                memberData.IdentityNo = hidCbIdno.Value;
                memberData.Birthday = txtCbBirthDay.Text.ToDateTime().Value;
                memberData.Phone = txtCbPhone.Text;
                memberData.Mail = txtCbEmail.Text;
                memberData.UnitName = txtCbUnit.Text;
                memberData.JobTitle = txtCbJobTitle.Text;
                memberData.SignArea = string.Join(",", listCbSignArea.Items.Cast<ListItem>().Where(item => item.Selected).Select(x => x.Value).ToList());
                memberData.ModifyDate = DateTime.Now;
                memberData.ModifyUser = txtCbName.Text;
                _db.SubmitChanges();

                Response.Redirect($"ApplyFinish.aspx?Id={registData.Id}");
            }
            else
            {
                var account = txtAccount.Text;
                var pwd = txtPassword.Text;
                if (loginAccount != null && loginAccount.Value != null)
                {
                    registData = _db.CompetitionGroup.FirstOrDefault(x => x.Account == memberAcc);
                    if (registData != null)
                    {
                        account = registData.Account;
                        pwd = registData.LoginPass;
                    }
                }
                int serialNum = _db.CompetitionGroup.Where(x => x.County == getActivity.County && x.TeamTypeId == 1).Count() + 1;
                var _contestCode = $"{getActivity.County}F{serialNum.ToString("000")}";
                var _newRegist = new CompetitionGroup()
                {
                    Account = account,
                    LoginPass = pwd,
                    County = getActivity.County,
                    CountyName = getActivity.CountyName,
                    TeamTypeId = 1,
                    ContestCode = _contestCode,
                    Title = txtTitle.Text,
                    CreateDate = DateTime.Now,
                    CreateUser = txtCbName.Text,
                    ModifyDate = DateTime.Now,
                    ModifyUser = txtCbName.Text,
                };
                _db.CompetitionGroup.InsertOnSubmit(_newRegist);
                _db.SubmitChanges();

                var _newMember = new CompetitionGroupMember()
                {
                    CompetitionId = _newRegist.Id,
                    Name = txtCbName.Text,
                    IdentityNo = hidCbIdno.Value,
                    Birthday = txtCbBirthDay.Text.ToDateTime().Value,
                    Phone = txtCbPhone.Text,
                    Mail = txtCbEmail.Text,
                    UnitName = txtCbUnit.Text,
                    JobTitle = txtCbJobTitle.Text,
                    SignArea = string.Join(",", listCbSignArea.Items.Cast<ListItem>().Where(item => item.Selected).Select(x => x.Value).ToList()),
                IsLeader = true,
                    CreateDate = DateTime.Now,
                    CreateUser = txtCbName.Text,
                    ModifyDate = DateTime.Now,
                    ModifyUser = txtCbName.Text,
                };
                _db.CompetitionGroupMember.InsertOnSubmit(_newMember);
                _db.SubmitChanges();

                var _workFileName = UploadFile(FileUploadWorkFile, $"C{_contestCode}{serialNum.ToString("00")}.pdf", "CookBookWorkFile");
                var _authorizeFileName = UploadFile(FileUploadAuthorizeFile, $"W{_contestCode}{serialNum.ToString("00")}.pdf", "CookBookAuthorizeFile");
                var _representativeConsentName = "";
                if (FileUploadRepresentativeConsent.HasFile) _representativeConsentName = UploadFile(FileUploadRepresentativeConsent, $"A{_contestCode}{serialNum.ToString("00")}.pdf", "CookBookRepresentativeConsent");

                _newRegist.WorkFile = _workFileName;
                _newRegist.AuthorizeFile = _authorizeFileName;
                _newRegist.RepresentativeConsent = _representativeConsentName;
                _db.SubmitChanges();

                Response.Redirect($"ApplyFinish.aspx?Id={_newRegist.Id}");
            }
        }
        else if (rbLessonPlan.Checked)
        {
            var registData = _db.CompetitionGroup.FirstOrDefault(x => x.Account == memberAcc && x.TeamTypeId == 2);
            if (!PlaceHolderLogin.Visible && registData != null)
            {
                int serialNum = registData.ContestCode.Substring(2, 3).ToInt32();
                var _contestCode = registData.ContestCode;

                var _workFileName = registData.WorkFile;
                var _authorizeFileName = registData.AuthorizeFile;
                var _representativeConsentName = registData.RepresentativeConsent;

                if (FileUploadWorkFile.HasFile) _workFileName = UploadFile(FileUploadWorkFile, $"C{_contestCode}{serialNum.ToString("00")}.pdf", "LessonPlanWorkFile");
                if (FileUploadAuthorizeFile.HasFile) _authorizeFileName = UploadFile(FileUploadAuthorizeFile, $"W{_contestCode}{serialNum.ToString("00")}.pdf", "LessonPlanAuthorizeFile");
                if (FileUploadRepresentativeConsent.HasFile) _representativeConsentName = UploadFile(FileUploadRepresentativeConsent, $"A{_contestCode}{serialNum.ToString("00")}.pdf", "LessonPlanRepresentativeConsent");

                //var _teachingFileName = UploadFile(FileUploadTeachingFile, $"P{_contestCode}{serialNum.ToString("00")}.pdf", "LessonPlanTeachingFile");
                var _teachingFileName = "";

                registData.SignupStatus = null;
                registData.WorkFile = _workFileName;
                registData.AuthorizeFile = _authorizeFileName;
                registData.TeachingFile = _teachingFileName;
                registData.RepresentativeConsent = _representativeConsentName;
                registData.ModifyDate = DateTime.Now;
                registData.ModifyUser = txtCbName.Text;

                var memberLeaderData = registData.CompetitionGroupMember.FirstOrDefault(x => x.IsLeader);
                memberLeaderData.Name = txtPmLeaderName.Text;
                memberLeaderData.IdentityNo = hidPmLeaderIdno.Value;
                memberLeaderData.Birthday = txtPmLeaderBirthday.Text.ToDateTime().Value;
                memberLeaderData.Phone = txtPmLeaderPhone.Text;
                memberLeaderData.Mail = txtPmLeaderEmail.Text;
                memberLeaderData.UnitName = txtPmLeaderUnit.Text;
                memberLeaderData.JobTitle = txtPmLeaderJobTitle.Text;
                memberLeaderData.SignArea = string.Join(",", listPmLeaderSignArea.Items.Cast<ListItem>().Where(item => item.Selected).Select(x => x.Value).ToList());
                memberLeaderData.ModifyDate = DateTime.Now;
                memberLeaderData.ModifyUser = txtPmLeaderName.Text;
                _db.SubmitChanges();

                if (PlaceHolderFirst.Visible)
                {
                    if (registData.CompetitionGroupMember.Count > 1)
                    {
                        var memberOneData = registData.CompetitionGroupMember.Where(x => !x.IsLeader).OrderBy(x => x.Id).FirstOrDefault();
                        memberOneData.Name = txtPmFirstName.Text;
                        memberOneData.IdentityNo = hidPmFirstIdno.Value;
                        memberOneData.Phone = txtPmFirstPhone.Text;
                        memberOneData.Mail = txtPmFirstEmail.Text;
                        memberOneData.Birthday = txtPmFirstBirthday.Text.ToDateTime().Value;
                        memberOneData.UnitName = txtPmFirstUnit.Text;
                        memberOneData.JobTitle = txtPmFirstJobTitle.Text;
                        memberOneData.ModifyDate = DateTime.Now;
                        memberOneData.ModifyUser = txtPmLeaderName.Text;
                    }
                    else
                    {
                        _db.CompetitionGroupMember.InsertOnSubmit(new CompetitionGroupMember
                        {
                            CompetitionId = registData.Id,
                            Name = txtPmFirstName.Text,
                            IdentityNo = hidPmFirstIdno.Value,
                            Birthday = txtPmFirstBirthday.Text.ToDateTime().Value,
                            Phone = txtPmFirstPhone.Text,
                            Mail = txtPmFirstEmail.Text,
                            UnitName = txtPmFirstUnit.Text,
                            JobTitle = txtPmFirstJobTitle.Text,
                            IsLeader = false,
                            CreateDate = DateTime.Now,
                            CreateUser = txtPmLeaderName.Text,
                            ModifyDate = DateTime.Now,
                            ModifyUser = txtPmLeaderName.Text,
                        });
                    }
                }
                else
                {
                    var memberDelData = registData.CompetitionGroupMember.Where(x => !x.IsLeader).OrderBy(x => x.Id).ToList();
                    _db.CompetitionGroupMember.DeleteAllOnSubmit(memberDelData);
                }

                if (PlaceHolderSecond.Visible)
                {
                    if (registData.CompetitionGroupMember.Count > 2)
                    {
                        var memberSecondData = registData.CompetitionGroupMember.Where(x => !x.IsLeader).OrderBy(x => x.Id).Skip(1).FirstOrDefault();
                        memberSecondData.Name = txtPmSecondName.Text;
                        memberSecondData.IdentityNo = hidPmSecondIdno.Value;
                        memberSecondData.Phone = txtPmSecondPhone.Text;
                        memberSecondData.Mail = txtPmSecondEmail.Text;
                        memberSecondData.Birthday = txtPmSecondBirthday.Text.ToDateTime().Value;
                        memberSecondData.UnitName = txtPmSecondUnit.Text;
                        memberSecondData.JobTitle = txtPmSecondJobTitle.Text;
                        memberSecondData.ModifyDate = DateTime.Now;
                        memberSecondData.ModifyUser = txtPmLeaderName.Text;
                    }
                    else
                    {
                        _db.CompetitionGroupMember.InsertOnSubmit(new CompetitionGroupMember
                        {
                            CompetitionId = registData.Id,
                            Name = txtPmSecondName.Text,
                            IdentityNo = hidPmSecondIdno.Value,
                            Birthday = txtPmSecondBirthday.Text.ToDateTime().Value,
                            Phone = txtPmSecondPhone.Text,
                            Mail = txtPmSecondEmail.Text,
                            UnitName = txtPmSecondUnit.Text,
                            JobTitle = txtPmSecondJobTitle.Text,
                            IsLeader = false,
                            CreateDate = DateTime.Now,
                            CreateUser = txtPmLeaderName.Text,
                            ModifyDate = DateTime.Now,
                            ModifyUser = txtPmLeaderName.Text,
                        });
                    }
                }
                else
                {
                    var memberDelData = registData.CompetitionGroupMember.Where(x => !x.IsLeader).OrderBy(x => x.Id).Skip(1).ToList();
                    _db.CompetitionGroupMember.DeleteAllOnSubmit(memberDelData);
                }
                _db.SubmitChanges();
                Response.Redirect($"ApplyFinish.aspx?Id={registData.Id}");
            }
            else
            {
                var account = txtAccount.Text;
                var pwd = txtPassword.Text;
                if (loginAccount != null && loginAccount.Value != null)
                {
                    registData = _db.CompetitionGroup.FirstOrDefault(x => x.Account == memberAcc);
                    if (registData != null)
                    {
                        account = registData.Account;
                        pwd = registData.LoginPass;
                    }
                }
                int serialNum = _db.CompetitionGroup.Where(x => x.County == getActivity.County && x.TeamTypeId == 2).Count() + 1;
                var _contestCode = $"{getActivity.County}T{serialNum.ToString("000")}";
                var _newRegist = new CompetitionGroup()
                {
                    Account = account,
                    LoginPass = pwd,
                    County = getActivity.County,
                    CountyName = getActivity.CountyName,
                    TeamTypeId = 2,
                    ContestCode = _contestCode,
                    Title = txtTitle.Text,
                    CreateDate = DateTime.Now,
                    CreateUser = txtPmLeaderName.Text,
                    ModifyDate = DateTime.Now,
                    ModifyUser = txtPmLeaderName.Text,
                };
                _db.CompetitionGroup.InsertOnSubmit(_newRegist);
                _db.SubmitChanges();

                var _newMemberList = new List<CompetitionGroupMember>();
                _newMemberList.Add(new CompetitionGroupMember
                {
                    CompetitionId = _newRegist.Id,
                    Name = txtPmLeaderName.Text,
                    IdentityNo = hidPmLeaderIdno.Value,
                    Birthday = txtPmLeaderBirthday.Text.ToDateTime().Value,
                    Phone = txtPmLeaderPhone.Text,
                    Mail = txtPmLeaderEmail.Text,
                    UnitName = txtPmLeaderUnit.Text,
                    JobTitle = txtPmLeaderJobTitle.Text,
                    SignArea = string.Join(",", listPmLeaderSignArea.Items.Cast<ListItem>().Where(item => item.Selected).Select(x => x.Value).ToList()),
                    IsLeader = true,
                    CreateDate = DateTime.Now,
                    CreateUser = txtPmLeaderName.Text,
                    ModifyDate = DateTime.Now,
                    ModifyUser = txtPmLeaderName.Text,
                });
                if (PlaceHolderFirst.Visible)
                    _newMemberList.Add(new CompetitionGroupMember
                    {
                        CompetitionId = _newRegist.Id,
                        Name = txtPmFirstName.Text,
                        IdentityNo = hidPmFirstIdno.Value,
                        Birthday = txtPmFirstBirthday.Text.ToDateTime().Value,
                        Phone = txtPmFirstPhone.Text,
                        Mail = txtPmFirstEmail.Text,
                        UnitName = txtPmFirstUnit.Text,
                        JobTitle = txtPmFirstJobTitle.Text,
                        IsLeader = false,
                        CreateDate = DateTime.Now,
                        CreateUser = txtPmLeaderName.Text,
                        ModifyDate = DateTime.Now,
                        ModifyUser = txtPmLeaderName.Text,
                    });
                if (PlaceHolderSecond.Visible)
                    _newMemberList.Add(new CompetitionGroupMember
                    {
                        CompetitionId = _newRegist.Id,
                        Name = txtPmSecondName.Text,
                        IdentityNo = hidPmSecondIdno.Value,
                        Birthday = txtPmSecondBirthday.Text.ToDateTime().Value,
                        Phone = txtPmSecondPhone.Text,
                        Mail = txtPmSecondEmail.Text,
                        UnitName = txtPmSecondUnit.Text,
                        JobTitle = txtPmSecondJobTitle.Text,
                        IsLeader = false,
                        CreateDate = DateTime.Now,
                        CreateUser = txtPmLeaderName.Text,
                        ModifyDate = DateTime.Now,
                        ModifyUser = txtPmLeaderName.Text,
                    });
                _db.CompetitionGroupMember.InsertAllOnSubmit(_newMemberList);
                _db.SubmitChanges();

                var _workFileName = UploadFile(FileUploadWorkFile, $"C{_contestCode}{serialNum.ToString("00")}.pdf", "LessonPlanWorkFile");
                var _authorizeFileName = UploadFile(FileUploadAuthorizeFile, $"W{_contestCode}{serialNum.ToString("00")}.pdf", "LessonPlanAuthorizeFile");
                //var _teachingFileName = UploadFile(FileUploadTeachingFile, $"P{_contestCode}{serialNum.ToString("00")}.pdf", "LessonPlanTeachingFile");
                var _teachingFileName = "";
                var _representativeConsentName = "";
                if (FileUploadRepresentativeConsent.HasFile) _representativeConsentName = UploadFile(FileUploadRepresentativeConsent, $"A{_contestCode}{serialNum.ToString("00")}.pdf", "LessonPlanRepresentativeConsent");

                _newRegist.WorkFile = _workFileName;
                _newRegist.AuthorizeFile = _authorizeFileName;
                _newRegist.TeachingFile = _teachingFileName;
                _newRegist.RepresentativeConsent = _representativeConsentName;
                _db.SubmitChanges();

                Response.Redirect($"ApplyFinish.aspx?Id={_newRegist.Id}");
            }
        }
    }

    private string UploadFile(FileUpload fileUpload, string newFileName, string filePath)
    {
        if (!Directory.Exists(Config.BaseDir + filePath + "/"))
        {
            Directory.CreateDirectory(Config.BaseDir + filePath + "/");
        }

        fileUpload.SaveAs(Path.Combine(Config.BaseDir + filePath + "/", newFileName));
        return $"{filePath}/{newFileName}";
    }

    #region 檢核
    private string CheckAllRegist(string CountyCode)
    {
        var _errMsg = "";

        var memberAcc = "";
        var loginAccount = Request.Cookies["ChiefChef"];
        if (loginAccount != null && loginAccount.Value != null)
        {
            memberAcc = loginAccount.Value;
        }
        if (PlaceHolderLogin.Visible)
        {
            if (rbCookbook.Checked)
            {
                var registData = _db.CompetitionGroupMember.FirstOrDefault(x => x.IdentityNo == hidCbIdno.Value);
                if (registData != null)
                {
                    if (registData.CompetitionGroup.TeamTypeId == 1)
                        return "您已成功報名過此組別";
                    if (registData.CompetitionGroup.TeamTypeId == 2 && registData.CompetitionGroup.County != CountyCode)
                        return $"您已成功報名過{registData.CompetitionGroup.CountyName}惜食教案組，無法報名其他縣市惜食料理食譜組";
                }
            }
            else if (rbLessonPlan.Checked)
            {
                var registLeaderData = _db.CompetitionGroupMember.FirstOrDefault(x => x.IdentityNo == hidPmLeaderIdno.Value);
                if (registLeaderData != null)
                {
                    if (registLeaderData.CompetitionGroup.TeamTypeId == 2)
                        _errMsg += $"{txtPmLeaderName.Text}已成功報名過此組別";
                    else if (registLeaderData.CompetitionGroup.TeamTypeId == 1 && registLeaderData.CompetitionGroup.County != CountyCode)
                        _errMsg += $"{txtPmLeaderName.Text}已成功報名過{registLeaderData.CompetitionGroup.CountyName}惜食料理食譜組，無法報名其他縣市惜食教案組";
                }

                if (PlaceHolderFirst.Visible)
                {
                    var registFirstData = _db.CompetitionGroupMember.FirstOrDefault(x => x.IdentityNo == hidPmFirstIdno.Value);
                    if (registFirstData != null)
                    {
                        if (registFirstData.CompetitionGroup.TeamTypeId == 2)
                            _errMsg += $"{(string.IsNullOrEmpty(_errMsg) ? "" : "\r\n")}{txtPmFirstName.Text}已成功報名過此組別";
                        else if (registFirstData.CompetitionGroup.TeamTypeId == 1 && registFirstData.CompetitionGroup.County != CountyCode)
                            _errMsg += $"{(string.IsNullOrEmpty(_errMsg) ? "" : "\r\n")}{txtPmFirstName.Text}已成功報名過{registFirstData.CompetitionGroup.CountyName}惜食料理食譜組，無法報名其他縣市惜食教案組";
                    }
                }

                if (PlaceHolderSecond.Visible)
                {
                    var registSecondData = _db.CompetitionGroupMember.FirstOrDefault(x => x.IdentityNo == hidPmSecondIdno.Value);
                    if (registSecondData != null)
                    {
                        if (registSecondData.CompetitionGroup.TeamTypeId == 2)
                            _errMsg += $"{(string.IsNullOrEmpty(_errMsg) ? "" : "\r\n")}{txtPmSecondName.Text}已成功報名過此組別";
                        else if (registSecondData.CompetitionGroup.TeamTypeId == 1 && registSecondData.CompetitionGroup.County != CountyCode)
                            _errMsg += $"{(string.IsNullOrEmpty(_errMsg) ? "" : "\r\n")}{txtPmSecondName.Text}已成功報名過{registSecondData.CompetitionGroup.CountyName}惜食料理食譜組，無法報名其他縣市惜食教案組";
                    }
                }
            }
        }
        else
        {
            if (rbLessonPlan.Checked)
            {
                var registLeaderData = _db.CompetitionGroupMember.FirstOrDefault(x => x.IdentityNo == hidPmLeaderIdno.Value && x.CompetitionGroup.Account != hidPmLeaderIdno.Value);
                if (registLeaderData != null)
                {
                    if (registLeaderData.CompetitionGroup.TeamTypeId == 2)
                        _errMsg += $"{txtPmLeaderName.Text}已成功報名過此組別";
                    else if (registLeaderData.CompetitionGroup.TeamTypeId == 1 && registLeaderData.CompetitionGroup.County != CountyCode)
                        _errMsg += $"{txtPmLeaderName.Text}已成功報名過{registLeaderData.CompetitionGroup.CountyName}惜食料理食譜組，無法報名其他縣市惜食教案組";
                }

                if (PlaceHolderFirst.Visible)
                {
                    var registFirstData = _db.CompetitionGroupMember.FirstOrDefault(x => x.IdentityNo == hidPmFirstIdno.Value && x.CompetitionGroup.Account != hidPmLeaderIdno.Value);
                    if (registFirstData != null)
                    {
                        if (registFirstData.CompetitionGroup.TeamTypeId == 2)
                            _errMsg += $"{(string.IsNullOrEmpty(_errMsg) ? "" : "\r\n")}{txtPmFirstName.Text}已成功報名過此組別";
                        else if (registFirstData.CompetitionGroup.TeamTypeId == 1 && registFirstData.CompetitionGroup.County != CountyCode)
                            _errMsg += $"{(string.IsNullOrEmpty(_errMsg) ? "" : "\r\n")}{txtPmFirstName.Text}已成功報名過{registFirstData.CompetitionGroup.CountyName}惜食料理食譜組，無法報名其他縣市惜食教案組";
                    }
                }

                if (PlaceHolderSecond.Visible)
                {
                    var registSecondData = _db.CompetitionGroupMember.FirstOrDefault(x => x.IdentityNo == hidPmSecondIdno.Value && x.CompetitionGroup.Account != hidPmLeaderIdno.Value);
                    if (registSecondData != null)
                    {
                        if (registSecondData.CompetitionGroup.TeamTypeId == 2)
                            _errMsg += $"{(string.IsNullOrEmpty(_errMsg) ? "" : "\r\n")}{txtPmSecondName.Text}已成功報名過此組別";
                        else if (registSecondData.CompetitionGroup.TeamTypeId == 1 && registSecondData.CompetitionGroup.County != CountyCode)
                            _errMsg += $"{(string.IsNullOrEmpty(_errMsg) ? "" : "\r\n")}{txtPmSecondName.Text}已成功報名過{registSecondData.CompetitionGroup.CountyName}惜食料理食譜組，無法報名其他縣市惜食教案組";
                    }
                }
            }
        }

        return _errMsg;
    }
    private bool CheckAllIdno()
    {
        if (rbCookbook.Checked && !CheckIdno(hidCbIdno.Value)) return false;
        if (rbLessonPlan.Checked)
        {
            if (!CheckIdno(hidPmLeaderIdno.Value)) return false;
            if (!CheckIdno(hidPmFirstIdno.Value) && PlaceHolderFirst.Visible) return false;
            if (!CheckIdno(hidPmSecondIdno.Value) && PlaceHolderSecond.Visible) return false;
        }
        return true;
    }
    public bool CheckIdno(string str)
    {
        string sex = "";
        string nationality = "";
        if (str == null || string.IsNullOrWhiteSpace(str) || str.Length != 10)
        {
            return false;
        }
        char[] pidCharArray = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        str = str.ToUpper(); // 轉換大寫
        char[] strArr = str.ToCharArray(); // 字串轉成char陣列
        int verifyNum = 0;

        string pat = @"[A-Z]{1}[1-2]{1}[0-9]{8}";
        // Instantiate the regular expression object.
        Regex rTaiwan = new Regex(pat, RegexOptions.IgnoreCase);
        // Match the regular expression pattern against a text string.
        Match mTaiwan = rTaiwan.Match(str);
        // 檢查身分證字號
        if (mTaiwan.Success)
        {
            // 原身分證英文字應轉換為10~33，這裡直接作個位數*9+10
            int[] pidIDInt = { 1, 10, 19, 28, 37, 46, 55, 64, 39, 73, 82, 2, 11, 20, 48, 29, 38, 47, 56, 65, 74, 83, 21, 3, 12, 30 };
            // 第一碼
            verifyNum = verifyNum + pidIDInt[Array.BinarySearch(pidCharArray, strArr[0])];
            // 第二~九碼
            for (int i = 1, j = 8; i < 9; i++, j--)
            {
                verifyNum += Convert.ToInt32(strArr[i].ToString(), 10) * j;
            }
            // 檢查碼
            verifyNum = (10 - (verifyNum % 10)) % 10;
            bool ok = verifyNum == Convert.ToInt32(strArr[9].ToString(), 10);
            if (ok)
            {
                // 判斷性別 & 國籍
                sex = "男";
                if (strArr[1] == '2') sex = "女";
                nationality = "本國籍";
            }
            return ok;
        }

        // 檢查統一證號(居留證)
        verifyNum = 0;
        pat = @"[A-Z]{1}[A-D]{1}[0-9]{8}";
        // Instantiate the regular expression object.
        Regex rForeign = new Regex(pat, RegexOptions.IgnoreCase);
        // Match the regular expression pattern against a text string.
        Match mForeign = rForeign.Match(str);
        if (mForeign.Success)
        {
            // 原居留證第一碼英文字應轉換為10~33，十位數*1，個位數*9，這裡直接作[(十位數*1) mod 10] + [(個位數*9) mod 10]
            int[] pidResidentFirstInt = { 1, 10, 9, 8, 7, 6, 5, 4, 9, 3, 2, 2, 11, 10, 8, 9, 8, 7, 6, 5, 4, 3, 11, 3, 12, 10 };
            // 第一碼
            verifyNum += pidResidentFirstInt[Array.BinarySearch(pidCharArray, strArr[0])];
            // 原居留證第二碼英文字應轉換為10~33，並僅取個位數*6，這裡直接取[(個位數*6) mod 10]
            int[] pidResidentSecondInt = { 0, 8, 6, 4, 2, 0, 8, 6, 2, 4, 2, 0, 8, 6, 0, 4, 2, 0, 8, 6, 4, 2, 6, 0, 8, 4 };
            // 第二碼
            verifyNum += pidResidentSecondInt[Array.BinarySearch(pidCharArray, strArr[1])];
            // 第三~八碼
            for (int i = 2, j = 7; i < 9; i++, j--)
            {
                verifyNum += Convert.ToInt32(strArr[i].ToString(), 10) * j;
            }
            // 檢查碼
            verifyNum = (10 - (verifyNum % 10)) % 10;
            bool ok = verifyNum == Convert.ToInt32(strArr[9].ToString(), 10);
            if (ok)
            {
                // 判斷性別 & 國籍
                sex = "男";
                if (strArr[1] == 'B' || strArr[1] == 'D') sex = "女";
                nationality = "外籍人士";
                if (strArr[1] == 'A' || strArr[1] == 'B') nationality += "(臺灣地區無戶籍國民、大陸地區人民、港澳居民)";
            }
            return ok;
        }
        return false;
    }
    private bool CheckAgeFile()
    {
        if (!FileUploadRepresentativeConsent.HasFiles)
        {
            var ageLimit = DateTime.Now.AddYears(-18);
            if (rbCookbook.Checked && txtCbBirthDay.Text.ToDateTime() > ageLimit) return false;
            if (rbLessonPlan.Checked)
            {
                if (txtPmLeaderBirthday.Text.ToDateTime() > ageLimit) return false;
                if (txtPmFirstBirthday.Text.ToDateTime() > ageLimit && PlaceHolderFirst.Visible) return false;
                if (txtPmSecondBirthday.Text.ToDateTime() > ageLimit && PlaceHolderSecond.Visible) return false;
            }
        }
        return true;
    }
    #endregion

    protected void rbPlanNum_CheckedChanged(object sender, EventArgs e)
    {
        PlaceHolderFirst.Visible = rbPlanNumTwo.Checked || rbPlanNumThree.Checked;
        PlaceHolderSecond.Visible = rbPlanNumThree.Checked;
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "InitFiles", "<script>setSelect2()</script>", false);
    }

    protected void txtAccount_TextChanged(object sender, EventArgs e)
    {
        SetLeaderIdno(txtAccount.Text);

        var registData = _db.CompetitionGroup.FirstOrDefault(x => x.Account == txtAccount.Text);
        if (registData != null)
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "InitFiles", JavascriptHelper.AlertJsAndRedirect("此帳號已成為會員，若要報名請登入後繼續", "Login.aspx"), false);
        }
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "InitFiles", "<script>setSelect2()</script>", false);
    }
    public void SetLeaderIdno(string finalText)
    {
        if (!string.IsNullOrEmpty(finalText))
        {
            var showText = "";
            for (int i = 0; i < finalText.Length; i++)
            {
                if (i < 4 || i > 6) showText += finalText[i];
                else showText += "*";
            }
            hidCbIdno.Value = finalText;
            hidPmLeaderIdno.Value = finalText;

            txtCbIdno.Text = showText;
            txtPmLeaderIdno.Text = showText;
        }
    }

    protected void txtPmSecondIdno_TextChanged(object sender, EventArgs e)
    {
        var originWord = hidPmSecondIdno.Value;
        var newText = txtPmSecondIdno.Text;
        var finalText = "";
        var showText = "";
        for (int i = 0; i < newText.Length; i++)
        {
            var thisWord = newText[i];
            if (thisWord != '*')
                finalText += thisWord;
            else
            {
                if (originWord.Length >= (i + 1))
                    finalText += originWord[i];
                else finalText += thisWord;
            }
        }
        for (int i = 0; i < finalText.Length; i++)
        {
            if (i < 4 || i > 6) showText += finalText[i];
            else showText += "*";
        }
        hidPmSecondIdno.Value = finalText;
        txtPmSecondIdno.Text = showText;
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "InitFiles", "<script>setSelect2()</script>", false);
    }

    protected void txtPmFirstIdno_TextChanged(object sender, EventArgs e)
    {
        var originWord = hidPmFirstIdno.Value;
        var newText = txtPmFirstIdno.Text;
        var finalText = "";
        var showText = "";
        for (int i = 0; i < newText.Length; i++)
        {
            var thisWord = newText[i];
            if (thisWord != '*')
                finalText += thisWord;
            else
            {
                if (originWord.Length >= (i + 1))
                    finalText += originWord[i];
                else finalText += thisWord;
            }
        }
        for (int i = 0; i < finalText.Length; i++)
        {
            if (i < 4 || i > 6) showText += finalText[i];
            else showText += "*";
        }
        hidPmFirstIdno.Value = finalText;
        txtPmFirstIdno.Text = showText;
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "InitFiles", "<script>setSelect2()</script>", false);
    }
}
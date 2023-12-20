﻿using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Tool;

public partial class Identity_CompetitionGroupEdit : System.Web.UI.Page
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

            var allCity = JsonHelper.GetLocal<List<County>>(("TaiwanCountyData.json"));
            if (employee != null && employee.e_EmployeeRole_Mapping.Any(y => y.RoleId == 2))
            {
                allCity = allCity.Where(x => x.CityCode == employee.City).ToList();
            }
            //縣市別
            ddlCounty.Items.Clear();
            ddlCounty.Items.AddRange(allCity.Select(x => new ListItem(x.CityName, x.CityCode)).ToArray());

            var getCompetition = _db.CompetitionGroup.FirstOrDefault(x => x.Id == id && x.TeamTypeId == 1);
            if (getCompetition == null) Response.Redirect("CompetitionGroupList.aspx?nid=" + Nid);
            if (!allCity.Select(x => x.CityCode).Contains(getCompetition.County)) Response.Redirect("CompetitionGroupList.aspx?nid=" + Nid);

            ddlCounty.SelectedValue = getCompetition.County;
            if(getCompetition.SignupStatus.HasValue)
                ddlStatus.SelectedValue = getCompetition.SignupStatus == true ? "1" : "0";

            var oldReturnReason = new List<ReturnData>();
            try
            {
                oldReturnReason = JsonConvert.DeserializeObject<List<ReturnData>>(getCompetition.ReturnReason);
            }
            catch (Exception ex)
            {

            }
            foreach (ListItem ro in listReturnReason.Items)
            {
                ro.Selected = oldReturnReason.Select(x => x.TypeId.ToString()).Contains(ro.Value);
            }
            txtOtherReason.Text = oldReturnReason.Any(x => x.TypeId == 4) ? oldReturnReason.FirstOrDefault(x => x.TypeId == 4)?.Remark : "";
            txtContestCode.Text =getCompetition.ContestCode;
            txtName.Text = getCompetition.CompetitionGroupMember.FirstOrDefault().Name;
            txtIdentityNo.Text = getCompetition.CompetitionGroupMember.FirstOrDefault().IdentityNo;
            txtBirthday.Text = getCompetition.CompetitionGroupMember.FirstOrDefault().Birthday.ToString("yyyy-MM-dd");
            txtPhone.Text = getCompetition.CompetitionGroupMember.FirstOrDefault().Phone;
            txtMail.Text = getCompetition.CompetitionGroupMember.FirstOrDefault().Mail;
            txtUnitName.Text = getCompetition.CompetitionGroupMember.FirstOrDefault().UnitName;
            txtJobTitle.Text = getCompetition.CompetitionGroupMember.FirstOrDefault().JobTitle;

            var signArea = (getCompetition.CompetitionGroupMember.FirstOrDefault().SignArea ?? "").Split(',').ToList();
            foreach (ListItem ro in listSignArea.Items)
            {
                ro.Selected = signArea.Contains(ro.Value);
            }

            txtTitle.Text = getCompetition.Title;
            litWorkFile.Text = $"<a href='../WPContent/{getCompetition.WorkFile}' class='btn btn-info' target='_blank' download>下載</a>";
            litAuthorizeFile.Text = $"<a href='../WPContent/{getCompetition.AuthorizeFile}' class='btn btn-info' target='_blank' download>下載</a>";
            if (!string.IsNullOrEmpty(getCompetition.RepresentativeConsent)) litRepresentativeConsent.Text = $"<a href='../WPContent/{getCompetition.RepresentativeConsent}' class='btn btn-info' target='_blank' download>下載</a>";
        }
    }

    protected void btn_OnCommand(object sender, CommandEventArgs e)
    {
        var adminid = hidAdminId.Value;
        var action = "CompetitionGroup";
        switch (e.CommandName)
        {
            case "Save":
                var returnReason = listReturnReason.Items.Cast<ListItem>().Where(item => item.Selected).Select(x => new ReturnData
                {
                    TypeId = x.Value.ToInt32(),
                    Remark = x.Value.ToInt32() == 1 ? "授權書未簽名" : (x.Value.ToInt32() == 2 ? "法定代理人同意書未簽名" : (x.Value.ToInt32() == 3 ? "欄位與上傳檔案不相符" : (x.Value.ToInt32() == 4 ? txtOtherReason.Text : "")))
                }).ToList();

                if (ddlStatus.SelectedValue == "0" && !returnReason.Any())
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJs("資料有誤時需選擇原因"));
                    return;
                }

                var getCompetition = _db.CompetitionGroup.FirstOrDefault(x => x.Id == id);
                getCompetition.County = ddlCounty.SelectedValue;
                getCompetition.CountyName = ddlCounty.SelectedItem.Text;
                if (!string.IsNullOrEmpty(ddlStatus.SelectedValue))
                {
                    getCompetition.SignupStatus = ddlStatus.SelectedValue == "1";
                    getCompetition.ReturnReason = JsonConvert.SerializeObject(returnReason);
                    if (ddlStatus.SelectedValue == "0")
                    {
                        var errMsg = "";
                        foreach (var item in returnReason)
                        {
                            errMsg += $"<p style=\"color:red\">{item.Remark}</p>";
                        }
                        var mailTitle = "報名退件通知：112 年首惜廚師甄選活動甄選";
                        var htmlContents = new System.Text.StringBuilder();
                        htmlContents.Append($"您好<br/>");
                        htmlContents.Append($"112 年首惜廚師甄選活動甄選，<br/>");
                        htmlContents.Append($"您的報名【食譜組】資料有問題，問題說明如下<br/>");
                        htmlContents.Append($"{errMsg}<br/>");
                        htmlContents.Append($"請您再次準備資料，並登入後修改<br/>");
                        htmlContents.Append($"感謝您參與~<br/>");
                        var mailContent = htmlContents.ToString();
                        SendMailHelper.SendMail(mailTitle, mailContent, getCompetition.CompetitionGroupMember.FirstOrDefault(x => x.IsLeader).Mail);
                    }
                    else
                    {
                        var mailTitle = "報名受理通知：112 年首惜廚師甄選活動甄選";
                        var htmlContents = new System.Text.StringBuilder();
                        htmlContents.Append($"您好<br/>");
                        htmlContents.Append($"112 年首惜廚師甄選活動甄選，<br/>");
                        htmlContents.Append($"您的報名【食譜組】資料已受理<br/>");
                        htmlContents.Append($"感謝您參與~<br/>");
                        var mailContent = htmlContents.ToString();
                        SendMailHelper.SendMail(mailTitle, mailContent, getCompetition.CompetitionGroupMember.FirstOrDefault(x => x.IsLeader).Mail);
                    }
                    _db.CompetitionGroupReturnLog.InsertOnSubmit(new CompetitionGroupReturnLog
                    {
                        CompetitionGroupId = getCompetition.Id,
                        Contents = JsonConvert.SerializeObject(returnReason),
                        CreateUser = hidAdminId.Value,
                        CreateDate = DateTime.Now,
                    });
                }
                _db.SubmitChanges();
                JavascriptHelper.ShowMessage(Page, "更新成功", JavascriptHelper.MessageType.Success, action + "List.aspx?nid=" + Nid);
                break;
            case "GoCancel":
                Response.Redirect(action + "List.aspx?nid=" + Nid);
                break;
        }
    }

    public class ReturnData
    {
        public int TypeId { get; set; }
        public string Remark { get; set; }
    }
}
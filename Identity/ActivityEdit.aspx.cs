using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class Identity_ActivityEdit : System.Web.UI.Page
{
    private int Nid => (Request.QueryString["nid"] ?? "0").ToInt32();
    private string CountyCode => Request.QueryString["CountyCode"];

    DataClassesDataContext _db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        if (Session["AdminId"] != null)
        {
            hidAdminId.Value = Session["AdminId"].ToString();
        }

        ddlCountyBind();
        ddlCounty_SelectedIndexChanged(null, null);
    }

    public void ActivityDataBind()
    {
        var contactData = new List<ContactData>();
        var getActivity = _db.Activity.FirstOrDefault(x => x.County == ddlCounty.SelectedValue);
        if (getActivity != null)
        {
            txtStartDate.Text = getActivity.SignupStartDate.ToString("yyyy-MM-dd");
            txtEndDate.Text = getActivity.SignupEndDate.ToString("yyyy-MM-dd");
            txtCommitteeList.Text = getActivity.CommitteeList;
            txtPics.Text = getActivity.Pics;
            txtIntroduceFile.Text = getActivity.IntroduceFile;
            txtOdtFile.Text = getActivity.OdtFile;
            txtPreliminaryAwardFile.Text = getActivity.PreliminaryAwardFile;
            var i = 1;
            contactData = getActivity.ActivityContactUser.Select(x => new ContactData
            {
                ItemCount = i++,
                ContactName = x.ContactName,
                ContactPhone = x.ContactPhone
            }).ToList();
            if (contactData.Count == 1)
            {
                foreach (var item in contactData)
                {
                    item.ShowBtn = false;
                }
            }
        }
        if (!contactData.Any())
        {
            contactData.Add(new ContactData
            {
                ItemCount = 1,
                ContactName = "",
                ContactPhone = "",
                ShowBtn = false
            });
        }
        ListView1.DataSource = contactData;
        ListView1.DataBind();
    }
    protected void btn_OnCommand(object sender, CommandEventArgs e)
    {
        var adminid = hidAdminId.Value;
        var action = "Activity";
        switch (e.CommandName)
        {
            case "Save":
                var newRow = _db.Activity.FirstOrDefault(x => x.County == ddlCounty.SelectedValue);
                if (newRow != null)
                {
                    newRow.SignupStartDate = txtStartDate.Text.ToDateTime().Value;
                    newRow.SignupEndDate = txtEndDate.Text.ToDateTime().Value;
                    newRow.CommitteeList = txtCommitteeList.Text;
                    newRow.Pics = txtPics.Text;
                    newRow.IntroduceFile = txtIntroduceFile.Text;
                    newRow.OdtFile = txtOdtFile.Text;
                    newRow.PreliminaryAwardFile = txtPreliminaryAwardFile.Text;

                    newRow.ModifyDate = DateTime.Now;
                    newRow.ModifyUser = adminid;
                    if (!string.IsNullOrEmpty(newRow.IntroduceFile) && !newRow.FileUploadDate.HasValue) newRow.FileUploadDate = DateTime.Now;

                    _db.ActivityContactUser.DeleteAllOnSubmit(newRow.ActivityContactUser);
                    _db.SubmitChanges();

                    var newContactUser = new List<ActivityContactUser>();
                    foreach (ListViewDataItem item in ListView1.Items)
                    {
                        var txtContactName = item.FindControl("txtContactName") as TextBox;
                        var txtContactPhone = item.FindControl("txtContactPhone") as TextBox;

                        newContactUser.Add(new ActivityContactUser
                        {
                            ActivityId = newRow.Id,
                            ContactName = txtContactName.Text,
                            ContactPhone = txtContactPhone.Text,
                            CreateDate = DateTime.Now,
                            CreateUser = adminid,
                            ModifyDate = DateTime.Now,
                            ModifyUser = adminid
                        });
                    }
                    _db.ActivityContactUser.InsertAllOnSubmit(newContactUser);
                    _db.SubmitChanges();

                    JavascriptHelper.ShowMessage(Page, "更新成功", JavascriptHelper.MessageType.Success, action + "List.aspx?nid=" + Nid);
                }
                else
                {
                    newRow = new Activity();

                    newRow.County = ddlCounty.SelectedValue;
                    newRow.CountyName = ddlCounty.SelectedItem.Text;
                    newRow.SignupStartDate = txtStartDate.Text.ToDateTime().Value;
                    newRow.SignupEndDate = txtEndDate.Text.ToDateTime().Value;
                    newRow.CommitteeList = txtCommitteeList.Text;
                    newRow.Pics = txtPics.Text;
                    newRow.IntroduceFile = txtIntroduceFile.Text;
                    newRow.OdtFile = txtOdtFile.Text;
                    newRow.PreliminaryAwardFile = txtPreliminaryAwardFile.Text;

                    newRow.CreateDate = DateTime.Now;
                    newRow.CreateUser = adminid;
                    newRow.ModifyDate = DateTime.Now;
                    newRow.ModifyUser = adminid;
                    if(!string.IsNullOrEmpty(newRow.IntroduceFile)) newRow.FileUploadDate = DateTime.Now;

                    _db.Activity.InsertOnSubmit(newRow);
                    _db.SubmitChanges();

                    var newContactUser = new List<ActivityContactUser>();
                    foreach (ListViewDataItem item in ListView1.Items)
                    {
                        var txtContactName = item.FindControl("txtContactName") as TextBox;
                        var txtContactPhone = item.FindControl("txtContactPhone") as TextBox;

                        newContactUser.Add(new ActivityContactUser
                        {
                            ActivityId = newRow.Id,
                            ContactName = txtContactName.Text,
                            ContactPhone = txtContactPhone.Text,
                            CreateDate = DateTime.Now,
                            CreateUser = adminid,
                            ModifyDate = DateTime.Now,
                            ModifyUser = adminid
                        });
                    }
                    _db.ActivityContactUser.InsertAllOnSubmit(newContactUser);
                    _db.SubmitChanges();


                    JavascriptHelper.ShowMessage(Page, "新增成功", JavascriptHelper.MessageType.Success, action + "List.aspx?nid=" + Nid);
                }

                break;
            case "GoCancel":
                Response.Redirect(action + "List.aspx?nid=" + Nid);
                break;
            case "AddContact":
                EditContact("add");
                break;
            case "DelContact":
                EditContact("del", e.CommandArgument.ToInt32());
                break;
        }
    }

    public void ddlCountyBind()
    {
        var allCity = JsonHelper.GetLocal<List<County>>(("TaiwanCountyData.json"));
        var employee = _db.e_Employees.FirstOrDefault(x => x.EmployeeId == hidAdminId.Value.ToInt32());
        if (employee != null && employee.e_EmployeeRole_Mapping.Any(y => y.RoleId == 2))
        {
            allCity = allCity.Where(x => x.CityCode == employee.City).ToList();
        }

        //縣市別
        ddlCounty.Items.Clear();
        ddlCounty.Items.AddRange(allCity.Select(x => new ListItem(x.CityName, x.CityCode)).ToArray());
        ddlCounty.Enabled = allCity.Count > 1;

        if (!string.IsNullOrEmpty(CountyCode) && ddlCounty.Items.FindByValue(CountyCode) != null) ddlCounty.SelectedValue = CountyCode;
        if (employee != null && employee.e_EmployeeRole_Mapping.Any(y => y.RoleId == 2))
        {
            if (!string.IsNullOrEmpty(employee.City) && ddlCounty.Items.FindByValue(employee.City) != null) ddlCounty.SelectedValue = employee.City;
        }
    }
    protected void ddlCounty_SelectedIndexChanged(object sender, EventArgs e)
    {
        ActivityDataBind();
    }

    public class ContactData
    {
        public int ItemCount { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public bool ShowBtn { get; set; } = true;
    }

    public void EditContact(string editType, int delCount = 0)
    {
        var contactData = new List<ContactData>();
        int i = 1;
        foreach (ListViewDataItem item in ListView1.Items)
        {
            var txtContactName = item.FindControl("txtContactName") as TextBox;
            var txtContactPhone = item.FindControl("txtContactPhone") as TextBox;

            if (editType == "del" && delCount == i)
            {
                delCount = 0;
            }
            else
            {
                contactData.Add(new ContactData
                {
                    ItemCount = i++,
                    ContactName = txtContactName.Text,
                    ContactPhone = txtContactPhone.Text
                });
            }
        }
        if (editType == "add")
            contactData.Add(new ContactData
            {
                ItemCount = i,
                ContactName = "",
                ContactPhone = ""
            });
        if (contactData.Count == 1)
        {
            foreach(var item in contactData)
            {
                item.ShowBtn = false;
            }
        }
        ListView1.DataSource = contactData;
        ListView1.DataBind();
    }
}
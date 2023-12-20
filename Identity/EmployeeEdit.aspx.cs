using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class Admin_EmployeeEdit : System.Web.UI.Page
{
    private int nid => (Request.QueryString["nid"] ?? "0").ToInt16();
    private int Id => (Request.QueryString["id"] ?? "0").ToInt16();
    private readonly DataClassesDataContext _db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        ddlBind();
        ddlCountBind();

        if (Id == 0) return;
        var result = _db.e_Employees.FirstOrDefault(x => x.EmployeeId == Id);
        if (result == null) return;
        {
            txtAccount.Text = result.Account;
            txtAccount.Enabled = false;
            txtName.Text = result.Name;
            txtTitle.Text = result.Title;
            //txtName.Text = result.Email;
            //txtTitleOfCourtesy.Text = result.TitleOfCourtesy;
            txtEmail.Text = result.Address;
            txtHomePhone.Text = result.HomePhone;
            txtPhone.Text = result.Phone;
            txtExtension.Text = result.Extension;
            txtNotes.Text = result.Notes;
            txtFiles.Text = result.PhotoPath;
            txtCountry.Text = result.Country;
            var roleList = result.e_EmployeeRole_Mapping.Select(x => x.RoleId.ToString()).ToList();
            if (roleList.Any())
            {
                listRoles.SelectedValue = roleList.FirstOrDefault();
            }
            ddlCountBind(result);
            ddlCounty.SelectedValue = result.City;
            if (result.ReportsTo.HasValue)
            {
                ddlReportsTo.SelectedValue = result.ReportsTo.ToString();
            }
            //if (result.BirthDate.HasValue)
            //{
            //    txtBirthDate.Text = result.BirthDate.Value.ToShortDateString();
            //}
            //if (result.HireDate.HasValue)
            //{
            //    txtHireDate.Text = result.HireDate.Value.ToShortDateString();
            //}
        }
    }
    private void ddlBind()
    {
        //類別
        ddlReportsTo.Items.Clear();
        ddlReportsTo.Items.Add(new ListItem("無", "0"));
        ddlReportsTo.Items.AddRange(_db.e_Employees.Where(x=>x.Account!="admin").Select(x => new ListItem(x.Name, x.EmployeeId.ToString())).ToArray());

        listRoles.Items.AddRange(_db.e_EmployeeRole.Select(x => new ListItem(x.Name, x.EmployeeRoleId.ToString())).ToArray());

    }
    private void ddlCountBind(e_Employees result = null)
    {
        var allCity = JsonHelper.GetLocal<List<County>>(("TaiwanCountyData.json"));
        var allEmployeeCity = _db.e_Employees.Where(x => x.e_EmployeeRole_Mapping.Any(y => y.RoleId == 2));
        if (result!=null)
        {
            allEmployeeCity = allEmployeeCity.Where(x => x.EmployeeId != result.EmployeeId);
        }
        if (listRoles.SelectedValue == "2")
        {
            allCity = allCity.Where(x => !allEmployeeCity.Select(o => o.City).Contains(x.CityCode)).ToList();
        }
        //縣市別
        ddlCounty.Items.Clear();
        ddlCounty.Items.Add(new ListItem("--請選擇--", ""));
        ddlCounty.Items.AddRange(allCity.Select(x => new ListItem(x.CityName, x.CityCode)).ToArray());
    }
    protected void btn_OnCommand(object sender, CommandEventArgs e)
    {
        string Action = "Employee";
        if (Id != 0)
        {
            switch (e.CommandName)
            {
                case "Save":
                    var newRow = _db.e_Employees.FirstOrDefault(x => x.EmployeeId == Id);
                    if (newRow != null)
                    {
                        newRow.Name = txtName.Text;
                        newRow.Title = txtTitle.Text;
                        //newRow.TitleOfCourtesy = txtTitleOfCourtesy.Text;
                        //if (!string.IsNullOrEmpty(txtBirthDate.Text))
                        //{
                        //    newRow.BirthDate = Convert.ToDateTime(txtBirthDate.Text);
                        //}
                        //if (!string.IsNullOrEmpty(txtHireDate.Text))
                        //{
                        //    newRow.HireDate = Convert.ToDateTime(txtHireDate.Text);
                        //}
                        newRow.Address = txtEmail.Text;
                        newRow.HomePhone = txtHomePhone.Text;
                        newRow.Phone = txtPhone.Text;
                        newRow.Extension = txtExtension.Text;
                        newRow.Notes = txtNotes.Text;
                        newRow.City = ddlCounty.SelectedValue;
                        newRow.Country = txtCountry.Text;
                        //    newRow.Email = txtName.Text;

                        if (ddlReportsTo.SelectedValue != "" && ddlReportsTo.SelectedValue != "0")
                        {
                            newRow.ReportsTo = Convert.ToInt32(ddlReportsTo.SelectedValue);
                        }
                        else
                        {
                            newRow.ReportsTo = null;
                        }

                        newRow.PhotoPath = txtFiles.Text;
                    
                        newRow.ModifyUser = Session["AdminId"]?.ToString();
                        newRow.ModifyDate = DateTime.Now;
                        _db.SubmitChanges();

                        //多選
                        var roles = listRoles.Items.Cast<ListItem>().Where(item => item.Selected)
                            .Select(x => x.Value.ToInt16()).ToList();
                        //多選加入
                        foreach (var iItem in roles.Except(newRow.e_EmployeeRole_Mapping.Select(x => x.RoleId)))
                        {
                            e_EmployeeRole_Mapping _newEmployeeRoleMapping = new e_EmployeeRole_Mapping();
                            _newEmployeeRoleMapping.RoleId = iItem;
                            _newEmployeeRoleMapping.EmployeeId = newRow.EmployeeId;
                            _db.e_EmployeeRole_Mapping.InsertOnSubmit(_newEmployeeRoleMapping);
                            _db.SubmitChanges();
                        }
                        //多選刪除
                        foreach (var dId in newRow.e_EmployeeRole_Mapping.Select(x => x.RoleId).Except(roles))
                        {
                            var dItem = _db.e_EmployeeRole_Mapping.FirstOrDefault(
                                x => x.EmployeeId == newRow.EmployeeId && x.RoleId == dId);
                            if (dItem != null)
                            {
                                _db.e_EmployeeRole_Mapping.DeleteOnSubmit(dItem);
                                _db.SubmitChanges();
                            }

                        }
                        ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJsAndRedirect("更新成功", Action + "List.aspx?nid=" + nid));
                    }
                    break;
            }
        }
    }
    protected void listRoles_SelectedIndexChanged(object sender, EventArgs e)
    {
        var result = _db.e_Employees.FirstOrDefault(x => x.EmployeeId == Id);
        ddlCountBind(result);
        if (listRoles.SelectedValue == "2")
            ddlCounty.Attributes.Add("required", "required");
        else ddlCounty.Attributes.Remove("required");
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Newtonsoft.Json;
using Tool;

public partial class Admin_EmployeeAdd : System.Web.UI.Page
{
    private int nid => (Request.QueryString["nid"] ?? "0").ToInt16();
    private readonly DataClassesDataContext _db = new DataClassesDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
     
            ddlBind();
            ddlCountBind();
        }

     
    }

 
    private void ddlBind()
    {
        //類別
        ddlReportsTo.Items.Clear();
        ddlReportsTo.Items.Add(new ListItem("無", "0"));
        ddlReportsTo.Items.AddRange(_db.e_Employees.Where(x => x.Account != "admin").Select(x => new ListItem(x.Name, x.EmployeeId.ToString())).ToArray());

        listRoles.Items.AddRange(_db.e_EmployeeRole.Select(x => new ListItem(x.Name, x.EmployeeRoleId.ToString())).ToArray());
    }
 
    private void ddlCountBind()
    {
        var allCity = JsonHelper.GetLocal<List<County>>(("TaiwanCountyData.json"));
        var allEmployeeCity = _db.e_Employees.Where(x => x.e_EmployeeRole_Mapping.Any(y => y.RoleId == 2)).Select(x => x.City);
        if (listRoles.SelectedValue == "2")
        {
            allCity = allCity.Where(x => !allEmployeeCity.Contains(x.CityCode)).ToList();
        }
        //縣市別
        ddlCounty.Items.Clear();
        ddlCounty.Items.Add(new ListItem("--請選擇--", ""));
        ddlCounty.Items.AddRange(allCity.Select(x => new ListItem(x.CityName, x.CityCode)).ToArray());
    }
    protected void btn_OnCommand(object sender, CommandEventArgs e)
    {
        string Action = "Employee";
        switch (e.CommandName)
        {
            case "Save":
                e_Employees newRow = new e_Employees();
                newRow.Account = txtAccount.Text;
                newRow.Password = txtPassword.Text;
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
                //newRow.Phone = txtPhone.Text;
                newRow.Extension = txtExtension.Text;
                newRow.Notes = txtNotes.Text;
                newRow.City = ddlCounty.SelectedValue;
                newRow.Country = txtCountry.Text;
                newRow.Status = 0;
                if (ddlReportsTo.SelectedValue != "" && ddlReportsTo.SelectedValue != "0")
                {
                    newRow.ReportsTo = Convert.ToInt32(ddlReportsTo.SelectedValue);
                }
                newRow.PhotoPath = txtFiles.Text;
                newRow.CreatUser = Session["AdminId"]?.ToString();
                newRow.CreateDate = DateTime.Now;
                _db.e_Employees.InsertOnSubmit(newRow);
                _db.SubmitChanges();
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
                ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJsAndRedirect("新增成功", Action + "List.aspx?nid=" + nid));
      
        break;
        }
    }

    protected void listRoles_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCountBind();
        if (listRoles.SelectedValue == "2")
            ddlCounty.Attributes.Add("required","required");
        else ddlCounty.Attributes.Remove("required");
    }
}
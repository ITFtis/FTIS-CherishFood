using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class Admin_EmployeeRoleAdd : System.Web.UI.Page
{
    private readonly DataClassesDataContext _db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ListView1.DataSource = _db.e_Employees.Where(x=>x.Account!="admin");
            ListView1.DataBind();
            ListView2.DataSource = _db.e_EmployeePermission;
            ListView2.DataBind();

        }
    }
    protected void btn_OnCommand(object sender, CommandEventArgs e)
    {
        string Action = "EmployeeRole";
        switch (e.CommandName)
        {
            case "Save":
                e_EmployeeRole newRow = new e_EmployeeRole();
                newRow.Name = txtName.Text;
                newRow.IsSystemRole = false;
                _db.e_EmployeeRole.InsertOnSubmit(newRow);
                _db.SubmitChanges();

                var employeePermission = _db.e_EmployeePermission;
                var employee = _db.e_Employees;
                foreach (var listview in ListView2.Items)
                {
                    HiddenField hid = (HiddenField)listview.FindControl("HidShopId");
                    CheckBox chk = (CheckBox)listview.FindControl("IsCharge");
                    if (hid != null && chk != null)
                    {
                        if (chk.Checked)
                        {
                            var pResult = employeePermission.FirstOrDefault(x => x.EmployeePermissionId == Convert.ToInt32(hid.Value));
                            e_Employee_RolePremission_Mapping _MrolePrm = new e_Employee_RolePremission_Mapping();
                            _MrolePrm.RoleId = newRow.EmployeeRoleId;
                            _MrolePrm.PermissionId = pResult.EmployeePermissionId;
                            _db.e_Employee_RolePremission_Mapping.InsertOnSubmit(_MrolePrm);
                            _db.SubmitChanges();
                        }
                    }
                }
                foreach (var listview in ListView1.Items)
                {
                    HiddenField hid = (HiddenField)listview.FindControl("HidShopId");
                    CheckBox chk = (CheckBox)listview.FindControl("IsCharge");
                    if (hid != null && chk != null)
                    {
                        if (chk.Checked)
                        {
                            var eResult = employee.FirstOrDefault(x => x.EmployeeId == Convert.ToInt32(hid.Value));
                            e_EmployeeRole_Mapping _MrolePrm = new e_EmployeeRole_Mapping();
                            _MrolePrm.RoleId = newRow.EmployeeRoleId;
                            _MrolePrm.EmployeeId = eResult.EmployeeId;
                            _db.e_EmployeeRole_Mapping.InsertOnSubmit(_MrolePrm);
                            _db.SubmitChanges();
                        }
                    }
                }
                ClientScript.RegisterStartupScript(GetType(), "message",JavascriptHelper.AlertJsAndRedirect("新增成功", Action + "List.aspx"));
                break;

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class Admin_EmployeeRoleEdit : System.Web.UI.Page
{
    private readonly DataClassesDataContext _db = new DataClassesDataContext();

    private int nid => (Request.QueryString["nid"] ?? "0").ToInt16();
    private int Id => (Request.QueryString["id"] ?? "0").ToInt16();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ListView1.DataSource = _db.e_Employees.Where(x => x.Account != "admin");
            ListView1.DataBind();
            ListView2.DataSource = _db.e_EmployeePermission;
            ListView2.DataBind();

            if (Id != 0)
            {
                var result = _db.e_EmployeeRole.FirstOrDefault(x => x.EmployeeRoleId == Id);
                if (result != null)
                {
                    txtName.Enabled = !result.IsSystemRole;
                    txtName.Text = result.Name;
                    var employeeList = result.e_EmployeeRole_Mapping.Select(x => x.EmployeeId.ToString()).ToList();
                    foreach (var emp in ListView1.Items)
                    {
                        HiddenField hid = (HiddenField)emp.FindControl("HidEmployeeId");
                        CheckBox chk = (CheckBox)emp.FindControl("IsCharge");
                        if (hid != null && chk != null)
                        {
                            chk.Checked = employeeList.Contains(hid.Value);
                        }
                    }
                    var perList = result.e_Employee_RolePremission_Mapping.Select(x => x.PermissionId.ToString()).ToList();
                    foreach (var listview in ListView2.Items)
                    {
                        HiddenField hid = (HiddenField)listview.FindControl("HidPermissionpId");
                        CheckBox chk = (CheckBox)listview.FindControl("IsCharge");
                        if (hid != null && chk != null)
                        {
                            chk.Checked = perList.Contains(hid.Value);
                        }
                    }
                }
            }


        }
    }
    protected void btn_OnCommand(object sender, CommandEventArgs e)
    {
        string Action = "EmployeeRole";
        switch (e.CommandName)
        {
            case "Save":
                var newRow = _db.e_EmployeeRole.FirstOrDefault(x => x.EmployeeRoleId == Id);
                if (newRow != null)
                {
                    newRow.Name = txtName.Text;

                    var DbempList = newRow.e_EmployeeRole_Mapping.Select(x => x.EmployeeId).ToList();
                    var SempList = (from listview in ListView1.Items
                                    let hid = (HiddenField)listview.FindControl("HidEmployeeId")
                                    let chk = (CheckBox)listview.FindControl("IsCharge")
                                    where hid != null && chk != null
                                    where chk.Checked
                                    select Convert.ToInt32(hid.Value)).ToList();
                    foreach (var iitem in SempList.Except(DbempList))
                    {
                        e_EmployeeRole_Mapping _MrolePrm = new e_EmployeeRole_Mapping();
                        _MrolePrm.RoleId = newRow.EmployeeRoleId;
                        _MrolePrm.EmployeeId = iitem;
                        _db.e_EmployeeRole_Mapping.InsertOnSubmit(_MrolePrm);
                        _db.SubmitChanges();
                    }
                    foreach (var iitem in DbempList.Except(SempList))
                    {
                        var dItem = _db.e_EmployeeRole_Mapping.FirstOrDefault(
                              x => x.RoleId == newRow.EmployeeRoleId && x.EmployeeId == iitem);
                        if (dItem != null)
                        {
                            _db.e_EmployeeRole_Mapping.DeleteOnSubmit(dItem);
                            _db.SubmitChanges();
                        }
                    }

                    var DbpermissionpList = newRow.e_Employee_RolePremission_Mapping.Select(x => x.PermissionId).ToList();
                    var SpermissionpList = (from listview in ListView2.Items
                                            let hid = (HiddenField)listview.FindControl("HidPermissionpId")
                                            let chk = (CheckBox)listview.FindControl("IsCharge")
                                            where hid != null && chk != null
                                            where chk.Checked
                                            select Convert.ToInt32(hid.Value)).ToList();
                    foreach (var iitem in SpermissionpList.Except(DbpermissionpList))
                    {
                        e_Employee_RolePremission_Mapping _MrolePrm = new e_Employee_RolePremission_Mapping();
                        _MrolePrm.RoleId = newRow.EmployeeRoleId;
                        _MrolePrm.PermissionId = iitem;
                        _db.e_Employee_RolePremission_Mapping.InsertOnSubmit(_MrolePrm);
                        _db.SubmitChanges();
                    }
                    foreach (var iitem in DbpermissionpList.Except(SpermissionpList))
                    {
                        var dItem = _db.e_Employee_RolePremission_Mapping.FirstOrDefault(
                            x => x.RoleId == newRow.EmployeeRoleId && x.PermissionId == iitem);
                        if (dItem != null)
                        {
                            _db.e_Employee_RolePremission_Mapping.DeleteOnSubmit(dItem);
                            _db.SubmitChanges();
                        }
                    }
                    ClientScript.RegisterStartupScript(GetType(), "message", JavascriptHelper.AlertJsAndRedirect("更新成功", Action + "List.aspx?nid=" + nid));
                }
                break;

        }
    }
}
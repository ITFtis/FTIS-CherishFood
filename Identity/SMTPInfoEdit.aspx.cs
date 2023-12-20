using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class Identity_SMTPInfoEdit : System.Web.UI.Page
{
    private int nid => (Request.QueryString["nid"] ?? "0").ToInt16();
    private readonly DataClassesDataContext _db = new DataClassesDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            var newRow = _db.s_SMTPInfo.FirstOrDefault();
            if (newRow != null)
            {
                txtAccount.Text = newRow.Account;
                txtPassword.Text = newRow.Password;
                txtName.Text = newRow.Name;
                txtServer.Text = newRow.Server;
                txtPort.Text = newRow.Port.ToString();
                chkIsEnable.Checked = newRow.IsSSL.Value;
            }
        }
    }
    protected void btn_OnCommand(object sender, CommandEventArgs e)
    {
        string Action = "WebContent";

        switch (e.CommandName)
        {
            case "Save":
                var newRow = _db.s_SMTPInfo.FirstOrDefault();
                if (newRow != null)
                {
                    newRow.Account = txtAccount.Text;
                    newRow.Password = txtPassword.Text;
                    newRow.Name = txtName.Text;
                    newRow.Server = txtServer.Text;
                    newRow.Port = txtPort.Text.ToInt16();
                    newRow.IsSSL = chkIsEnable.Checked;
                    _db.SubmitChanges();
                    LitAlertMsg.Text = JavascriptHelper.SuccessMsg("更新成功");
                }
                else
                {
                    newRow = new s_SMTPInfo();
                    newRow.Account = txtAccount.Text;
                    newRow.Password = txtPassword.Text;
                    newRow.Name = txtName.Text;
                    newRow.Server = txtServer.Text;
                    newRow.Port = txtPort.Text.ToInt16();
                    newRow.IsSSL = chkIsEnable.Checked;
                    _db.s_SMTPInfo.InsertOnSubmit(newRow);
                    _db.SubmitChanges();
                    LitAlertMsg.Text = JavascriptHelper.SuccessMsg("更新成功");
                }
                break;
        }

    }
}
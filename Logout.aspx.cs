using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["ChiefChef"] != null)
        {
            HttpCookie cookie = new HttpCookie("ChiefChef");
            cookie.Expires = DateTime.Now.AddDays(-15);
            Response.Cookies.Add(cookie);
        }
        Response.Redirect("login.aspx");
    }
}
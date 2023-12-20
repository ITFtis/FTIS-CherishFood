using NPOI.OpenXmlFormats.Dml.Chart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact : System.Web.UI.Page
{
    DataClassesDataContext _db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "聯絡我們|首惜廚師甄選活動";
        var contentsUs = _db.SinglePage.FirstOrDefault(x => x.Title == "contactus");
        litContents.Text = contentsUs?.Contents;
    }
}
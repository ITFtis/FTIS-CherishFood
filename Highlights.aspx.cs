using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Highlights : System.Web.UI.Page
{
    DataClassesDataContext _db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "精彩花絮|首惜廚師甄選活動";

        ListViewNews.DataSource = _db.Highlights.Where(x => x.ReleaseDate <= DateTime.Now).OrderByDescending(x => x.ReleaseDate).ToList();
        ListViewNews.DataBind();
    }
}
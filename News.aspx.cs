using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class News : System.Web.UI.Page
{
    DataClassesDataContext _db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "最新消息|首惜廚師甄選活動";

        ListViewNews.DataSource = _db.News.Where(x => x.ReleaseDate <= DateTime.Now).OrderByDescending(x => x.ReleaseDate).ToList();
        ListViewNews.DataBind();
    }
}
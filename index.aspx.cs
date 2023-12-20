using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    DataClassesDataContext _db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        var getBanner = _db.Banner.Where(x => true).OrderBy(x => x.Sort).ThenByDescending(x => x.CreateDate).FirstOrDefault();
        if (getBanner != null)
        {
            ImageBanner.ImageUrl = "WPContent/" + getBanner.PcPic;
            ImageBanner.Attributes.Add("alt", getBanner.Title);
        }
        else
        {
            ImageBanner.ImageUrl = "images/KV_concept.jpg";
            ImageBanner.Attributes.Add("alt", "首惜廚師，惜食{美味食譜}{創意教案}甄選，總獎金70萬等你來挑戰");
        }

        ListViewNews.DataSource = _db.News.Where(x => x.ReleaseDate <= DateTime.Now).OrderByDescending(x => x.ReleaseDate).Take(6).ToList();
        ListViewNews.DataBind();
    }
}
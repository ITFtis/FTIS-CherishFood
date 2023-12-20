using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class HighlightsContents : System.Web.UI.Page
{
    private int id => (Request.QueryString["Id"] ?? "0").ToInt32();
    DataClassesDataContext _db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "精彩花絮|首惜廚師甄選活動";
        var thisHighlights = _db.Highlights.FirstOrDefault(x => x.ReleaseDate <= DateTime.Now && x.Id == id);
        if (thisHighlights == null) Response.Redirect("NewsList.aspx");

        litReleaseDate.Text = thisHighlights.ReleaseDate.ToString("yyyy/MM/dd");
        litTitle.Text = thisHighlights.Title;
        imgMainPic.ImageUrl = $"../WPContent/{thisHighlights.MainPic}";
        imgMainPic.Attributes.Add("alt", thisHighlights.Title);
        litContents.Text = thisHighlights.Contents;
        if (!string.IsNullOrEmpty(thisHighlights.VideoUrl)) litYoutubeLink.Text = $"<iframe width='560' height='315' src='{GetYoutubeUrl(thisHighlights.VideoUrl)}' title='YouTube video player' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share' allowfullscreen></iframe>";
        else PlaceHolderVideo.Visible = false;
    }

    private string GetYoutubeUrl(string galleryUrl)
    {
        var _response = "https://www.youtube.com/embed/" + (galleryUrl.Split('/')[galleryUrl.Split('/').Count() - 1]).Split('=')[(galleryUrl.Split('/')[galleryUrl.Split('/').Count() - 1]).Split('=').Count() - 1];

        if (galleryUrl.Split('/')[galleryUrl.Split('/').Count() - 1].Split('?').Count() > 1)
        {
            foreach (var item in galleryUrl.Split('/')[galleryUrl.Split('/').Count() - 1].Split('?')[1].Split('&'))
            {
                if (item.Split('=')[0].ToLower() == "v")
                {
                    _response = "https://www.youtube.com/embed/" + item.Split('=')[1];
                }
            }
        }
        else
        {
            _response = "https://www.youtube.com/embed/" + galleryUrl.Split('/')[galleryUrl.Split('/').Count() - 1];
        }
        return _response;
    }
}
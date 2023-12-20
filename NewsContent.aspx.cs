using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class NewsContent : System.Web.UI.Page
{
    private int id => (Request.QueryString["Id"] ?? "0").ToInt32();
    DataClassesDataContext _db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "最新消息|首惜廚師甄選活動";
        var thisNews = _db.News.FirstOrDefault(x => x.ReleaseDate <= DateTime.Now && x.Id == id);
        if (thisNews == null) Response.Redirect("NewsList.aspx");

        litReleaseDate.Text = thisNews.ReleaseDate.ToString("yyyy/MM/dd");
        litTitle.Text = thisNews.Title;
        imgMainPic.ImageUrl = $"../WPContent/{thisNews.MainPic}";
        imgMainPic.Attributes.Add("alt", thisNews.Title);
        litContents.Text = thisNews.Contents;
        if (!string.IsNullOrEmpty(thisNews.VideoUrl)) litYoutubeLink.Text = $"<iframe width='560' height='315' src='{GetYoutubeUrl(thisNews.VideoUrl)}' title='YouTube video player' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share' allowfullscreen></iframe>";
        else PlaceHolderVideo.Visible= false;
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    DataClassesDataContext _db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        var result = _db.SystemSetting.FirstOrDefault(x => x.Title == "Header");
        if (result != null)
        {
            litMeta.Text = result.Contents;
        }
        var result2 = _db.SystemSetting.FirstOrDefault(x => x.Title == "GoogleAnalyticId");
        if (result2 != null)
        {
            if (!string.IsNullOrEmpty(result2.Contents))
                litGoogleAnalytics.Text = $@"<script async src='https://www.googletagmanager.com/gtag/js?id={result2.Contents}'></script>
                                             <!-- Global site tag (gtag.js) - Google Analytics -->
                                             <script>
                                                 window.dataLayer = window.dataLayer || [];
                                                 function gtag(){{dataLayer.push(arguments);}}
                                                 gtag('js', new Date());
                                             
                                                 gtag('config', '{result2.Contents}',{{ 'debug_mode':true }});
                                             </script>";
        }

        PlaceHolder1.Visible = Request.Cookies["ChiefChef"] == null;
        PlaceHolder3.Visible = Request.Cookies["ChiefChef"] == null;
        PlaceHolder2.Visible = Request.Cookies["ChiefChef"] != null;
        PlaceHolder4.Visible = Request.Cookies["ChiefChef"] != null;

        //如果個人變數是第一次產生時。
        if (Session["Visited_S"] == null)
        {
            var getCount = _db.ViewCount.FirstOrDefault(x => x.ViewDate == DateTime.Today);
            if (getCount == null)
            {
                getCount = new ViewCount
                {
                    Counts = 0,
                    ViewDate = DateTime.Today,
                };
                getCount.Counts += 1;
                _db.ViewCount.InsertOnSubmit(getCount);
            }
            else
            {
                getCount.Counts += 1;
            }
            _db.SubmitChanges();
            Session["Visited_S"] = DateTime.Now;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Config 的摘要描述
/// </summary>
public class Config
{
    public static string BaseDir = HttpContext.Current.Request.PhysicalApplicationPath + "WPContent\\";
    public static string BaseUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath?.TrimEnd('/') + "/WPContent/";
    public static string WebName = "首惜廚師甄選活動活動";
}
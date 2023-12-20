<%@ WebHandler Language="C#" Class="FileDeleteHandler" %>

using System;
using System.IO;
using System.Web;

public class FileDeleteHandler : IHttpHandler
{

    /// <summary>
    /// FileDeleteHandler 的摘要描述
    /// </summary>

    public void ProcessRequest(HttpContext context)
    {
        context.Response.Clear();
        context.Response.ContentType = "application/json";
        var fileName = context.Request["key"];
        if (string.IsNullOrEmpty(fileName)) return;
        var file = Config.BaseDir + fileName;
        File.Delete(file);
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(new CustomResponse { URL = file, FName = fileName });
        //回應JSON
        context.Response.Write(json);
    }
    public class CustomResponse
    {
        public string URL { get; set; }
        public string FName { get; set; }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
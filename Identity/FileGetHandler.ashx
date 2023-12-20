<%@ WebHandler Language="C#" Class="FileGetHandler" %>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using Newtonsoft.Json;
/// <summary>
/// FileUploadHandler 的摘要描述
/// </summary>
/// <summary>
/// FileGetHandler 的摘要描述
/// </summary>
public class FileGetHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.Clear();
        context.Response.ContentType = "application/json";
        var DirPath = context.Request["dir"];
        var fileNames = context.Request["files"];
        if (!Directory.Exists(Config.BaseDir + DirPath + "/"))
        {
            Directory.CreateDirectory(Config.BaseDir + DirPath + "/");
        }

        if (string.IsNullOrEmpty(fileNames)) return;
        var res = new UpLoadResponse();
        foreach (var file in fileNames.Split(','))
        {
            string fileName = file.Split('/').LastOrDefault();
            string type = "";
            string filetype = "";
            var ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".mpg":
                    type = "video";
                    filetype = "video/mp4";
                    break;
                case ".mp3":
                    type = "video";
                    filetype = "video/mp4";
                    break;
                case ".mp4":
                    type = "video";
                    filetype = "video/mp4";
                    break;
                case ".pdf":
                    type = "pdf";
                    break;
                case ".doc":
                    type = "office";
                    break;
                case ".xls":
                    type = "office";
                    break;
                case ".xlsx":
                    type = "office";
                    break;
                case ".tif":
                    type = "office";
                    break;
                case ".docx":
                    type = "office";
                    break;
                case ".txt":
                    type = "text";
                    break;
                case ".ppt":
                    type = "office";
                    break;
                default:
                    type = "image";
                    break;
            }

            res.initialPreview.Add(Config.BaseUrl + file);
        
            var _previewConfig = new PreviewConfig()
            {
                caption = fileName,
                url = "FileDeleteHandler.ashx",//定义要删除的action
                key = file,
            };
            //if (!string.IsNullOrEmpty(fileType))
            //{
            _previewConfig.type = type;
            if(type == "video")
            {
                _previewConfig.filetype = filetype;
            }
            //}
            res.initialPreviewConfig.Add(_previewConfig);
        }
        var result = JsonConvert.SerializeObject(res);

        context.Response.Write(result);
    }
    private string UnicodeToUTF8(string strFrom)
    {
        byte[] bytSrc;
        byte[] bytDestination;
        string strTo = String.Empty;

        bytSrc = Encoding.Unicode.GetBytes(strFrom);
        bytDestination = Encoding.Convert(Encoding.Unicode, Encoding.ASCII, bytSrc);
        strTo = Encoding.ASCII.GetString(bytDestination);

        return strTo;
    }
    public class UpLoadResponse
    {
        public UpLoadResponse()
        {
            initialPreviewConfig = new List<PreviewConfig>();
            initialPreview = new List<string>();
        }
        public List<string> initialPreview { get; set; }
        public List<PreviewConfig> initialPreviewConfig { get; set; }

    }
    public class PreviewConfig
    {
        public string caption { get; set; }
        public string width { get; set; }
        public string url { get; set; }
        public string key { get; set; }
        public string extra { get; set; }
        public string type { get; set; }
        public string filetype { get; set; }
        public string downloadUrl { get; set; }
    }
    public static bool CheckFile(string path)
    {
        return File.Exists(path);
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}
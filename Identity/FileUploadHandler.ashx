<%@ WebHandler Language="C#" Class="FileUploadHandler" %>

using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using Newtonsoft.Json;

/// <summary>
/// FileUploadHandler 的摘要描述
/// </summary>
public class FileUploadHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.Clear();
        context.Response.ContentType = "application/json";
        if (context.Request.Files.Count > 0)
        {
            var DirPath = context.Request["dir"];

            if (!Directory.Exists(Config.BaseDir + DirPath + "/"))
            {
                Directory.CreateDirectory(Config.BaseDir + DirPath + "/");
            }

            var InitFileList = new List<string>();
              

            foreach (string postedFile in context.Request.Files)
            {
                var file = context.Request.Files[postedFile];
                if (file != null)
                {
                    var fileName = file.FileName;
                    var pathToCheck = fileName;
                    var myCount = 2;
                    while (CheckFile(Path.Combine(Config.BaseDir + DirPath + "/", pathToCheck)))
                    {
                        var tempfileName = myCount + "_" + fileName;
                        pathToCheck = tempfileName;
                        myCount++;
                    }
                    fileName = pathToCheck;
                    file.SaveAs(Path.Combine(Config.BaseDir + DirPath + "/", fileName));
                    InitFileList.Add(fileName);
                    //返回响应 
                }
            }
            UpLoadResponse res = new UpLoadResponse();
            foreach (var fileName in InitFileList)
            {
                if (!string.IsNullOrEmpty(fileName))
                {
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
                            type = "image";
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
                    var fileSize = new System.IO.FileInfo(Config.BaseDir + DirPath + "/" + fileName).Length;
                    var preview = Config.BaseUrl + DirPath + "/" + fileName;
                    res.initialPreview.Add(preview);
                    var _previewConfig = new PreviewConfig()
                    {
                        caption = fileName,
                        width = "120px",
                        size = fileSize,
                        url = "FileDeleteHandler.ashx", //定义要删除的action
                        key = DirPath + "/" + fileName,
                        append = false,
                    };

                    _previewConfig.type = type;
                    if (type == "video")
                    {
                        _previewConfig.filetype = filetype;
                    }

                    res.initialPreviewConfig.Add(_previewConfig);
                }
            }
            //    var result = JsonConvert.SerializeObject(res, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, Formatting = Formatting.Indented });
            var result = JsonConvert.SerializeObject(res);
            context.Response.Charset = "utf8";
            context.Response.Write(result);
        }
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
        public long size { get; set; }
        public string url { get; set; }
        public string key { get; set; }
        public string extra { get; set; }
        public bool append { get; set; }
        public string type { get; set; }
        public string filetype { get; set; }
        public string downloadUrl { get; set; }
       
    }

    public class FileInfo
    {
        public string name { get; set; }
    }

    public static bool CheckFile(string path)
    {
        if (File.Exists(path))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

/// <summary>
/// reCAPTCHAHelper 的摘要描述
/// </summary>
public class reCAPTCHAHelper
{
    public class reCAPTCHAObject
    {
        public string success { get; set; }
    }
    public const string secreSiteKey = "6LfK67QkAAAAAA1RrA11rFHuW4DntHKansB-A5Je";
    private const string secreKey = "6LfK67QkAAAAABbBpsNTNZYYw4TI2ChPSNVupqSb";
    public reCAPTCHAHelper()
    {
    }

    public static bool Validate(string recaptcharesponse)
    {
        string url = $"https://www.google.com/recaptcha/api/siteverify?secret={secreKey}&response={recaptcharesponse}";
        bool Valid = false;
        //Request to Google Server
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
        try
        {
            //Google recaptcha Response
            using (WebResponse wResponse = req.GetResponse())
            {
                using (StreamReader readStream = new StreamReader(wResponse.GetResponseStream()))
                {
                    string jsonResponse = readStream.ReadToEnd();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    reCAPTCHAObject data = js.Deserialize<reCAPTCHAObject>(jsonResponse);// Deserialize Json
                    Valid = Convert.ToBoolean(data.success);
                }
            }
            return Valid;
        }
        catch (WebException ex)
        {
            throw ex;
        }
    }
    public static string CheckValidate(string recaptcharesponse)
    {
        string url = $"https://www.google.com/recaptcha/api/siteverify?secret={secreKey}&response={recaptcharesponse}";
        string Valid = "";
        //Request to Google Server
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
        try
        {
            //Google recaptcha Response
            using (WebResponse wResponse = req.GetResponse())
            {
                using (StreamReader readStream = new StreamReader(wResponse.GetResponseStream()))
                {
                    Valid = readStream.ReadToEnd();
                }
            }
            return Valid;
        }
        catch (WebException ex)
        {
            throw ex;
        }
    }
}
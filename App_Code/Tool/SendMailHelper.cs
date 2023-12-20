using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using NLog;

namespace Tool
{
    public class SendMailHelper
    {
        private static readonly DataClassesDataContext _db = new DataClassesDataContext();
        public static bool SendMail(string subject, string body, string mailTo)
        {
            var isSuccess =false;
            var logger = LogManager.GetCurrentClassLogger();
            try
            {
                var result = _db.s_SMTPInfo.FirstOrDefault();
                if (result != null)
                {
                    var account = result.Account;
                    var port = result.Port ?? 25;
                    var server = result.Server;
                    var password = result.Password;
                    var isSsl = result.IsSSL ?? false;

                    var name = result.Name;
                    var sendName = name + " <" + account + ">";
                    var mmsg = new MailMessage(sendName, mailTo);
                    mmsg.IsBodyHtml = true; //設定是否採用HTML格式
                    mmsg.BodyEncoding = Encoding.UTF8; //設定mail內容的編碼
                    mmsg.SubjectEncoding = Encoding.UTF8; //設定mail主旨的編碼
                    mmsg.Priority = MailPriority.Normal; //設定優先權 1.High 2.Normail 3.Low
                    mmsg.Subject = subject; // mail主旨
                    mmsg.Body = body; //mail內容
                    var mySmtp = new SmtpClient(server, port); //允許程式使用smtp+來發mail，並設定smtp server & port   smtp.tgpf.org.tw
                    if (!string.IsNullOrEmpty(password))
                    {
                        mySmtp.Credentials =
                            new NetworkCredential(account, password); //設定帳號與密碼 需要using system.net;       
                    }
                    mySmtp.EnableSsl = isSsl;
                    mySmtp.Send(mmsg);
                    mmsg.Dispose(); //釋放資源
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
             return isSuccess;
        }
        public static bool LogInfo(string str)
        {
            try
            {
                var myLogFileName = DateTime.Now.ToString("yyyyMMdd");
                var myLogFileDataName = DateTime.Now.ToString("yyyyMM");
                var myDir = Config.BaseDir + myLogFileDataName + "\\";
                if (!Directory.Exists(myDir)) { Directory.CreateDirectory(myDir); }
                var strRecord = $"[{DateTime.Now:yyyy/MM/dd hh:mm:ss}]Message : {str.Trim()}";
                var logFile = myDir + myLogFileName + ".log";
                var sw = new StreamWriter(logFile, true, System.Text.Encoding.GetEncoding("BIG5"));
                sw.WriteLine(strRecord);
                sw.Flush();
                sw.Close();
                sw.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
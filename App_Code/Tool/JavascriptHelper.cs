using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace Tool
{
    /// <summary>
    /// JavascriptUtil 的摘要描述
    /// </summary>
    public class JavascriptHelper
    {
        public enum MessageType { Success, Error, Info, Warning };

        /// <summary>
        /// 顯示訊息
        /// </summary>
        /// <param name="alertMsg"></param>
        /// <returns></returns>
        public static string AlertJs(string alertMsg)
        {
            var cont = $"alert(\"{alertMsg}\");";
            return (WrapperScript(cont));
        }
        /// <summary>
        /// Confirm訊息
        /// </summary>
        /// <param name="alertMsg"></param>
        /// <returns></returns>
        public static string ConfirmJs(string alertMsg)
        {
            var cont = $"confirm(\"{alertMsg}\");";

            return (WrapperScript(cont));
        }
        public static string FancyboxClose()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(WrapperScript("parent.jQuery.fancybox.close()"));

            return sb.ToString();
        }
        /// <summary>
        /// 顯示訊息後導至某頁
        /// </summary>
        /// <param name="alertMsg">要顯示的訊息</param>
        /// <param name="path">之後要去的位置</param>
        /// <returns></returns>
        public static string AlertJsAndRedirect(string alertMsg, string path)
        {
            var alertMsgJs = $"alert('{alertMsg}');";
            return WrapperScript(alertMsgJs + Redirect(path));

        }

        /// <summary>
        /// 顯示訊息後導回上頁
        /// </summary>
        /// <param name="alertMsg">要顯示的訊息</param>        
        /// <returns></returns>
        public static string AlertJsAndGoBack(string alertMsg)
        {
            var alertMsgJs = $" alert('{alertMsg}'); ";
            return WrapperScript(alertMsgJs + " history.go(-1);  ");

        }

        public static string GoBack(int backPage)
        {

            return WrapperScript(" history.go(-" + backPage.ToString() + "); ");
        }

        public static string GoBack()
        {
            return WrapperScript(" history.go(-1); ");
        }

        /// <summary>
        /// 導畫面至某頁
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string Redirect(string path)
        {
            return (string.Format(" window.location.href='{0}';", path));
        }

        /// <summary>
        /// 開啟ModalDialog以傳遞資料
        /// </summary>
        /// <param name="path">網頁路徑</param>
        /// <param name="paramDic">傳遞的參數,其中key為ClientId為要傳回後的欄位ID</param>
        /// <param name="width">視窗寬度</param>
        /// <param name="height">視窗寬度</param>
        /// <returns></returns>
        public static string OpenDialog(string path, Dictionary<string, string> paramDic, int width, int height)
        {
            string paramStr = "";
            StringBuilder jsStr = new StringBuilder();

            if (paramDic.Count > 0)
            {
                List<string> tmpParamList = new List<string>();

                foreach (string key in paramDic.Keys)
                {
                    tmpParamList.Add(string.Format("{0}={1}", key, paramDic[key]));
                }
                paramStr = "?" + string.Join("&", tmpParamList.ToArray());

            }

            jsStr.AppendLine(string.Format("var retuenValue = window.showModalDialog(\"{0}{1}\", \"MyDialog\", \"dialogWidth={2}px;dialogHeight={3}px\");", path, paramStr, width, height));

            return (WrapperScript(jsStr.ToString()));
        }

        /// <summary>
        /// 開啟視窗
        /// </summary>
        /// <param name="path"></param>
        /// <param name="paramDic"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static string OpenWin(string path, Dictionary<string, string> paramDic, int width, int height)
        {
            var paramStr = "";

            if (paramDic != null && paramDic.Count > 0)
            {
                paramStr = "?" + string.Join("&", paramDic.Keys.Select(key => $"{key}={paramDic[key]}").ToArray());

            }

            paramStr = $"window.open (\"{path}{paramStr}\", \"openWin\", \"height={height}, width={width}\")";
            return WrapperScript(paramStr);
        }

        /// <summary>
        /// 開啟視窗
        /// </summary>
        /// <param name="path"></param>
        /// <param name="paramDic"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="isScrollbars"></param>
        /// <returns></returns>
        public static string OpenWin(string path, Dictionary<string, string> paramDic, int width, int height, bool isScrollbars)
        {
            if (isScrollbars)
            {
                var paramStr = "";
                if (paramDic != null && paramDic.Count > 0)
                {
                    paramStr = "?" + string.Join("&", paramDic.Keys.Select(key => $"{key}={paramDic[key]}").ToArray());
                }

                paramStr = $"window.open (\"{path}{paramStr}\", \"openWin\", \"height={height}, width={width},scrollbars=1\")";
                return WrapperScript(paramStr);
            }
            else
            {
                return (OpenWin(path, paramDic, width, height));
            }

        }


        /// <summary>
        /// 將字串以<script></script>包覆
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string WrapperScript(string str)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<script>");
            sb.AppendLine(str);
            sb.AppendLine("</script>");
            return sb.ToString();
        }


        public static string SuccessMsg(string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class='alert alert-success alert-dismissible'> ");
            sb.AppendLine("<button type = 'button' class='close' data-dismiss='alert' aria-hidden='true'>×</button>");
            sb.AppendLine("<h4><i class='icon fa fa-warning'></i>操作完成</h4>");
            sb.AppendLine(msg);
            sb.AppendLine("</div>");
            return sb.ToString();
        }
        public static string ErrorMsg(string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class='alert alert-danger alert-dismissible'> ");
            sb.AppendLine("<button type = 'button' class='close' data-dismiss='alert' aria-hidden='true'>×</button>");
            sb.AppendLine("<h4><i class='icon fa fa-warning'></i>操作失敗</h4>");
            sb.AppendLine(msg);
            sb.AppendLine("</div>");
            return sb.ToString();
        }
        public static void ShowMessage(Page page, string Message, MessageType type)
        {
            page.ClientScript.RegisterStartupScript(typeof(Page), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "','N');", true);
            //   Page.ScriptManager.RegisterStartupScript(typeof(Page), this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }
        public static void ShowMessage(Page page, string Message, MessageType type, string url)
        {
            page.ClientScript.RegisterStartupScript(typeof(Page), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "','" + url + "');", true);
            //   Page.ScriptManager.RegisterStartupScript(typeof(Page), this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }
        public enum ResultStatus : int
        {
            Success = 1,
            Error = 0
        }
    }
}

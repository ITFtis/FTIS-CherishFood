using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Tool
{
    public class JsonHelper
    {
        public static string SavePath = HttpContext.Current.Request.PhysicalApplicationPath + "json\\";
        public static string WebPath = Config.BaseUrl;

        /// <summary>
        /// 根据单元格将内容返回为对应类型的数据
        /// </summary>
        /// <param name="cell">单元格</param>
        /// <returns>数据</returns>
        public static T GetLocal<T>(string FilePath)
        {
            var fullPath = SavePath + FilePath;
            try
            {
                using (StreamReader r = new StreamReader(fullPath))
                {
                    string json = r.ReadToEnd();
                    T items = JsonConvert.DeserializeObject<T>(json);

                    return items;
                }
            }
            catch (Exception ex)
            { 
            
            }
            return default(T);
        }
    }
}
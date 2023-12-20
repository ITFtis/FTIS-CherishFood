using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;

namespace Tool
{
    /// <summary>
    /// FileUploadHelper 的摘要描述
    /// </summary>
    public class FileUploadHelper
    {
        public static string SavePath = Config.BaseDir;
        public static string WebPath = Config.BaseUrl;
        /// <summary>
        /// 檢查資料夾..沒有的話就建立
        /// </summary>
        public static void CheckDir()
        {
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
        }
        /// <summary>
        /// 檢查檔案是否已經存在
        /// </summary>
        public static bool CheckFile(string fileName)
        {
            return File.Exists(SavePath + fileName);
        }
        /// <summary>
        /// 檢查圖片寬度是否超過
        /// </summary>
        public static bool CheckPicPx(FileUpload myFileUpload, int allowWidth)
        {
            var picFile = myFileUpload.PostedFile.InputStream;
            var pic = System.Drawing.Image.FromStream(picFile);
            return pic.Width <= allowWidth;
        }
        /// <summary>
        /// 檢查副檔名
        /// </summary>
        public static bool CheckFuFileName(FileUpload myFileUpload, string[] allowExtensions)
        {
            var allow = false;

            var extension = Path.GetExtension(myFileUpload.FileName);
            if (extension == null) return false;
            var uploadFuFileName = extension.ToLower();
            //string[] allowExtensions ={ ".jpg", ".gif" };

            foreach (var t in allowExtensions)
            {
                if (uploadFuFileName == t)
                {
                    allow = true;
                }
            }

            return allow;
        }
        /// <summary>
        /// 刪除檔案
        /// </summary>
        /// <param name="filePath"></param>
        public static void DeleteUploadFile(string filePath)
        {

            File.Delete(filePath);
        }

        /// <summary>
        /// 刪除檔案
        /// </summary>
        public static void DeleteFile(string fileName)
        {
            if (CheckFile(fileName))
            {
                File.Delete(SavePath + fileName);
            }
        }

        /// <summary>
        /// 檔案上傳
        /// </summary>
        public static List<string> UploadFile(FileUpload fileUpload1)
        {
            CheckDir();// 檢查資料夾
            var myList = new List<string>();
            foreach (var postedFile in fileUpload1.PostedFiles)
            {
                var fileName = postedFile.FileName;
                var pathToCheck = fileName;
                var myCount = 2;
                while (CheckFile(pathToCheck))
                {
                    var tempfileName = myCount + "_" + fileName;
                    pathToCheck = tempfileName;
                    myCount++;
                }
                fileName = pathToCheck;
                postedFile.SaveAs(SavePath + fileName);
                myList.Add(fileName);
            }
            return myList;
        }


        /// <summary>
        /// 檔案上傳
        /// </summary>
        /// <param name="fileUpload1"></param>
        /// <param name="newName"></param>
        public static bool UploadFile(FileUpload fileUpload1, string newName)
        {
            var isSuccess = false;
            CheckDir();// 檢查資料夾
            try
            {
                if (fileUpload1.HasFile)
                {
                    fileUpload1.SaveAs(SavePath + newName);
                    isSuccess = true;
                }
            }
            catch (Exception)
            {
                throw  new Exception();
            }
            return isSuccess;
        }
    }
}
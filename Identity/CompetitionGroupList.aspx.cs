using ICSharpCode.SharpZipLib.Zip;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class Identity_CompetitionGroupList : System.Web.UI.Page
{
    private int Nid => (Request.QueryString["nid"] ?? "0").ToInt32();
    DataClassesDataContext _db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            e_Employees employee = null;
            if (Session["AdminId"] != null)
            {
                hidAdminId.Value = Session["AdminId"].ToString();
                employee = _db.e_Employees.FirstOrDefault(x => x.EmployeeId == hidAdminId.Value.ToInt32());
            }

            var allCity = JsonHelper.GetLocal<List<County>>(("TaiwanCountyData.json"));
            if (employee != null && employee.e_EmployeeRole_Mapping.Any(y => y.RoleId == 2))
            {
                allCity = allCity.Where(x => x.CityCode == employee.City).ToList();
            }
            //縣市別
            ddlCounty.Items.Clear();
            if (allCity.Count > 1) ddlCounty.Items.Add(new ListItem("--請選擇--", ""));
            ddlCounty.Items.AddRange(allCity.Select(x => new ListItem(x.CityName, x.CityCode)).ToArray());

            ListViewBind();
        }
    }
    public void ListViewBind()
    {
        var userResult = _db.CompetitionGroup.Where(x => x.TeamTypeId == 1).Select(x => new
        {
            x.Id,
            x.County,
            x.CountyName,
            x.ContestCode,
            x.WorkFile,
            x.AuthorizeFile,
            x.RepresentativeConsent,
            x.SignupStatus,
            MemberName = x.CompetitionGroupMember.FirstOrDefault(o => o.IsLeader).Name,
        });

        if (!string.IsNullOrEmpty(ddlCounty.SelectedValue))
        {
            userResult = userResult.Where(x => x.County == ddlCounty.SelectedValue);
        }

        if (!string.IsNullOrEmpty(txtKey.Text))
        {
            userResult = userResult.Where(x => x.ContestCode.Contains(txtKey.Text));
        }

        var employee = _db.e_Employees.FirstOrDefault(x => x.EmployeeId == hidAdminId.Value.ToInt32());
        if (employee != null && employee.e_EmployeeRole_Mapping.Any(y => y.RoleId == 2))
        {
            userResult = userResult.Where(x => x.County == employee.City);
        }


        ListView1.DataSource = userResult.OrderBy(x => x.Id).ToList();
        ListView1.DataBind();
    }
    protected void btn_OnCommand(object sender, CommandEventArgs e)
    {
        const string action = "CompetitionGroup";
        switch (e.CommandName)
        {
            case "GoEdit":
                Response.Redirect(action + "Edit.aspx?id=" + e.CommandArgument + "&nid=" + Nid);
                break;
            case "GoSearch":
                ListViewBind();
                break;
            case "DownloadWorkFile":
                DownloadFiles("CookBookWorkFile");
                break;
            case "DownloadAuthorizeFile":
                DownloadFiles("CookBookAuthorizeFile");
                break;
            case "DownloadRepresentativeConsent":
                DownloadFiles("CookBookRepresentativeConsent");
                break;
            case "GoExcel":
                OutputExcel();
                break;
        }
    }

    private void OutputExcel()
    {
        string ExcelName = "食譜組初賽報名資料_" + DateTime.Today.ToString("yyyyMMdd");
        var userResult = _db.CompetitionGroupMember.Where(x => x.CompetitionGroup.TeamTypeId == 1);

        if (!string.IsNullOrEmpty(ddlCounty.SelectedValue))
        {
            userResult = userResult.Where(x => x.CompetitionGroup.County == ddlCounty.SelectedValue);
        }

        if (!string.IsNullOrEmpty(txtKey.Text))
        {
            userResult = userResult.Where(x => x.CompetitionGroup.ContestCode.Contains(txtKey.Text));
        }

        var employee = _db.e_Employees.FirstOrDefault(x => x.EmployeeId == hidAdminId.Value.ToInt32());
        if (employee != null && employee.e_EmployeeRole_Mapping.Any(y => y.RoleId == 2))
        {
            userResult = userResult.Where(x => x.CompetitionGroup.County == employee.City);
        }

        var outputResult = userResult.ToList().AsEnumerable().
            Select(x => new
            {
                縣市 = x.CompetitionGroup.CountyName,
                參賽編號 = x.CompetitionGroup.ContestCode,
                審核 = GetStatus(x.CompetitionGroup.SignupStatus),
                參賽者名稱 = x.Name,
                參賽者身分證號 = x.IdentityNo,
                參賽者生日 = x.Birthday,
                參賽者電話 = x.Phone,
                參賽者信箱 = x.Mail,
                參賽者單位 = x.UnitName,
                參賽者職稱年級 = x.JobTitle,
            }).OrderByDescending(x => x.參賽編號);

        var excelData = ExcelHelper.LinqToDataTable(outputResult);
        excelData.Columns["參賽者單位"].ColumnName = "參賽者單位/學校";
        excelData.Columns["參賽者職稱年級"].ColumnName = "參賽者職稱/年級";

        // 產生 Excel 資料流。 
        Response.Clear();
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        MemoryStream ms = ExcelHelper.RenderDataTableToExcel(excelData) as MemoryStream;
        // 設定強制下載標頭。 
        Response.AddHeader("Content-Disposition", string.Format("attachment; filename=" + ExcelName + ".xlsx"));
        // 輸出檔案。 
        Response.BinaryWrite(ms.ToArray());
        ms.Close();
        ms.Dispose();
        Response.Flush();
        Response.End();
    }
    private void DownloadFiles(string directory)
    {
        var fileName = "";
        if (directory == "CookBookWorkFile") fileName = "食譜表";
        if (directory == "CookBookAuthorizeFile") fileName = "作品授權書";
        if (directory == "CookBookRepresentativeConsent") fileName = "法定代理人同意書";

        #region 抓資料
        var userResult = _db.CompetitionGroup.Where(x => x.TeamTypeId == 1).Select(x => new
        {
            x.Id,
            x.County,
            x.CountyName,
            x.ContestCode,
            x.WorkFile,
            x.AuthorizeFile,
            x.RepresentativeConsent,
            x.SignupStatus,
            MemberName = x.CompetitionGroupMember.FirstOrDefault(o => o.IsLeader).Name,
        });

        if (!string.IsNullOrEmpty(ddlCounty.SelectedValue))
        {
            userResult = userResult.Where(x => x.County == ddlCounty.SelectedValue);
        }

        if (!string.IsNullOrEmpty(txtKey.Text))
        {
            userResult = userResult.Where(x => x.ContestCode.Contains(txtKey.Text));
        }

        var employee = _db.e_Employees.FirstOrDefault(x => x.EmployeeId == hidAdminId.Value.ToInt32());
        if (employee != null && employee.e_EmployeeRole_Mapping.Any(y => y.RoleId == 2))
        {
            userResult = userResult.Where(x => x.County == employee.City);
        }
        #endregion

        var fileList = new List<string>();
        foreach (var item in userResult)
        {
            var filePath = "";
            switch (directory)
            {
                case "CookBookWorkFile":
                    if (!string.IsNullOrEmpty(item.WorkFile)) filePath = Config.BaseDir + item.WorkFile;
                    break;
                case "CookBookAuthorizeFile":
                    if (!string.IsNullOrEmpty(item.AuthorizeFile)) filePath = Config.BaseDir + item.AuthorizeFile;
                    break;
                case "CookBookRepresentativeConsent":
                    if (!string.IsNullOrEmpty(item.RepresentativeConsent)) filePath = Config.BaseDir + item.RepresentativeConsent;
                    break;
            }
            if (!string.IsNullOrEmpty(filePath))
                if (File.Exists(filePath))
                    fileList.Add(filePath);
        }
        var zipPath = Config.BaseDir + directory + ".zip";
        ZipFile(fileList, zipPath, 0);

        MemoryStream destination = new MemoryStream();

        using (FileStream source = File.Open(zipPath, FileMode.Open))
        {
            // Copy source to destination.
            source.CopyTo(destination);
        }
        destination.Position = 0;
        File.Delete(zipPath);

        // 產生 Excel 資料流。 
        Response.Clear();
        Response.ContentType = "application/zip";
        // 設定強制下載標頭。 
        Response.AddHeader("Content-Disposition", string.Format($"attachment; filename={fileName}.zip"));

        Response.BinaryWrite(destination.ToArray());
        destination.Close();
        destination.Dispose();
        Response.Flush();
        Response.End();
    }

    public string GetFile(object obj)
    {
        var p = "";
        if (!string.IsNullOrEmpty(obj?.ToString()))
        {
            var files = obj.ToString().Split(',');
            p = $"<a href='../WPContent/{obj.ToString()}' target=\"_blank\" download class=\"btn btn-primary\">檔案</a>";
        }
        return p;
    }
    public string GetStatus(object obj)
    {
        var p = "待審核";
        if (obj != null)
        {
            if (obj.ToString().ToBoolean()) p = "審核通過";
            else p = "補件";
        }
        return p;
    }

    public static void ZipFile(List<string> fileToZipS, string zipedFile, int Level)
    {

        foreach (string fileToZip in fileToZipS)
        {
            //如果文件没有找到，则报错
            if (!File.Exists(fileToZip))
            {
                throw new System.IO.FileNotFoundException("指定要压缩的文件: " + fileToZip + " 不存在!");
                break;
            }
        }

        using (FileStream ZipFile = File.Create(zipedFile))
        {
            using (ZipOutputStream ZipStream = new ZipOutputStream(ZipFile))
            {
                foreach (string fileToZip in fileToZipS)
                {
                    string fileName = fileToZip.Substring(fileToZip.LastIndexOf("\\") + 1);

                    using (FileStream fs = File.OpenRead(fileToZip))
                    {
                        byte[] buffer = new byte[fs.Length];
                        fs.Read(buffer, 0, buffer.Length);
                        fs.Close();

                        ZipEntry ZipEntry = new ZipEntry(fileName);
                        ZipStream.PutNextEntry(ZipEntry);
                        ZipStream.SetLevel(Level);

                        ZipStream.Write(buffer, 0, buffer.Length);
                    }
                }
                ZipStream.Finish();
                ZipStream.Close();
            }
        }
    }
}
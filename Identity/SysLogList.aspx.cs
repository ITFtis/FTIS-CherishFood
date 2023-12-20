using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class Identity_SysLogList : System.Web.UI.Page
{
    DataClassesDataContext _db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ListViewBind();
        }
    }
    public List<SysLog> GetData()
    {
        var userResult = _db.SysLog.Where(x => true);
        if (!string.IsNullOrEmpty(txtStartDate.Text))
        {
            userResult = userResult.Where(x => x.CreateDate >= txtStartDate.Text.ToDateTime());
        }
        if (!string.IsNullOrEmpty(txtEndDate.Text))
        {
            userResult = userResult.Where(x => x.CreateDate.Date <= txtEndDate.Text.ToDateTime().Value.Date);
        }

        return userResult.OrderByDescending(x => x.CreateDate).ToList();
    }
    public void ListViewBind()
    {
        var userResult = GetData().Select(x => new
        {
            x.Id,
            Action = x.Action == "login" ? "登入" : (x.Action == "logout" ? "登出" : ""),
            x.Account,
            x.IPsource,
            x.CreateDate,
            x.IsSuccess,
        });
        ListView1.DataSource = userResult;
        ListView1.DataBind();
    }

    protected void btn_OnCommand(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "GoSearch":
                ListViewBind();
                break;
            case "GoExcel":
                OutputExcel();
                break;
        }
    }
    private void OutputExcel()
    {
        string ExcelName = "系統登出入記錄_" + DateTime.Today.ToString("yyyyMMdd");
        var userResult = GetData();

        var outputResult = userResult.AsEnumerable().Select(x => new
        {
            操作行為 = x.Action == "login" ? "登入" : (x.Action == "logout" ? "登出" : ""),
            帳號 = x.Account,
            IP = x.IPsource,
            操作時間 = x.CreateDate.ToString("yyyy-MM-dd HH:mm"),
        }).OrderByDescending(x => x.操作時間).ToList();

        var excelData = ExcelHelper.LinqToDataTable(outputResult);

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
}
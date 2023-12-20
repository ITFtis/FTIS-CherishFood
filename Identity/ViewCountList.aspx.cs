using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

public partial class Identity_ViewCountList : System.Web.UI.Page
{
    private int Nid => (Request.QueryString["nid"] ?? "0").ToInt32();
    DataClassesDataContext _db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ListViewBind();
        }
    }
    public List<ViewCount> GetData()
    {
        var userResult = _db.ViewCount.Where(x => true);

        if (!string.IsNullOrEmpty(txtStartDate.Text))
        {
            userResult = userResult.Where(x => x.ViewDate >= txtStartDate.Text.ToDateTime());
        }

        if (!string.IsNullOrEmpty(txtEndDate.Text))
        {
            userResult = userResult.Where(x => x.ViewDate <= txtEndDate.Text.ToDateTime());
        }
        return userResult.AsEnumerable().GroupBy(x => x.ViewDate).Select(x => new ViewCount
        {
            ViewDate = x.Key,
            Counts = x.Sum(o => o.Counts)
        }).OrderByDescending(x => x.ViewDate).ToList();
    }
    public void ListViewBind()
    {
        var userResult = GetData();
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
                ExportExcel();
                break;
        }
    }

    private void ExportExcel()
    {
        var _data = GetData().AsEnumerable().Select(x => new
            {
                日期 = x.ViewDate.ToString("yyyy-MM-dd"),
                瀏覽量 = x.Counts
            }).OrderByDescending(x => x.日期);
        // 產生 Excel 資料流。 
        Response.Clear();
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        MemoryStream ms = ExcelHelper.RenderDataTableToExcel(ExcelHelper.LinqToDataTable(_data)) as MemoryStream;
        // 設定強制下載標頭。 
        Response.AddHeader("Content-Disposition", string.Format($"attachment; filename=網站瀏覽量_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx"));
        // 輸出檔案。 
        Response.BinaryWrite(ms.ToArray());
        ms.Close();
        ms.Dispose();
        Response.Flush();
        Response.End();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ascx_TaiwanCityControl : System.Web.UI.UserControl
{
    private class CityArea
    {
        public string City { get; set; }
        public List<Area> Areas { get; set; }
    }

    private class Area
    {
        public string AreaName { get; set; }
    }
    private string _CssClass = "";
    public string County
    {
        get { return ddlCity.SelectedValue; }
        set
        {
            var newResult = getCityArea();

            var listCity = newResult.Select(x => x.City).Distinct().ToList();
            ddlCity.Items.Clear();
            foreach (var row in listCity)
            {
                ddlCity.Items.Add(new ListItem(row));
            }
            ddlCity.Items.Insert(0, new ListItem("請選擇", ""));
            if (ddlCity.Items.FindByValue(value) != null)
            {

                ddlCity.SelectedValue = value;
                ddlCity_OnSelectedIndexChanged(null, null);
            }
        }
    }
   
    public string District
    {
        get { return ddlArea.SelectedValue; }
        set
        {
            ddlCity_OnSelectedIndexChanged(null, null);
            if (ddlArea.Items.FindByValue(value) != null)
            {
                ddlArea.SelectedValue = value;
            }
        }
    }
    private bool _CheckNull = false;
    public bool CheckNull
    {
        get { return _CheckNull; }
        set { _CheckNull = value; }
    }
    public string CssClass
    {
        get { return _CssClass; }
        set { _CssClass = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        RequiredFieldValidator1.Visible = CheckNull;
        RequiredFieldValidator4.Visible = CheckNull;
        ddlCity.CssClass = CssClass;
        ddlArea.CssClass = CssClass;
        //var newResult = getCityArea();
        //var listCity = newResult.Select(x => x.City).Distinct().ToList();
        //ddlCity.Items.Clear();
        //foreach (var row in listCity)
        //{
        //    ddlCity.Items.Add(new ListItem(row));
        //}
        //ddlCity.Items.Insert(0, new ListItem("請選擇", ""));
        //ddlCity_OnSelectedIndexChanged(null, null);
    }

    private List<CityArea> getCityArea(string city = null)
    {
        var newList = new List<CityArea>();

        var newCity = new CityArea();
        var newListArea = new List<Area>();
        var newArea = new Area();

        #region 台北市

        if (city == null || city == "台北市")
        {
            newCity = new CityArea();
            newListArea = new List<Area>();

            newCity.City = "台北市";

            newArea = new Area();
            newArea.AreaName = "中正區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "大同區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "中山區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "松山區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "大安區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "萬華區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "信義區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "士林區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "北投區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "內湖區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "南港區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "文山區";
            newListArea.Add(newArea);


            newCity.Areas = newListArea;
            newList.Add(newCity);
        }

        #endregion

        #region 基隆市

        if (city == null || city == "基隆市")
        {
            newCity = new CityArea();
            newListArea = new List<Area>();

            newCity.City = "基隆市";

            newArea = new Area();
            newArea.AreaName = "仁愛區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "信義區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "中正區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "中山區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "安樂區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "暖暖區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "七堵區";
            newListArea.Add(newArea);


            newCity.Areas = newListArea;
            newList.Add(newCity);
        }

        #endregion

        #region 新北市

        if (city == null || city == "新北市")
        {
            newCity = new CityArea();
            newListArea = new List<Area>();

            newCity.City = "新北市";

            newArea = new Area();
            newArea.AreaName = "萬里區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "金山區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "板橋區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "汐止區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "深坑區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "石碇區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "瑞芳區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "平溪區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "雙溪區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "貢寮區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "新店區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "坪林區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "烏來區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "永和區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "中和區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "土城區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "三峽區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "樹林區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "鶯歌區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "三重區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "新莊區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "泰山區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "林口區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "蘆洲區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "五股區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "八里區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "淡水區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "三芝區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "石門區";
            newListArea.Add(newArea);


            newCity.Areas = newListArea;
            newList.Add(newCity);
        }

        #endregion

        #region 連江縣

        if (city == null || city == "連江縣")
        {
            newCity = new CityArea();
            newListArea = new List<Area>();

            newCity.City = "連江縣";

            newArea = new Area();
            newArea.AreaName = "南竿鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "北竿鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "莒光鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "東引鄉";
            newListArea.Add(newArea);


            newCity.Areas = newListArea;
            newList.Add(newCity);
        }

        #endregion

        #region 宜蘭縣

        if (city == null || city == "宜蘭縣")
        {
            newCity = new CityArea();
            newListArea = new List<Area>();

            newCity.City = "宜蘭縣";

            newArea = new Area();
            newArea.AreaName = "宜蘭市";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "頭城鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "礁溪鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "壯圍鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "員山鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "羅東鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "三星鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "大同鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "五結鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "冬山鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "蘇澳鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "南澳鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "釣魚台";
            newListArea.Add(newArea);


            newCity.Areas = newListArea;
            newList.Add(newCity);

        }

        #endregion

        #region 新竹市

        if (city == null || city == "新竹市")
        {
            newCity = new CityArea();
            newListArea = new List<Area>();

            newCity.City = "新竹市";

            newArea = new Area();
            newArea.AreaName = "新竹市";
            newListArea.Add(newArea);


            newCity.Areas = newListArea;
            newList.Add(newCity);
        }

        #endregion

        #region 新竹縣

        if (city == null || city == "新竹縣")
        {
            newCity = new CityArea();
            newListArea = new List<Area>();

            newCity.City = "新竹縣";

            newArea = new Area();
            newArea.AreaName = "竹北市";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "湖口鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "新豐鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "新埔鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "關西鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "芎林鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "寶山鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "竹東鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "五峰鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "橫山鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "尖石鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "北埔鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "峨眉鄉";
            newListArea.Add(newArea);


            newCity.Areas = newListArea;
            newList.Add(newCity);

        }

        #endregion

        #region 桃園市

        if (city == null || city == "桃園市")
        {
            newCity = new CityArea();
            newListArea = new List<Area>();

            newCity.City = "桃園市";

            newArea = new Area();
            newArea.AreaName = "中壢市";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "平鎮市";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "龍潭鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "楊梅市";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "新屋鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "觀音鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "桃園市";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "龜山鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "八德市";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "大溪鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "復興鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "大園鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "蘆竹鄉";
            newListArea.Add(newArea);


            newCity.Areas = newListArea;
            newList.Add(newCity);
        }

        #endregion

        #region 苗栗縣

        if (city == null || city == "苗栗縣")
        {
            newCity = new CityArea();
            newListArea = new List<Area>();

            newCity.City = "苗栗縣";

            newArea = new Area();
            newArea.AreaName = "竹南鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "頭份鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "三灣鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "南庄鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "獅潭鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "後龍鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "通霄鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "苑裡鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "苗栗市";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "造橋鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "頭屋鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "公館鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "大湖鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "泰安鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "銅鑼鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "三義鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "西湖鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "卓蘭鎮";
            newListArea.Add(newArea);


            newCity.Areas = newListArea;
            newList.Add(newCity);
        }

        #endregion

        #region 台中市

        if (city == null || city == "台中市")
        {
            newCity = new CityArea();
            newListArea = new List<Area>();

            newCity.City = "台中市";

            newArea = new Area();
            newArea.AreaName = "中區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "東區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "南區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "西區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "北區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "北屯區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "西屯區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "南屯區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "太平區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "大里區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "霧峰區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "烏日區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "豐原區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "后里區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "石岡區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "東勢區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "和平區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "新社區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "潭子區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "大雅區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "神岡區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "大肚區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "沙鹿區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "龍井區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "梧棲區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "清水區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "大甲區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "外埔區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "大安區";
            newListArea.Add(newArea);


            newCity.Areas = newListArea;
            newList.Add(newCity);

        }

        #endregion

        #region 新北市

        if (city == null || city == "新北市")
        {
            newCity = new CityArea();
            newListArea = new List<Area>();


        }

        #endregion

        #region 彰化縣

        if (city == null || city == "彰化縣")
        {
            newCity = new CityArea();
            newListArea = new List<Area>();

            newCity.City = "彰化縣";

            newArea = new Area();
            newArea.AreaName = "彰化市";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "芬園鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "花壇鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "秀水鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "鹿港鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "福興鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "線西鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "和美鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "伸港鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "員林鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "社頭鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "永靖鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "埔心鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "溪湖鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "大村鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "埔鹽鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "田中鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "北斗鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "田尾鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "埤頭鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "溪州鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "竹塘鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "二林鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "大城鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "芳苑鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "二水鄉";
            newListArea.Add(newArea);


            newCity.Areas = newListArea;
            newList.Add(newCity);
        }

        #endregion

        #region 南投縣

        if (city == null || city == "南投縣")
        {
            newCity = new CityArea();
            newListArea = new List<Area>();

            newCity.City = "南投縣";

            newArea = new Area();
            newArea.AreaName = "南投市";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "中寮鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "草屯鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "國姓鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "埔里鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "仁愛鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "名間鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "集集鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "水里鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "魚池鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "信義鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "竹山鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "鹿谷鄉";
            newListArea.Add(newArea);


            newCity.Areas = newListArea;
            newList.Add(newCity);
        }

        #endregion

        #region 嘉義市

        if (city == null || city == "嘉義市")
        {
            newCity = new CityArea();
            newListArea = new List<Area>();

            newCity.City = "嘉義市";

            newArea = new Area();
            newArea.AreaName = "嘉義市";
            newListArea.Add(newArea);


            newCity.Areas = newListArea;
            newList.Add(newCity);
        }

        #endregion

        #region 嘉義縣

        if (city == null || city == "嘉義縣")
        {
            newCity = new CityArea();
            newListArea = new List<Area>();

            newCity.City = "嘉義縣";

            newArea = new Area();
            newArea.AreaName = "番路鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "梅山鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "竹崎鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "阿里山鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "中埔鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "大埔鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "水上鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "鹿草鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "太保市";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "朴子市";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "東石鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "六腳鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "新港鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "民雄鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "大林鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "溪口鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "義竹鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "布袋鎮";
            newListArea.Add(newArea);


            newCity.Areas = newListArea;
            newList.Add(newCity);
        }

        #endregion

        #region 雲林縣

        if (city == null || city == "雲林縣")
        {
            newCity = new CityArea();
            newListArea = new List<Area>();

            newCity.City = "雲林縣";

            newArea = new Area();
            newArea.AreaName = "斗南鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "大埤鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "虎尾鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "土庫鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "東勢鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "褒忠鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "台西鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "崙背鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "麥寮鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "斗六市";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "林內鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "古坑鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "莿桐鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "西螺鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "二崙鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "北港鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "水林鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "口湖鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "四湖鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "元長鄉";
            newListArea.Add(newArea);


            newCity.Areas = newListArea;
            newList.Add(newCity);
        }

        #endregion

        #region 台南市

        if (city == null || city == "台南市")
        {
            newCity = new CityArea();
            newListArea = new List<Area>();

            newCity.City = "台南市";

            newArea = new Area();
            newArea.AreaName = "中西區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "東區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "南區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "北區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "安平區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "安南區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "永康區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "歸仁區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "新化區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "左鎮區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "玉井區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "楠西區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "仁德區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "關廟區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "南化區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "龍崎區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "官田區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "麻豆區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "佳里區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "西港區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "七股區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "將軍區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "學甲區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "北門區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "新營區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "後壁區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "白河區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "東山區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "六甲區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "下營區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "柳營區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "鹽水區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "善化區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "大內區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "新市區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "安定區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "山上區";
            newListArea.Add(newArea);


            newCity.Areas = newListArea;
            newList.Add(newCity);
        }

        #endregion

        #region 高雄市

        if (city == null || city == "高雄市")
        {
            newCity = new CityArea();
            newListArea = new List<Area>();

            newCity.City = "高雄市";

            newArea = new Area();
            newArea.AreaName = "新興區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "前金區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "苓雅區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "鹽埕區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "鼓山區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "旗津區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "前鎮區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "三民區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "楠梓區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "小港區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "左營區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "仁武區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "大社區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "東沙群島";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "岡山區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "路竹區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "南沙群島";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "阿蓮區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "田寮區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "燕巢區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "橋頭區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "梓官區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "彌陀區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "湖內區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "永安區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "鳳山區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "大寮區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "林園區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "鳥松區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "大樹區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "旗山區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "美濃區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "六龜區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "內門區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "甲仙區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "杉林區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "桃源區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "茄萣區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "茂林區";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "那瑪夏區";
            newListArea.Add(newArea);


            newCity.Areas = newListArea;
            newList.Add(newCity);

        }

        #endregion

        #region 澎湖縣

        if (city == null || city == "澎湖縣")
        {
            newCity = new CityArea();
            newListArea = new List<Area>();

            newCity.City = "澎湖縣";

            newArea = new Area();
            newArea.AreaName = "馬公市";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "西嶼鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "望安鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "湖西鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "七美鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "白沙鄉";
            newListArea.Add(newArea);


            newCity.Areas = newListArea;
            newList.Add(newCity);
        }

        #endregion

        #region 金門縣

        if (city == null || city == "金門縣")
        {
            newCity = new CityArea();
            newListArea = new List<Area>();

            newCity.City = "金門縣";

            newArea = new Area();
            newArea.AreaName = "金沙鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "金湖鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "金寧鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "金城鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "烈嶼鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "烏坵鄉";
            newListArea.Add(newArea);


            newCity.Areas = newListArea;
            newList.Add(newCity);
        }

        #endregion

        #region 屏東縣

        if (city == null || city == "屏東縣")
        {
            newCity = new CityArea();
            newListArea = new List<Area>();

            newCity.City = "屏東縣";

            newArea = new Area();
            newArea.AreaName = "屏東市";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "三地門鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "霧台鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "瑪家鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "九如鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "里港鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "高樹鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "鹽埔鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "長治鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "麟洛鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "竹田鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "內埔鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "萬丹鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "潮州鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "泰武鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "萬巒鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "來義鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "崁頂鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "新埤鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "南州鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "林邊鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "東港鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "琉球鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "佳冬鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "新園鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "枋寮鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "枋山鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "獅子鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "車城鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "牡丹鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "恆春鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "滿州鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "春日鄉";
            newListArea.Add(newArea);


            newCity.Areas = newListArea;
            newList.Add(newCity);
        }

        #endregion

        #region 台東縣

        if (city == null || city == "台東縣")
        {
            newCity = new CityArea();
            newListArea = new List<Area>();

            newCity.City = "台東縣";

            newArea = new Area();
            newArea.AreaName = "台東市";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "綠島鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "蘭嶼鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "卑南鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "鹿野鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "關山鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "海端鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "池上鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "延平鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "東河鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "成功鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "長濱鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "太麻里鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "大武鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "達仁鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "金峰鄉";
            newListArea.Add(newArea);


            newCity.Areas = newListArea;
            newList.Add(newCity);
        }

        #endregion

        #region 花蓮縣

        if (city == null || city == "花蓮縣")
        {
            newCity = new CityArea();
            newListArea = new List<Area>();

            newCity.City = "花蓮縣";

            newArea = new Area();
            newArea.AreaName = "花蓮市";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "新城鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "秀林鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "吉安鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "壽豐鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "鳳林鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "光復鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "豐濱鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "瑞穗鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "玉里鎮";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "萬榮鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "富里鄉";
            newListArea.Add(newArea);

            newArea = new Area();
            newArea.AreaName = "卓溪鄉";
            newListArea.Add(newArea);


            newCity.Areas = newListArea;
            newList.Add(newCity);
        }

        #endregion

        #region 新北市

        //if (city == null || city == "新北市")
        //{
        //    newCity = new CityArea();
        //    newListArea = new List<Area>();


        //}

        #endregion

        #region 新北市

        if (city == null || city == "新北市")
        {
            newCity = new CityArea();
            newListArea = new List<Area>();


        }

        #endregion


        #region 測試

        //if (city == null || city == "台北市")
        //{
        //    newCity = new CityArea();
        //    newListArea = new List<Area>();

        //    newCity.City = "台北市";

        //    newArea = new Area();
        //    newArea.AreaName = "中正區";
        //    newListArea.Add(newArea);

        //    newCity.Areas = newListArea;
        //    newList.Add(newCity);
        //}

        #endregion



        return newList;
    }

    protected void ddlCity_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        var newResult = getCityArea(ddlCity.SelectedValue);
        var listArea = newResult.FirstOrDefault()?.Areas;
        ddlArea.Items.Clear();
        ddlArea.Items.Insert(0, new ListItem("請選擇"));
        if (listArea != null)
            foreach (var row in listArea)
            {
                ddlArea.Items.Add(new ListItem(row.AreaName));
            }
    }
    public void CountySet(string county)
    {
        ddlCity.SelectedValue = county;
        ddlCity_OnSelectedIndexChanged(null, null);
    }
}
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sitemap.aspx.cs" Inherits="Sitemap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="inner-banner">
        <div class="ss01"></div>
        <div class="ss02"></div>
        <div class="ss03"></div>
        <div class="light_inner"></div>
        <!--電腦版banner圖-->
        <img src="images/main_KV.jpg" alt="首惜廚師，惜食{美味食譜}{創意教案}甄選，總獎金70萬等你來挑戰" class="pc-banner">
        <!--手機版banner圖-->
        <img src="images/main_KV_mobile.jpg" alt="" class="mobile-banner">
    </div>
    <div class="title-area" id="content">
        <a href="#C" title="中央內容區塊" id="AC" accesskey="C" name="C" class="accesskey ac">:::</a>
        <h2 class="unit-title">網站導覽</h2>
        <div class="path">
            <ul>
                <li><a href="index.aspx">首頁</a></li>
                <li>網站導覽</li>
            </ul>
        </div>
    </div>
    <div class="main-content">
        <div class="wrapper">
            <!-----內容區------>
            <div class="white-box unit-sitemap-area">
                <p>
                    本網站依『無障礙網頁開發規範』設計原則而建置，遵循無障礙網站設計之規範提供網頁導盲磚（:::）、網站導覽（Site Navigator）、鍵盤快速鍵（Access Key）等設計方式。<br>
                    網站的主要樣版內容分為二個大區塊：<br>
                    1）上方導覽連結區<br>
                    2）主要內容顯示區<br>
                    本網站的便捷鍵﹝Accesskey,也稱為快速鍵﹞設定如下：<br>
                    Alt+U：最上層選單功能區，移至網頁最上方之項目位置。<br>
                    Alt+C：主要內容顯示區，移至網頁之主要內容位置。
                            <br>
                    Alt+Z：下方頁尾資訊區塊。                            
                </p>
                <br>
                <br>
                <div class="mainitem"><a href="Preliminary.aspx" title="各縣市初賽">1.各縣市初賽</a></div>
                <ul class="subitem">
                    <li><a href="Apply.aspx" title="各縣市初賽-我要報名-食譜組">1-1 各縣市初賽-我要報名-食譜組</a></li>
                    <li><a href="Apply.aspx" title="各縣市初賽-我要報名-教案組">1-2 各縣市初賽-我要報名-教案組</a></li>
                </ul>
                <div class="mainitem"><a href="Final.aspx" title="全國決賽">2.全國決賽</a></div>
                <div class="mainitem"><a href="WorkShop.aspx" title="工作坊">3.工作坊</a></div>
                <div class="mainitem"><a href="News.aspx" title="最新消息">4.最新消息</a></div>
                <div class="mainitem"><a href="Highlights.aspx" title="精彩花絮">5.精彩花絮</a></div>
                <div class="mainitem"><a href="Contact.aspx" title="聯絡我們">6.聯絡我們</a></div>
                <div class="mainitem"><a href="javascript:void（0）" target="_blank" title="環保局登入（另開新頁面）">7.環保局登入（另開新頁面）</a></div>
            </div>
            <!---//edit-area white-box------>
            <!-----//內容區END------>
        </div>
        <!--//wrapper--->
    </div>
    <!--//main-content-->
</asp:Content>


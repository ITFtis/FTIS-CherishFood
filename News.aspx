<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="News" %>

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
        <h2 class="unit-title">最新消息</h2>
        <div class="path">
            <ul>
                <li><a href="index.aspx">首頁</a></li>
                <li>最新消息</li>
            </ul>
        </div>
    </div>
    <div class="main-content">
        <div class="wrapper">
            <!-----內容區------>
            <ul class="news-list j-d-flex j-flex-wrap">
                <asp:ListView ID="ListViewNews" runat="server">
                    <ItemTemplate>
                        <li>
                            <a href='NewsContent.aspx?Id=<%# Eval("Id") %>'>
                                <div class="photo">
                                    <img src='../WPContent/<%# Eval("MainPic") %>' alt="">
                                </div>
                                <p class="news-date"><%# Eval("ReleaseDate","{0:yyyy/MM/dd}") %></p>
                                <div class="news-title"><%# Eval("Title") %></div>
                            </a>
                        </li>
                    </ItemTemplate>
                </asp:ListView>
            </ul>
            <!-----//內容區END------>
        </div>
        <!--//wrapper--->

    </div>
    <!--//main-content-->
</asp:Content>


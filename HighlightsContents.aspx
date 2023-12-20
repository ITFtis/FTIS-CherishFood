<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HighlightsContents.aspx.cs" Inherits="HighlightsContents" %>

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
        <h2 class="unit-title">精彩花絮</h2>
        <div class="path">
            <ul>
                <li><a href="index.aspx">首頁</a></li>
                <li>精彩花絮</li>
            </ul>
        </div>
    </div>



    <div class="main-content">
        <div class="wrapper">
            <!-----內容區------>
            <div class="news-content-title j-d-flex">
                <div class="news-content-date">
                    <asp:Literal ID="litReleaseDate" runat="server"></asp:Literal></div>
                <h2>
                    <asp:Literal ID="litTitle" runat="server"></asp:Literal></h2>
            </div>

            <div class="edit-area white-box">
                <asp:Image ID="imgMainPic" runat="server" />
                <asp:Literal ID="litContents" runat="server"></asp:Literal>
            </div>
            <!---//編輯器edit-area white-box------>

            <!---影片區---->
            <asp:PlaceHolder ID="PlaceHolderVideo" runat="server">
                <div class="edit-area white-box video-box">
                    <div class="video-container">
                        <asp:Literal ID="litYoutubeLink" runat="server"></asp:Literal>
                    </div>
                </div>
            </asp:PlaceHolder>
            <!---//影片區---->

            <!-----//內容區END------>
        </div>
        <!--//wrapper--->

    </div>
    <!--//main-content-->
</asp:Content>


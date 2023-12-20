<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="WorkShop.aspx.cs" Inherits="WorkShop" %>

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
        <h2 class="unit-title">工作坊</h2>
        <div class="path">
            <ul>
                <li><a href="index.aspx">首頁</a></li>
                <li>工作坊</li>
            </ul>
        </div>
    </div>
    <div class="main-content">
        <div class="wrapper">
            <!-----內容區------>
            <div class="edit-area white-box">
                <asp:Literal ID="litContents" runat="server"></asp:Literal>
            </div>
            <!---//編輯器edit-area white-box------>
            <!-----//內容區END------>
        </div>
        <!--//wrapper--->
    </div>
    <!--//main-content-->
</asp:Content>


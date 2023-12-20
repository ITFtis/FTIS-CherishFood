<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Preliminary.aspx.cs" Inherits="Preliminary" %>

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
        <h2 class="unit-title">各縣市初賽</h2>
        <div class="path">
            <ul>
                <li><a href="index.aspx">首頁</a></li>
                <li>各縣市初賽</li>
            </ul>
        </div>
    </div>
    <div class="main-content">
        <div class="wrapper">
            <!-----內容區------>
            <h3 class="k-apply-title set-mt">初賽相關事宜請洽各直轄市、縣（市）環境保護局</h3>
            <ul class="k-first-list">
                <asp:ListView ID="ListViewCounty" runat="server">
                    <ItemTemplate>
                        <li>
                            <div class="k-item">
                                <div class="k-img">
                                    <%# GetFile(Eval("Pics"), 3) %>
                                </div>
                                <div class="k-info">
                                    <h3><%# Eval("CountyName") %></h3>
                                    <p>報名時間：<%# Eval("SignupStartDate","{0:MM/dd}") %>~<%# Eval("SignupEndDate","{0:MM/dd}") %></p>
                                    <p><%# Eval("ContactUser") %></p>
                                </div>
                                <ul class="k-btn">
                                    <li><%# GetSign(Eval("Id"),Eval("SignupStartDate"),Eval("SignupEndDate")) %></li>
                                    <li><%# GetFile(Eval("IntroduceFile"), 1) %></li>
                                    <li><a href='ApplySearch.aspx?Id=<%# Eval("Id") %>' class="k-btn-apply">報名查詢</a></li>
                                    <li><%# GetFile(Eval("PreliminaryAwardFile"), 2) %></li>
                                </ul>
                            </div>
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


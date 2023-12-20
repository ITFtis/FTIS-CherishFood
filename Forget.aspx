<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Forget.aspx.cs" Inherits="Forget" %>

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
        <h2 class="unit-title">各縣市初賽<span>忘記密碼</span></h2>
        <div class="path">
            <ul>
                <li><a href="index.aspx">首頁</a></li>
                <li>忘記密碼</li>
            </ul>
        </div>
    </div>
    <div class="main-content">
        <div class="wrapper">
            <!-----內容區------>
            <h3 class="k-apply-title set-mt">初賽相關事宜請洽各直轄市、縣（市）環境保護局</h3>
            <h3 class="k-apply-title">請填寫您的帳號，<span>密碼重設函會發送到您註冊時的email信箱</span></h3>
            <div class="k-form-box k-search-box">
                <div>
                    <div class="k-apply-search">
                        <ul class="k-form-list">
                            <li>
                                <label class="k-form-label" for="txtAccount">會員帳號</label>
                                <asp:TextBox ID="txtAccount" runat="server" CssClass="k-form-input" placeholder="請輸入會員帳號（身分證字號）" required></asp:TextBox>
                            </li>
                        </ul>
                        <asp:Button ID="Button1" runat="server" Text="確認送出" CssClass="k-btn-common k-btn-search" OnClick="Button1_Click"/>
                    </div>
                </div>
            </div>
            <a href="Preliminary.aspx" class="k-btn-common k-btn-lg">回縣市初賽頁</a>
            <!-----//內容區END------>
        </div>
        <!--//wrapper--->
    </div>
    <!--//main-content-->
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src='https://www.google.com/recaptcha/api.js'></script>
    <script src="https://www.google.com/recaptcha/api.js?render=6LfK67QkAAAAAA1RrA11rFHuW4DntHKansB-A5Je&onload=onloadCallback&render=explicit" async defer></script>

    <script type="text/javascript">
        var onloadCallback = function () {
            grecaptcha.execute('6LfK67QkAAAAAA1RrA11rFHuW4DntHKansB-A5Je', { action: 'login' }).then(function (token) {
                $('<%="#"+hidtoken.ClientID%>').val(token);
            });
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hidtoken" runat="server" />
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
        <h2 class="unit-title">各縣市初賽<span>會員登入</span></h2>
        <div class="path">
            <ul>
                <li><a href="index.aspx">首頁</a></li>
                <li>會員登入</li>
            </ul>
        </div>
    </div>
    <div class="main-content">
        <div class="wrapper">
            <!-----內容區------>
            <h3 class="k-apply-title set-mt">初賽相關事宜請洽各直轄市、縣（市）環境保護局</h3>
            <div class="k-apply-title">請填寫報名時填寫的會員登入資料</div>
            <div class="k-form-box k-search-box">
                <div>
                    <div class="k-apply-search">
                        <ul class="k-form-list">
                            <li>
                                <label class="k-form-label" for="your_name">會員帳號</label>
                                <asp:TextBox ID="txtAccount" runat="server" CssClass="k-form-input" placeholder="請輸入會員帳號（身分證字號/護照號碼）"></asp:TextBox>
                            </li>
                            <li>
                                <label class="k-form-label" for="your_id">會員密碼</label>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="k-form-input" placeholder="請輸會員密碼" TextMode="Password"></asp:TextBox>
                            </li>
                        </ul>
                        <asp:Button ID="Button1" runat="server" Text="確認送出" CssClass="k-btn-common k-btn-search" OnClick="Button1_Click"/>
                    </div>
                </div>
            </div>
            <a href="Forget.aspx" class="k-btn-common k-btn-lg">忘記密碼</a>
            <a href="Preliminary.aspx" class="k-btn-common k-btn-lg">回縣市初賽頁</a>
            <!-----//內容區END------>
        </div>
        <!--//wrapper--->
    </div>
    <!--//main-content-->
</asp:Content>


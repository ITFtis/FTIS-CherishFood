<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ApplySearch.aspx.cs" Inherits="ApplySearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
        <h2 class="unit-title">各縣市初賽<span>報名查詢</span></h2>
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
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="k-apply-box">
                        <ul class="k-navbar">
                            <li>
                                <asp:Literal ID="litApply" runat="server"></asp:Literal>
                            </li>
                            <li>
                                <asp:Literal ID="litIntroduceFile" runat="server"></asp:Literal></li>
                            <li>
                                <asp:Literal ID="litOdtFile" runat="server"></asp:Literal></li>
                            <li class="active"><a href="#" class="k-btn-apply" style="pointer-events: none;">報名查詢</a></li>
                            <li>
                                <asp:Literal ID="litPreliminaryAwardFile" runat="server"></asp:Literal></li>
                        </ul>
                        <div class="k-apply-info">
                            <div class="k-info-box">
                                <div class="k-img">
                                    <asp:Literal ID="litPics" runat="server"></asp:Literal>
                                </div>
                                <div class="k-info">
                                    <h3>報名單位：<span><asp:Literal ID="litCounty" runat="server"></asp:Literal></span></h3>
                                    <p>報名時間：<asp:Literal ID="litSignRange" runat="server"></asp:Literal></p>
                                    <p>
                                        <asp:Literal ID="litContactUser" runat="server"></asp:Literal>
                                    </p>
                                </div>
                            </div>
                            <fieldset class="k-group">
                                <legend>請選擇要查詢的參賽組別：</legend>
                                <div class="k-group-select">
                                    <label class="k-form-radio">
                                        惜食料理食譜組
                                        <asp:RadioButton ID="rbCookbook" runat="server" GroupName="group" Checked="true" OnCheckedChanged="rb_CheckedChanged" AutoPostBack="true" />
                                        <span class="k-checkmark"></span>
                                    </label>
                                    <label class="k-form-radio">
                                        惜食教案組
                                        <asp:RadioButton ID="rbLessonPlan" runat="server" GroupName="group" OnCheckedChanged="rb_CheckedChanged" AutoPostBack="true" />
                                        <span class="k-checkmark"></span>
                                    </label>
                                </div>
                            </fieldset>
                        </div>
                    </div>
                    <asp:PlaceHolder ID="PlaceHolderSearch" runat="server">
                        <div class="k-apply-title">請填寫報名時填寫的資料</div>
                        <div class="k-form-box k-search-box">
                            <div>
                                <div class="k-apply-search">
                                    <ul class="k-form-list">
                                        <li>
                                            <label class="k-form-label" for="your_name">姓名</label>
                                            <asp:TextBox ID="txtName" runat="server" CssClass="k-form-input" placeholder="請輸入參賽者／隊長姓名" required AutoComplete="OFF"></asp:TextBox>
                                        </li>
                                        <li>
                                            <label class="k-form-label" for="your_id">身分證或護照證號</label>
                                            <asp:TextBox ID="txtIdmo" runat="server" CssClass="k-form-input" placeholder="請輸入參賽者／隊長身分證號或護照號" required AutoComplete="OFF"></asp:TextBox>
                                        </li>
                                    </ul>
                                    <asp:Button ID="Button1" runat="server" Text="確認送出" CssClass="k-btn-common k-btn-search" OnClick="Button1_Click" />
                                </div>
                            </div>
                        </div>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolderResult" runat="server">
                        <div class="k-form-box k-apply-msg">
                            <div class="k-apply-success">
                                <p>
                                    <asp:Literal ID="litMsg" runat="server"></asp:Literal>
                                </p>
                            </div>
                        </div>
                    </asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
            <a href="Preliminary.aspx" class="k-btn-common k-btn-lg">回縣市初賽頁</a>
            <!-----//內容區END------>
        </div>
        <!--//wrapper--->

    </div>
    <!--//main-content-->
</asp:Content>


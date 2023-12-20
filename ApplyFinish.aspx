<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ApplyFinish.aspx.cs" Inherits="ApplyFinish" %>

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
        <h2 class="unit-title">各縣市初賽<span>我要報名</span></h2>
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
            <div class="k-apply-box">
                <ul class="k-navbar">
                    <li class="active"><a href="#" class="k-btn-apply" style="pointer-events: none;">我要報名</a></li>
                    <li>
                        <asp:Literal ID="litIntroduceFile" runat="server"></asp:Literal></li>
                    <li>
                        <asp:Literal ID="litOdtFile" runat="server"></asp:Literal></li>
                    <li>
                        <asp:Literal ID="litApplySearch" runat="server"></asp:Literal></li>
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
                    <%--<fieldset class="k-group">
                        <legend>請選擇要查詢的參賽組別：</legend>
                        <div class="k-group-select">
                            <label class="k-form-radio">
                                惜食料理食譜組
                                        <asp:RadioButton ID="rbCookbook" runat="server" GroupName="group" Enabled="false" />
                                <span class="k-checkmark"></span>
                            </label>
                            <label class="k-form-radio">
                                惜食教案組
                                        <asp:RadioButton ID="rbLessonPlan" runat="server" GroupName="group" Enabled="false" />
                                <span class="k-checkmark"></span>
                            </label>
                        </div>
                    </fieldset>--%>
                </div>
            </div>
            <div class="k-apply-title">您要報名參賽的組別：<span><asp:Literal ID="litGroupName" runat="server"></asp:Literal></span></div>
            <div class="k-form-box k-apply-msg">
                <div class="k-apply-success">
                    <p>~您已報名成功~</p>
                    <p class="k-no">您的參賽編號：<span><asp:Literal ID="litContestCode" runat="server"></asp:Literal></span></p>
                </div>
            </div>
            <a href="Preliminary.aspx" class="k-btn-common k-btn-lg">回縣市初賽頁</a>


            <!-----//內容區END------>
        </div>
        <!--//wrapper--->

    </div>
    <!--//main-content-->
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Identity/MasterPage.master" AutoEventWireup="true" CodeFile="SystemSettingEdit.aspx.cs" Inherits="Identity_SystemSettingEdit" ValidateRequest="false" %>

<%@ Register Src="~/Identity/SiteMap.ascx" TagPrefix="uc1" TagName="SiteMap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hidAdminId" runat="server" />
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <uc1:SiteMap runat="server" ID="SiteMap" />
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
        <!-- Main content -->
        <section class="content">
            <div class="box box-info box-solid">
                <div class="box-header with-border">
                    <h3 class="box-title">內容</h3>
                    <!-- /.box-tools -->
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="col-lg-12 ">
                        <div class="form-group  ">
                            <asp:Label ID="Label2" AssociatedControlID="txtGoogleAnalyticId" Text="Google Analytic 評估Id" runat="server" />
                            <asp:TextBox ID="txtGoogleAnalyticId" runat="server" CssClass="form-control"></asp:TextBox>
                            <div class="help-block with-errors"></div>
                        </div>
                        <div class="form-group  ">
                            <asp:Label ID="Label1" AssociatedControlID="txtContents" Text="Header設定" runat="server" />
                            <asp:TextBox ID="txtContents" TextMode="MultiLine" Rows="10" runat="server" CssClass="form-control"></asp:TextBox>
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>
                    <%--<div class="col-lg-6 ">
                        <div class="form-group  ">
                            <asp:Label ID="Label2" AssociatedControlID="txtGoogleAnalyticId" Text="Google Analytic 評估Id" runat="server" />
                            <asp:TextBox ID="txtGoogleAnalyticId" runat="server" CssClass="form-control"></asp:TextBox>
                            <div class="help-block with-errors"></div>
                        </div>
                        <div class="form-group  ">
                            <asp:Label ID="Label3" AssociatedControlID="txtFacebookPixelId" Text="Facebook Pixel Id" runat="server" />
                            <asp:TextBox ID="txtFacebookPixelId" runat="server" CssClass="form-control"></asp:TextBox>
                            <div class="help-block with-errors"></div>
                        </div>
                        <div class="form-group  ">
                            <asp:Label ID="Label4" AssociatedControlID="txtFacebookFanPageName" Text="Facebook粉專名稱" runat="server" />
                            <asp:TextBox ID="txtFacebookFanPageName" runat="server" CssClass="form-control"></asp:TextBox>
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>
                    <div class="col-lg-6 ">
                        <div class="form-group  ">
                            <asp:Label ID="Label6" AssociatedControlID="txtLineAccountId" Text="LINE官方帳號網址" runat="server" />
                            <asp:TextBox ID="txtLineAccountId" runat="server" CssClass="form-control" TextMode="Url"></asp:TextBox>
                            <div class="help-block with-errors"></div>
                        </div>
                        <div class="form-group  ">
                            <asp:Label ID="Label7" AssociatedControlID="txtServicePhone" Text="客服電話" runat="server" />
                            <asp:TextBox ID="txtServicePhone" runat="server" CssClass="form-control"></asp:TextBox>
                            <div class="help-block with-errors"></div>
                        </div>
                        <div class="form-group  ">
                            <asp:Label ID="Label5" AssociatedControlID="txtFacebookFanPage" Text="Facebook粉專網址" runat="server" />
                            <asp:TextBox ID="txtFacebookFanPage" runat="server" CssClass="form-control" TextMode="Url"></asp:TextBox>
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>--%>
                    <!-- /.box-body -->
                </div>
                <div class="box-footer">
                    <asp:Button ID="btnSave" runat="server" Text="儲存" CssClass="btn btn-info pull-right" CommandName="GoSave" OnCommand="btn_OnCommand" />
                </div>
            </div>
            <!-- /.row -->
        </section>
        <!-- /.content -->
    </div>
</asp:Content>


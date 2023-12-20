<%@ Page Title="" Language="C#" MasterPageFile="~/Identity/MasterPage.master" AutoEventWireup="true" CodeFile="CompetitionGroupList.aspx.cs" Inherits="Identity_CompetitionGroupList" %>

<%@ Register Src="~/Identity/SiteMap.ascx" TagPrefix="uc1" TagName="SiteMap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper">
        <uc1:SiteMap runat="server" />
        <section class="content">
            <div class="row">
                <div class="col-xs-12">
                    <asp:HiddenField ID="hidAdminId" runat="server" />
                    <div class="box box-info box-solid">
                        <div class="box-header with-border">
                            <h3 class="box-title">進階搜尋</h3>
                            <div class="box-tools pull-right">
                                <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                    <i class="fa fa-plus"></i>
                                </button>
                            </div>
                            <!-- /.box-tools -->
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">
                            <div class="col-lg-6">
                                <div class="form-group  ">
                                    <asp:Label ID="Label3" AssociatedControlID="ddlCounty" Text="縣市" runat="server" />
                                    <asp:DropDownList ID="ddlCounty" CssClass="form-control select2" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group  ">
                                    <asp:Label ID="Label1" AssociatedControlID="txtKey" Text="關鍵字" runat="server" />
                                    <asp:TextBox ID="txtKey" runat="server" CssClass="form-control" placeholder="請輸入參賽編號"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="box-footer">
                            <h3 class="box-title " style="float: right">
                                <asp:Button ID="Button4" runat="server" Text="匯出" CssClass="btn btn-warning " CommandName="GoExcel" OnCommand="btn_OnCommand" CausesValidation="false" />
                                <asp:Button ID="Button3" runat="server" Text="搜尋" CssClass="btn btn-primary " CommandName="GoSearch" OnCommand="btn_OnCommand" CausesValidation="false" />
                            </h3>
                        </div>
                        <!-- /.box-body -->

                    </div>
                    <div class="box">
                        <div class="box-header">
                            <h3 class="box-title " style="float: right">
                                <asp:Button ID="btnGoadd" runat="server" Text="下載食譜表" CssClass="btn btn-success" CommandName="DownloadWorkFile" OnCommand="btn_OnCommand" CausesValidation="false" />
                                <asp:Button ID="Button1" runat="server" Text="下載授權書" CssClass="btn btn-success" CommandName="DownloadAuthorizeFile" OnCommand="btn_OnCommand" CausesValidation="false" />
                                <asp:Button ID="Button2" runat="server" Text="下載同意書" CssClass="btn btn-success" CommandName="DownloadRepresentativeConsent" OnCommand="btn_OnCommand" CausesValidation="false" />
                            </h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">
                            <asp:Literal ID="LitAlertMsg" runat="server"></asp:Literal>
                            <asp:HiddenField ID="listSelectKey" runat="server" />
                            <asp:ListView ID="ListView1" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Container.DataItemIndex +1 %></td>
                                        <td><%# Eval("CountyName") %></td>
                                        <td><%# Eval("ContestCode") %></td>
                                        <td><%# Eval("MemberName") %></td>
                                        <td><%# GetFile(Eval("WorkFile"))%></td>
                                        <td><%# GetFile(Eval("AuthorizeFile"))%></td>
                                        <td><%# GetFile(Eval("RepresentativeConsent"))%></td>
                                        <td><%# GetStatus(Eval("SignupStatus")) %></td>
                                        <td>
                                            <asp:Button ID="lvbtnEdit" runat="server" Text="修改" CssClass="btn btn-info" CausesValidation="false" CommandName="GoEdit" OnCommand="btn_OnCommand" CommandArgument='<%# Eval("Id") %>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    無資料
                                </EmptyDataTemplate>
                                <LayoutTemplate>
                                    <table class="table table-bordered table-striped dataTables">
                                        <thead>
                                            <tr>
                                                <th>序號</th>
                                                <th>縣市</th>
                                                <th>參賽編號</th>
                                                <th>參賽者名稱</th>
                                                <th>食譜表</th>
                                                <th>作品授權書</th>
                                                <th>法定代理人同意書</th>
                                                <th>確認</th>
                                                <th class="col-lg-3">修改</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr id="itemPlaceholder" runat="server">
                                            </tr>
                                        </tbody>
                                    </table>
                                </LayoutTemplate>
                            </asp:ListView>
                        </div>
                        <!-- /.box-body -->
                    </div>
                    <!-- /.box -->
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->
        </section>
        <!-- /.content -->
    </div>
</asp:Content>


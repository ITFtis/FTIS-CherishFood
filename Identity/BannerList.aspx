<%@ Page Title="" Language="C#" MasterPageFile="~/Identity/MasterPage.master" AutoEventWireup="true" CodeFile="BannerList.aspx.cs" Inherits="Identity_BannerList" %>

<%@ Register Src="~/Identity/SiteMap.ascx" TagPrefix="uc1" TagName="SiteMap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper">
        <uc1:SiteMap runat="server" />
        <section class="content">
            <div class="row">
                <div class="col-xs-12">
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
                            <div class="col-lg-12">
                                <div class="form-group  ">
                                    <asp:Label ID="Label1" AssociatedControlID="txtSearchKey" Text="關鍵字" runat="server" />
                                    <asp:TextBox ID="txtSearchKey" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="box-footer">
                            <h3 class="box-title " style="float: right">
                                <asp:Button ID="Button4" runat="server" Text="匯出" CssClass="btn btn-warning " CommandName="GoExcel" OnCommand="btn_OnCommand" Visible="False" CausesValidation="false" />
                                <asp:Button ID="Button3" runat="server" Text="搜尋" CssClass="btn btn-primary " CommandName="GoSearch" OnCommand="btn_OnCommand" CausesValidation="false" />
                            </h3>
                        </div>
                        <!-- /.box-body -->

                    </div>
                    <div class="box">
                        <div class="box-header">
                            <h3 class="box-title " style="float: right">
                                <asp:Button ID="btnGoadd" runat="server" Text="新增" CssClass="btn btn-primary " CommandName="GoAdd" OnCommand="btn_OnCommand" CausesValidation="false" />
                            </h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">
                            <asp:Literal ID="LitAlertMsg" runat="server"></asp:Literal>
                            <asp:HiddenField ID="listSelectKey" runat="server" />
                            <asp:ListView ID="ListView1" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:HiddenField ID="hidId" runat="server" Value='<%# Eval("Id") %>'/>
                                            <%# Eval("Sort") %>
                                        </td>
                                        <td><%# Eval("Title") %></td>
                                        <td><%# GetDisPic(Eval("PcPic"))%></td>
                                        <td><%# GetDisPic(Eval("MobilePic"))%></td>
                                        <td><%# Eval("UrlLink") %></td>
                                        <td>
                                            <asp:Button ID="lvbtnEdit" runat="server" Text="修改" CssClass="btn btn-info" CausesValidation="false" CommandName="GoEdit" OnCommand="btn_OnCommand" CommandArgument='<%# Eval("Id") %>' />
                                            <asp:Button ID="lvbtnDelete" runat="server" Text="刪除" CssClass="btn btn-danger" CausesValidation="false" CommandName="GoDelete" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('確定刪除？')" OnCommand="btn_OnCommand" />
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
                                                <th>排序</th>
                                                <th>標題</th>
                                                <th>PC版圖片</th>
                                                <th>手機版圖片</th>
                                                <th>連結</th>
                                                <th class="col-lg-3"></th>
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


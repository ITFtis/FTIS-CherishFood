<%@ Page Title="" Language="C#" MasterPageFile="~/Identity/MasterPage.master" AutoEventWireup="true" CodeFile="BannerEdit.aspx.cs" Inherits="Identity_BannerEdit" %>

<%@ Register Src="~/Identity/SiteMap.ascx" TagPrefix="uc1" TagName="SiteMap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <uc1:SiteMap runat="server" ID="SiteMap" />
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
        <!-- Main content -->
        <section class="content">
            <div class="row">
                <div class="col-xs-12">
                    <!-- Horizontal Form -->
                    <div class="box ">
                        <div class="box-body">
                            <div class="col-lg-12 ">
                                <div class="box box-info box-solid">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">內容</h3>
                                        <!-- /.box-tools -->
                                    </div>
                                    <!-- /.box-header -->
                                    <div class="box-body">
                                        <div class="col-lg-12 ">
                                            <asp:HiddenField ID="hidAdminId" runat="server" />
                                            <div class="form-group  ">
                                                <asp:Label ID="Label2" AssociatedControlID="txtTitle" Text="標題(註記用)" runat="server" />
                                                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                            <div class="form-group  ">
                                                <asp:Label ID="Label1" AssociatedControlID="txtSort" Text="排序" runat="server" />
                                                <asp:TextBox ID="txtSort" runat="server" required="required" CssClass="form-control" Text="999" TextMode="Number"></asp:TextBox>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                            <div class="form-group  ">
                                                <asp:Label ID="labReleaseTime" AssociatedControlID="txtLinks" Text="連結" runat="server" />
                                                <asp:TextBox ID="txtLinks" runat="server" required="required" CssClass="form-control"></asp:TextBox>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                            <div class="form-group ">
                                                <div class="panel panel-primary">
                                                    <div class="panel-heading">PC版圖片上傳</div>
                                                    <div class="panel-body">
                                                        <asp:FileUpload ID="FileUpload1" data-dir="indexPic" data-ext="jpg,jpeg,png,gif,svg,tiff" CssClass="Sinputfiles" runat="server" accept=".jpg, .jpeg, .png, .gif, .svg, .tiff"/>
                                                        <asp:TextBox ID="txtPcPic" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group ">
                                                <div class="panel panel-primary">
                                                    <div class="panel-heading">手機版圖片上傳</div>
                                                    <div class="panel-body">
                                                        <asp:FileUpload ID="FileUpload2" data-dir="indexPic" data-ext="jpg,jpeg,png,gif,svg,tiff" CssClass="Sinputfiles" runat="server" accept=".jpg, .jpeg, .png, .gif, .svg, .tiff"/>
                                                        <asp:TextBox ID="txtMobilePic" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.box-body -->
                            </div>
                        </div>
                        <!-- /.box-header -->
                        <!-- /.box-body -->
                        <div class="box-footer">
                            <asp:Button ID="Button1" runat="server" Text="返回" UseSubmitBehavior="False" CausesValidation="False" CssClass=" btn btn-default" CommandName="GoCancel" OnCommand="btn_OnCommand" />
                            <asp:Button ID="btnSave" runat="server" Text="儲存" CssClass="btn btn-info pull-right" CommandName="Save" OnCommand="btn_OnCommand" />
                        </div>
                        <!-- /.box-footer -->
                    </div>
                </div>
                <!-- /.box -->
            </div>
            <!-- /.col -->
            <!-- /.row -->
        </section>
        <!-- /.content -->
    </div>
</asp:Content>


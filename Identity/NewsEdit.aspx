<%@ Page Title="" Language="C#" MasterPageFile="~/Identity/MasterPage.master" AutoEventWireup="true" CodeFile="NewsEdit.aspx.cs" Inherits="Identity_NewsEdit" ValidateRequest="false" %>

<%@ Register Src="~/Identity/SiteMap.ascx" TagPrefix="uc1" TagName="SiteMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../Scripts/ckeditor/ckeditor.js"></script>
    <script>
        $(document).ready(function () {
            CKEDITOR.replace('<%=txtContents.ClientID%>',
                {
                    filebrowserBrowseUrl: '../Scripts/ckfinder/ckfinder.html',
                    filebrowserImageBrowseUrl: '../Scripts/ckfinder/ckfinder.html?type=Images',
                    filebrowserFlashBrowseUrl: '../Scripts/ckfinder/ckfinder.html?type=Flash',
                    filebrowserUploadUrl: '../Scripts/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
                    filebrowserImageUploadUrl: '../Scripts/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',
                    filebrowserFlashUploadUrl: '../Scripts/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash',
                    allowedContent: true
                });
            CKEDITOR.config.height = 500;
        });
    </script>
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
                                        <h3 class="box-title">新增/修改</h3>
                                        <!-- /.box-tools -->
                                    </div>
                                    <!-- /.box-header -->
                                    <div class="box-body">
                                        <div class="col-lg-12 ">
                                            <asp:HiddenField ID="hidAdminId" runat="server" />
                                            <div class="form-group  ">
                                                <asp:Label ID="labMainTitle" AssociatedControlID="txtTitle" Text="標題" runat="server" />
                                                <asp:TextBox ID="txtTitle" runat="server" required="required" CssClass="form-control" AutoComplete="OFF"></asp:TextBox>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                            <div class="form-group  ">
                                                <asp:Label ID="Label1" AssociatedControlID="txtSummary" Text="摘要" runat="server" />
                                                <asp:TextBox ID="txtSummary" runat="server" required="required" CssClass="form-control" AutoComplete="OFF"></asp:TextBox>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                            <div class="form-group  ">
                                                <asp:Label ID="labReleaseTime" AssociatedControlID="txtReleaseDate" Text="發布日期" runat="server" />
                                                <asp:TextBox ID="txtReleaseDate" runat="server" required="required" CssClass="form-control datepicker" AutoComplete="OFF"></asp:TextBox>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                            <div class="form-group  ">
                                                <asp:Label ID="Label2" AssociatedControlID="txtVideoUrl" Text="Youtube崁入連結" runat="server" />
                                                <asp:TextBox ID="txtVideoUrl" runat="server" CssClass="form-control" AutoComplete="OFF"></asp:TextBox>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                            <div class="form-group ">
                                                <div class="panel panel-primary">
                                                    <div class="panel-heading">主要圖片上傳</div>
                                                    <div class="panel-body">
                                                        <asp:FileUpload ID="FileUpload1" data-dir="News" data-ext="jpg,jpeg,png,gif,svg,tiff" CssClass="Sinputfiles" runat="server" accept=".jpg, .jpeg, .png, .gif, .svg, .tiff"/>
                                                        <asp:TextBox ID="txtMainPic" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /.box-body -->
                                </div>
                            </div>
                            <div class="col-lg-12 ">
                                <div class="box box-default box-solid">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">內容編輯器</h3>
                                        <!-- /.box-tools -->
                                    </div>
                                    <!-- /.box-header -->
                                    <div class="box-body">
                                        <div class="col-lg-12 ">
                                            <div class="form-group">
                                                <asp:Label ID="labNews" AssociatedControlID="txtContents" runat="server" />
                                                <asp:TextBox ID="txtContents" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /.box-body -->
                                </div>
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


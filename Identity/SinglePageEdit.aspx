<%@ Page Title="" Language="C#" MasterPageFile="~/Identity/MasterPage.master" AutoEventWireup="true" CodeFile="SinglePageEdit.aspx.cs" Inherits="Identity_SinglePageEdit" ValidateRequest="false" %>

<%@ Register Src="~/Identity/SiteMap.ascx" TagPrefix="uc1" TagName="SiteMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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


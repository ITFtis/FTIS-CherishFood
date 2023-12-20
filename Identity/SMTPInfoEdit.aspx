<%@ Page Title="" Language="C#" MasterPageFile="~/Identity/MasterPage.master" AutoEventWireup="true" CodeFile="SMTPInfoEdit.aspx.cs" Inherits="Identity_SMTPInfoEdit" %>
<%@ Register Src="~/Identity/SiteMap.ascx" TagPrefix="uc1" TagName="SiteMap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <uc1:SiteMap runat="server" ID="SiteMap" />
        <!-- Main content -->
        <section class="content">
            <div class="row">
                <div class="col-xs-12">
                    <!-- Horizontal Form -->
                    <div class="box box-info">
                        <div class="box-header with-border">
                            <h3 class="box-title">
                                <asp:Literal ID="LitNodeTitle" runat="server"></asp:Literal></h3>
                        </div>
                        <div class="box-body">
                            <asp:Literal ID="LitAlertMsg" runat="server"></asp:Literal>
                            <div class="form-horizontal">
                                <div class="form-group  col-sm-6   ">
                                    <asp:Label ID="Label2" AssociatedControlID="txtServer" Text="主機" CssClass="col-sm-2 control-label" runat="server" />
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtServer" runat="server" CssClass="form-control"   />
                                    </div>
                                </div>
                                <div class="form-group  col-sm-6   ">
                                    <asp:Label ID="Label3" AssociatedControlID="txtPort" Text="Port" CssClass="col-sm-2 control-label" runat="server" />
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtPort" runat="server" CssClass="form-control"   />
                                    </div>
                                </div>
                                <div class="form-group  col-sm-6   ">
                                    <asp:Label ID="Label4" AssociatedControlID="txtName" Text="寄件名稱" CssClass="col-sm-2 control-label" runat="server" />
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"   />
                                    </div>
                                </div>
                                <div class="form-group  col-sm-6   ">
                                    <asp:Label ID="labAccount" AssociatedControlID="txtAccount" Text="帳號" CssClass="col-sm-2 control-label" runat="server" />
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtAccount" runat="server" CssClass="form-control"   />
                                    </div>
                                </div>
                                <div class="form-group  col-sm-6   ">
                                    <asp:Label ID="Label1" AssociatedControlID="txtPassword" Text="密碼" CssClass="col-sm-2 control-label" runat="server" />
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"   />
                                    </div>
                                </div>
                                <div class="form-group  col-sm-6   ">
                                    <asp:Label ID="labIsEnable" AssociatedControlID="chkIsEnable" Text="SSL" CssClass="col-sm-2 control-label" runat="server" />
                                    <div class="col-sm-10">
                                        <asp:CheckBox ID="chkIsEnable" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- /.box-header -->
                        <!-- /.box-body -->
                        <div class="box-footer">
                            <input type="button" id="btnBack" value="返回" class="cancel btn btn-default pull-right" onclick="javascript: window.history.go(-1);" />
                            <asp:Button ID="btnSave" runat="server" Text="儲存" CssClass="btn btn-info pull-right" CommandName="Save" OnCommand="btn_OnCommand" />
                        </div>
                        <!-- /.box-footer -->
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


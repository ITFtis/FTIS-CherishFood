<%@ Page Title="" Language="C#" MasterPageFile="~/Identity/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeAdd.aspx.cs" Inherits="Admin_EmployeeAdd" %>

<%@ Register Src="~/Identity/SiteMap.ascx" TagPrefix="uc1" TagName="SiteMap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <uc1:SiteMap runat="server" ID="SiteMap" />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Main content -->
        <section class="content">
            <div class="row">
                <div class="col-xs-12">
                    <!-- Horizontal Form -->
                    <div class="box box-info">
                        <div class="box-header with-border">
                            <h3 class="box-title">員工資料</h3>
                        </div>
                        <div class="nav-tabs-custom">
                            <ul class="nav nav-tabs">
                                <li class="active"><a href="#basic" data-toggle="tab">基本資料</a></li>
                                <li><a href="#photo" data-toggle="tab">照片</a></li>
                            </ul>
                            <div class="tab-content">
                                <div class="tab-pane active" id="basic">
                                    <div class="form-horizontal">
                                        <div class="box-body">
                                            <div class="form-group  col-sm-6  has-feedback ">
                                                <asp:Label ID="labAccount" AssociatedControlID="txtAccount" Text="帳號" CssClass="col-sm-2 control-label" runat="server" />
                                                <div class="col-sm-10">
                                                    <asp:TextBox ID="txtAccount" CssClass="form-control" runat="server" required></asp:TextBox>
                                                    <div class="help-block with-errors"></div>
                                                </div>
                                            </div>
                                            <div class="form-group  col-sm-6 has-feedback">
                                                <asp:Label ID="labPassword" AssociatedControlID="txtPassword" Text="密碼" CssClass="col-sm-2 control-label" runat="server" />
                                                <div class="col-sm-10">
                                                    <asp:TextBox ID="txtPassword" data-minlength="6" data-error="請勿小於6位數" CssClass="form-control " TextMode="Password" runat="server" required></asp:TextBox>
                                                    <div class="help-block with-errors"></div>
                                                </div>
                                            </div>
                                            <div class="form-group  col-sm-6 ">
                                                <asp:Label ID="labName" AssociatedControlID="txtName" Text="姓名" CssClass="col-sm-2 control-label" runat="server" />
                                                <div class="col-sm-10">
                                                    <asp:TextBox ID="txtName" CssClass="form-control " runat="server" required></asp:TextBox>
                                                    <div class="help-block with-errors"></div>
                                                </div>
                                            </div>
                                            <div class="form-group  col-sm-6">
                                                <asp:Label ID="labTitle" AssociatedControlID="txtTitle" Text="職稱" CssClass="col-sm-2 control-label" runat="server" />
                                                <div class="col-sm-10">
                                                    <asp:TextBox ID="txtTitle" CssClass="form-control " runat="server" required></asp:TextBox>
                                                    <div class="help-block with-errors"></div>
                                                </div>
                                            </div>
                                            <%--<div class="form-group  col-sm-6">
                                                <asp:Label ID="labTitleOfCourtesy" AssociatedControlID="txtTitleOfCourtesy" Text="稱呼" CssClass="col-sm-2 control-label" runat="server" />
                                                <div class="col-sm-10">
                                                    <asp:TextBox ID="txtTitleOfCourtesy" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group  col-sm-6">
                                                <asp:Label ID="labBirthDate" AssociatedControlID="txtBirthDate" Text="生日" CssClass="col-sm-2 control-label" runat="server" />
                                                <div class="col-sm-10">
                                                    <asp:TextBox ID="txtBirthDate" CssClass="form-control datepicker" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group  col-sm-6">
                                                <asp:Label ID="labHireDate" AssociatedControlID="txtHireDate" Text="雇傭日期" CssClass="col-sm-2 control-label" runat="server" />
                                                <div class="col-sm-10">
                                                    <asp:TextBox ID="txtHireDate" CssClass="form-control datepicker" runat="server"></asp:TextBox>
                                                </div>
                                            </div>--%>

                                            <div class="form-group  col-sm-6">
                                                <asp:Label ID="labHomePhone" AssociatedControlID="txtHomePhone" Text="住家電話" CssClass="col-sm-2 control-label" runat="server" />
                                                <div class="col-sm-10">
                                                    <asp:TextBox ID="txtHomePhone" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <%--                                         <div class="form-group  col-sm-6">
                                                <asp:Label ID="labPhone" AssociatedControlID="txtPhone" Text="手機" CssClass="col-sm-2 control-label" runat="server" />
                                                <div class="col-sm-10">
                                                    <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>--%>
                                            <div class="form-group  col-sm-6">
                                                <asp:Label ID="labOwnerTel" AssociatedControlID="txtOwnerTel" Text="電話" CssClass="col-sm-2 control-label" runat="server" />
                                                <div class="col-sm-10">
                                                    <asp:TextBox ID="txtOwnerTel" CssClass="form-control" runat="server" required></asp:TextBox>
                                                    <div class="help-block with-errors"></div>
                                                </div>
                                            </div>
                                            <div class="form-group  col-sm-6">
                                                <asp:Label ID="labExtension" AssociatedControlID="txtExtension" Text="分機" CssClass="col-sm-2 control-label" runat="server" />
                                                <div class="col-sm-10">
                                                    <asp:TextBox ID="txtExtension" CssClass="form-control" runat="server" MaxLength="4"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group col-sm-6">
                                                <asp:Label ID="Label3" AssociatedControlID="txtEmail" Text="信箱" CssClass="col-sm-2 control-label" runat="server" />
                                                <div class="col-sm-10">
                                                    <asp:TextBox ID="txtEmail" CssClass="form-control " runat="server" required TextMode="Email"></asp:TextBox>
                                                    <div class="help-block with-errors"></div>
                                                </div>
                                            </div>
                                            <div class="form-group  col-sm-6">
                                                <asp:Label ID="labReportsTo" AssociatedControlID="ddlReportsTo" Text="主管" CssClass="col-sm-2 control-label" runat="server" />
                                                <div class="col-sm-10">
                                                    <asp:DropDownList ID="ddlReportsTo" CssClass="form-control select2" runat="server"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group  col-sm-6">
                                                <asp:Label ID="labRoles" AssociatedControlID="listRoles" Text="角色" CssClass="col-sm-2 control-label" runat="server" />
                                                <div class="col-sm-10 ">
                                                    <asp:DropDownList ID="listRoles" SelectionMode="Multiple" CssClass="form-control select2" data-placeholder="請選擇角色" runat="server" OnSelectedIndexChanged="listRoles_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group  col-sm-6">
                                                <asp:Label ID="Label1" AssociatedControlID="ddlCounty" Text="所屬行政區" CssClass="col-sm-2 control-label" runat="server" />
                                                <div class="col-sm-10">
                                                    <asp:DropDownList ID="ddlCounty" CssClass="form-control select2" runat="server"></asp:DropDownList>
                                                    <div class="help-block with-errors"></div>
                                                </div>
                                            </div>
                                            <div class="form-group  col-sm-6">
                                                <asp:Label ID="Label2" AssociatedControlID="txtCountry" Text="單位" CssClass="col-sm-2 control-label" runat="server" />
                                                <div class="col-sm-10">
                                                    <asp:TextBox ID="txtCountry" CssClass="form-control" runat="server" MaxLength="15" required></asp:TextBox>
                                                    <div class="help-block with-errors"></div>
                                                </div>
                                            </div>
                                            <%--<div class="form-group  col-sm-12">
                                                <asp:Label ID="labAddress" AssociatedControlID="txtAddress" Text="地址" CssClass="col-sm-1 control-label" runat="server" />
                                                <div class="col-sm-10 ">
                                                    <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>--%>
                                            <div class="form-group  col-sm-12">
                                                <asp:Label ID="labNotes" AssociatedControlID="txtNotes" Text="備註" CssClass="col-sm-1 control-label" runat="server" />
                                                <div class="col-sm-10 ">
                                                    <asp:TextBox ID="txtNotes" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane" id="photo">
                                    <div class="form-horizontal">
                                        <div class="box-body">
                                            <div class="form-group  col-sm-12">
                                                <div class="panel panel-primary">
                                                    <div class="panel-heading">
                                                        照片上傳
                                                    </div>
                                                    <div class="panel-body">
                                                        <asp:FileUpload ID="FileUpload1" data-dir="Employee" data-ext="jpg,jpeg,png,gif,svg,tiff" accept=".jpg, .jpeg, .png, .gif, .svg, .tiff" CssClass="Sinputfiles" runat="server" />
                                                        <asp:TextBox ID="txtFiles" CssClass="form-control" runat="server" Text=""></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
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


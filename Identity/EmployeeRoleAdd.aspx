<%@ Page Title="" Language="C#" MasterPageFile="~/Identity/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeRoleAdd.aspx.cs" Inherits="Admin_EmployeeRoleAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>員工管理
            </h1>
            <ol class="breadcrumb">
                <li><a href="index.aspx"><i class="fa fa-dashboard"></i>首頁</a></li>
                <li><a href="#">員工角色</a></li>
                <li class="active">新增</li>
            </ol>
        </section>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Main content -->
        <section class="content">
            <div class="row">
                <div class="col-xs-12">
                    <!-- Horizontal Form -->
                    <div class="box box-info">
                        <div class="box-header with-border">
                            <h3 class="box-title">員工角色</h3>
                        </div>
                        <div class="nav-tabs-custom">
                            <ul class="nav nav-tabs">
                                <li class="active"><a href="#basic" data-toggle="tab">基本資料</a></li>
                                <li><a href="#account" data-toggle="tab">帳號</a></li>
                                <li><a href="#Permission" data-toggle="tab">權限</a></li>
                            </ul>
                            <div class="tab-content">
                                <div class="tab-pane active" id="basic">
                                    <div class="form-horizontal">
                                        <div class="box-body">
                                            <div class="form-group  col-sm-6  has-feedback ">
                                                <asp:Label ID="labAccount" AssociatedControlID="txtName" Text="角色名稱" CssClass="col-sm-2 control-label" runat="server" />
                                                <div class="col-sm-10">
                                                    <asp:TextBox ID="txtName" CssClass="form-control" runat="server" required></asp:TextBox>
                                                    <div class="help-block with-errors"></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane" id="account">
                                    <div class="form-horizontal">
                                        <div class="box-body">
                                            <div class="form-group  col-sm-12">
                                                    <asp:ListView ID="ListView1" runat="server">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td><%# Eval("Account") %></td>
                                                                <td>
                                                                    <%# Eval("Name") %> <%# Eval("Title") %>
                                                                </td>
                                                                <td>
                                                                    <%# Eval("Phone") %> 
                                                                </td>
                                                                <td>
                                                                    <asp:HiddenField ID="HidShopId" runat="server" Value='<%# Eval("EmployeeId") %>' />
                                                                    <asp:CheckBox ID="IsCharge" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                        <EmptyDataTemplate>
                                                            <table class="table table-bordered table-stripedERA4">
                                                                <thead>
                                                                    <tr>
                                                                        <th>帳號</th>
                                                                        <th>姓名</th>
                                                                        <th>手機</th>
                                                                        <th class="col-lg-3">管理</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                </tbody>
                                                            </table>
                                                        </EmptyDataTemplate>
                                                        <LayoutTemplate>
                                                            <table class="table table-bordered table-stripedERA4">
                                                                <thead>
                                                                    <tr>
                                                                        <th>帳號</th>
                                                                        <th>姓名</th>
                                                                        <th>手機</th>
                                                                        <th class="col-lg-3">管理</th>
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
                                            </div>
                                    </div>
                                </div>
                                <div class="tab-pane" id="Permission">
                                    <div class="form-horizontal">
                                        <div class="box-body">
                                            <div class="form-group  col-sm-12">
                                                    <asp:ListView ID="ListView2" runat="server">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td><%# Eval("Name") %></td>

                                                                <td>
                                                                    <asp:HiddenField ID="HidShopId" runat="server" Value='<%# Eval("EmployeePermissionId") %>' />
                                                                    <asp:CheckBox ID="IsCharge" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                        <EmptyDataTemplate>
                                                            <table class="table table-bordered table-stripedERA2">
                                                                <thead>
                                                                    <tr>
                                                                        <th>項目</th>
                                                                        <th class="col-lg-3">管理</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                </tbody>
                                                            </table>
                                                        </EmptyDataTemplate>
                                                        <LayoutTemplate>
                                                            <table class="table table-bordered table-stripedERA2 ">
                                                                <thead>
                                                                    <tr>
                                                                        <th>項目</th>
                                                                        <th class="col-lg-3">管理</th>
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


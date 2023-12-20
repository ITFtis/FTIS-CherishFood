<%@ Page Title="" Language="C#" MasterPageFile="~/Identity/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeRoleList.aspx.cs" Inherits="Admin_EmployeeRoleList" %>

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
                <li class="active">列表</li>
            </ol>`  
        </section>
        <!-- Main content -->
        <section class="content">
            <div class="row">
                <div class="col-xs-12">
                    <div class="box">
                        <div class="box-header">
                            <h3 class="box-title " style="float: right">
                                <asp:Button ID="btnGoadd" runat="server" Text="新增" CssClass="btn btn-primary " CommandName="GoAdd" OnCommand="btn_OnCommand" CausesValidation="false" /></h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">
                               <asp:Literal ID="AlertMsg" runat="server"></asp:Literal> 
                            <asp:HiddenField ID="listSelectKey" runat="server" />
                            <asp:ListView ID="ListView1" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("Name") %></td>
                                        <td><%# Eval("IsSystemRole") %></td>
                                        <td>
                                            <asp:Button ID="lvbtnEdit" runat="server" Text="修改" CssClass="btn btn-info" CausesValidation="false" CommandName="GoEdit" OnCommand="btn_OnCommand" CommandArgument='<%# Eval("EmployeeRoleId") %>'  Visible='<%# !(bool)Eval("IsSystemRole") %>' />
                                            <asp:Button ID="lvbtnDelete" runat="server" Text="刪除" CssClass="btn btn-danger" CausesValidation="false" CommandName="GoDelete" CommandArgument='<%# Eval("EmployeeRoleId") %>' OnClientClick="return confirm('確定刪除？')" OnCommand="btn_OnCommand" Visible='<%# !(bool)Eval("IsSystemRole") %>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    <table class="table table-bordered table-stripedERA4 dataTables">
                                        <thead>
                                            <tr>
                                                <th>角色名稱</th>
                                                <th>系統預設</th>
                                                <th class="col-lg-3"></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>
                                    </table>
                                </EmptyDataTemplate>
                                <LayoutTemplate>
                                    <table class="table table-bordered table-stripedERA4 dataTables">
                                        <thead>
                                            <tr>
                                                <th>角色名稱</th>
                                                <th>系統預設</th>
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


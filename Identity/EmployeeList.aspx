<%@ Page Title="" Language="C#" MasterPageFile="~/Identity/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeList.aspx.cs" Inherits="Admin_EmployeeList" %>
<%@ Register Src="~/Identity/SiteMap.ascx" TagPrefix="uc1" TagName="SiteMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <uc1:SiteMap runat="server" id="SiteMap" />
        <!-- Main content -->
        <section class="content">
            <div class="row">
                <div class="col-xs-12">
                    <div class="box">
                        <div class="box-header">
                            <h3 class="box-title " style="float: right">
                                <asp:Button ID="btnGoadd" runat="server" Text="新增" CssClass="btn btn-primary " CommandName="GoAdd" OnCommand="btn_OnCommand" CausesValidation="false" />
                            </h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">
                        
                            <asp:Literal ID="AlertMsg" runat="server"></asp:Literal> 
                            <asp:HiddenField ID="listSelectKey" runat="server" />
                            <asp:ListView ID="ListView1" runat="server" >
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("Account") %></td>
                                        <td><%# Eval("Name") %>/<%# Eval("Title") %></td>
                                        <td><%# Eval("EmployeeRolesName") %></td>
                                        <td><%# Eval("Phone") %></td>
                                        <td><%# Eval("ReportTo") %></td>
                                        <td>
                                            <asp:Button ID="lvbtnEdit" runat="server" Text="修改" CssClass="btn btn-info" CausesValidation="false" CommandName="GoEdit" OnCommand="btn_OnCommand" CommandArgument='<%# Eval("EmployeeId") %>' />
                                            <span id="lvbtnResetPassword" class="btn btn-info resultList" data-href="ChangePassword.aspx" data-reload="true" data-id='<%# Eval("EmployeeId") %>'>重設密碼</span>
                                            <asp:Button ID="lvbtnDelete" runat="server" Text="刪除" CssClass="btn btn-danger" CausesValidation="false" CommandName="GoDelete" CommandArgument='<%# Eval("EmployeeId") %>' OnClientClick="return confirm('確定刪除？')" OnCommand="btn_OnCommand" />
                                            <asp:Button ID="lvbtnStatus" runat="server" Text='<%# (((int)Eval("Status") == 0 ||(int)Eval("Status") == 1)? "停用":"啟用")  %>' CssClass='<%# Eval("btnCss") %>' CausesValidation="false" CommandName="GoStatus" CommandArgument='<%# Eval("EmployeeId") %>' OnClientClick='<%# Eval("alertWord") %>' OnCommand="btn_OnCommand" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    <table class="table table-bordered table-stripedEL6 dataTables">
                                        <thead>
                                        <tr>
                                            <th>帳號</th>
                                            <th>姓名/職稱</th>
                                            <th>角色名稱</th>
                                            <th>手機</th>
                                            <th>主管</th>
                                            <th class="col-lg-3"></th>
                                        </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>
                                    </table>
                                </EmptyDataTemplate>
                                <LayoutTemplate>
                                    <table class="table table-bordered table-stripedEL6 dataTables">
                                        <thead>
                                        <tr>
                                            <th>帳號</th>
                                            <th>姓名/職稱</th>
                                            <th>角色名稱</th>
                                            <th>手機</th>
                                            <th>主管</th>
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


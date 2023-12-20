<%@ Page Title="" Language="C#" MasterPageFile="~/Identity/FancyBoxHeadFooter.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Admin_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-xs-12">
            <div class="form-horizontal">
                <div class="box-body">
                    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                    <div class="form-group  col-sm-12">
                        <asp:Label ID="labAccount" AssociatedControlID="txtAccount" Text="帳號" CssClass="col-sm-2 control-label" runat="server" />
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtAccount" CssClass="form-control" runat="server" Enabled="False"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group col-sm-12">
                        <asp:Label ID="labPassword" AssociatedControlID="txtPassword" Text="密碼" CssClass="col-sm-2 control-label" runat="server" />
                        <div class="col-sm-10">
                          
                            <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" required TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="requiredtxtPassword" ControlToValidate="txtPassword" runat="server">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                            <asp:Button ID="btnResetPassword" runat="server" Text="儲存" CssClass="btn btn-info pull-right col-sm-1 " OnClick="btnResetPassword_OnClick" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


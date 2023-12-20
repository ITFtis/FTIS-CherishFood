<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TaiwanCityControl.ascx.cs" Inherits="ascx_TaiwanCityControl" %>
<asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="True" CssClass="" OnSelectedIndexChanged="ddlCity_OnSelectedIndexChanged"></asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
    Display="Dynamic" ControlToValidate="ddlCity" ErrorMessage="請選擇縣市"></asp:RequiredFieldValidator>
<asp:DropDownList ID="ddlArea" runat="server" CssClass="" AutoPostBack="True"></asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red"
    Display="Dynamic" ControlToValidate="ddlArea" ErrorMessage="請選擇區域"></asp:RequiredFieldValidator>
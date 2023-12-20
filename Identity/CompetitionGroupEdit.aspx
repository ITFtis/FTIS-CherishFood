<%@ Page Title="" Language="C#" MasterPageFile="~/Identity/MasterPage.master" AutoEventWireup="true" CodeFile="CompetitionGroupEdit.aspx.cs" Inherits="Identity_CompetitionGroupEdit" %>

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
                                        <h3 class="box-title">確認</h3>
                                        <!-- /.box-tools -->
                                    </div>
                                    <!-- /.box-header -->
                                    <div class="box-body">
                                        <div class="col-lg-12 ">
                                            <asp:HiddenField ID="hidAdminId" runat="server" />
                                            <div class="form-group  ">
                                                <asp:Label ID="Label2" AssociatedControlID="ddlCounty" Text="縣市" runat="server" />
                                                <asp:DropDownList ID="ddlCounty" CssClass="form-control select2" runat="server"></asp:DropDownList>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group  ">
                                                <asp:Label ID="Label1" AssociatedControlID="ddlStatus" Text="確認" runat="server" />
                                                <asp:DropDownList ID="ddlStatus" CssClass="form-control select2" runat="server">
                                                    <asp:ListItem Value="">待確認</asp:ListItem>
                                                    <asp:ListItem Value="1">確認</asp:ListItem>
                                                    <asp:ListItem Value="0">補件</asp:ListItem>
                                                </asp:DropDownList>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group  ">
                                                <asp:Label ID="labEndDate" AssociatedControlID="listReturnReason" Text="原因" runat="server" />
                                                <asp:ListBox ID="listReturnReason" runat="server" CssClass="form-control select2" SelectionMode="Multiple" data-placeholder="請選擇補件原因(可複選)">
                                                    <asp:ListItem Value="1">授權書未簽名</asp:ListItem>
                                                    <asp:ListItem Value="2">法定代理人同意書未簽名</asp:ListItem>
                                                    <asp:ListItem Value="3">欄位與上傳檔案不相符</asp:ListItem>
                                                    <asp:ListItem Value="4">其他</asp:ListItem>
                                                </asp:ListBox>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group  ">
                                                <asp:Label ID="Label16" AssociatedControlID="txtOtherReason" Text="其他原因" runat="server" />
                                                <asp:TextBox ID="txtOtherReason" runat="server" CssClass="form-control" AutoComplete="OFF"></asp:TextBox>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="box box-info box-solid">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">報名資料內容</h3>
                                        <!-- /.box-tools -->
                                    </div>
                                    <!-- /.box-header -->
                                    <div class="box-body">
                                        <div class="col-lg-12 ">
                                            <div class="form-group  ">
                                                <asp:Label ID="Label3" AssociatedControlID="txtContestCode" Text="參賽編號" runat="server" />
                                                <asp:TextBox ID="txtContestCode" runat="server" CssClass="form-control" AutoComplete="OFF" Enabled="false"></asp:TextBox>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 ">
                                            <div class="form-group  ">
                                                <asp:Label ID="Label4" AssociatedControlID="txtName" Text="姓名" runat="server" />
                                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" AutoComplete="OFF" Enabled="false"></asp:TextBox>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                            <div class="form-group  ">
                                                <asp:Label ID="Label6" AssociatedControlID="txtBirthday" Text="生日" runat="server" />
                                                <asp:TextBox ID="txtBirthday" runat="server" CssClass="form-control" AutoComplete="OFF" Enabled="false"></asp:TextBox>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                            <div class="form-group  ">
                                                <asp:Label ID="Label7" AssociatedControlID="txtMail" Text="聯絡信箱" runat="server" />
                                                <asp:TextBox ID="txtMail" runat="server" CssClass="form-control" AutoComplete="OFF" Enabled="false"></asp:TextBox>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                            <div class="form-group  ">
                                                <asp:Label ID="Label8" AssociatedControlID="txtJobTitle" Text="職稱/年級" runat="server" />
                                                <asp:TextBox ID="txtJobTitle" runat="server" CssClass="form-control" AutoComplete="OFF" Enabled="false"></asp:TextBox>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 ">
                                            <div class="form-group  ">
                                                <asp:Label ID="Label5" AssociatedControlID="txtIdentityNo" Text="身分證號/護照號" runat="server" />
                                                <asp:TextBox ID="txtIdentityNo" runat="server" CssClass="form-control" AutoComplete="OFF" Enabled="false"></asp:TextBox>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                            <div class="form-group  ">
                                                <asp:Label ID="Label9" AssociatedControlID="txtPhone" Text="姓名" runat="server" />
                                                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" AutoComplete="OFF" Enabled="false"></asp:TextBox>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                            <div class="form-group  ">
                                                <asp:Label ID="Label10" AssociatedControlID="txtName" Text="服務單位/學校" runat="server" />
                                                <asp:TextBox ID="txtUnitName" runat="server" CssClass="form-control" AutoComplete="OFF" Enabled="false"></asp:TextBox>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                            <div class="form-group  ">
                                                <asp:Label ID="Label15" AssociatedControlID="listSignArea" Text="報名區域" runat="server" />
                                                <asp:ListBox ID="listSignArea" runat="server" CssClass="form-control select2" SelectionMode="Multiple" disabled data-placeholder="需符合以下任一條件（複選，必填一項）">
                                                    <asp:ListItem>戶籍地</asp:ListItem>
                                                    <asp:ListItem>居住地</asp:ListItem>
                                                    <asp:ListItem>任職地</asp:ListItem>
                                                    <asp:ListItem>目前就讀學校所在地</asp:ListItem>
                                                </asp:ListBox>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>                                        
                                        <div class="col-lg-12 ">
                                            <div class="form-group  ">
                                                <asp:Label ID="Label11" AssociatedControlID="txtTitle" Text="作品名稱" runat="server" />
                                                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" AutoComplete="OFF" Enabled="false"></asp:TextBox>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                            <div class="form-group  ">
                                                <asp:Label ID="Label12" AssociatedControlID="litWorkFile" Text="食譜表" runat="server" />
                                                <asp:Literal ID="litWorkFile" runat="server"></asp:Literal>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                            <div class="form-group  ">
                                                <asp:Label ID="Label13" AssociatedControlID="litAuthorizeFile" Text="作品授權書" runat="server" />
                                                <asp:Literal ID="litAuthorizeFile" runat="server"></asp:Literal>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                            <div class="form-group  ">
                                                <asp:Label ID="Label14" AssociatedControlID="litRepresentativeConsent" Text="法定代理人同意書" runat="server" />
                                                <asp:Literal ID="litRepresentativeConsent" runat="server"></asp:Literal>
                                                <div class="help-block with-errors"></div>
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


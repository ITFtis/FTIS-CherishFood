<%@ Page Title="" Language="C#" MasterPageFile="~/Identity/MasterPage.master" AutoEventWireup="true" CodeFile="FinalCompetitionEdit.aspx.cs" Inherits="Identity_FinalCompetitionEdit" %>

<%@ Register Src="~/Identity/SiteMap.ascx" TagPrefix="uc1" TagName="SiteMap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
                                        <h3 class="box-title">報名資料內容</h3>
                                        <!-- /.box-tools -->
                                    </div>
                                    <!-- /.box-header -->
                                    <div class="box-body">
                                        <div class="col-lg-12 ">
                                            <asp:HiddenField ID="hidAdminId" runat="server" />
                                            <div class="form-group  ">
                                                <asp:Label ID="Label2" AssociatedControlID="ddlContestCode" Text="參賽者編號" runat="server" />
                                                <asp:DropDownList ID="ddlContestCode" CssClass="form-control select2" runat="server" OnSelectedIndexChanged="ddlContestCode_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
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
                                    </div>
                                </div>
                                <div class="box box-info box-solid">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">決賽資料內容</h3>
                                        <!-- /.box-tools -->
                                    </div>
                                    <!-- /.box-header -->
                                    <div class="box-body">
                                        <div class="col-lg-12 ">
                                            <div class="form-group  ">
                                                <asp:Label ID="Label1" AssociatedControlID="ddlFinalGroup" Text="決賽組別" runat="server" />
                                                <asp:DropDownList ID="ddlFinalGroup" CssClass="form-control select2" runat="server">
                                                    <asp:ListItem Value="">請選擇</asp:ListItem>
                                                </asp:DropDownList>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                            <div class="form-group  ">
                                                <asp:Label ID="Label11" AssociatedControlID="txtTitle" Text="決賽作品名稱" runat="server" />
                                                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" AutoComplete="OFF"></asp:TextBox>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                            <div class="form-group ">
                                                <div class="panel panel-primary">
                                                    <div class="panel-heading">決賽食譜表</div>
                                                    <div class="panel-body">
                                                        <asp:FileUpload ID="FileUpload2" data-dir="fcbWorkFile" data-ext="pdf" CssClass="Sinputfiles" runat="server" accept=".pdf" />
                                                        <asp:TextBox ID="txtFinalWorkFile" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group ">
                                                <div class="panel panel-primary">
                                                    <div class="panel-heading">決賽作品授權書</div>
                                                    <div class="panel-body">
                                                        <asp:FileUpload ID="FileUpload1" data-dir="fcbAuthorizeFile" data-ext="pdf" CssClass="Sinputfiles" runat="server" accept=".pdf" />
                                                        <asp:TextBox ID="txtFinalAuthorizeFile" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group ">
                                                <div class="panel panel-primary">
                                                    <div class="panel-heading">自我介紹簡報</div>
                                                    <div class="panel-body">
                                                        <asp:FileUpload ID="FileUpload3" data-dir="fcbIntroduceFile" data-ext="pdf,ppt" CssClass="Sinputfiles" runat="server" accept=".pdf, .ppt" />
                                                        <asp:TextBox ID="txtFinalIntroduceFile" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group ">
                                                <div class="panel panel-primary">
                                                    <div class="panel-heading">法定代理人同意書</div>
                                                    <div class="panel-body">
                                                        <asp:FileUpload ID="FileUpload4" data-dir="fcbRepresentativeConsent" data-ext="pdf" CssClass="Sinputfiles" runat="server" accept=".pdf" />
                                                        <asp:TextBox ID="txtFinalRepresentativeConsent" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
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


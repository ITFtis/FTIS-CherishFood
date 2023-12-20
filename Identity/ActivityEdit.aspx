<%@ Page Title="" Language="C#" MasterPageFile="~/Identity/MasterPage.master" AutoEventWireup="true" CodeFile="ActivityEdit.aspx.cs" Inherits="Identity_ActivityEdit"  ValidateRequest="false" %>

<%@ Register Src="~/Identity/SiteMap.ascx" TagPrefix="uc1" TagName="SiteMap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                                            <div class="form-group  ">
                                                <asp:Label ID="Label2" AssociatedControlID="ddlCounty" Text="縣市" runat="server" />
                                                <asp:DropDownList ID="ddlCounty" CssClass="form-control select2" runat="server" OnSelectedIndexChanged="ddlCounty_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 ">
                                            <div class="form-group  ">
                                                <asp:Label ID="Label1" AssociatedControlID="txtStartDate" Text="報名開始日期" runat="server" />
                                                <asp:TextBox ID="txtStartDate" runat="server" required="required" CssClass="form-control form_date" AutoComplete="OFF"></asp:TextBox>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 ">
                                            <div class="form-group  ">
                                                <asp:Label ID="labEndDate" AssociatedControlID="txtEndDate" Text="報名結束日期" runat="server" />
                                                <asp:TextBox ID="txtEndDate" runat="server" required="required" CssClass="form-control form_date" AutoComplete="OFF"></asp:TextBox>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>
                                        <div class="col-lg-12 ">
                                            <div class="form-group  ">
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Label ID="Label3" AssociatedControlID="ListView1" Text="聯絡人" runat="server" />
                                                        <asp:ListView ID="ListView1" runat="server">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td><%# Eval("ItemCount") %></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtContactName" runat="server" CssClass="form-control" Text='<%# Eval("ContactName") %>' AutoComplete="OFF"></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtContactPhone" runat="server" CssClass="form-control" Text='<%# Eval("ContactPhone") %>' AutoComplete="OFF"></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:Button ID="btnDel" runat="server" Text="刪除" CssClass="btn btn-danger" UseSubmitBehavior="False" CausesValidation="False" OnCommand="btn_OnCommand" CommandName="DelContact" CommandArgument='<%# Eval("ItemCount") %>' Visible='<%# Eval("ShowBtn") %>' /></td>
                                                                </tr>
                                                            </ItemTemplate>
                                                            <EmptyDataTemplate>
                                                                無資料
                                                            </EmptyDataTemplate>
                                                            <LayoutTemplate>
                                                                <table class="table table-bordered table-striped">
                                                                    <thead>
                                                                        <tr>
                                                                            <th>序號</th>
                                                                            <th>聯絡人姓名</th>
                                                                            <th>連絡電話</th>
                                                                            <th class="col-lg-2"></th>
                                                                        </tr>
                                                                    </thead>
                                                                    <tbody>
                                                                        <tr id="itemPlaceholder" runat="server">
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </LayoutTemplate>
                                                        </asp:ListView>
                                                        <asp:Button ID="Button2" runat="server" Text="增加" CssClass="btn btn-info pull-right" UseSubmitBehavior="False" CausesValidation="False" OnCommand="btn_OnCommand" CommandName="AddContact" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="col-lg-12 ">
                                            <div class="form-group ">
                                                <div class="panel panel-primary">
                                                    <div class="panel-heading">活動圖檔(建議比例4:3，圖檔大小不得超過500kb)</div>
                                                    <div class="panel-body">
                                                        <asp:FileUpload ID="FileUpload1" data-dir="Activity" data-maxsize="500"  data-ext="jpg,jpeg,png,gif,svg,tiff" CssClass="Sinputfiles" runat="server" accept=".jpg, .jpeg, .png, .gif, .svg, .tiff" />
                                                        <asp:TextBox ID="txtPics" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group ">
                                                <div class="panel panel-primary">
                                                    <div class="panel-heading">活動簡章</div>
                                                    <div class="panel-body">
                                                        <asp:FileUpload ID="FileUpload2" data-dir="Activity" data-maxsize="5120" data-ext="pdf" CssClass="Sinputfiles" runat="server" accept=".pdf" />
                                                        <asp:TextBox ID="txtIntroduceFile" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group ">
                                                <div class="panel panel-primary">
                                                    <div class="panel-heading">活動簡章Odt檔（此欄位不須填寫，統一由環保署協助上傳）</div>
                                                    <div class="panel-body">
                                                        <asp:FileUpload ID="FileUpload5" data-dir="Activity" data-maxsize="5120" data-ext="odt" CssClass="Sinputfiles" runat="server" accept=".odt" />
                                                        <asp:TextBox ID="txtOdtFile" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group ">
                                                <div class="panel panel-primary">
                                                    <div class="panel-heading">初賽得獎名單</div>
                                                    <div class="panel-body">
                                                        <asp:FileUpload ID="FileUpload3" data-dir="Activity" data-maxsize="5120" data-ext="pdf" CssClass="Sinputfiles" runat="server" accept=".pdf" />
                                                        <asp:TextBox ID="txtPreliminaryAwardFile" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group ">
                                                <div class="panel panel-primary">
                                                    <div class="panel-heading">委員名單</div>
                                                    <div class="panel-body">
                                                        <asp:FileUpload ID="FileUpload4" data-dir="Activity" data-maxsize="5120" data-ext="pdf" CssClass="Sinputfiles" runat="server" accept=".pdf" />
                                                        <asp:TextBox ID="txtCommitteeList" CssClass="form-control" runat="server"></asp:TextBox>
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


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply.aspx.cs" Inherits="Apply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- Select2 -->
    <link rel="stylesheet" href="Identity/plugins/select2/select2.min.css" />
    <script src="Identity/plugins/select2/select2.full.min.js"></script>

    <script>
        function setSelect2() {
            $(".select2").select2();
        }
    </script>
    <style>
        .select2-container .select2-selection--multiple {
            min-height: 52px;
        }

        .select2-container .select2-search--inline .select2-search__field {
            font-size: 18px;
            padding: 8px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="inner-banner">
        <div class="ss01"></div>
        <div class="ss02"></div>
        <div class="ss03"></div>
        <div class="light_inner"></div>
        <!--電腦版banner圖-->
        <img src="images/main_KV.jpg" alt="首惜廚師，惜食{美味食譜}{創意教案}甄選，總獎金70萬等你來挑戰" class="pc-banner">

        <!--手機版banner圖-->
        <img src="images/main_KV_mobile.jpg" alt="" class="mobile-banner">
    </div>
    <div class="title-area" id="content">
        <a href="#C" title="中央內容區塊" id="AC" accesskey="C" name="C" class="accesskey ac">:::</a>
        <h2 class="unit-title">各縣市初賽<span>我要報名</span></h2>
        <div class="path">
            <ul>
                <li><a href="index.asox">首頁</a></li>
                <li>各縣市初賽</li>
            </ul>
        </div>
    </div>



    <div class="main-content">
        <div class="wrapper">
            <!-----內容區------>
            <h3 class="k-apply-title set-mt">初賽相關事宜請洽各直轄市、縣（市）環境保護局</h3>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <div class="k-apply-box">
                        <ul class="k-navbar">
                            <li class="active"><a href="#" class="k-btn-apply" style="pointer-events: none;">我要報名</a></li>
                            <li>
                                <asp:Literal ID="litIntroduceFile" runat="server"></asp:Literal></li>
                            <li>
                                <asp:Literal ID="litOdtFile" runat="server"></asp:Literal></li>
                            <li>
                                <asp:Literal ID="litApplySearch" runat="server"></asp:Literal></li>
                            <li>
                                <asp:Literal ID="litPreliminaryAwardFile" runat="server"></asp:Literal></li>
                        </ul>
                        <div class="k-apply-info">
                            <div class="k-info-box">
                                <div class="k-img">
                                    <asp:Literal ID="litPics" runat="server"></asp:Literal>
                                </div>
                                <div class="k-info">
                                    <h3>報名單位：<span><asp:Literal ID="litCounty" runat="server"></asp:Literal></span></h3>
                                    <p>報名時間：<asp:Literal ID="litSignRange" runat="server"></asp:Literal></p>
                                    <p>
                                        <asp:Literal ID="litContactUser" runat="server"></asp:Literal>
                                    </p>
                                </div>
                            </div>
                            <fieldset class="k-group">
                                <legend>請選擇要報名的參賽組別：</legend>
                                <div class="k-group-select">
                                    <label class="k-form-radio">
                                        惜食料理食譜組
                                        <asp:RadioButton ID="rbCookbook" runat="server" GroupName="group" Checked="true" OnCheckedChanged="rb_CheckedChanged" AutoPostBack="true" />
                                        <span class="k-checkmark"></span>
                                    </label>
                                    <label class="k-form-radio">
                                        惜食教案組
                                        <asp:RadioButton ID="rbLessonPlan" runat="server" GroupName="group" OnCheckedChanged="rb_CheckedChanged" AutoPostBack="true" />
                                        <span class="k-checkmark"></span>
                                    </label>
                                </div>
                            </fieldset>
                        </div>
                    </div>
                    <h3 class="k-apply-title">您要報名參賽的組別：<span><asp:Literal ID="litGroupName" runat="server"></asp:Literal></span></h3>
                    <div>
                        <asp:PlaceHolder ID="PlaceHolderPlanNum" runat="server">
                            <div class="k-apply-num">
                                <h4>參賽人數</h4>
                                <label class="k-form-radio">
                                    1位
                                    <asp:RadioButton ID="rbPlanNumOne" runat="server" GroupName="num" OnCheckedChanged="rbPlanNum_CheckedChanged" AutoPostBack="true" />
                                    <span class="k-checkmark"></span>
                                </label>
                                <label class="k-form-radio">
                                    2位
                                    <asp:RadioButton ID="rbPlanNumTwo" runat="server" GroupName="num" OnCheckedChanged="rbPlanNum_CheckedChanged" AutoPostBack="true" />
                                    <span class="k-checkmark"></span>
                                </label>
                                <label class="k-form-radio">
                                    3位
                                    <asp:RadioButton ID="rbPlanNumThree" runat="server" GroupName="num" Checked="true" OnCheckedChanged="rbPlanNum_CheckedChanged" AutoPostBack="true" />
                                    <span class="k-checkmark"></span>
                                </label>
                            </div>
                        </asp:PlaceHolder>
                        <div class="k-form-box">
                            <asp:PlaceHolder ID="PlaceHolderLogin" runat="server">
                                <fieldset>
                                    <legend>會員註冊資料</legend>
                                    <ul class="k-form-list">
                                        <li>
                                            <label class="k-form-label" for="txtAccount">會員帳號</label>
                                            <asp:TextBox ID="txtAccount" runat="server" CssClass="k-form-input" placeholder="請輸入您的身分證字號或護照號做為會員帳號" AutoComplete="OFF" OnTextChanged="txtAccount_TextChanged" AutoPostBack="true" required></asp:TextBox>
                                        </li>
                                        <li>
                                            <label class="k-form-label" for="txtPassword">會員密碼</label>
                                            <asp:TextBox ID="txtPassword" runat="server" CssClass="k-form-input" placeholder="輸入密碼（限8~12碼且混合數字與大小寫英文）" AutoComplete="OFF" TextMode="Password" required></asp:TextBox>
                                        </li>
                                        <li>
                                            <label class="k-form-label" for="txtPasswordConfirm">確認密碼</label>
                                            <asp:TextBox ID="txtPasswordConfirm" runat="server" CssClass="k-form-input" placeholder="請再次輸入密碼" AutoComplete="OFF" TextMode="Password" required></asp:TextBox>
                                        </li>
                                    </ul>
                                </fieldset>
                            </asp:PlaceHolder>
                            <asp:PlaceHolder ID="PlaceHolderCookBookMember" runat="server">
                                <fieldset>
                                    <legend>基本資料</legend>
                                    <div class="k-form-row">
                                        <ul class="k-form-list k-form-col">
                                            <li>
                                                <label class="k-form-label" for="contestant_name">參賽者姓名</label>
                                                <asp:TextBox ID="txtCbName" runat="server" CssClass="k-form-input" placeholder="請輸入參賽者姓名" AutoComplete="OFF" required></asp:TextBox>
                                            </li>
                                            <li>
                                                <label class="k-form-label" for="contestant_id">身份證或護照號</label>
                                                <asp:TextBox ID="txtCbIdno" runat="server" CssClass="k-form-input" placeholder="請輸入參賽者身份證字號或護照號" AutoComplete="OFF" Enabled="false" required></asp:TextBox>
                                                <asp:HiddenField ID="hidCbIdno" runat="server" />
                                            </li>
                                            <li>
                                                <label class="k-form-label" for="tel">連絡電話</label>
                                                <asp:TextBox ID="txtCbPhone" runat="server" CssClass="k-form-input" placeholder="ex.0912987564" AutoComplete="OFF" TextMode="Phone" required></asp:TextBox>
                                            </li>
                                            <li>
                                                <label class="k-form-label" for="email">連絡email</label>
                                                <asp:TextBox ID="txtCbEmail" runat="server" CssClass="k-form-input" placeholder="ex.cook@gmail.com" AutoComplete="OFF" TextMode="Email" required></asp:TextBox>
                                            </li>
                                        </ul>
                                        <ul class="k-form-list k-form-col">
                                            <li>
                                                <label class="k-form-label" for="birth">出生年月日</label>
                                                <asp:TextBox ID="txtCbBirthDay" runat="server" CssClass="k-form-input" placeholder="請輸入參賽者出生年月日" AutoComplete="OFF" TextMode="Date" required></asp:TextBox>
                                            </li>
                                            <li>
                                                <label class="k-form-label" for="unit">服務／學校單位</label>
                                                <asp:TextBox ID="txtCbUnit" runat="server" CssClass="k-form-input" placeholder="請輸入參賽者服務單位或學校單位" AutoComplete="OFF" required></asp:TextBox>
                                            </li>
                                            <li>
                                                <label class="k-form-label" for="title">職稱／年級</label>
                                                <asp:TextBox ID="txtCbJobTitle" runat="server" CssClass="k-form-input" placeholder="ex.經理／三年級" AutoComplete="OFF" required></asp:TextBox>
                                            </li>
                                            <li>
                                                <label class="k-form-label" for='<%=listCbSignArea.ClientID%>'>報名區域</label>
                                                <asp:ListBox ID="listCbSignArea" runat="server" Style="height: 52px" CssClass="k-form-input select2" SelectionMode="Multiple" data-placeholder="需符合以下任一條件（複選，必填一項）">
                                                    <asp:ListItem>戶籍地</asp:ListItem>
                                                    <asp:ListItem>居住地</asp:ListItem>
                                                    <asp:ListItem>任職地</asp:ListItem>
                                                    <asp:ListItem>目前就讀學校所在地</asp:ListItem>
                                                </asp:ListBox>
                                            </li>
                                        </ul>
                                    </div>
                                </fieldset>
                            </asp:PlaceHolder>
                            <asp:PlaceHolder ID="PlaceHolderPlanMember" runat="server">
                                <fieldset>
                                    <legend>隊長資料</legend>
                                    <div class="k-form-row">
                                        <ul class="k-form-list k-form-col">
                                            <li>
                                                <label class="k-form-label" for="leader_name">隊長姓名</label>
                                                <asp:TextBox ID="txtPmLeaderName" runat="server" CssClass="k-form-input" placeholder="請輸入隊長姓名" AutoComplete="OFF" required></asp:TextBox>
                                            </li>
                                            <li>
                                                <label class="k-form-label" for="leader_id">身份證或護照號</label>
                                                <asp:TextBox ID="txtPmLeaderIdno" runat="server" CssClass="k-form-input" placeholder="請輸入隊長身份證字號或護照號" AutoComplete="OFF" Enabled="false" required></asp:TextBox>
                                                <asp:HiddenField ID="hidPmLeaderIdno" runat="server" />
                                            </li>
                                            <li>
                                                <label class="k-form-label" for="leader_tel">連絡電話</label>
                                                <asp:TextBox ID="txtPmLeaderPhone" runat="server" CssClass="k-form-input" placeholder="ex.0912987654" AutoComplete="OFF" TextMode="Phone" required></asp:TextBox>
                                            </li>
                                            <li>
                                                <label class="k-form-label" for="leader_email">連絡email</label>
                                                <asp:TextBox ID="txtPmLeaderEmail" runat="server" CssClass="k-form-input" placeholder="ex.cook@gmail.com" AutoComplete="OFF" TextMode="Email" required></asp:TextBox>
                                            </li>
                                        </ul>
                                        <ul class="k-form-list k-form-col">
                                            <li>
                                                <label class="k-form-label" for="leader_birth">出生年月日</label>
                                                <asp:TextBox ID="txtPmLeaderBirthday" runat="server" CssClass="k-form-input" placeholder="請輸入隊長出生年月日" AutoComplete="OFF" required TextMode="Date"></asp:TextBox>
                                            </li>
                                            <li>
                                                <label class="k-form-label" for="leader_unit">服務／學校單位</label>
                                                <asp:TextBox ID="txtPmLeaderUnit" runat="server" CssClass="k-form-input" placeholder="請輸入隊長服務單位或學校單位" AutoComplete="OFF" required></asp:TextBox>
                                            </li>
                                            <li>
                                                <label class="k-form-label" for="leader_title">職稱／年級</label>
                                                <asp:TextBox ID="txtPmLeaderJobTitle" runat="server" CssClass="k-form-input" placeholder="ex.經理／三年級" AutoComplete="OFF" required></asp:TextBox>
                                            </li>
                                            <li>
                                                <label class="k-form-label" for='<%=listPmLeaderSignArea.ClientID%>'>報名區域</label>
                                                <asp:ListBox ID="listPmLeaderSignArea" runat="server" Style="height: 52px" CssClass="k-form-input select2" SelectionMode="Multiple" data-placeholder="需符合以下任一條件（複選，必填一項）">
                                                    <asp:ListItem>戶籍地</asp:ListItem>
                                                    <asp:ListItem>居住地</asp:ListItem>
                                                    <asp:ListItem>任職地</asp:ListItem>
                                                    <asp:ListItem>目前就讀學校所在地</asp:ListItem>
                                                </asp:ListBox>
                                            </li>
                                        </ul>
                                    </div>
                                </fieldset>
                                <asp:PlaceHolder ID="PlaceHolderFirst" runat="server">
                                    <fieldset>
                                        <legend>隊員一資料</legend>
                                        <div class="k-form-row">
                                            <ul class="k-form-list k-form-col">
                                                <li>
                                                    <label class="k-form-label" for="player1_name">隊員一姓名</label>
                                                    <asp:TextBox ID="txtPmFirstName" runat="server" CssClass="k-form-input" placeholder="請輸入隊員一姓名" AutoComplete="OFF" required></asp:TextBox>
                                                </li>
                                                <li>
                                                    <label class="k-form-label" for="player1_id">身份證或護照號</label>
                                                    <asp:TextBox ID="txtPmFirstIdno" runat="server" CssClass="k-form-input" placeholder="請輸入隊員一身份證字號或護照號" AutoComplete="OFF" required OnTextChanged="txtPmFirstIdno_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                    <asp:HiddenField ID="hidPmFirstIdno" runat="server" />
                                                </li>
                                                <li>
                                                    <label class="k-form-label" for="player1_tel">連絡電話</label>
                                                    <asp:TextBox ID="txtPmFirstPhone" runat="server" CssClass="k-form-input" placeholder="ex.0912987654" AutoComplete="OFF" TextMode="Phone" required></asp:TextBox>
                                                </li>
                                                <li>
                                                    <label class="k-form-label" for="player1_email">連絡email</label>
                                                    <asp:TextBox ID="txtPmFirstEmail" runat="server" CssClass="k-form-input" placeholder="ex.cook@gmail.com" AutoComplete="OFF" TextMode="Email" required></asp:TextBox>
                                                </li>
                                            </ul>
                                            <ul class="k-form-list k-form-col">
                                                <li>
                                                    <label class="k-form-label" for="player1_birth">出生年月日</label>
                                                    <asp:TextBox ID="txtPmFirstBirthday" runat="server" CssClass="k-form-input" placeholder="請輸入隊員一出生年月日" AutoComplete="OFF" TextMode="Date" required></asp:TextBox>
                                                </li>
                                                <li>
                                                    <label class="k-form-label" for="player1_unit">服務／學校單位</label>
                                                    <asp:TextBox ID="txtPmFirstUnit" runat="server" CssClass="k-form-input" placeholder="請輸入隊員一服務單位或學校單位" AutoComplete="OFF" required></asp:TextBox>
                                                </li>
                                                <li>
                                                    <label class="k-form-label" for="player1_title">職稱／年級</label>
                                                    <asp:TextBox ID="txtPmFirstJobTitle" runat="server" CssClass="k-form-input" placeholder="ex.經理／三年級" AutoComplete="OFF" required></asp:TextBox>
                                                </li>
                                            </ul>
                                        </div>
                                    </fieldset>
                                </asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolderSecond" runat="server">
                                    <fieldset>
                                        <legend>隊員二資料</legend>
                                        <div class="k-form-row">
                                            <ul class="k-form-list k-form-col">
                                                <li>
                                                    <label class="k-form-label" for="player2_name">隊員二姓名</label>
                                                    <asp:TextBox ID="txtPmSecondName" runat="server" CssClass="k-form-input" placeholder="請輸入隊員二姓名" AutoComplete="OFF" required></asp:TextBox>
                                                </li>
                                                <li>
                                                    <label class="k-form-label" for="player2_id">身份證或護照號</label>
                                                    <asp:TextBox ID="txtPmSecondIdno" runat="server" CssClass="k-form-input" placeholder="請輸入隊員二身份證字號或護照號" AutoComplete="OFF" required OnTextChanged="txtPmSecondIdno_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                    <asp:HiddenField ID="hidPmSecondIdno" runat="server" />
                                                </li>
                                                <li>
                                                    <label class="k-form-label" for="player2_tel">連絡電話</label>
                                                    <asp:TextBox ID="txtPmSecondPhone" runat="server" CssClass="k-form-input" placeholder="ex.0912987654" AutoComplete="OFF" TextMode="Phone" required></asp:TextBox>
                                                </li>
                                                <li>
                                                    <label class="k-form-label" for="player2_email">連絡email</label>
                                                    <asp:TextBox ID="txtPmSecondEmail" runat="server" CssClass="k-form-input" placeholder="ex.cook@gmail.com" AutoComplete="OFF" TextMode="Email" required></asp:TextBox>
                                                </li>
                                            </ul>
                                            <ul class="k-form-list k-form-col">
                                                <li>
                                                    <label class="k-form-label" for="player2_birth">出生年月日</label>
                                                    <asp:TextBox ID="txtPmSecondBirthday" runat="server" CssClass="k-form-input" placeholder="請輸入隊員二出生年月日" AutoComplete="OFF" TextMode="Date" required></asp:TextBox>
                                                </li>
                                                <li>
                                                    <label class="k-form-label" for="player2_unit">服務／學校單位</label>
                                                    <asp:TextBox ID="txtPmSecondUnit" runat="server" CssClass="k-form-input" placeholder="請輸入隊員二服務單位或學校單位" AutoComplete="OFF" required></asp:TextBox>
                                                </li>
                                                <li>
                                                    <label class="k-form-label" for="player2_title">職稱／年級</label>
                                                    <asp:TextBox ID="txtPmSecondJobTitle" runat="server" CssClass="k-form-input" placeholder="ex.經理／三年級" AutoComplete="OFF" required></asp:TextBox>
                                                </li>
                                            </ul>
                                        </div>
                                    </fieldset>
                                </asp:PlaceHolder>
                            </asp:PlaceHolder>
                        </div>
                        <div class="k-form-box">
                            <fieldset>
                                <legend>參賽資料</legend>
                                <ul class="k-form-list  k-form-lg">
                                    <li>
                                        <label class="k-form-label" for="work_title">初賽參賽作品名稱</label>
                                        <asp:TextBox ID="txtTitle" runat="server" CssClass="k-form-input" placeholder="請輸入參賽的作品名稱" AutoComplete="OFF" required MaxLength="100"></asp:TextBox>
                                    </li>
                                    <li>
                                        <p class="k-form-label">
                                            <asp:Literal ID="litWorkFileTitle" runat="server"></asp:Literal>
                                        </p>
                                        <section class="j-d-flex upload-area">
                                            <asp:FileUpload ID="FileUploadWorkFile" class="input-noshow" Style="display: none" runat="server" accept=".pdf" onchange="SetFileName(this,'file_name_recipe')" />
                                            <label for='<%=FileUploadWorkFile.ClientID%>' class="k-btn-common k-btn-upload">
                                                <span>上傳檔案</span>
                                            </label>
                                            <span class="file-name" id="file_name_recipe">
                                                <asp:Literal ID="litWorkFile" runat="server"></asp:Literal>
                                            </span>
                                        </section>

                                        <span class="k-file">檔案格式：限pdf</span>
                                    </li>
                                    <li>
                                        <p class="k-form-label">初賽作品授權書</p>
                                        <section class="j-d-flex upload-area">
                                            <asp:FileUpload ID="FileUploadAuthorizeFile" class="input-noshow" Style="display: none" runat="server" accept=".pdf" onchange="SetFileName(this,'file_name_PowerOfAttorney')" />
                                            <label for='<%=FileUploadAuthorizeFile.ClientID%>' class="k-btn-common k-btn-upload">
                                                <span>上傳檔案</span>
                                            </label>
                                            <span class="file-name" id="file_name_PowerOfAttorney">
                                                <asp:Literal ID="litAuthorizeFile" runat="server"></asp:Literal>
                                            </span>
                                        </section>
                                        <span class="k-file">檔案格式：限pdf</span>
                                    </li>
                                    <asp:PlaceHolder ID="PlaceHolderTeachingFile" runat="server">
                                        <li>
                                            <p class="k-form-label">初賽相關教學檔案或照片</p>
                                            <section class="j-d-flex upload-area">
                                                <asp:FileUpload ID="FileUploadTeachingFile" class="input-noshow" Style="display: none" runat="server" accept=".pdf" onchange="SetFileName(this,'file_name_attachment')" />
                                                <label for='<%=FileUploadTeachingFile.ClientID%>' class="k-btn-common k-btn-upload">
                                                    <span>上傳檔案</span>
                                                </label>
                                                <span class="file-name" id="file_name_attachment">
                                                    <asp:Literal ID="litTeachingFile" runat="server"></asp:Literal>
                                                </span>
                                            </section>
                                            <span class="k-file">檔案格式：限pdf</span>
                                        </li>
                                    </asp:PlaceHolder>
                                    <li>
                                        <p class="k-form-label">法定代理人同意書</p>
                                        <section class="j-d-flex upload-area">
                                            <asp:FileUpload ID="FileUploadRepresentativeConsent" class="input-noshow" Style="display: none" runat="server" accept=".pdf" onchange="SetFileName(this,'file_name_consent')" />
                                            <label for='<%=FileUploadRepresentativeConsent.ClientID%>' class="k-btn-common k-btn-upload">
                                                <span>上傳檔案</span>
                                            </label>
                                            <span class="file-name" id="file_name_consent">
                                                <asp:Literal ID="litRepresentativeConsent" runat="server"></asp:Literal>
                                            </span>
                                        </section>
                                        <span class="k-file">檔案格式：限pdf</span>
                                    </li>
                                </ul>
                            </fieldset>
                        </div>
                        <div class="k-form-box k-agree-box">
                            <div class="k-agree">
                                <h4>注意事項：</h4>
                                <ol class="default-list">
                                    <li>一、每位參賽選手僅能選擇一縣市（符合就讀學校所在地、戶籍地、居住地或任職所在地），且每位參賽者在1個組別僅能報名一次（不論是否為隊長或隊員）。</li>
                                    <li>二、以團隊名義報名之參賽者，指定授權代表人(隊長)有權代表該團體負責比賽報名、聯繫、入圍及得獎權利義務之一切相關事宜，並請自行分配團體內部的各項權責歸屬。</li>
                                    <li>三、為保障參賽者的參賽資料，請妥善保管各團隊自身帳號密碼，請勿將帳號、密碼等資料交付給他人，若因個人疏失造成資料外流、遺失等情事，相關責任自負。</li>
                                    <li>
                                </ol>
                            </div>
                        </div>
                        <asp:PlaceHolder ID="PlaceHolderCheck" runat="server">
                            <div class="k-form-box k-agree-box">
                                <div class="k-agree">
                                    <h4>個人資料之同意提供：<%--<a href="#" target="_blank" class="k-btn-common">蒐集個人資料告知事項</a>--%></h4>
                                    <ol>
                                        <li>
                                            <asp:CheckBox ID="chbKnowAll" runat="server" />
                                            <label for='<%= chbKnowAll.ClientID %>'><span class="k-no">一、</span>本甄選活動茲依據個人資料保護法之相關規定辦理。</label>
                                        </li>
                                        <li>
                                            <asp:CheckBox ID="chbDataUser" runat="server" />
                                            <label for='<%= chbDataUser.ClientID %>'><span class="k-no">二、</span>相關個人資料僅供環保署首惜廚師甄選活動使用。</label>
                                        </li>
                                        <li>
                                            <asp:CheckBox ID="chbDataCollect" runat="server" />
                                            <label for='<%= chbDataCollect.ClientID %>'><span class="k-no">三、</span>本人同意本機構於特定目的範圍內蒐集、處理及利用本人之個人資料，並得將本人資料提供予參與徵信資料交換或履行法定義務必要範圍內請求行政協助之公務機關。</label>
                                        </li>
                                    </ol>
                                </div>
                            </div>
                        </asp:PlaceHolder>
                        <asp:Button ID="Button1" runat="server" Text="確定送出" CssClass="k-btn-common k-btn-lg" OnClick="Button1_Click" />
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="Button1" />
                </Triggers>
            </asp:UpdatePanel>
            <!-----//內容區END------>
        </div>
        <!--//wrapper--->
    </div>
    <!--//main-content-->
    <script>    
        $(".select2").select2();
        function SetFileName(fileUpload, fileNameId) {
            var fileData = fileUpload.files[0]; // 檔案資訊
            var fileName = fileData.name; // 檔案名稱
            document.getElementById(fileNameId).innerText = fileName;
        }
    </script>
</asp:Content>


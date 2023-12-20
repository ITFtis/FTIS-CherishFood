<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="banner">
        <div class="s01"></div>
        <div class="s02"></div>
        <div class="s03"></div>
        <div class="light"></div>
        <div>
            <a href="#">
                <asp:Image ID="ImageBanner" runat="server" />
                <%--<img src="images/KV_concept.jpg" alt="首惜廚師，惜食{美味食譜}{創意教案}甄選，總獎金70萬等你來挑戰">--%>
            </a>
        </div>
    </div>
    <div class="event-info" id="content">
        <a href="#C" title="中央內容區塊" id="AC" accesskey="C" name="C" class="accesskey ac">:::</a>
        <div class="wrapper2">
            <div class="ei-icon-list">
                <i class="icon-purpose"></i>
                <i class="icon-people"></i>
                <i class="icon-team"></i>
            </div>


            <ul class="ei-ul">
                <li class="ei-area">
                    <div class="ei-text">
                        <h3>活動目的</h3>
                        <article>
                            為推廣社會大眾關注及支持惜食理念，看料理家們如何化平凡為神奇，在美味料理的同時落實惜食理念；教育界如何運用活潑有趣的教案推廣更多人瞭解惜食理念，一同開創臺灣料理新食代！
                        </article>
                    </div>
                </li>
                <li class="ei-area">
                    <div class="ei-text">
                        <h3>參加對象</h3>
                        <article>
                            凡餐飲相關產業廚師、教師、學生、從業人員、環境教育人員、對料理或惜食文化推廣感興趣的人皆可參加。
                        </article>
                    </div>
                </li>
                <li class="ei-area">
                    <div class="ei-text">
                        <h3>組隊方式</h3>
                        <article>
                            <ol class="ol-list">
                                <li>惜食料理食譜組：限個人報名參加。</li>
                                <li>惜食教案組：不限個人或團隊報名參加，若以團隊參賽，成員至多3 名，惟報名時請以 1 人為代表人報名，勿多人同時報名。</li>
                            </ol>
                        </article>
                    </div>
                </li>
            </ul>
        </div>
        <!--//wrapper2--->
    </div>

    <!---參賽分組---->
    <div class="group-area">
        <div class="wrapper2 group j-d-flex j-flex-wrap">
            <section class="g-item">
                <div class="g-content">
                    <p class="g1"><span>限個人報名參加</span></p>
                    <p class="g2">惜食料理</p>
                    <h2 class="g3">食譜組</h2>
                    <p class="g-text">以吃全食（零廚餘）、吃格外、食當季、吃在地（低碳排料理）等惜食概念，規劃設計至少 1 道惜食且美味的食譜。</p>
                    <a href="Apply.aspx" class="btn-go">我要報名</a>
                </div>
                <div class="g-img"></div>
            </section>
            <section class="g-item">
                <div class="g-content">
                    <p class="g1"><span>不限個人或團隊報名參加</span></p>
                    <p class="g2">惜食料理</p>
                    <h2 class="g3">教案組</h2>
                    <p class="g-text">以 10 項惜食行動「主動說、可以選、可打包、吃格外、吃全食、吃在地、惜食材、愛地球、愛分享、愛推廣」，規劃設計至少 4 節（可分堂、分天）之惜食教案。</p>
                    <a href="Apply.aspx" class="btn-go">我要報名</a>
                </div>
                <div class="g-img part2"></div>
            </section>
        </div>
    </div>
    <!---//參賽分組---->

    <!--甄選時程-->
    <div class="timeline-area">
        <div class="wrapper2">
            <h2>甄選時程</h2>
            <div class="time-line j-d-flex">
                <div class="time1">
                    <i></i>
                    <p>地方初賽報名投件</p>
                    <p class="time">112/06/15 12:00</p>
                </div>
                <span class="time-arrow"></span>
                <div class="time2">
                    <i></i>
                    <p>地方初賽辦理</p>
                    <p class="time">112/08/11 前</p>
                </div>
                <span class="time-arrow"></span>
                <div class="time3">
                    <i></i>
                    <p>全國決賽/頒獎典禮</p>
                    <p class="time">112/09/16</p>
                </div>
            </div>
        </div>
    </div>
    <!--//甄選時程-->

    <!--獎項-->
    <div class="award-area j-d-flex">
        <section class="award-item">
            <div class="award-item-wrap">
                <div class="award-item-title">
                    惜食料理食譜組 獎項
                </div>
                <ul>
                    <li>
                        <i class="award-number">
                            <span class="set-space">1</span>名
                        </i>
                        <div class="award-item-content">
                            <p>首惜廚師獎</p>
                            <p class="award-money">100,000元<span>禮卷</span></p>
                            <p class="award-gift">獎狀一紙、獎座一座、紀念綠領巾乙條及錦旗一面</p>
                        </div>
                    </li>
                    <li>
                        <i class="award-number">
                            <span class="set-space">1</span>名
                        </i>
                        <div class="award-item-content">
                            <p>惜食職人獎</p>
                            <p class="award-money">50,000元<span>禮卷</span></p>
                            <p class="award-gift">獎狀一紙、獎座一座、紀念綠領巾乙條及錦旗一面</p>
                        </div>
                    </li>
                    <li>
                        <i class="award-number">
                            <span class="set-space">1</span>名
                        </i>
                        <div class="award-item-content">
                            <p>惜食達人獎</p>
                            <p class="award-money">30,000元<span>禮卷</span></p>
                            <p class="award-gift">獎狀一紙、獎座一座、紀念綠領巾乙條及錦旗一面</p>
                        </div>
                    </li>
                    <li>
                        <i class="award-number">
                            <span class="set-space">3</span>名
                        </i>
                        <div class="award-item-content">
                            <p>惜食特色獎</p>
                            <p class="award-money">15,000元<span>禮卷</span></p>
                            <p class="award-gift">獎狀一紙、獎座一座及錦旗一面</p>
                        </div>
                    </li>
                    <li>
                        <i class="award-number">
                            <span>16</span>名
                        </i>
                        <div class="award-item-content">
                            <p>滿漢全惜獎</p>
                            <p class="award-money">8,000元<span>禮卷</span></p>
                            <p class="award-gift">獎狀一紙、獎座一座及錦旗一面</p>
                        </div>
                    </li>
                </ul>
            </div>
        </section>

        <section class="award-item award-idea">
            <div class="award-item-wrap">
                <div class="award-item-title">
                    惜食教案組 獎項
                </div>
                <ul>
                    <li>
                        <i class="award-number">
                            <span class="set-space">1</span>名
                        </i>
                        <div class="award-item-content">
                            <p>巧食金獎</p>
                            <p class="award-money">100,000元<span>禮卷</span></p>
                            <p class="award-gift">獎狀一紙、獎座一座、紀念綠領巾乙條及錦旗一面</p>
                        </div>
                    </li>
                    <li>
                        <i class="award-number">
                            <span class="set-space">1</span>名
                        </i>
                        <div class="award-item-content">
                            <p>巧食銀獎</p>
                            <p class="award-money">50,000元<span>禮卷</span></p>
                            <p class="award-gift">獎狀一紙、獎座一座、紀念綠領巾乙條及錦旗一面</p>
                        </div>
                    </li>
                    <li>
                        <i class="award-number">
                            <span class="set-space">1</span>名
                        </i>
                        <div class="award-item-content">
                            <p>巧食銅獎</p>
                            <p class="award-money">30,000元<span>禮卷</span></p>
                            <p class="award-gift">獎狀一紙、獎座一座、紀念綠領巾乙條及錦旗一面</p>
                        </div>
                    </li>
                    <li>
                        <i class="award-number">
                            <span class="set-space">3</span>名
                        </i>
                        <div class="award-item-content">
                            <p>創意食育獎</p>
                            <p class="award-money">15,000元<span>禮卷</span></p>
                            <p class="award-gift">獎狀一紙、獎座一座及錦旗一面</p>
                        </div>
                    </li>
                    <li>
                        <i class="award-number">
                            <span>16</span>名
                        </i>
                        <div class="award-item-content">
                            <p>特色教案獎</p>
                            <p class="award-money">8,000元<span>禮卷</span></p>
                            <p class="award-gift">獎狀一紙、獎座一座及錦旗一面</p>
                        </div>
                    </li>
                </ul>
            </div>
        </section>
    </div>
    <!--//award-area--->
    <!--//獎項-->

    <!--惜食料理食譜甄選主題--->
    <div class="recipe-article-area">
        <div class="wrapper">
            <div class="recipe-article-title">
                <h2>惜食料理食譜甄選主題</h2>
            </div>
            <div class="recipe-article-body j-d-flex">
                <section class="recipe-col">
                    <div class="recipe-box recipe-article-text">
                        <h3>全食物利用<span>（零廚餘）</span></h3>
                        <p>採用天然、完整，沒有加工精製過的食材，並將食材完整利用。如：將蔬菜連根帶葉一起料理運用，做到既美味又不浪費的料理。</p>
                    </div>
                    <div class="recipe-box recipe-article-img rai02"></div>

                </section>

                <section class="recipe-col">
                    <div class="recipe-box recipe-article-img rai01"></div>
                    <div class="recipe-box recipe-article-text">
                        <h3>即期品、格外品料理</h3>
                        <p>將即期品或市場規格之外（如表皮損傷、過熟、短小或外型不佳等蔬果）但品質無虞的食材，透過料理方式，成為一道賞心悅目的餐點。</p>
                    </div>
                </section>

                <section class="recipe-col">
                    <div class="recipe-box recipe-article-text">
                        <h3>食當季、吃在地<span>（低碳排料理）</span></h3>
                        <p>選用當季且在地食材，烹飪出一道低食物里程的低碳料理</p>
                    </div>
                    <div class="recipe-box recipe-article-img rai03"></div>
                </section>

            </div>


            <div class="recipe-article-footer">
                附註：不限定主食材、副食材，可混合多個主題進行食譜設計。
            </div>
        </div>
    </div>
    <!---//惜食料理食譜甄選主題--->

    <!----惜食教案甄選主題----->

    <div class="idea-area">
        <div class="wrapper2">
            <div class="idea-article-title">
                <h2>惜食教案甄選主題</h2>
            </div>
            <div class="idea-list-wrap j-d-flex">
                <ul class="idea-list">
                    <li>
                        <i class="idea-icon01"></i>
                        <div>
                            <h3>主動說</h3>
                            <p>鼓勵主動說明餐點／食品內容或主動詢問餐點內容，不吃的食物可事先表明。 </p>
                        </div>
                    </li>
                    <li>
                        <i class="idea-icon02"></i>
                        <div>
                            <h3>可以選</h3>
                            <p>鼓勵「吃多少，點/買多少」，主動說出份量大小的需求，並可依喜好減少特殊食材。 </p>
                        </div>
                    </li>
                    <li>
                        <i class="idea-icon03"></i>
                        <div>
                            <h3>可打包</h3>
                            <p>鼓勵打包吃不完的食物，並妥善存放、儘快食用。 </p>
                        </div>
                    </li>
                    <li>
                        <i class="idea-icon04"></i>
                        <div>
                            <h3>吃格外</h3>
                            <p>不排斥格外品（如：醜蔬果）和即期品；如為即食需求，鼓勵可優先選擇即期品。 </p>
                        </div>
                    </li>
                    <li>
                        <i class="idea-icon05"></i>
                        <div>
                            <h3>吃全食</h3>
                            <p>煮飯時，鼓勵將整個食材（如果皆可食）全部入菜食用，來一頓零廚餘的料理。 </p>
                        </div>
                    </li>
                </ul>
                <ul class="idea-list">
                    <li>
                        <i class="idea-icon06"></i>
                        <div>
                            <h3>吃在地</h3>
                            <p>自煮時鼓勵優先購買在地食材；外食時鼓勵優先選擇惜食推廣種子店家、綠色餐廳。 </p>
                        </div>
                    </li>
                    <li>
                        <i class="idea-icon07"></i>
                        <div>
                            <h3>惜食材</h3>
                            <p>
                                ◆ 鼓勵每天至少 1 餐，把點的食物全部吃完<br>
                                ◆ 鼓勵善用食材不浪費（如：骨頭熬湯、果皮堆肥）。
                            </p>
                        </div>
                    </li>
                    <li>
                        <i class="idea-icon08"></i>
                        <div>
                            <h3>愛地球</h3>
                            <p>
                                ◆ 鼓勵一週一蔬食日，並且做好廚餘分類。<br>
                                ◆ 鼓勵自備環保杯、餐具、購物袋。
                            </p>
                        </div>
                    </li>
                    <li>
                        <i class="idea-icon09"></i>
                        <div>
                            <h3>愛分享</h3>
                            <p>鼓勵可將吃不完的食材／食物，趁新鮮與親友分享或捐贈給食物銀行／剩食再利用組織。 </p>
                        </div>
                    </li>
                    <li>
                        <i class="idea-icon10"></i>
                        <div>
                            <h3>愛推廣</h3>
                            <p>鼓勵可適時與親友分享惜食理念。 </p>
                        </div>
                    </li>
                </ul>
            </div>
            <!---idea-list-wrap END----->
            <div class="idea-article-footer">
                附註：可混合多個主題進行教案設計。 
            </div>
        </div>
    </div>
    <!----//惜食教案甄選主題----->
    <!--最新消息-->
    <div class="i-news-area">
        <div class="wrapper">
            <h2>最新消息</h2>
            <ul class="i-news-list">
                <asp:ListView ID="ListViewNews" runat="server">
                    <ItemTemplate>
                        <li class="i-news-li">
                            <a href='NewsContent.aspx?Id=<%# Eval("Id") %>'>
                                <div class="i-news-photo">
                                    <img src='../WPContent/<%# Eval("MainPic") %>' alt='<%# Eval("Title") %>'>
                                </div>
                                <p class="news-date"><%# Eval("ReleaseDate","{0:yyyy/MM/dd}") %></p>
                                <div class="news-title"><%# Eval("Title") %></div>
                            </a>
                        </li>
                    </ItemTemplate>
                </asp:ListView>
            </ul>
        </div>

    </div>
    <!--//最新消息-->
</asp:Content>


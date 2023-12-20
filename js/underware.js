$('.owl-carousel').each(function () {
    var $carousel = $(this);
    $carousel.owlCarousel({
        dots: $carousel.data("dots"),
        items: $carousel.data("items"),
        slideBy: $carousel.data("slideby"),
        center: $carousel.data("center"),
        loop: $carousel.data("loop"),
        margin: $carousel.data("margin"),
        nav: $carousel.data("nav"),
        autoplay: true,
        autoplayTimeout: $carousel.data("autoplay-timeout"),
        navText: ['<span class="fa fa-chevron-left"><span>', '<span class="fa fa-chevron-right"></span>'],
        responsive: $carousel.data("responsive"),
        animateOut: $carousel.data("animateout"),
        animateIn: $carousel.data("animatein"),
    });
});


$(".th-productlist .btn >span").on('click',function(){
    var self = $(this);
    var parents = self.parents('.th-productlist');
    self.addClass('On').siblings().removeClass('On');
    if(parents.hasClass('contTwo')){
        parents.removeClass('contTwo');
    }
    if(parents.hasClass('contThree')){
        parents.removeClass('contThree');
    }
    self.parents('.th-productlist').toggleClass(self.attr('data-btn'));
});

$(".th-productlist-100 .btn >span").on('click',function(){
    var self = $(this);
    var parents = self.parents('.th-productlist-100');
    self.addClass('On').siblings().removeClass('On');
    if(parents.hasClass('contTwo')){
        parents.removeClass('contTwo');
    }
    if(parents.hasClass('contThree')){
        parents.removeClass('contThree');
    }
    self.parents('.th-productlist-100').toggleClass(self.attr('data-btn'));
});


$('.sizeList li').on('click',function(){
    if(!$(this).hasClass('none')){
        $(this).addClass('active').siblings().removeClass('active');
    }
});

$(".underpantsSize li").on('click',function(){
    $(this).addClass('active').siblings().removeClass('active');
});


$(window).on('scroll',function(){
    if($(".product-choose").length>0){
        var cont = $(".product-choose");
        var tagertH = cont.offset().top+cont.height()-$(".buyBtnCont").height()-$("#header").height();
        if($(".buyBtnCont").length>0){
            if($(this).scrollTop() > tagertH){
                $(".buyBtnCont").addClass("fixed")
            }else{
                $(".buyBtnCont").removeClass("fixed")
            }
        }
    }
});

$(".linksList li h4").on('click',function(){
    $(this).parent().toggleClass('show').siblings().removeClass("show");
});



// 用來紀錄收合內的照片sider的啟動狀態
var pluginState={
    howToWear: false,
    howToWearPC:false,
    barSize: false,
    pantiesSize: false,
    preadMore: false
};

$(".switchLightBox").on("click",function(event){
    var self = $(this);
    var contClass = '.lightBox-' + self.attr('data-class');
    var showBlock = self.attr('data-show');
    var isIframe = showBlock == 'youtubeIframe' ? true : false;
    var plugin;
    var idx;
    $(contClass).find(".pt-bannerList li").each(function(){
        if($(this).attr('data-id') == $(event.target).attr('data-id')){
            idx = $(this).index();
        }
    });

    // 打開該燈箱
    $(contClass).addClass("show");
    // 打開燈箱內的slider區塊 or youtube區塊
    $(contClass).find('.'+showBlock).addClass('show');

    // 收合內的slider啟動----
    if(!pluginState[self.attr('data-class')]){
        // plugin啟動
        if(pluginState[self.attr('data-class')]!=undefined ){
            if(self.attr('data-class') == 'howToWearPC'){
                //pc版穿搭示範點擊的照片必須是開啟後的slider的第一張照片
                plugin = $(contClass).find(".imgSliderPC").cl_rtol2( {'idx':idx});
            }else{
                plugin = $(contClass).find(".imgSlider").sliderImg();
            }
            pluginState[self.attr('data-class')] = plugin;
        }

    }else{
        // 啟動後的其他處理
        if(self.attr('data-class') == 'howToWearPC'){
            //pc版穿搭示範點擊的照片必須是開啟後的slider的第一張照片
            $(contClass).find(".imgSliderPC").cl_rtol2('setImgNext', idx);
        }
    }


    



    // X按鈕的點擊處裡
    $(contClass).find('.closeBtn').on('click',function(){
        var youtubeCont = $(contClass).find('.'+showBlock);
        $(contClass).removeClass("show");
        youtubeCont.removeClass('show');
        if(isIframe){
            // click close button also close youtube video
            youtubeCont.find('iframe')[0].contentWindow.postMessage('{"event":"command","func":"' + 'pauseVideo' + '","args":""}', '*');
        }
    });
	

});
  

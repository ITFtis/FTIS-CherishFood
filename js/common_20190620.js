  // goTop
  $("#goTop").on("click",function(){$("html,body").stop().animate({scrollTop: 0});});

  $(window).scroll(function(){
    if($(window).scrollTop()>$(".main-content").offset().top){
      $("#goTop").addClass('show');
    }else{
      $("#goTop").removeClass('show');
    }

    if($(window).scrollTop()>100){
      $("#header").addClass('graybg');
    }else{
      $("#header").removeClass('graybg');
    }
  });

  $("#menuBtn").on("mousedown",function () { 
    if($('body').hasClass('rightMenu')){
      $('body').removeClass('rightMenu');
    }
    if($('body').hasClass('leftMenu')){
      leftMenuHelper.beforeClose();
    }else{
      leftMenuHelper.afterOpen();
    }
  });


  $('.mobileMemberMenuBtn').on('mousedown',function(){
    if($('body').hasClass('leftMenu')){
      $('body').removeClass('leftMenu');
    }
    if($('body').hasClass('rightMenu')){
      rightMenuHelper.beforeClose();
    }else{
      rightMenuHelper.afterOpen();
    }
  });

$(".hasThird").on('mousedown',function(){
  $(this).closest('.menuBlock').siblings(".menuBlock").find(".thirdOpen").removeClass("thirdOpen");
  $(this).closest('li').toggleClass('thirdOpen').siblings('.thirdOpen').removeClass("thirdOpen");
});


$(".menuBlock .typeTitle").on('mousedown',function(){
  if(window.innerWidth<1200){
    $(this).closest(".menuBlock").toggleClass("open").siblings(".open").removeClass("open");
  }
});


$(".mobileShow .hasThird").on('mousedown',function(){
  if(window.innerWidth<1200){
    $(this).closest(".typeBlock").toggleClass("open");
  }
});

// 解決ios and in app 開啟網頁問題
var leftMenuHelper = (function(bodyCls) {
    var scrollTop;
    return {
      afterOpen: function() {
        scrollTop = document.scrollingElement.scrollTop;
        document.body.classList.add(bodyCls);
        document.body.style.top = -scrollTop + 'px';
      },
      beforeClose: function() {
        document.body.classList.remove(bodyCls);
        // scrollTop lost after set position:fixed, restore it back.
        document.scrollingElement.scrollTop = scrollTop;
      }
    };
  })('leftMenu');
  
  var rightMenuHelper = (function(bodyCls) {
    var scrollTop;
    return {
      afterOpen: function() {
        scrollTop = document.scrollingElement.scrollTop;
        document.body.classList.add(bodyCls);
        document.body.style.top = -scrollTop + 'px';
      },
      beforeClose: function() {
        document.body.classList.remove(bodyCls);
        // scrollTop lost after set position:fixed, restore it back.
        document.scrollingElement.scrollTop = scrollTop;
      }
    };
  })('rightMenu');



// open search bar  input
//$(".searchText").on('click',function(){
//    $(this).closest('.searchBar').toggleClass("open");
//});


// Add - Sub product in shop cart
//(function ($) {
//    "use strict";
//    // use strict

//    $('.quantity').each(function () {
//        var index = $(this).children('input').val() != '' ? $(this).children('input').val() : 0;

//        $(this).children('input').val(index);

//        $(this).children('.add').on('click', function () {
//            index++;
//            $(this).siblings('input').val(index);
//        });

//        $(this).children('.sub').on('click', function () {
//            index--;
//            $(this).siblings('input').val(index);
//        });
//    });
//})(jQuery);

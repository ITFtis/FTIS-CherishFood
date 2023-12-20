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
    if($('html').hasClass('rightMenu')){
      $('html').removeClass('rightMenu')
    }
    $('html').toggleClass('leftMenu');
  });


  $('.mobileMemberMenuBtn').on('mousedown',function(){
    if($('html').hasClass('leftMenu')){
      $('html').removeClass('leftMenu')
    }
    $('html').toggleClass('rightMenu');
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

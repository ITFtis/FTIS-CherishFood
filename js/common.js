$(document).ready(function () {
	//header 背景變色
 //    $(window).scroll(function () {		
	// 	if ($(this).scrollTop() > 80) {
	// 		$(".header").addClass("bgcolor");
	// 	} else {
	// 		$(".header").removeClass("bgcolor");
	// 	}
	// });
    //手機版 漢堡選單
    $(".m-hamburger").click(function () {
		$(this).toggleClass("active");
		$(".mobile-menu").fadeToggle(300);
		//$("body").toggleClass("no-scroll");
		//展開選單時，選單底下的背景物件不要滾動(IOS沒用)
	});

    //回頂部   

    // hide #back-top first
	$("#gotop").hide();
	
	// fade in #gotop
	$(function () {
		$(window).scroll(function () {
			if ($(this).scrollTop() > 200) {
				$('#gotop').fadeIn();
			} else {
				$('#gotop').fadeOut();
			}
		});

		// scroll body to 0px on click
		$('#gotop').click(function () {
			$('body,html').animate({
				scrollTop: 0
			}, 500);
			return false;
		});
	});
	

});




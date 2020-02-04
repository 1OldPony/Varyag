var categorysState = 1
var aboutState = 1


$(document).ready(function () {

    $("#ships-catalog").mouseenter(function() {
        $("#catalog.category").css('display', 'grid');
    }); 
    
    $("#cinema").mouseenter(function() {
        $("#cinemaOrders.category").css('display', 'flex');
    });

    $("#aboutUs").mouseenter(function() {
            $("#aboutUsTopNav.category").css('display', 'flex');
    });
    
    $("#menu-nav-top, #cinema, #ships-catalog, #aboutUs").mouseleave(function (event) {
        if (event.relatedTarget.id != "catalog" && event.relatedTarget.id != "cinemaOrders" && event.relatedTarget.id != "aboutUsTopNav") {
            $(".category").hide();
        }
    });
});
////////////////////////показываем пункты верхнего подменю про музей и гото-предистинацию на девайсах///////////////////////
museumGotoShow();
function museumGotoShow() {
    if (window.innerWidth < 611) {
        $(".aboutUsGoto").attr("style", "display:flex")
    }

    if (window.innerWidth < 401) {
        $(".aboutUsMuseum").attr("style", "display:flex")
    }
}

cinemaAboutUsSubNavPosition();
function cinemaAboutUsSubNavPosition() {
    var cinemaLeft = $("#cinema.nav-element-top").offset().left;
    var aboutUsLeft = $("#aboutUs.nav-element-top").offset().left; 
    $("#cinemaOrders.category").css("left", cinemaLeft);
    $("#aboutUsTopNav.category").css("left", aboutUsLeft);
}
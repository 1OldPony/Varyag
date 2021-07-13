var leftMenuOffset;
$(document).ready(function () {
    //////////////////////////высота контролов слайдера заказчиков = высоте столбца заказчиков///////////////////////
    $("#left.control, #right.control").height($(".allCustomers").height());
    leftMenuOffset = $(".projectsHalf").offset().top;



    //document.addEventListener("DOMContentLoaded", () => {
    //    alert("DOM готов!");
    //});
});
$(window).scroll(function () {
    if ($(window).width() > 1000) {
        if ($(this).scrollTop() >= (leftMenuOffset - 50)) {
            if ($(".leftMenu").css('position') != 'fixed') {
                $(".leftMenu").css('position', 'fixed');
            }

            if ($(window).width() >= 1001) {
                $('.projectsHalf').css('margin-left', '361px');
            }
            else {
                $('.projectsHalf').css('margin-left', 'auto');
            }
        }
        else {
            if ($(".leftMenu").css('position') != 'initial') {
                $(".leftMenu").css('position', 'initial');
            }

            if ($(window).width() >= 1001) {
                $('.projectsHalf').css('margin-left', '10px');
            }
            else {
                $('.projectsHalf').css('margin-left', 'auto');
            }
        }
    }
    else {
        if ($(".leftMenu").attr('style') != null) {
            if ($(".leftMenu").css('display') != 'none') {
                $(".leftMenu").css('display', 'flex');
            }
            else {
                $(".leftMenu").removeAttr('style');
            }

        }
    }
});

//$(window).scroll(function() {
//    if ($(this).scrollTop() >= (leftMenuOffset-50)) {
//        if ($(".leftMenu").css('position')!='fixed') {
//            $(".leftMenu").css('position', 'fixed');
//        }

//        if ($(window).width() >= 1001) {
//            $('.projectsHalf').css('margin-left', '361px');
//        }
//        else {
//            $('.projectsHalf').css('margin-left', 'auto');
//        }
//    }
//    else {
//        if ($(".leftMenu").css('position') != 'initial') {
//            $(".leftMenu").css('position', 'initial');
//        }

//            if ($(window).width() >= 1001) {
//                $('.projectsHalf').css('margin-left', '10px');
//            }
//            else {
//                $('.projectsHalf').css('margin-left', 'auto');
//            }
//    }
//});

$(window).resize(function () {
    if ($(window).width() > 1000) {
        if ($(this).scrollTop() >= (leftMenuOffset - 50)) {
            if ($(".leftMenu").css('position') != 'fixed') {
                $(".leftMenu").css('position', 'fixed');
            }

            if ($(window).width() >= 1001) {
                $('.projectsHalf').css('margin-left', '361px');
            }
            else {
                $('.projectsHalf').css('margin-left', 'auto');
            }
        }
        else {
            if ($(".leftMenu").css('position') != 'initial') {
                $(".leftMenu").css('position', 'initial');
            }
            if ($(window).width() >= 1001) {
                $('.projectsHalf').css('margin-left', '10px');
            }
            else {
                $('.projectsHalf').css('margin-left', 'auto');
            }
        }
    }
    else {
        //if ($(".leftMenu").css('display') != '') {
            $(".leftMenu").removeAttr('style');
            $(".projectsHalf").removeAttr('style'); 
        //}
    }
});
//$(window).resize(function () {
    //if ($(this).scrollTop() >= (leftMenuOffset - 50)) {
    //    if ($(".leftMenu").css('position') != 'fixed') {
    //        $(".leftMenu").css('position', 'fixed');
    //    }

    //    if ($(window).width() >= 1001) {
    //        $('.projectsHalf').css('margin-left', '361px');
    //    }
    //    else {
    //        $('.projectsHalf').css('margin-left', 'auto');
    //    }
    //}
    //else {
    //    if ($(".leftMenu").css('position') != 'initial') {
    //        $(".leftMenu").css('position', 'initial');
    //    }
    //    if ($(window).width() >= 1001) {
    //        $('.projectsHalf').css('margin-left', '10px');
    //    }
    //    else {
    //        $('.projectsHalf').css('margin-left', 'auto');
    //    }
    //}
//});

/////////////////показываем верхние подменю////////////////////
//$("#ships-catalog").mouseenter(function () {
//    $("#catalog.category").css('display', 'grid');
//});

//$("#cinema").mouseenter(function () {
//    $("#cinemaOrders.category").css('display', 'flex');
//});

//$("#aboutUs").mouseenter(function () {
//    $("#aboutUsTopNav.category").css('display', 'flex');
//});

//$("#menu-nav-top, #cinema, #ships-catalog, #aboutUs").mouseleave(function (event) {
//    if (event.relatedTarget.id != "catalog" && event.relatedTarget.id != "cinemaOrders" && event.relatedTarget.id != "aboutUsTopNav") {
//        $(".category").hide();
//    }
//});

////////////////////////показываем пункты верхнего подменю про музей и гото-предистинацию на девайсах///////////////////////
//museumGotoShow();
//function museumGotoShow() {
//    if (window.innerWidth < 611) {
//        $(".aboutUsGoto").attr("style", "display:flex")
//    }

//    if (window.innerWidth < 401) {
//        $(".aboutUsMuseum").attr("style", "display:flex")
//    }
//}

//cinemaAboutUsSubNavPosition();
//function cinemaAboutUsSubNavPosition() {
//    var cinemaLeft = $("#cinema.nav-element-top").offset().left;
//    var aboutUsLeft = $("#aboutUs.nav-element-top").offset().left;
//    $("#cinemaOrders.category").css("left", cinemaLeft);
//    $("#aboutUsTopNav.category").css("left", aboutUsLeft);
//}

/////////////////////Перещелкиваем видео в новостях////////////////////
$("#videoOne").click(function () {
    var url = $("#firstVideoUrl").val();
    $("#videoPlayer").html("<iframe src='" + url + "' style='position:absolute;top:0;left:0;width:100%;height:100%;' frameborder='0' allowfullscreen></iframe>");
});
$("#videoTwo").click(function () {
    var url = $("#secondVideoUrl").val();
    $("#videoPlayer").html("<iframe src='" + url + "' style='position:absolute;top:0;left:0;width:100%;height:100%;' frameborder='0' allowfullscreen></iframe>");
});
$("#videoThree").click(function () {
    var url = $("#thirdVideoUrl").val();
    $("#videoPlayer").html("<iframe src='" + url + "' style='position:absolute;top:0;left:0;width:100%;height:100%;' frameborder='0' allowfullscreen></iframe>");
});

//////////////////добавление яндекс карт, точка на варяге//////////////////////
ymaps.ready(function () {
    var mapVaryag = new ymaps.Map("ourLocation", {
        center: [61.7702, 34.4359],
        zoom: 14
    });
    var VaryagMark = new ymaps.Placemark([61.7702, 34.4359], {
        balloonContent: 'Верфь деревянного судостроения "Вряг"<br />varyag@onego.ru<br />8 814 273 35 80',
        iconContent: ''
    },
        {
            preset: 'islands#redIcon'
        });

    mapVaryag.controls.remove('zoomControl');
    mapVaryag.controls.remove('geolocationControl');
    mapVaryag.controls.remove('searchControl');
    mapVaryag.controls.remove('routeButtonControl');
    mapVaryag.controls.remove('trafficControl');
    mapVaryag.controls.remove('rulerControl');
    mapVaryag.controls.remove('typeSelector');
    mapVaryag.controls.remove('fullscreenControl');

    mapVaryag.geoObjects.add(VaryagMark);
});

/////////////////////////выделяем выбранную категорию новостей//////////////////////////

$("#allNewsOpen, #allNewsClose").click(function () {
    if ($("#allNewsOpen").css('display') != 'none') {
        $("#allNews-Sub").attr('class', 'leftSubNavOpen');
        $("#allNews-Sub").css('visibility', 'visible');
        $("#allNews-Sub").css('opacity', '1');
        $(".leftNavMenu").css('padding-bottom', '79px')
    }
    else {
        $("#allNews-Sub").attr('class', 'leftSubNavClose');
        $("#allNews-Sub").css('visibility', 'hidden');
        $("#allNews-Sub").css('opacity', '0');
        $(".leftNavMenu").css('padding-bottom', '10px')
    }
    $("#allNewsOpen").toggle()
    $("#allNewsClose").toggle()
});
$("#themeNewsOpen, #themeNewsClose").click(function () {
    if ($("#themeNewsOpen").css('display') != 'none') {
        $("#themeNews-sub").attr('class', 'leftSubNavOpen');
        $("#themeNews-sub").css('visibility', 'visible');
        $("#themeNews-sub").css('opacity', '1');
        $("#allNewsNav").css('margin-top', '69px');
    }
    else {
        $("#themeNews-sub").attr('class', 'leftSubNavClose');
        $("#themeNews-sub").css('visibility', 'hidden');
        $("#themeNews-sub").css('opacity', '0');
        $("#allNewsNav").css('margin-top', '0px');
    }
    $("#themeNewsOpen").toggle()
    $("#themeNewsClose").toggle()
});
$("#articlesOpen, #articlesClose").click(function () {
    if ($("#articlesOpen").css('display') != 'none') {
        $("#articles-sub").attr('class', 'leftSubNavOpen');
        $("#articles-sub").css('visibility', 'visible');
        $("#articles-sub").css('opacity', '1');
        $("#themeNewsNav").css('margin-top', '46px');
    }
    else {
        $("#articles-sub").attr('class', 'leftSubNavClose');
        $("#articles-sub").css('visibility', 'hidden');
        $("#articles-sub").css('opacity', '0');
        $("#themeNewsNav").css('margin-top', '0px');
    }
    $("#articlesOpen").toggle()
    $("#articlesClose").toggle()
});
/////////////////////////выделяем выбранную подкатегорию лодок//////////////////////////
//boatsTypeSelect();
//function boatsTypeSelect() {
//    var nav = $("#boatsTypeSelector").val()
//    switch (nav) {
//        case "traditional":
//            $("#traditional").attr("class", "nav-element-minor-choosen");
//            break;
//        case "row":
//            $("#row").attr("class", "nav-element-minor-choosen");
//            break;
//        case "sail":
//            $("#sail").attr("class", "nav-element-minor-choosen");
//            break;
//        default:
//            $("#allBoats").attr("class", "nav-element-minor-choosen");
//            break;
//    }
//}

//////////////////////////обслуживание панели навигации внутри каталога//////////////////////////
//navElMinorChoose();
///////////////////заставляем поднавигацию каталога следовать за экраном при прокрутке////////////////////////
//$(window).scroll(function () {
//    if ($(this).scrollTop() > 714 && window.innerWidth > 790) {
//        $('.sub-nav-elements').css("position", "fixed");
//    }
//    else {
//        $('.sub-nav-elements').css("position", "relative");
//    }
//});

////////////////////показываем подменю на левом меню, меняем + на -/////////////////////////

$("#lodkiOpen, #lodkiClose").click(function () {
    if ($("#lodkiOpen").css('display') != 'none') {
        $("#lodki-Sub").attr('class', 'leftSubNavOpen');
        $("#lodki-Sub").css('visibility', 'visible');
        $("#lodki-Sub").css('opacity', '1');
        $("#shlupkiNav").css('margin-top', '69px')
    }
    else {
        $("#lodki-Sub").attr('class', 'leftSubNavClose');
        $("#lodki-Sub").css('visibility', 'hidden');
        $("#lodki-Sub").css('opacity', '0');
        $("#shlupkiNav").css('margin-top', '0px')
    }
    $("#lodkiOpen").toggle()
    $("#lodkiClose").toggle()
});
$("#shlupkiOpen, #shlupkiClose").click(function () {
    if ($("#shlupkiOpen").css('display') != 'none') {
        $("#shlupki-Sub").attr('class', 'leftSubNavOpen');
        $("#shlupki-Sub").css('visibility', 'visible');
        $("#shlupki-Sub").css('opacity', '1');
        $("#kateraNav").css('margin-top', '92px')
    }
    else {
        $("#shlupki-Sub").attr('class', 'leftSubNavClose');
        $("#shlupki-Sub").css('visibility', 'hidden');
        $("#shlupki-Sub").css('opacity', '0');
        $("#kateraNav").css('margin-top', '0px')
    }
    $("#shlupkiOpen").toggle()
    $("#shlupkiClose").toggle()
});
$("#kateraOpen, #kateraClose").click(function () {
    if ($("#kateraOpen").css('display') != 'none') {
        $("#katera-Sub").attr('class', 'leftSubNavOpen');
        $("#katera-Sub").css('visibility', 'visible');
        $("#katera-Sub").css('opacity', '1');
        $("#ladiyNav").css('margin-top', '92px')
    }
    else {
        $("#katera-Sub").attr('class', 'leftSubNavClose');
        $("#katera-Sub").css('visibility', 'hidden');
        $("#katera-Sub").css('opacity', '0');
        $("#ladiyNav").css('margin-top', '0px')
    }
    $("#kateraOpen").toggle()
    $("#kateraClose").toggle()
});
$("#ladiyOpen, #ladiyClose").click(function () {
    if ($("#ladiyOpen").css('display') != 'none') {
        $("#ladiy-Sub").attr('class', 'leftSubNavOpen');
        $("#ladiy-Sub").css('visibility', 'visible');
        $("#ladiy-Sub").css('opacity', '1');
        $("#sailboatsNav").css('margin-top', '46px')
    }
    else {
        $("#ladiy-Sub").attr('class', 'leftSubNavClose');
        $("#ladiy-Sub").css('visibility', 'hidden');
        $("#ladiy-Sub").css('opacity', '0');
        $("#sailboatsNav").css('margin-top', '0px')
    }
    $("#ladiyOpen").toggle()
    $("#ladiyClose").toggle()
});
$("#sailboatsOpen, #sailboatsClose").click(function () {
    if ($("#sailboatsOpen").css('display') != 'none') {
        $("#sailboats-Sub").attr('class', 'leftSubNavOpen');
        $("#sailboats-Sub").css('visibility', 'visible');
        $("#sailboats-Sub").css('opacity', '1');
        $("#modelsNav").css('margin-top', '92px')
    }
    else {
        $("#sailboats-Sub").attr('class', 'leftSubNavClose');
        $("#sailboats-Sub").css('visibility', 'hidden');
        $("#sailboats-Sub").css('opacity', '0');
        $("#modelsNav").css('margin-top', '0px')
    }
    $("#sailboatsOpen").toggle()
    $("#sailboatsClose").toggle()
});

$("#modelsOpen, #modelsClose").click(function () {
    if ($("#modelsOpen").css('display') != 'none') {
        $("#models-Sub").attr('class', 'leftSubNavOpen');
        $("#models-Sub").css('visibility', 'visible');
        $("#models-Sub").css('opacity', '1');
        $(".leftNavMenu").css('padding-bottom', '107px')
    }
    else {
        $("#models-Sub").attr('class', 'leftSubNavClose');
        $("#models-Sub").css('visibility', 'hidden');
        $("#models-Sub").css('opacity', '0');
        $(".leftNavMenu").css('padding-bottom', '10px')
    }
    $("#modelsOpen").toggle()
    $("#modelsClose").toggle()
});

//////////////////Для пролистывания списка заказчиков на странице "о нас"//////////////////////
var slideNumber = 0;
var custWidth = $(".allCustomers").width();
var step = custWidth / 9;

$("#right.control").click(function () {

    if (window.innerWidth > 990) {
        var stepWide = custWidth;

        if (slideNumber == 2) {
            slideNumber = 0;
            var scrollNumber = stepWide * slideNumber;
        }
        else {
            var scrollNumber = stepWide * (slideNumber + 1);
            slideNumber += 1;
        }
    }
    else {
        if (slideNumber == 8) {
            slideNumber = 0;
            var scrollNumber = step * slideNumber;
        }
        else {
            var scrollNumber = step * (slideNumber + 1);
            slideNumber += 1;
        }
    }

    $(".allCustomers").css('transform', "translatex(-" + scrollNumber + "px)");
});

$("#left.control").click(function () {
    if (window.innerWidth > 990) {
        var stepWide = custWidth;

        if (slideNumber == 0) {
            slideNumber = 3;
        }

        var scrollNumber = stepWide * (slideNumber - 1);
    }
    else {

        if (slideNumber == 0) {
            slideNumber = 9;
        }

        var scrollNumber = step * (slideNumber - 1);
    }

    $(".allCustomers").css('transform', "translatex(-" + scrollNumber + "px)");

    slideNumber -= 1;
});

/////////////////////////Переключение видов выдачи проектов//////////////////////////
function switchProjectsViewList() {
    if ($('.lineStyleCatalog').attr('id') != 'activated') {
        $('.lineStyleCatalog').attr('id', 'activated')
        $('.plitcaStyleCatalog').attr('id', 'deactivated')
        $('.iconListRed').attr('id', 'activated');
        $('.iconList').attr('id', 'deactivated');
        $('.iconPlitcaRed').attr('id', 'deactivated');
        $('.iconPlitca').attr('id', 'activated');
    }
}

function switchProjectsViewPlitca() {
    if ($('.plitcaStyleCatalog').attr('id') != 'activated') {
        $('.plitcaStyleCatalog').attr('id', 'activated')
        $('.lineStyleCatalog').attr('id', 'deactivated')
        $('.iconPlitcaRed').attr('id', 'activated');
        $('.iconPlitca').attr('id', 'deactivated');
        $('.iconListRed').attr('id', 'deactivated');
        $('.iconList').attr('id', 'activated');
    }
}

//////////////////////Сортируем по длинне///////////////////////
function lengthSort(category, lengthSort) {
    if (lengthSort != 'Down') {
        $('#sortDown').css('display', 'none');
        $('#sortUp').css('display', 'block');
    }
    else {
        $('#sortDown').css('display', 'block');
        $('#sortUp').css('display', 'none');
    }
    $('#sortScreen').css('display', 'block');
    $('#sortScreen2').css('display', 'block');
    $('.sortOptions').css('color', 'lightgrey');

    $('.plitcaStyleCatalog').load("../Catalog/CatalogSort?category=" + category + "&plitca=true" + "&lengthSort=" + lengthSort, function () {
        if ($('#sortScreen').css('display') == 'block') {
            $('#sortScreen').css('display', 'none');
            $('.sortOptions').css('color', '#183f61');
            $('#sortScreen2').css('display', 'none');
        }
    });
    $('.lineStyleCatalog').load("../Catalog/CatalogSort?category=" + category + "&plitca=false" + "&lengthSort=" + lengthSort, function () {
        if ($('#sortScreen').css('display') == 'block') {
            $('#sortScreen').css('display', 'none');
            $('.sortOptions').css('color', '#183f61');
            $('#sortScreen2').css('display', 'none');
        }
    });
}

function navigationButton() {
    if ($(".leftMenu").css("left") == '-31px') {
        $(".leftMenu").css("left", "-341px");
        $(".leftMenu").css("overflow", "unset");
        $("body").css("overflow", "unset");
        $('#blackScreen').css('display', 'none');
    }
    else {
        $('.leftMenu').css('left', '-31px');
        $('body').css('overflow', 'hidden');
        $('.leftMenu').css('overflow', 'scroll');
        $('#blackScreen').css('display', 'block');
    }
}


//////////////////////////виджет контакта//////////////////////////
VK.Widgets.Group("vk_groups", { mode: 3, width: "200", height: "200" }, 137987101);







//$(".nav-element-minor").mouseenter(function () {
//    deselectNavElemMinor();
//    $(this).attr("class", "nav-element-minor-choosen");
//});

//////////////////снимаем выделение с элементов подменю каталога и меню навигации по новостям,/////////////////
/////////////////выделяем элементы показывающие, какой пункт меню видит пользователь///////////////////////////
//$(".nav-element-minor").mouseleave(function () {
//    var nav = $("#newsTypeSelector").val()
//    if (nav == undefined) {
//        $(".nav-element-minor-choosen").attr("class", "nav-element-minor");
//        navElMinorChoose();
//    }
//    else {
//        $(".nav-element-minor-choosen").attr("class", "nav-element-minor");
//        newsTypeSelect();
//    }

//});

//$(".nav-element, .sub-nav, .catalog").mouseleave(function (event) {
//    var page = $("#currentPage").val();
//    switch (page) {
//        case "boats":
//        case "boatsrow":
//        case "boatssail":
//        case "boatstraditional":
//            if ((event.currentTarget.id != "sailboats" && event.target.id != "sailboats-Sub")
//                && (event.currentTarget.id != "shlupki" && event.target.id != "shlupki-Sub")
//                && (event.currentTarget.id != "katera" && event.target.id != "katera-Sub")
//                && (event.currentTarget.id != "ladiy" && event.target.id != "ladiy-Sub")) {
//                hideAll();
//                $("#lodki").attr("class", "nav-element-choosen");
//                $("#lodki-Sub").show();
//                break;
//            }
//        case "shlupki":
//        case "boatyal":
//        case "botik":
//        case "katerrow":
//        case "maketstudy":
//            if ((event.currentTarget.id != "lodki" && event.target.id != "lodki-Sub")
//                && (event.currentTarget.id != "sailboats" && event.target.id != "sailboats-Sub")
//                && (event.currentTarget.id != "katera" && event.target.id != "katera-Sub")
//                && (event.currentTarget.id != "ladiy" && event.target.id != "ladiy-Sub")) {
//                hideAll();
//                $("#shlupki").attr("class", "nav-element-choosen");
//                $("#shlupki-Sub").show();
//                break;
//            }
//        case "katera":
//        case "motosailer":
//        case "katercabin":
//        case "katerfish":
//        case "katerpass":
//        case "katerproject":
//            if ((event.currentTarget.id != "lodki" && event.target.id != "lodki-Sub")
//                && (event.currentTarget.id != "sailboats" && event.target.id != "sailboats-Sub")
//                && (event.currentTarget.id != "shlupki" && event.target.id != "shlupki-Sub")
//                && (event.currentTarget.id != "ladiy" && event.target.id != "ladiy-Sub")) {
//                hideAll();
//                $("#katera").attr("class", "nav-element-choosen");
//                $("#katera-Sub").show();
//                break;
//            }
//        case "ladiy":
//        case "ladyarow":
//        case "ladyasail":
//        case "ladyaproject":
//            if ((event.currentTarget.id != "lodki" && event.target.id != "lodki-Sub")
//                && (event.currentTarget.id != "sailboats" && event.target.id != "sailboats-Sub")
//                && (event.currentTarget.id != "shlupki" && event.target.id != "shlupki-Sub")
//                && (event.currentTarget.id != "katera" && event.target.id != "katera-Sub")) {
//                hideAll();
//                $("#ladiy").attr("class", "nav-element-choosen");
//                $("#ladiy-Sub").show();
//            }
//            break;
//        case "sailboats":
//        case "yacht":
//        case "sailboatstudy":
//        case "shvertbot":
//        case "sailboathistorical":
//        case "sailboatproject":
//            if ((event.currentTarget.id != "lodki" && event.target.id != "lodki-Sub")
//                && (event.currentTarget.id != "shlupki" && event.target.id != "shlupki-Sub")
//                && (event.currentTarget.id != "katera" && event.target.id != "katera-Sub")
//                && (event.currentTarget.id != "ladiy" && event.target.id != "ladiy-Sub")) {
//                if ($(window).width() > 383) {
//                    hideAll();
//                    $("#sailboats").attr("class", "nav-element-choosen");
//                    $("#sailboats-Sub").show();
//                }
//                break;
//            }
//            else
//                break;
//        case "models":
//            if ((event.currentTarget.id != "lodki" && event.target.id != "lodki-Sub")
//                && (event.currentTarget.id != "sailboats" && event.target.id != "sailboats-Sub")
//                && (event.currentTarget.id != "shlupki" && event.target.id != "shlupki-Sub")
//                && (event.currentTarget.id != "katera" && event.target.id != "katera-Sub")
//                && (event.currentTarget.id != "ladiy" && event.target.id != "ladiy-Sub")) {
//                hideAll();
//                $("#models").attr("class", "nav-element-choosen");
//            }
//            break;
//        default:
//            break;
//    }
//});
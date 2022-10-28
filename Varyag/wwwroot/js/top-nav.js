var leftMenuOffset;
var htmlHeight;
var scrollTop=0;

$(document).on('ready', function () {
    //spaceCalculate();
    if ($(".projectsHalf").height() != undefined) {
        leftMenuOffset = $(".projectsHalf").offset().top;
    }

    $('.slideDescription').slick({
        slidesToShow: 1,
        arrows: false,
        asNavFor: '.slider'
    });

    $('.slider').slick({
        centerMode: true,
        slidesToShow: 7,
        swipeToSlide: true,
        arrows: false,
        focusOnSelect: true,
        infinite: true,
        asNavFor: '.slideDescription',
        responsive: [
            {
                breakpoint: 1000,
                settings: {
                    slidesToShow: 5,
                }
            },
            {
                breakpoint: 800,
                settings: {
                    slidesToShow: 3,
                }
            },
            {
                breakpoint: 610,
                settings: {
                    slidesToShow: 1,
                    centerMode: false
                }
            }
        ]
    });
});

$(window).scroll(function () {
    
    //$('#spaceCount').val($(".footerNew").offset().top);

    if ($(".leftMenu").css('position', 'fixed')) {
        htmlHeight = $("html").height();
    }

    if ($(window).width() > 1000) {
        scrollTop = $(this).scrollTop();

        if (scrollTop + $(".leftMenu").height() + 61 >= $(".footerNew").offset().top) {
            //: not(#mainPage)
            $(".leftMenu").css('position', 'absolute');
            $(".leftMenu").css('top', "auto");
            $(".leftMenu").css('bottom', 0);
        }
        else {
            if (scrollTop >= (leftMenuOffset - 50)) {
                $(".leftMenu").css('position', 'fixed');
                $(".leftMenu").css('top', 60);
                $(".leftMenu").css('bottom', "auto");

                $('.projectsHalf').css('margin-left', '361px');
            }
            else {
                $(".leftMenu").css('position', 'initial');
                $('.projectsHalf').css('margin-left', '10px');

                $("#mainPage.leftMenu").css('position', 'fixed');
            }
        }
    }
    else {
        if ($(this).scrollTop() > scrollTop && $(this).scrollTop()>50) {
            //$('.spaceUnderTopMenu').css('margin-bottom', '0px');
            $('.topMenu').css('top', '-50px');
            $('.fromTheTopMenu').css('display', 'none');
            $('#arrowDown').css('display', 'block');
            $('#arrowUp').css('display', 'none');
        }
        else {
            //$('.spaceUnderTopMenu').css('margin-bottom', '50px');
            $('.topMenu').css('top', '0px');
        }
        scrollTop = $(this).scrollTop();

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

$(window).resize(function () {
    scrollTop = $(this).scrollTop();
    if ($(window).width() > 1000) {
        if ($(this).scrollTop() >= (leftMenuOffset - 50)) {
            if ($(".leftMenu").css('position') != 'fixed') {
                $(".leftMenu").css('position', 'fixed');
                $('.projectsHalf').css('margin-left', '361px');
            }
        }
        else {
            if ($(".leftMenu").css('position') != 'initial') {
                $(".leftMenu").css('position', 'initial');
                $('.projectsHalf').css('margin-left', '10px');

                $("#mainPage.leftMenu").css('position', 'fixed');
            }
        }
    }
    else {
        $(".leftMenu").removeAttr('style');
        $(".projectsHalf").removeAttr('style');
        $("body").css("overflow", "unset");
        $('#blackScreen').css('display', 'none');
    }
});

/////////////////////Перещелкиваем видео в новостях////////////////////
$("#videoOne").click(function () {
    if ($("#videoOne").attr("class") !="nav-element-minor-choosen") {
        $("#videoOne").attr("class", "nav-element-minor-choosen");
    }
    $("#videoTwo").attr("class", "nav-element-minor");
    $("#videoThree").attr("class", "nav-element-minor");

    var url = $("#firstVideoUrl").val();
    $("#videoPlayer").html("<iframe src='" + url + "' style='position:absolute;top:0;left:0;width:100%;height:100%;' frameborder='0' allowfullscreen></iframe>");
});
$("#videoTwo").click(function () {
    if ($("#videoTwo").attr("class") != "nav-element-minor-choosen") {
        $("#videoTwo").attr("class", "nav-element-minor-choosen");
    }
    $("#videoOne").attr("class", "nav-element-minor");
    $("#videoThree").attr("class", "nav-element-minor");

    var url = $("#secondVideoUrl").val();
    $("#videoPlayer").html("<iframe src='" + url + "' style='position:absolute;top:0;left:0;width:100%;height:100%;' frameborder='0' allowfullscreen></iframe>");
});
$("#videoThree").click(function () {
    if ($("#videoThree").attr("class") != "nav-element-minor-choosen") {
        $("#videoThree").attr("class", "nav-element-minor-choosen");
    }
    $("#videoOne").attr("class", "nav-element-minor");
    $("#videoTwo").attr("class", "nav-element-minor");

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
        balloonContent: 'Верфь деревянного судостроения "Вряг"<br />verf.varyag@yandex.ru<br />8 814 273 35 80',
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
        $("#sailboatsNav").css('margin-top', '72px')
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
        $(".leftNavMenu").css('padding-bottom', '56px')
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
$("#catalogOpen, #catalogClose").click(function () {
    if ($("#catalogOpen").css('display') != 'none') {
        $("#catalog-sub").attr('class', 'leftSubNavOpen');
        $("#catalog-sub").css('visibility', 'visible');
        $("#catalog-sub").css('opacity', '1');
        $("#aboutUsNav").css('margin-top', '139px')
    }
    else {
        $("#catalog-sub").attr('class', 'leftSubNavClose');
        $("#catalog-sub").css('visibility', 'hidden');
        $("#catalog-sub").css('opacity', '0');
        $("#aboutUsNav").css('margin-top', '0px')
    }
    $("#catalogOpen").toggle()
    $("#catalogClose").toggle()
});
$("#aboutUsOpen, #aboutUsClose").click(function () {
    if ($("#aboutUsOpen").css('display') != 'none') {
        $("#aboutUs-sub").attr('class', 'leftSubNavOpen');
        $("#aboutUs-sub").css('visibility', 'visible');
        $("#aboutUs-sub").css('opacity', '1');
        $(".leftNavMenu").css('padding-bottom', '69px')
    }
    else {
        $("#aboutUs-sub").attr('class', 'leftSubNavClose');
        $("#aboutUs-sub").css('visibility', 'hidden');
        $("#aboutUs-sub").css('opacity', '0');
        $(".leftNavMenu").css('padding-bottom', '10px')
    }
    $("#aboutUsOpen").toggle()
    $("#aboutUsClose").toggle()
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
function lengthSort(category, searchText) {
    let lengthSort;
    if ($('#sortOptions').val() == 'По возрастанию длинны') {
        lengthSort = 'Up';
    }
    else {
        lengthSort = 'Down';
    }
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

    $('.plitcaStyleCatalog').load("../Catalog/CatalogSort?category=" + category + "&plitca=true" + "&lengthSort=" + lengthSort + "&searchText=" + searchText, function () {
        if ($('#sortScreen').css('display') == 'block') {
            $('#sortScreen').css('display', 'none');
            $('.sortOptions').css('color', '#183f61');
            $('#sortScreen2').css('display', 'none');
        }
    });
    $('.lineStyleCatalog').load("../Catalog/CatalogSort?category=" + category + "&plitca=false" + "&lengthSort=" + lengthSort + "&searchText=" + searchText, function () {
        if ($('#sortScreen').css('display') == 'block') {
            $('#sortScreen').css('display', 'none');
            $('.sortOptions').css('color', '#183f61');
            $('#sortScreen2').css('display', 'none');
        }
    });
}

////////////////////////Показываем и прячем левое меню////////////////////////
function navigationButton() {
    if ($(".leftMenu").css("left") == '-37px') {
        $(".leftMenu").css("left", "-341px");
        $(".leftMenu").css("overflow", "unset");
        $("body").css("overflow", "unset");
        $('#blackScreen').css('display', 'none');
    }
    else {
        $('.leftMenu').css('left', '-37px');
        if ($(window).width() < 1280) {
            $('body').css('overflow', 'hidden');
        }
        if ($(window).width() < 1350) {
            $('.leftMenu').css('overflow', 'scroll');
        }
        $('#blackScreen').css('display', 'block');
    }
}

////////////////////////Показываем сколько найдено проектов в поиске////////////////////////
$("#projectSearch").on("input", function () {
    var x = $("#projectSearch").css("top")
    let searchLine = $("#projectSearch").val();
    let categorys2 = new Map()
    categorys2.set('Лодки', '../../../katalog/lodki');
    categorys2.set('Народные лодки', '../../../katalog/lodki/narodnye-lodki');
    categorys2.set('Прогулочные парусные лодки', '../../../katalog/lodki/progulochnye-parusnye-lodki');
    categorys2.set('Прогулочные гребные лодки', '../../../katalog/lodki/progulochnye-grebnye-lodki');
    categorys2.set('Катера', '../../../katalog/katera');
    categorys2.set('Рабочие и рыболовные катера', '../../../katalog/katera/rabochie-i-rybolovnye-katera');
    categorys2.set('Пассажирские катера', '../../../katalog/katera/passazhirskie-katera');
    categorys2.set('Каютные катера', '../../../katalog/katera/kayutnye-katera');
    categorys2.set('Мотосейлеры', '../../../katalog/katera/motoseylery');
    categorys2.set('Парусники', '../../../katalog/parusniki');
    categorys2.set('Исторические парусники', '../../../katalog/parusniki/istoricheskie-parusniki');
    categorys2.set('Учебные парусники', '../../../katalog/parusniki/uchebnye-parusniki');
    categorys2.set('Швертботы', '../../../katalog/parusniki/shvertboty');
    categorys2.set('Парусные яхты', '../../../katalog/parusniki/parusnye-yahty');
    categorys2.set('Шлюпки', '../../../katalog/shlyupki');
    categorys2.set('Шлюпки ЯЛ2, ЯЛ4, ЯЛ6', '../../../katalog/shlyupki/shlyupki-yal2yal4yal6');
    categorys2.set('Ботики', '../../../katalog/shlyupki/botiki');
    categorys2.set('Гребные катера и вельботы', '../../../katalog/shlyupki/grebnye-katera-i-velboty');
    categorys2.set('Учебные пособия', '../../../katalog/shlyupki/uchebnye-posobiya');
    categorys2.set('Ладьи', '../../../katalog/ladi');
    categorys2.set('Парусно-моторные ладьи', '../../../katalog/ladi/parusno-motornye-ladi');
    categorys2.set('Парусно-гребные ладьи', '../../../katalog/ladi/parusno-grebnye-ladi');
    categorys2.set('Струги и галеры', '../../../katalog/ladi/strugi-i-galery');
    categorys2.set('Разное', '.../../../katalog/raznoe');
    categorys2.set('Модели и макеты', '../../../katalog/raznoe/modeli-i-makety');
    categorys2.set('Прочая продукция', '../../../katalog/raznoe/prochaya-produkciya');

    let categorys = ['Лодки', 'Народные лодки', 'Прогулочные парусные лодки', 'Прогулочные гребные лодки', 'Катера',
        'Рабочие и рыболовные катера', 'Пассажирские катера', 'Каютные катера', 'Мотосейлеры', 'Парусники', 'Исторические парусники',
        'Учебные парусники', 'Швертботы', 'Парусные яхты', 'Шлюпки', 'Шлюпки ЯЛ2, ЯЛ4, ЯЛ6', 'Ботики',
        'Гребные катера и вельботы', 'Учебные пособия', 'Ладьи', 'Парусно-моторные ладьи',
        'Парусно-гребные ладьи', 'Струги и галеры', 'Разное', 'Модели и макеты', 'Прочая продукция'];
    let findedCategorys = new Array();


    if ($("#projectSearch").val() == '') {
        $(".underSearch").css("top", "0")
        $(".underSearch").css("display", "none")
        $("#suggestions").html('');

        if ($(window).width() < 501 && $("#projectSearch").val() == '') {
            $(".search").css('width', 'auto');
            $(".forSearchText").css('display', 'none');
            $(".forSearchText").css('width', '0px');
            $(".searchButton").css('border-bottom-left-radius', '5px');
            $(".searchButton").css('border-top-left-radius', '5px');
            $(".fullTopMenu").css('display', 'flex');
            $(".middleTopmenu").css('display', 'flex');
        }
        if ($(".closeIcon").css("display") == "none") {
            $(".closeIcon").css("display", "block")
            $(".searchIcon").css("display", "none")
        }
    }
    else {
        if (x == "auto" || x == "0") {
            $(".underSearch").css("display", "flex")
            $(".underSearch").css("top", "36px")
            var width = $(".forSearchText").width() + $(".searchButton").width();
            $(".underSearch").css("width", width)
        }

        if ($(".searchIcon").css("display") == "none") {
            $(".searchIcon").css("display", "block")
            $(".closeIcon").css("display", "none")
        }

        $("#searchedProjectsCount").load("../../Catalog/ProjectsSearchCount?value=" + searchLine);

        if (searchLine.length >= 1) {
            for (var i = 0; i < categorys.length; i++) {
                if (categorys[i].toLowerCase().includes(searchLine.toLowerCase())) {
                    findedCategorys.push(categorys[i]);
                }
            }

            if ($("#suggestions").html != "") {
                $("#suggestions").html('');
                for (var i = 0; i < findedCategorys.length; i++) {
                    $("#suggestions").append("<a href=\"" + categorys2.get(findedCategorys[i]) + "\" class=\"searchSugestions\">Перейти в раздел \"" + findedCategorys[i] + "\"</a>")
                }
            }
            else {
                for (var i = 0; i < findedCategorys.length; i++) {
                    $("#suggestions").append("<a class=\"searchSugestions\">Перейти в раздел \"" + findedCategorys[i] + "\"</a>")
                }
            }
        }
    }
})

$("#closeUnderSearch").click(function () {
    $(".underSearch").css("top", "0")
    $(".underSearch").css("display", "none")
})
$(".closeIcon").click(function () {
    $("#projectSearch").val("");
    $("#closeUnderSearch").click();
    
    $(".forSearchText").css('width', '0px');

    $(".forSearchText").on("transitionend webkitTransitionEnd oTransitionEnd", function () {
        if ($(".forSearchText").css('width') == "6px") {
            $(".forSearchText").css('opacity', '0')
        }
    })

    $(".searchButton").css('border-bottom-left-radius', '5px');
    $(".searchButton").css('border-top-left-radius', '5px');
    $(".searchIcon").toggle();
    $(".closeIcon").toggle();
    if ($(window).width() < 501) {
        $(".search").css('width', 'auto');
        //$(".fullTopMenu").css('display', 'flex');
        $(".middleTopmenu").css('display', 'flex');
    }
})
///////////////////////////////////Осуществляем поиск///////////////////////////////////////
$(".searchIcon").click(function () {
    if ($("#projectSearch").val() == '') {
        $(".forSearchText").css('opacity', '1');
        $(".forSearchText").css('width', '200px');
        $(".searchButton").css('border-bottom-left-radius', '0px');
        $(".searchButton").css('border-top-left-radius', '0px');
        $(".searchIcon").toggle();
        $(".closeIcon").toggle();
        if ($(window).width() < 361) {
            $(".forSearchText").css('width', '70%');
            $(".search").css('width', '100%');
            //$(".fullTopMenu").css('display', 'none');
            $(".middleTopmenu").css('display', 'none');
        }
        else if ($(window).width() < 501) {
            $(".forSearchText").css('width', '75%');
            $(".search").css('width', '100%');
            //$(".fullTopMenu").css('display', 'none');
            $(".middleTopmenu").css('display', 'none');}
    }
    else {
        window.location.href = '../../../katalog/poisk?searchText=' + $("#projectSearch").val();
    }
});

$("#projectSearch").keypress(function (e) {
    if (e.key == "Enter") {
        $(".searchButton").click();
    }
});

function fromTheTopMenu() {
    if ($('.fromTheTopMenu').css('display') != 'flex') {
        $('.fromTheTopMenu').css('display', 'flex');
    }
    else {
        $('.fromTheTopMenu').css('display', 'none');
    }
    $('#arrowDown,#arrowUp').toggle();
}
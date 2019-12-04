// Please see documentation at https://docs.microsoft.com/ore/client-side/bundling-and-mini
// for details on configuring this project to bundle and minify static web assets.

$(document).ready(function () {

    //////////////////////////высота контролов слайдера заказчиков = высоте столбца заказчиков///////////////////////
    $("#left.control, #right.control").height($(".allCustomers").height());

    /////////////////////////////настраиваем тайниМЦЕ/////////////////////////
    tinymce.init({
        selector: 'textarea#mce',
        skin: 'oxide',
        width: 1200,
        height: 200,
        language: 'ru',
        plugins: 'code',
        toolbar: 'code'
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

    //////////////////////////виджет контакта//////////////////////////
    VK.Widgets.Group("vk_groups", { mode: 3, width: "200", height:"200" }, 137987101);
});

/////////////////////применяем переданные настройки редактора новостных превью к превью////////////////
FotoAttrChange('short');
FotoAttrChange('middle');
FotoAttrChange('wide');

///////////////////////////////Редактирования текста и фото новостного превью////////////////////////////////
function FotoTextChange(fotoType) {
    newsSaveButtonDisable();
    switch (fotoType) {
        case "short":
            $("#shortFotoNewsText").text($("#shortFotoText").val());
            break;
        case "middle":
            $("#middleFotoNewsText").text($("#middleFotoText").val());
            break;
        case "wide":
            $("#wideFotoNewsText").text($("#wideFotoText").val());
            break;
        default:
            break;
    }
}

function FotoAttrChange(fotoType) {
    newsSaveButtonDisable();
    var xCoordinate;
    var yCoordinate;
    var scale;
    switch (fotoType) {
        case "short":
            xCoordinate = $("#shortFotoX").val() + "%";
            yCoordinate = $("#shortFotoY").val() + "%";
            scale = $("#shortFotoScale").val() + "% auto";
            $("#creator.partNewsElementViewShort").css({
                "background-position-x": xCoordinate,
                "background-position-y": yCoordinate,
                "background-repeat": "no-repeat",
                "background-size": scale
            });
            break;
        case "middle":
            xCoordinate = $("#middleFotoX").val() + "%";
            yCoordinate = $("#middleFotoY").val() + "%";
            scale = $("#middleFotoScale").val() + "% auto";
            $("#creator.partNewsElementViewMiddle").css({
                "background-position-x": xCoordinate,
                "background-position-y": yCoordinate,
                "background-repeat": "no-repeat",
                "background-size": scale
            });
            break;
        case "wide":
            xCoordinate = $("#wideFotoX").val() + "%";
            yCoordinate = $("#wideFotoY").val() + "%";
            scale = $("#wideFotoScale").val() + "% auto";
            $("#creator.partNewsElementViewWide").css({
                "background-position-x": xCoordinate,
                "background-position-y": yCoordinate,
                "background-repeat": "no-repeat",
                "background-size": scale
            });
            break;
        default:
            break;
    }
}

/////////////////////////передаем текст новостных превью при загрузках новых фото/////////////////////////////
$("#newsFotoUpload").click(function () {
    $("#shortFotoText").val($("#shortFotoNewsText").text().trim());
    $("#middleFotoText").val($("#middleFotoNewsText").text().trim());
    $("#wideFotoText").val($("#wideFotoNewsText").text().trim());
    $("#fotoEditorForm").submit();
})

///////////////сохраняем параметры редактора фоток превью новостей в основную форму,//////////////
////////////////разблокируем кнопку сохранения новости////////////////////////////////////////////
$("#saveEditorParams").click(function () {
    $("#ShortImgScale").val($("#shortFotoScale").val());
    $("#ShortImgX").val($("#shortFotoX").val());
    $("#ShortImgY").val($("#shortFotoY").val());
    $("#ShortStory").val($("#shortFotoText").val());
    $("#MiddleImgScale").val($("#middleFotoScale").val());
    $("#MiddleImgX").val($("#middleFotoX").val());
    $("#MiddleImgY").val($("#middleFotoY").val());
    $("#MiddleStory").val($("#middleFotoText").val());
    $("#WideImgScale").val($("#wideFotoScale").val());
    $("#WideImgX").val($("#wideFotoX").val());
    $("#WideImgY").val($("#wideFotoY").val());
    $("#WideStory").val($("#wideFotoText").val());
    $("#newsSaveButton").removeAttr("disabled");
})

////////////////////////////деактивируем кнопку сохранения новости//////////////////////////////
function newsSaveButtonDisable() {
        $("#newsSaveButton").attr("disabled", "disabled");
}

////////////////////////показываем и прячем полный вид новости в административной части///////////////////////
$("#showFullNewsPreview").click(function () {
    var visibility = $("#fullNewsPreview").css("display");
    if (visibility == "none") {
        $("#fullNewsPreview").show();
    }
    else {
        $("#fullNewsPreview").hide();
    }
});

////////////////////////////мненяем видимый вариант текста новостных превью////////////////////////////
$(window).on('load resize', function () {
    if (window.innerWidth >= 1190) {
        $("#shortStory").css("display", "initial");
        $("#middleStory").css("display", "none");
        $("#wideStory").css("display", "none");
    }
    else if (window.innerWidth >= 794 && window.innerWidth <= 1189) {
        $("#shortStory").css("display", "none");
        $("#middleStory").css("display", "none");
        $("#wideStory").css("display", "initial");
    }
    else {
        $("#shortStory").css("display", "none");
        $("#middleStory").css("display", "initial");
        $("#wideStory").css("display", "none");
    }
});

//////////////////////////обслуживание панели навигации внутри каталога//////////////////////////
navElMinorChoose();

$(window).scroll(function () {
    if ($(this).scrollTop() > 714 && window.innerWidth > 790) {
        $('.sub-nav-elements').css("position", "fixed");
    }
    else/* if ($(this).scrollTop() < 714)*/ {
        $('.sub-nav-elements').css("position", "relative");
    }
});

$("#lodki").mouseenter(function () {
    hideAll();
    $("#lodki").attr("class", "nav-element-choosen");
    $("#lodki-Sub").show();
});

$("#shlupki").mouseenter(function () {
    hideAll();
    $("#shlupki").attr("class", "nav-element-choosen");
    $("#shlupki-Sub").show();
});

$("#katera").mouseenter(function () {
    hideAll();
    $("#katera").attr("class", "nav-element-choosen");
    $("#katera-Sub").show();
});

$("#ladiy").mouseenter(function () {
    hideAll();
    $("#ladiy").attr("class", "nav-element-choosen");
    $("#ladiy-Sub").show();
});

$("#sailboats").mouseenter(function () {
    hideAll();
    $("#sailboats").attr("class", "nav-element-choosen");
    $("#sailboats-Sub").show();
});

$("#models").mouseenter(function () {
    hideAll();
    $("#models").attr("class", "nav-element-choosen");
    $("#models-Sub").show();
});

$(".nav-element-minor").mouseenter(function () {
    deselectNavElemMinor();
    $(this).attr("class", "nav-element-minor-choosen");
});

$(".nav-element-minor").mouseleave(function () {
    $(".nav-element-minor-choosen").attr("class", "nav-element-minor");
    navElMinorChoose();
});

$(".nav-element, .sub-nav, .catalog").mouseleave(function (event) {
    var page = $("#currentPage").val();
    switch (page) {
        case "boats":
        case "boatsrow":
        case "boatssail":
        case "boatstraditional":
            if ((event.currentTarget.id != "sailboats" && event.target.id != "sailboats-Sub")
                && (event.currentTarget.id != "shlupki" && event.target.id != "shlupki-Sub")
                && (event.currentTarget.id != "katera" && event.target.id != "katera-Sub")
                && (event.currentTarget.id != "ladiy" && event.target.id != "ladiy-Sub")
                && (event.currentTarget.id != "models" && event.target.id != "models-Sub")) {
                hideAll();
                $("#lodki").attr("class", "nav-element-choosen");
                $("#lodki-Sub").show();
                break;
            }
        case "shlupki":
        case "boatyal":
        case "botik":
        case "katerrow":
            if ((event.currentTarget.id != "lodki" && event.target.id != "lodki-Sub")
                && (event.currentTarget.id != "sailboats" && event.target.id != "sailboats-Sub")
                && (event.currentTarget.id != "katera" && event.target.id != "katera-Sub")
                && (event.currentTarget.id != "ladiy" && event.target.id != "ladiy-Sub")
                && (event.currentTarget.id != "models" && event.target.id != "models-Sub")) {
                hideAll();
                $("#shlupki").attr("class", "nav-element-choosen");
                $("#shlupki-Sub").show();
                break;
            }
        case "katera":
        case "motosailer":
        case "katercabin":
        case "katerfish":
        case "katerpass":
        case "katerproject":
            if ((event.currentTarget.id != "lodki" && event.target.id != "lodki-Sub")
                && (event.currentTarget.id != "sailboats" && event.target.id != "sailboats-Sub")
                && (event.currentTarget.id != "shlupki" && event.target.id != "shlupki-Sub")
                && (event.currentTarget.id != "ladiy" && event.target.id != "ladiy-Sub")
                && (event.currentTarget.id != "models" && event.target.id != "models-Sub")) {
                hideAll();
                $("#katera").attr("class", "nav-element-choosen");
                $("#katera-Sub").show();
                break;
            }
        case "ladiy":
        case "ladyarow":
        case "ladyasail":
        case "ladyaproject":
            if ((event.currentTarget.id != "lodki" && event.target.id != "lodki-Sub")
                && (event.currentTarget.id != "sailboats" && event.target.id != "sailboats-Sub")
                && (event.currentTarget.id != "shlupki" && event.target.id != "shlupki-Sub")
                && (event.currentTarget.id != "katera" && event.target.id != "katera-Sub")
                && (event.currentTarget.id != "models" && event.target.id != "models-Sub")) {
                hideAll();
                $("#ladiy").attr("class", "nav-element-choosen");
                $("#ladiy-Sub").show();
            }
            break;
        case "sailboats":
        case "yacht":
        case "sailboatstudy":
        case "shvertbot":
        case "sailboathistorical":
        case "sailboatproject":
            if ((event.currentTarget.id != "lodki" && event.target.id != "lodki-Sub")
                && (event.currentTarget.id != "shlupki" && event.target.id != "shlupki-Sub")
                && (event.currentTarget.id != "katera" && event.target.id != "katera-Sub")
                && (event.currentTarget.id != "ladiy" && event.target.id != "ladiy-Sub")
                && (event.currentTarget.id != "models" && event.target.id != "models-Sub")) {
                if ($(window).width() > 383) {
                    hideAll();
                    $("#sailboats").attr("class", "nav-element-choosen");
                    $("#sailboats-Sub").show();
                }
                break;
            }
            else
                break;
        case "models":
        case "maketstudy":
        case "maketcinema":
        case "maketmuseum":
            if ((event.currentTarget.id != "lodki" && event.target.id != "lodki-Sub")
                && (event.currentTarget.id != "sailboats" && event.target.id != "sailboats-Sub")
                && (event.currentTarget.id != "shlupki" && event.target.id != "shlupki-Sub")
                && (event.currentTarget.id != "katera" && event.target.id != "katera-Sub")
                && (event.currentTarget.id != "ladiy" && event.target.id != "ladiy-Sub")) {
                hideAll();
                $("#models").attr("class", "nav-element-choosen");
                $("#models-Sub").show();
            }
            break;
        default:
            break;
    }
});


function hideAll() {
    $("#sailboats").attr("class", "nav-element");
    $("#lodki").attr("class", "nav-element");
    $("#shlupki").attr("class", "nav-element");
    $("#katera").attr("class", "nav-element");
    $("#ladiy").attr("class", "nav-element");
    $("#models").attr("class", "nav-element");
    $("#models-Sub").hide()
    $("#sailboats-Sub").hide();
    $("#lodki-Sub").hide();
    $("#shlupki-Sub").hide();
    $("#katera-Sub").hide();
    $("#ladiy-Sub").hide();
};

function deselectNavElemMinor() {
    
    var page = $("#currentPage").val();
    switch (page) {
        case "boatsrow":
        case "boatssail":
        case "boatstraditional":
            $('#boatsrow').attr("class", "nav-element-minor");
            $('#boatssail').attr("class", "nav-element-minor");
            $('#boatstraditional').attr("class", "nav-element-minor");
            break;
        case "boatyal":
        case "botik":
        case "katerrow":
            $('#katerrow').attr("class", "nav-element-minor");
            $('#botik').attr("class", "nav-element-minor");
            $('#boatyal').attr("class", "nav-element-minor");
            break;
        case "motosailer":
        case "katercabin": 
        case "katerfish":
        case "katerpass":
        case "katerproject":
            $('#katerproject').attr("class", "nav-element-minor");
            $('#katerpass').attr("class", "nav-element-minor");
            $('#katerfish').attr("class", "nav-element-minor");
            $('#katercabin').attr("class", "nav-element-minor");
            $('#motosailer').attr("class", "nav-element-minor");
            break;
        case "ladyarow":
        case "ladyasail":
        case "ladyaproject":
            $('#ladyaproject').attr("class", "nav-element-minor");
            $('#ladyasail').attr("class", "nav-element-minor");
            $('#ladyarow').attr("class", "nav-element-minor");
            break;
        case "yacht":
        case "shvertbot":
        case "sailboatstudy":
        case "sailboathistorical":
        case "sailboatproject":
            $('#sailboatproject').attr("class", "nav-element-minor");
            $('#sailboathistorical').attr("class", "nav-element-minor");
            $('#sailboatstudy').attr("class", "nav-element-minor");
            $('#shvertbot').attr("class", "nav-element-minor");
            $('#yacht').attr("class", "nav-element-minor");
            break;
        case "maketstudy":
        case "maketcinema":
        case "maketmuseum":
            $('#maketmuseum').attr("class", "nav-element-minor");
            $('#maketcinema').attr("class", "nav-element-minor");
            $('#maketstudy').attr("class", "nav-element-minor");
            break;
        default:
    }
}

function navElMinorChoose() {
    var page = $("#currentPage").val();
    switch (page) {
        case "boatsrow":
            $('#boatsrow').attr("class", "nav-element-minor-choosen");
            break;
        case "boatssail":
            $('#boatssail').attr("class", "nav-element-minor-choosen");
            break;
        case "boatstraditional":
            $('#boatstraditional').attr("class", "nav-element-minor-choosen");
            break;
        case "boatyal":
            $('#boatyal').attr("class", "nav-element-minor-choosen");
            break;
        case "botik":
            $('#botik').attr("class", "nav-element-minor-choosen");
            break;
        case "katerrow":
            $('#katerrow').attr("class", "nav-element-minor-choosen");
            break;
        case "motosailer":
            $('#motosailer').attr("class", "nav-element-minor-choosen"); 
            break;
        case "katercabin":
            $('#katercabin').attr("class", "nav-element-minor-choosen"); 
            break;
        case "katerfish":
            $('#katerfish').attr("class", "nav-element-minor-choosen");
            break;
        case "katerpass":
            $('#katerpass').attr("class", "nav-element-minor-choosen");
            break; 
        case "katerproject":
            $('#katerproject').attr("class", "nav-element-minor-choosen");
            break;
        case "ladyarow":
            $('#ladyarow').attr("class", "nav-element-minor-choosen");
            break; 
        case "ladyasail":
            $('#ladyasail').attr("class", "nav-element-minor-choosen");
            break; 
        case "ladyaproject":
            $('#ladyaproject').attr("class", "nav-element-minor-choosen");
            break;
        case "yacht":
            $('#yacht').attr("class", "nav-element-minor-choosen"); 
            break; 
        case "shvertbot":
            $('#shvertbot').attr("class", "nav-element-minor-choosen");
            break; 
        case "sailboatstudy":
            $('#sailboatstudy').attr("class", "nav-element-minor-choosen");
            break; 
        case "sailboathistorical":
            $('#sailboathistorical').attr("class", "nav-element-minor-choosen");
            break; 
        case "sailboatproject":
            $('#sailboatproject').attr("class", "nav-element-minor-choosen");
            break; 
        case "maketstudy":
            $('#maketstudy').attr("class", "nav-element-minor-choosen");
            break; 
        case "maketcinema":
            $('#maketcinema').attr("class", "nav-element-minor-choosen");
            break;
        case "maketmuseum":
            $('#maketmuseum').attr("class", "nav-element-minor-choosen");
            break;
        default:
    }
};
//////////////////Для пролистывания списка заказчиков//////////////////////
var slideNumber = 0;

$("#right.control").click(function () {

    var custWidth = $(".allCustomers").width();
    var step = custWidth / 3;
    if (slideNumber == 2) {
        slideNumber = 0;
        var scrollNumber = step * slideNumber;
    }
    else {
        var scrollNumber = step * (slideNumber + 1);
        slideNumber += 1;
    }

    $(".allCustomers").css('transform', "translatex(-" + scrollNumber + "px)");

});

$("#left.control").click(function () {

    if (slideNumber == 0) {
        slideNumber = 3;
    }

    var custWidth = $(".allCustomers").width();
    var step = custWidth / 3;
    var scrollNumber = step * (slideNumber - 1);

    $(".allCustomers").css('transform', "translatex(-" + scrollNumber + "px)");

    slideNumber -= 1;
});


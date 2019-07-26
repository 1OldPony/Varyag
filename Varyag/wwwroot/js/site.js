// Please see documentation at https://docs.microsoft.com/ore/client-side/bundling-and-mini
// for details on configuring this project to bundle and minify static web assets.

$(document).ready(function () {

    $(window).scroll(function () {
        if ($(this).scrollTop() > 714 && window.innerWidth > 790) {
            $('.sub-nav-elements').css("position", "fixed");
        }
        else/* if ($(this).scrollTop() < 714)*/ {
            $('.sub-nav-elements').css("position", "relative");
        }
    });

    $("#sailboats").mouseenter(function () {
        hideAll();
        $("#sailboats").attr("class", "nav-element-choosen");
        $("#sailboats-Sub").show();
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

    $("#models").mouseenter(function () {
        hideAll();
        $("#models").attr("class", "nav-element-choosen");
        $("#models-Sub").show();
    });

    $(".nav-element-minor").mouseenter(function () {
        $(this).attr("class", "nav-element-minor-choosen");
    });

    $(".nav-element-minor").mouseleave(function () {
        $(".nav-element-minor-choosen").attr("class", "nav-element-minor");
    });

    $(".nav-element, .sub-nav, .catalog").mouseleave(function (event) {
        var page = $("#currentPage").val();
        switch (page)
        {
            case "sailboats":
                if ((event.currentTarget.id != "lodki" && event.target.id != "lodki-Sub")
                    && (event.currentTarget.id != "shlupki" && event.target.id != "shlupki-Sub")
                    && (event.currentTarget.id != "katera" && event.target.id != "katera-Sub")
                    && (event.currentTarget.id != "ladiy" && event.target.id != "ladiy-Sub")
                    && (event.currentTarget.id != "models" && event.target.id != "models-Sub")) {
                    //var catalog = $('.catalog').height();
                    //var header = $('.header').height();
                    //var tophat = $('.top-hat').height();
                    //var height = tophat + header + catalog;
                    if ($(window).width() > 383) {
                        hideAll();
                        $("#sailboats").attr("class", "nav-element-choosen");
                        $("#sailboats-Sub").show();
                    }
                    break;
                }
            case "lodki":
                if ((event.currentTarget.id != "sailboats" && event.target.id != "sailboats-Sub")
                    && (event.currentTarget.id != "shlupki" && event.target.id != "shlupki-Sub")
                    && (event.currentTarget.id != "katera" && event.target.id != "katera-Sub")
                    && (event.currentTarget.id != "ladiy" && event.target.id != "ladiy-Sub")
                    && (event.currentTarget.id != "models" && event.target.id != "models-Sub"))
                {
                    hideAll();
                    $("#lodki").attr("class", "nav-element-choosen");
                    $("#lodki-Sub").show();
                    break;
                }
            case "shlupki":
                if ((event.currentTarget.id != "lodki" && event.target.id != "lodki-Sub")
                    && (event.currentTarget.id != "sailboats" && event.target.id != "sailboats-Sub")
                    && (event.currentTarget.id != "katera" && event.target.id != "katera-Sub")
                    && (event.currentTarget.id != "ladiy" && event.target.id != "ladiy-Sub")
                    && (event.currentTarget.id != "models" && event.target.id != "models-Sub"))
                {
                    hideAll();
                    $("#shlupki").attr("class", "nav-element-choosen");
                    $("#shlupki-Sub").show();
                    break;
                }
            case "katera":
                if ((event.currentTarget.id != "lodki" && event.target.id != "lodki-Sub")
                    && (event.currentTarget.id != "sailboats" && event.target.id != "sailboats-Sub")
                    && (event.currentTarget.id != "shlupki" && event.target.id != "shlupki-Sub")
                    && (event.currentTarget.id != "ladiy" && event.target.id != "ladiy-Sub")
                    && (event.currentTarget.id != "models" && event.target.id != "models-Sub"))
                {
                    hideAll();
                    $("#katera").attr("class", "nav-element-choosen");
                    $("#katera-Sub").show();
                    break;
                }
            case "ladiy":
                if ((event.currentTarget.id != "lodki" && event.target.id != "lodki-Sub")
                    && (event.currentTarget.id != "sailboats" && event.target.id != "sailboats-Sub")
                    && (event.currentTarget.id != "shlupki" && event.target.id != "shlupki-Sub")
                    && (event.currentTarget.id != "katera" && event.target.id != "katera-Sub")
                    && (event.currentTarget.id != "models" && event.target.id != "models-Sub"))
                {
                    hideAll();
                    $("#ladiy").attr("class", "nav-element-choosen");
                    $("#ladiy-Sub").show();
                }
                break;
            case "models":
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
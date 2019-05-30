// Please see documentation at https://docs.microsoft.com/ore/client-side/bundling-and-mini
// for details on configuring this project to bundle and minify static web assets.

$(document).ready(function () {
    
    $("#yachts").mouseenter(function showYachts () {
        hideAll();
        $("#yachts-Sub").show();
    });

    $("#lodki").mouseenter(function () {
        hideAll();
        $("#lodki-Sub").show();
    });

    $("#shlupki").mouseenter(function () {
        hideAll();
        $("#shlupki-Sub").show();
    });

    $("#katera").mouseenter(function () {
        hideAll();
        $("#katera-Sub").show();
    });

    $("#lodiy").mouseenter(function () {
        hideAll();
        $("#lodiy-Sub").show();
    });



    $(".nav-element, .sub-nav, .catalog").mouseleave(function (event) {
        var page = $("#currentPage").val();
        switch (page)
        {
            case "yachts":
                if ((event.currentTarget.id != "lodki" && event.target.id != "lodki-Sub")
                    && (event.currentTarget.id != "shlupki" && event.target.id != "shlupki-Sub")
                    && (event.currentTarget.id != "katera" && event.target.id != "katera-Sub")
                    && (event.currentTarget.id != "lodiy" && event.target.id != "lodiy-Sub"))
                {
                 hideAll();
                $("#yachts-Sub").show();
                }
                break;
            case "lodki":
                if ((event.currentTarget.id != "yachts" && event.target.id != "yachts-Sub")
                    && (event.currentTarget.id != "shlupki" && event.target.id != "shlupki-Sub")
                    && (event.currentTarget.id != "katera" && event.target.id != "katera-Sub")
                    && (event.currentTarget.id != "lodiy" && event.target.id != "lodiy-Sub"))
                {
                    hideAll();
                    $("#lodki-Sub").show();
                    break;
                }
            case "shlupki":
                if ((event.currentTarget.id != "lodki" && event.target.id != "lodki-Sub")
                    && (event.currentTarget.id != "yachts" && event.target.id != "yachts-Sub")
                    && (event.currentTarget.id != "katera" && event.target.id != "katera-Sub")
                    && (event.currentTarget.id != "lodiy" && event.target.id != "lodiy-Sub"))
                {
                    hideAll();
                    $("#shlupki-Sub").show();
                    break;
                }
            case "katera":
                if ((event.currentTarget.id != "lodki" && event.target.id != "lodki-Sub")
                    && (event.currentTarget.id != "yachts" && event.target.id != "yachts-Sub")
                    && (event.currentTarget.id != "shlupki" && event.target.id != "shlupki-Sub")
                    && (event.currentTarget.id != "lodiy" && event.target.id != "lodiy-Sub"))
                {
                    hideAll();
                    $("#katera-Sub").show();
                    break;
                }
            case "lodiy":
                if ((event.currentTarget.id != "lodki" && event.target.id != "lodki-Sub")
                    && (event.currentTarget.id != "yachts" && event.target.id != "yachts-Sub")
                    && (event.currentTarget.id != "shlupki" && event.target.id != "shlupki-Sub")
                    && (event.currentTarget.id != "katera" && event.target.id != "katera-Sub"))
                {
                    hideAll();
                    $("#lodiy-Sub").show();
                }
                break;
            default:
                break;
        }
    });
});

function hideAll() {
    $("#yachts-Sub").hide();
    $("#lodki-Sub").hide();
    $("#shlupki-Sub").hide();
    $("#katera-Sub").hide();
    $("#lodiy-Sub").hide();
};


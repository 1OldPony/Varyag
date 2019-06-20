// Please see documentation at https://docs.microsoft.com/ore/client-side/bundling-and-mini
// for details on configuring this project to bundle and minify static web assets.

$(document).ready(function () {
    
    $("#sailboats").mouseenter(function () {
        hideAll();
        $("#sailboats-Sub").show();
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

    $("#models").mouseenter(function () {
        hideAll();
        $("#models-Sub").show();
    });

    $(".nav-element, .sub-nav, .catalog").mouseleave(function (event) {
        var page = $("#currentPage").val();
        switch (page)
        {
            case "sailboats":
                if ((event.currentTarget.id != "lodki" && event.target.id != "lodki-Sub")
                    && (event.currentTarget.id != "shlupki" && event.target.id != "shlupki-Sub")
                    && (event.currentTarget.id != "katera" && event.target.id != "katera-Sub")
                    && (event.currentTarget.id != "lodiy" && event.target.id != "lodiy-Sub")
                    && (event.currentTarget.id != "models" && event.target.id != "models-Sub"))
                {
                    hideAll();
                    $("#sailboats-Sub").show();
                }
                break;
            case "lodki":
                if ((event.currentTarget.id != "sailboats" && event.target.id != "sailboats-Sub")
                    && (event.currentTarget.id != "shlupki" && event.target.id != "shlupki-Sub")
                    && (event.currentTarget.id != "katera" && event.target.id != "katera-Sub")
                    && (event.currentTarget.id != "lodiy" && event.target.id != "lodiy-Sub")
                    && (event.currentTarget.id != "models" && event.target.id != "models-Sub"))
                {
                    hideAll();
                    $("#lodki-Sub").show();
                    break;
                }
            case "shlupki":
                if ((event.currentTarget.id != "lodki" && event.target.id != "lodki-Sub")
                    && (event.currentTarget.id != "sailboats" && event.target.id != "sailboats-Sub")
                    && (event.currentTarget.id != "katera" && event.target.id != "katera-Sub")
                    && (event.currentTarget.id != "lodiy" && event.target.id != "lodiy-Sub")
                    && (event.currentTarget.id != "models" && event.target.id != "models-Sub"))
                {
                    hideAll();
                    $("#shlupki-Sub").show();
                    break;
                }
            case "katera":
                if ((event.currentTarget.id != "lodki" && event.target.id != "lodki-Sub")
                    && (event.currentTarget.id != "sailboats" && event.target.id != "sailboats-Sub")
                    && (event.currentTarget.id != "shlupki" && event.target.id != "shlupki-Sub")
                    && (event.currentTarget.id != "lodiy" && event.target.id != "lodiy-Sub")
                    && (event.currentTarget.id != "models" && event.target.id != "models-Sub"))
                {
                    hideAll();
                    $("#katera-Sub").show();
                    break;
                }
            case "lodiy":
                if ((event.currentTarget.id != "lodki" && event.target.id != "lodki-Sub")
                    && (event.currentTarget.id != "sailboats" && event.target.id != "sailboats-Sub")
                    && (event.currentTarget.id != "shlupki" && event.target.id != "shlupki-Sub")
                    && (event.currentTarget.id != "katera" && event.target.id != "katera-Sub")
                    && (event.currentTarget.id != "models" && event.target.id != "models-Sub"))
                {
                    hideAll();
                    $("#lodiy-Sub").show();
                }
                break;
            case "models":
                if ((event.currentTarget.id != "lodki" && event.target.id != "lodki-Sub")
                    && (event.currentTarget.id != "sailboats" && event.target.id != "sailboats-Sub")
                    && (event.currentTarget.id != "shlupki" && event.target.id != "shlupki-Sub")
                    && (event.currentTarget.id != "katera" && event.target.id != "katera-Sub")
                    && (event.currentTarget.id != "lodiy" && event.target.id != "lodiy-Sub")) {
                    hideAll();
                    $("#models-Sub").show();
                }
                break;
            default:
                break;
        }
    });
});

function hideAll() {
    $("#models-Sub").hide()
    $("#sailboats-Sub").hide();
    $("#lodki-Sub").hide();
    $("#shlupki-Sub").hide();
    $("#katera-Sub").hide();
    $("#lodiy-Sub").hide();
};


//function navigation() {
//    $.ajax({
//        url: @Url.Action("Sailboats", "Catalog")
//    });
//};
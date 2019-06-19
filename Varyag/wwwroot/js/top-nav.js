$(document).ready(function () {

    $("#ships-catalog").mouseenter(function () {
        var shCat = $("#cat").val();
        if (shCat == 0) {
            $(".menu-nav-top").append("<div id=category class=category><div class=menu-top-element><img src=/images/icons/гребная_лодка.jpg /><a asp-action=>Лодки</a></div><div class=menu-top-element><img src=/images/icons/гребная_лодка.jpg /><a asp-action=>Шлюпки</a></div><div class=menu-top-element><img src=/images/icons/гребная_лодка.jpg /><a asp-action=>Катера</a></div><div class=menu-top-element><img src=/images/icons/гребная_лодка.jpg /><a asp-action=>Ладьи</a></div><div class=menu-top-element><img src=/images/icons/гребная_лодка.jpg /><a asp-action=>Парусники</a></div><div class=menu-top-element><img src=/images/icons/гребная_лодка.jpg /><a asp-action=>Макеты</a></div></div>")
            $("#cat").val(1);
        }
        else {
            $("#category").show();
        }
    });

    $("#ships-catalog, #menu-nav-top").mouseleave(function (event) {

        if (event.relatedTarget.id != "category") {
            $("#category").hide();
        }
    });
});

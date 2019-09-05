var categorysState = 1
var aboutState = 1


$(document).ready(function () {

    $("#ships-catalog").mouseenter(function ShowCategorys() {
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
            $(".category").hide();
        }
    });
    
    $('#mobileShips-Catalog').click(function () {
        function show() {
            if (categorysState === 1) {
                categorysState = 2;
                aboutState = 1;
                HideAll();
                var shCat = $("#cat").val();
                if (categorysState === 2) {
                    if (shCat == 0) {
                        $(".menu-nav-top").append("<div id=category class=category><div class=menu-top-element><img src=/images/icons/гребная_лодка.jpg /><a asp-action=>Лодки</a></div><div class=menu-top-element><img src=/images/icons/гребная_лодка.jpg /><a asp-action=>Шлюпки</a></div><div class=menu-top-element><img src=/images/icons/гребная_лодка.jpg /><a asp-action=>Катера</a></div><div class=menu-top-element><img src=/images/icons/гребная_лодка.jpg /><a asp-action=>Ладьи</a></div><div class=menu-top-element><img src=/images/icons/гребная_лодка.jpg /><a asp-action=>Парусники</a></div><div class=menu-top-element><img src=/images/icons/гребная_лодка.jpg /><a asp-action=>Макеты</a></div></div>")
                        $("#cat").val(1);
                    }
                    else {
                        $("#category").show();
                    }
                }
            }
            else {
                $("#category").hide();
                categorysState = 1
            }
        }
        show();
    });


    $('#mobileAbout').click(function() {
        function show () {
            if (aboutState === 1) {
                aboutState = 2;
                categorysState = 1;
                HideAll();
                ShowAbout();
            }
            else {
                $("#shortAbout").hide();
                aboutState = 1
            }
        }
        show();
    });

    function ShowAbout() {
        var shAbUs = $("#abus").val();
        if (aboutState === 2) {
            if (shAbUs == 0) {
                $(".menu-nav-top").append("<div id=shortAbout class=category><div id=shortNav class=menu-top-element><img src=/images/icons/гребная_лодка.jpg /><a asp-action=>Наши новости</a></div><div id=shortNav class=menu-top-element><img src=/images/icons/гребная_лодка.jpg /><a asp-action=>Мы в сми</a></div><div id=shortNav class=menu-top-element><img src=/images/icons/гребная_лодка.jpg /><a asp-action=>О нас</a></div><div id=veryShortNav class=menu-top-element><img src=/images/icons/гребная_лодка.jpg /><a asp-action=>Гото-Предистинация</a></div></div>")
                $("#abus").val(1);
            }
            else {
                HideAll();
                $("#shortAbout").show();
            }
        };
    };

    function HideAll() {
        $("#category").hide();
        $("#shortAbout").hide();
    };

});


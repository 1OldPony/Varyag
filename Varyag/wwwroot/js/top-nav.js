var categorysState = 1
var aboutState = 1


$(document).ready(function () {

    $("#ships-catalog").mouseenter(function() {
        var existance = $("#cat").val(); 
        if (existance == 0) {
            $(".menu-nav-top").append("<div id=catalog class=category><div id=boatsTopNav class=menu-top-element ><a href=../../каталог/лодки><div class=topNavTopCategory>Лодки</div></a><a href=../../Каталог/Лодки/Прогулочные_гребные_лодки><div class=topNavCategory>Прогулочные гребные</div></a ><a href=../../Каталог/Лодки/Прогулочные_парусные_лодки><div class=topNavCategory>Прогулочные парусные</div></a ><a href=../../Каталог/Лодки/Народные_лодки><div class=topNavCategory>Народные</div></a ></div ><div id=bigboatsTopNav class=menu-top-element><a href=../../Каталог/Шлюпки><div class=topNavTopCategory>Шлюпки</div></a><a href=../../Каталог/Шлюпки/Шлюпки_ЯЛ2,ЯЛ4,ЯЛ6><div class=topNavCategory>Ял-6,Ял-4,Ял-2</div></a ><a href=../../Каталог/Шлюпки/Гребные_катера_и_вельботы><div class=topNavCategory>Гребные катера<br />и вельботы</div></a ><a href=../../Каталог/Шлюпки/Ботики><div class=topNavCategory>Ботики</div></a ></div ><div id=katersTopNav class=menu-top-element><a href=../../Каталог/Катера><div class=topNavTopCategory>Катера</div></a><a href=../../Каталог/Катера/Мотосейлеры><div class=topNavCategory>Мотосейлеры</div></a ><a href=../../Каталог/Катера/Каютные_катера><div class=topNavCategory>Каютные</div></a ><a href=../../Каталог/Катера/Рабочие_и_рыболовные_катера><div class=topNavCategory>Рабочие/Рыболовные</div></a ><a href=../../Каталог/Катера/Пассажирские_катера><div class=topNavCategory>Пассажирские</div></a ><a href=../../Каталог/Катера/Проекты_катеров><div class=topNavCategory>Проекты</div></a></div><div id=ladiyTopNav class=menu-top-element><a href=../../Каталог/Ладьи><div class=topNavTopCategory>Ладьи</div></a><a href=../../Каталог/Ладьи/Парусно-гребные_ладьи><div class=topNavCategory>Парусно-гребные</div></a ><a href=../../Каталог/Ладьи/Парусно-моторные_ладьи><div class=topNavCategory>Парусно-моторные</div></a ><a href=../../Каталог/Ладьи/Проекты_ладей><div class=topNavCategory>Проекты</div></a></div ><div id=sailboatsTopNav class=menu-top-element><a href=../../Каталог/Парусники><div class=topNavTopCategory>Парусники</div></a><a href=../../Каталог/Парусники/Яхты><div class=topNavCategory>Парусные_яхты</div></a><a href=../../Каталог/Парусники/Швертботы><div class=topNavCategory>Швертботы</div></a><a href=../../Каталог/Парусники/Учебные_парусники><div class=topNavCategory>Учебные</div></a><a href=../../Каталог/Парусники/Исторические_парусники><div class=topNavCategory>Исторические</div></a><a href=../../Каталог/Парусники/Проекты_парусников><div class=topNavCategory>Проекты</div></a ></div ><div id=maketsTopNav class=menu-top-element><a href=../../Каталог/Макеты><div class=topNavTopCategory>Макеты</div></a><a href=../../Каталог/Макеты/Учебные_макеты_судов_и_кораблей><div class=topNavCategory>Обучающие</div></a ><a href=../../Каталог/Макеты/Макеты_судов_и_кораблей_для_фильмов><div class=topNavCategory>Для кино</div></a ><a href=../../Каталог/Макеты/Макеты_судов_для_музеев><div class=topNavCategory>Для музеев</div></a ></div ></div >")
            $("#cat").val(1);
        }   else {
            $("#catalog.category").show();
        }
    }); 
    
    $("#cinema").mouseenter(function() {
        var existance = $("#cin").val();
        if (existance == 0) {
            $(".menu-nav-top").append("<div id=cinemaOrders class=category><a asp-action=><div id=cinemaOrders class=topNavCategory>Судно &quot;Якуцк&quot; для фильма &quot;Первые&quot;</div></a ><a asp-action=><div id=cinemaOrders class=topNavCategory>Модели для фильма &quot;Капитан Хорнблауер&quot;</div></a ><a asp-action=><div id=cinemaOrders class=topNavCategory>Шхуна &quot;Святой Петр&quot;</div></a ><a asp-action=><div id=cinemaOrders class=topNavCategory>Модель барка &quot;Крузенштерн&quot;</div></a ><a asp-action=><div id=cinemaOrders class=topNavCategory>Драккары для г.Выборг</div></a ><a asp-action=><div id=cinemaOrders class=topNavCategory>Корабль-музей &quot;Гото Предистинация&quot;</div></a ></div >")
            $("#cin").val(1);
        } else {
            $("#cinemaOrders.category").show();
        }
    });

    $("#aboutUs").mouseenter(function() {
        var existance = $("#abUs").val();
        if (existance == 0) {
            $(".menu-nav-top").append("<div id=aboutUsTopNav class=category><a asp-action=><div id=aboutUsTopNav class=topNavCategory>О нашей верфи</div></a ><a asp-action=><div id=aboutUsTopNav class=topNavCategory>О нашем производстве</div></a ><a asp-action=><div id=aboutUsTopNav class=topNavCategory>Наши новости</div></a ><a asp-action=><div id=aboutUsTopNav class=topNavCategory>СМИ о нас</div></a ><a id=aboutUsTopNav asp-action=><div class=topNavCategory>Корабль-Музей Гото Предистинация</div></a ><a id=aboutUsTopNav asp-action=><div class=topNavCategory>Музей</div></a ></div >")
            $("#abUs").val(1);
        } else {
            $("#aboutUsTopNav.category").show();
        }
    });
    
    $("#menu-nav-top, #cinema, #ships-catalog, #aboutUs").mouseleave(function (event) {
        if (event.relatedTarget.id != "catalog" && event.relatedTarget.id != "cinemaOrders" && event.relatedTarget.id != "aboutUsTopNav") {
            $(".category").hide();
        }
    });
});
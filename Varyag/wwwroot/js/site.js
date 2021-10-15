﻿// Please see documentation at https://docs.microsoft.com/ore/client-side/bundling-and-mini
// for details on configuring this project to bundle and minify static web assets.



$(document).ready(function () {

    /////////////////////////////настраиваем тайниМЦЕ/////////////////////////
    tinymce.init({
        selector: 'textarea#mce',
        skin: 'oxide',
        width: 1250,
        height: 400,
        language: 'ru',
        plugins: 'code',
        toolbar: 'code'
    });

    ////////////////////Показываем список прикрепленных проектов новости при ее редактировании/////////////////////
    if ($("[name='LinkedProjectNames']").val() != undefined) {
        newsLinkToProject(true);
    }    
});

/////////////////назначаем id и onclick новостным полным превью и кнопкам их показа/////////////////
$("#0[name=showHideButton]").on("click", function () {
    showHideFullNewsPreview("#0.MyContainer", "#0[name = showHideButton]");
})
$("#1[name=showHideButton]").on("click", function () {
    showHideFullNewsPreview("#1.MyContainer", "#1[name = showHideButton]");
})
$("#2[name=showHideButton]").on("click", function () {
    showHideFullNewsPreview("#2.MyContainer", "#2[name = showHideButton]");
})
$("#3[name=showHideButton]").on("click", function () {
    showHideFullNewsPreview("#3.MyContainer", "#3[name = showHideButton]");
})
$("#4[name=showHideButton]").on("click", function () {
    showHideFullNewsPreview("#4.MyContainer", "#4[name = showHideButton]");
})
$("#5[name=showHideButton]").on("click", function () {
    showHideFullNewsPreview("#5.MyContainer", "#5[name = showHideButton]");
})
$("#6[name=showHideButton]").on("click", function () {
    showHideFullNewsPreview("#6.MyContainer", "#6[name = showHideButton]");
})
$("#7[name=showHideButton]").on("click", function () {
    showHideFullNewsPreview("#7.MyContainer", "#7[name = showHideButton]");
})
$("#8[name=showHideButton]").on("click", function () {
    showHideFullNewsPreview("#8.MyContainer", "#8[name = showHideButton]");
})
$("#9[name=showHideButton]").on("click", function () {
    showHideFullNewsPreview("#9.MyContainer", "#9[name = showHideButton]");
})

/////////////////обрабатываем нажатие на кнопки развертывания-сокрытия полного превью новости///////////////////
function showHideFullNewsPreview(selectorPreview, selectorButton) {
    var visibility = $(selectorPreview).css("display");
    if (visibility == "none") {
        $(selectorPreview).show();
        $(selectorButton).val("Скрыть")
    }
    else {
        $(selectorPreview).hide();
        $(selectorButton).val("Развернутый вид")
    }
}

/////////////////////применяем переданные настройки редактора новостных превью к превью////////////////
FotoAttrChange('short');
FotoAttrChange('middle');
FotoAttrChange('wide');
annotationToTextarea();

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
            scale = $("#shortFotoScale").val() + "%";
            $("#creator.partNewsElementViewShort, #editor.partNewsElementViewShort").css({
                "background-position-x": xCoordinate,
                "background-position-y": yCoordinate,
                "background-size": scale
            });
            break;
        case "middle":
            xCoordinate = $("#middleFotoX").val() + "%";
            yCoordinate = $("#middleFotoY").val() + "%";
            scale = $("#middleFotoScale").val() + "%";
            $("#creator.partNewsElementViewMiddle, #editor.partNewsElementViewMiddle").css({
                "background-position-x": xCoordinate,
                "background-position-y": yCoordinate,
                "background-size": scale
            });
            break;
        case "wide":
            xCoordinate = $("#wideFotoX").val() + "%";
            yCoordinate = $("#wideFotoY").val() + "%";
            scale = $("#wideFotoScale").val() + "%";
            $("#creator.partNewsElementViewWide, #editor.partNewsElementViewWide").css({
                "background-position-x": xCoordinate,
                "background-position-y": yCoordinate,
                "background-size": scale
            });
            break;
        default:
            break;
    }
}

/////////////////////////передаем текст новостных превью при загрузках новых фото/////////////////////////////
$("#newsFotoUpload").click(function () {
    annotationToTextarea();
    keyWordSave();
    newsDateSave();
    $("#fotoEditorForm").submit();
})

function annotationToTextarea() {
    $("#shortFotoText").val($("#shortFotoNewsText").text().trim());
    $("#middleFotoText").val($("#middleFotoNewsText").text().trim());
    $("#wideFotoText").val($("#wideFotoNewsText").text().trim());
}

function keyWordSave() {
    $("#keyWordRefresh").val($("#keyWord").val());
}

function newsDateSave() {
    $("#newsDateRefresh").val($("#newsDate").val());
}

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

/////////////////////////деактивируем кнопку сохранения новости////////////////////////////
function newsSaveButtonDisable() {
        $("#newsSaveButton").attr("disabled", "disabled");
}

////////////////////////Обслуживаем механизм создания превью статей//////////////////////////
//let x = 2;
function refreshPreviewEditor() {
    //$('#sortScreen').css('display', 'block');
    //$('#sortScreen2').css('display', 'block');
    //$('.sortOptions').css('color', 'lightgrey');
    if ($('#creator.partNewsElementViewShort')) {

    }

    let editorData = $('.newsFotoEditor').html();

    let response = fetch('/articles/SaveTempFoto', {
        method: 'POST',
        body: new FormData(fotoEditorForm)
    });
    //document.getElementById('fotoEditorForm')
    //if (response.ok) {
    //if (x%2==0) {
        $('#creator.partNewsElementViewShort').style('class', 'partNewsElementViewShort2');
        $('#creator.partNewsElementViewMiddle').attr('class', 'partNewsElementViewMiddle2');
        $('#creator.partNewsElementViewWide').attr('class', 'partNewsElementViewWide2');
    //}
    //else {
    //    $('#creator.partNewsElementViewShort2').attr('class', 'partNewsElementViewShort');
    //    $('#creator.partNewsElementViewMiddle2').attr('class', 'partNewsElementViewMiddle');
    //    $('#creator.partNewsElementViewWide2').attr('class', 'partNewsElementViewWide');
    //}
    //x++;

    //$('#creator.partNewsElementViewShort').css('background-image', 'url(/images/temp/wide.jpg)');
    //$('#creator.partNewsElementViewMiddle').css('background-image', 'url(/images/temp/short.jpg)');
    //$('#creator.partNewsElementViewWide').css('background-image', 'url(/images/temp/middle.jpg) no-repeat');

    //$('#creator.partNewsElementViewShort').css('background-image', 'url(/images/temp/short.jpg)');
    //$('#creator.partNewsElementViewMiddle').css('background-image', 'url(/images/temp/middle.jpg)');
    //$('#creator.partNewsElementViewWide').css('background-image', 'url(/images/temp/wide.jpg) no-repeat');
    //}
    //else {
    //    alert("Ошибка HTTP: " + response.status);
    //}

    //$('#previewEditorForm').load("../Articles/SaveTempFoto?fotoType=" + category + "&plitca=true" + "&lengthSort=" + lengthSort, function () {
    //    if ($('#sortScreen').css('display') == 'block') {
    //        $('#sortScreen').css('display', 'none');
    //        $('.sortOptions').css('color', '#183f61');
    //        $('#sortScreen2').css('display', 'none');
    //    }
    //});
}
function myfunction2() {
    $('#creator.partNewsElementViewShort').attr('class', 'punishmentShort');
    $('#creator.partNewsElementViewMiddle').attr('class', 'punishmentMiddle');
    $('#creator.partNewsElementViewWide').attr('class', 'punishmentWide');
}
function myfunction() {
    $('#creator.punishmentShort').attr('class', 'partNewsElementViewShort');
    $('#creator.punishmentMiddle').attr('class', 'partNewsElementViewMiddle');
    $('#creator.punishmentWide').attr('class', 'partNewsElementViewWide');
}
////////////////////////////Создаем список связанных проектов//////////////////////////////
function newsLinkToProject(firstTimeEdit) {
    let projects = $("[name='LinkedProjectNames']").val();
    if (!projects.includes($("[name='LinkedProjects'] option:selected").text())) {
        if (!firstTimeEdit) {
            projects += '/' + $("[name='LinkedProjects'] option:selected").text();
        }
        $("[name='LinkedProjectNames']").val(projects);
        let projectSplit = projects.split('/');

        $("#LinkedProjectsList").empty();
        for (var i = 1; i < projectSplit.length; i++) {
            $("#LinkedProjectsList").append("<div id='" + i + "' style='display:flex;width:100%;justify-content:space-between;'><div>" + projectSplit[i] + "</div><div style='cursor:pointer' onclick='removeLinkToProject(" + i + ")'>удалить</div></div>");
        }
    }
}


////////////////////////////Удаляем элемент списка связанных проектов//////////////////////////////
function removeLinkToProject(id) {
    $('#' + id).remove();
    let projects = $("[name='LinkedProjectNames']").val();
    let projectSplit = projects.split('/');
    let newProjectSplit = [];
    let deleteIndicator = false;

    for (var i = 0; i < projectSplit.length; i++) {
        if (!deleteIndicator) {
            if (i != id) {
                newProjectSplit[i] = projectSplit[i];
            }
            else {
                if (projectSplit[i + 1] != undefined) {
                    newProjectSplit[i] = projectSplit[i + 1];
                    deleteIndicator = true;
                }
                else {
                    break;
                }
            }
        }
        else {
            if (projectSplit[i + 1] != undefined) {
                newProjectSplit[i] = projectSplit[i + 1];
            }
            else {
                break;
            }
        }
    }
    projects = "";
    if (newProjectSplit.length != 1) {
        for (var i = 1; i < newProjectSplit.length; i++) {
            projects += '/' + newProjectSplit[i];
        }
    }
    $("[name='LinkedProjectNames']").val(projects);


    $("#LinkedProjectsList").empty();
    for (var i = 1; i < newProjectSplit.length; i++) {
        $("#LinkedProjectsList").append("<div id='" + i + "' style='display:flex;width:100%;justify-content:space-between;'><div>" + newProjectSplit[i] + "</div><div style='cursor:pointer' onclick='removeLinkToProject(" + i + ")'>удалить</div></div>");
    }
}
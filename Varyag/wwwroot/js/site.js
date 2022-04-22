// Please see documentation at https://docs.microsoft.com/ore/client-side/bundling-and-mini
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
    //if ($("[name='LinkedProjectNames']").val() != undefined) {
    //    newsLinkToProject(true);
    //}    
    newsLinkToProject(true)
});
////////////////////////////Создаем список связанных проектов//////////////////////////////
//$('#LinkedProjects').change(function () {
//})
function newsLinkToProject(firstTime) {
    let projects = $("[name='LinkedProjectNames']").val();

    if (firstTime) {
        let projectSplit = projects.split('/');
        $("#LinkedProjectsList").empty();
        for (var i = 1; i < projectSplit.length; i++) {
            $("#LinkedProjectsList").append("<div id='" + i + "' style='display:flex;width:100%;justify-content:space-between;'><div>" + projectSplit[i] + "</div><div style='cursor:pointer' onclick='removeLinkToProject(" + i + ")'>удалить</div></div>");
        }
    }
    else {
        //if (projects != "") {
        if (!projects.includes($("[name='LinkedProjects'] option:selected").text())) {
            projects += '/' + $("[name='LinkedProjects'] option:selected").text();
            $("[name='LinkedProjectNames']").val(projects);

            let projectSplit = projects.split('/');
            $("#LinkedProjectsList").empty();
            for (var i = 1; i < projectSplit.length; i++) {
                $("#LinkedProjectsList").append("<div id='" + i + "' style='display:flex;width:100%;justify-content:space-between;'><div>" + projectSplit[i] + "</div><div style='cursor:pointer' onclick='removeLinkToProject(" + i + ")'>удалить</div></div>");
            }
            //}
            //else {
            //    let projectSplit = projects.split('/');
            //    $("#LinkedProjectsList").empty();
            //    for (var i = 1; i < projectSplit.length; i++) {
            //        $("#LinkedProjectsList").append("<div id='" + i + "' style='display:flex;width:100%;justify-content:space-between;'><div>" + projectSplit[i] + "</div><div style='cursor:pointer' onclick='removeLinkToProject(" + i + ")'>удалить</div></div>");
            //    }
            //}
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

function articlesSaveButtonActive() {
    $("#articleSave").removeAttr("disabled");
}
function articlesSaveButtonDisable() {
    $("#articleSave").attr("disabled", "disabled");
}

////////////////////////Обслуживаем механизм создания превью статей//////////////////////////
function refreshPreviewEditor() {
    let response = fetch('/articles/SaveTempFoto', {
        method: 'POST',
        body: new FormData(fotoEditorForm)
    });
    
    setTimeout(fotoRefresh($('#typeOfFoto').val()), 1000);
}
function fotoRefresh(typeOfFoto) {
    switch (typeOfFoto) {
        case 'общая':
            $('#creator.partNewsElementViewShort').css('background-image', 'url(/images/temp/wide.jpg?' + Math.random() + ')');
            $('#creator.partNewsElementViewMiddle').css('background-image', 'url(/images/temp/short.jpg?' + Math.random() + ')');
            $('#creator.partNewsElementViewWide').css('background-image', 'url(/images/temp/middle.jpg?' + Math.random() + ')');
            break;
        case 'мелкая':
            $('#creator.partNewsElementViewShort').css('background-image', 'url(/images/temp/short.jpg?Р' + Math.random() + ')');
            break;
        case 'средняя':
            $('#creator.partNewsElementViewMiddle').css('background-image', 'url(/images/temp/middle.jpg?К' + Math.random() + ')');
            break;
        case 'широкая':
            $('#creator.partNewsElementViewWide').css('background-image', 'url(/images/temp/wide.jpg?У' + Math.random() + ')');
            break;
        default:
            break;
    }
}
//////////////Отправляем форму для эдита, сохраняя данные из редактора превью/////////////////
function editFormSend() {
    fillTheForm('shortFotoScaleForm', 'shortFotoScale');
    fillTheForm('shortFotoXForm', 'shortFotoX');
    fillTheForm('shortFotoYForm', 'shortFotoY');
    fillTheForm('shortStoryForm', 'shortFotoText');

    fillTheForm('middleFotoScaleForm', 'middleFotoScale');
    fillTheForm('middleFotoXForm', 'middleFotoX');
    fillTheForm('middleFotoYForm', 'middleFotoY');
    fillTheForm('middleStoryForm', 'middleFotoText');

    fillTheForm('wideFotoScaleForm', 'wideFotoScale');
    fillTheForm('wideFotoXForm', 'wideFotoX');
    fillTheForm('wideFotoYForm', 'wideFotoY');
    fillTheForm('wideStoryForm', 'wideFotoText');

    $('#editForm').submit();
}
function fillTheForm(formId, editorId) {
    if ($('#' + formId).val() != $('#' + editorId).val()) {
        $('#' + formId).val($('#' + editorId).val());
    }
}
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


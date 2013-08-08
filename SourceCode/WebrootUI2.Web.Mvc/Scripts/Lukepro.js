

function Views(urlPath, idOfDiv) {
    var $loadingElem = $("<div class='ui-loading'> <img  src='/Content/Images/Items/loading.gif'> </div>");
    $loadingElem.insertBefore("#" + idOfDiv);
    $.ajax({
        type: "POST",
        url: urlPath,
        dataType: "html",
        contentType: "application/json",
        success: function (result) {
            $("#" + idOfDiv).html(result.toString());
            $loadingElem.remove();
        },
        error: function () {
            $loadingElem.remove();
        }
    });
}
function Search(urlPath, idOfDiv, query) {
    var $loadingElem = $("<div class='ui-loading'> <img  src='/Content/Images/Items/loading.gif'> </div>");
    $loadingElem.insertBefore("#" + idOfDiv);
    $.ajax({
        type: "POST",
        url: urlPath + "?query=" + query,
        dataType: "html",
        contentType: "application/json",
        success: function (result) {
            $("#" + idOfDiv).html(result.toString());
            $loadingElem.remove();
        },
        error: function () {
            $loadingElem.remove();
        }
    });
}

/// <reference path="jquery-1.9.1.min.js" />
/// <reference path="jposition.js" />
/// <reference path="joverlay.js" />
/// <reference path="jloading_v2.js" />

var overlay;
var currentPage;

function removeOverlay() {
    if (overlay) overlay.remove();
    overlay = null;
}
function appendOverlay() {
    removeOverlay();
    overlay = $.joverlay();
}

function removePage() {
    if (currentPage) currentPage.remove();
    currentPage = null;
}
function appendPage(html,tag) {
    removePage();
    currentPage = $(html);
    if (tag) tag.append(currentPage);
    else $(document.body).append(currentPage);
}

(function () {
    if (!window["utility"]) window["utility"] = {};
    var utility = window["utility"];

    //get page
    function getPage(pageName, callback) {
        $.ajax({
            url: "/utility/getPage.ashx",
            type: "get",
            data: { pageName: pageName },
            dataType: "html",
            success: function (result) {
                //$("[data-type=dynamic]").remove();
                //$.data("")
                if (callback) {
                    callback(result);
                }
            },
            error: function () {
                console.info("ajax error");
            }
        });
    }

    utility.getPage = getPage;

})();

$(function () {
    window["utility"].getPage("login", function (page) {
        appendOverlay();
        appendPage(page);
    });

    //#region footer
    $.footerToBottom();
    $(window).bind("resize", $.footerToBottom);
    //#endregion

});
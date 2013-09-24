/// <reference path="jquery-1.9.1.min.js" />
/// <reference path="jposition.js" />
/// <reference path="joverlay.js" />
/// <reference path="jloading_v2.js" />



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


var overlay;
var currentPage;
var pageContainer;
var utility = window.utility;

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
function appendPage(html, tag) {
    debugger;
    removePage();
    currentPage = $(html);
    if (tag) tag.append(currentPage);
    else $(document.body).append(currentPage);
}


function navLogin() {
    utility.getPage("login", function (page) {
        appendOverlay();
        appendPage(page);
    });
}
function navHome() {
    utility.getPage("home", function (page) {
        appendPage(page, pageContainer);
    });
}

function navChangePassword() {
    utility.getPage("ChangePassword", function (page) {
        appendPage(page, pageContainer);
    });
}

function checkLogin() {
    $("#frmCheckLogin").formProcess({
        success: function (result) {
            if (!result.Success) {
                navLogin();
            }
            else {
                navHome();
            }
        },
        dataType: "json"
    });
}


$(function () {

    pageContainer = $("[data-role=page-container]");

    //#region footer
    $.footerToBottom();
    $(window).bind("resize", function () {
        $.footerToBottom();
    });
    //#endregion
    //navHome();
    checkLogin();
});
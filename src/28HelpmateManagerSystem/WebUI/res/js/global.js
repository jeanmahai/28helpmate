/// <reference path="jquery-1.9.1.min.js" />
/// <reference path="jposition.js" />
/// <reference path="joverlay.js" />
/// <reference path="jloading_v2.js" />

jQuery(function ($) {
    $.datepicker.regional['zh-CN'] = {
        closeText: '关闭',
        prevText: '&#x3c;上月',
        nextText: '下月&#x3e;',
        currentText: '今天',
        monthNames: ['一月', '二月', '三月', '四月', '五月', '六月',
                '七月', '八月', '九月', '十月', '十一月', '十二月'],
        monthNamesShort: ['一', '二', '三', '四', '五', '六',
                '七', '八', '九', '十', '十一', '十二'],
        dayNames: ['星期日', '星期一', '星期二', '星期三', '星期四', '星期五', '星期六'],
        dayNamesShort: ['周日', '周一', '周二', '周三', '周四', '周五', '周六'],
        dayNamesMin: ['日', '一', '二', '三', '四', '五', '六'],
        weekHeader: '周',
        dateFormat: 'yy-mm-dd',
        firstDay: 1,
        isRTL: false,
        showMonthAfterYear: true,
        yearSuffix: '年'
    };
    $.datepicker.setDefaults($.datepicker.regional['zh-CN']);
});

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

    //init datepicker
    $("[data-role=datepicker]").datepicker();
});
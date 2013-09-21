(function () {
    if (!window["utility"]) window["utility"] = {};
    var utility = window["utility"];

    var footer = $("div[data-role=footer]");
    var nav = $("div[data-role=navigation]");
    var cnt = $("div[data-role=content]");
    var win = $(window);

    function resetFooter() {
        var winHeight = win.height();
        var bodyHeight = $(document.body).height();
        if (bodyHeight < winHeight) {

        }
    }

    //get page
    function getPage(pageName, callback) {
        $.ajax({
            url: "/utility/getPage.ashx",
            type: "get",
            data: { pageName: pageName },
            dataType: "html",
            success: function (result) {
                $("[data-type=dynamic]").remove();
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
        $(document.body).append(page);
    });

    //#region footer
    $.footerToBottom();
    $(window).bind("resize", $.footerToBottom);
    //#endregion
});
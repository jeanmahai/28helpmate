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
        var overlay = $.joverlay();
        $(document.body).append(page);
    });

    //#region footer
    $.footerToBottom();
    $(window).bind("resize", $.footerToBottom);
    //#endregion
});
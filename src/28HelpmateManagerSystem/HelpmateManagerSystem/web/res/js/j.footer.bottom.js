/// <reference path="../jq/jquery-1.9.1.min.js" />


/*
当页面的内容的高度不能充满window的高度时,把footer设置在底部显示.
原理:设置容器控件的min-height,让整个页面的高度等于window的高度,当内容新增时,会自动进行增高.
仅HTML5支持

使用方法: 特性标示 data-role=footer
@eContent 参数非必须,如果为空,则使用footer上一个
*/
(function () {
    if (!$.footerToBottom) {
        $.footerToBottom = function (eContent) {
            var footer = $("[data-role=footer]").first();
            if (!eContent) {
                eContent = footer.prev();
            }
            if (footer.length <= 0) return;
            var docHeight = $(document.documentElement).height();
            var winHeight = $(window).height();
            if (docHeight >= winHeight) return;
            var oHeight = winHeight - docHeight;
            eContent.css({
                height: "auto",
                minHeight: eContent.height() + oHeight
            });
        };
    }
})();
/// <reference path="../jq/jquery-1.9.1.min.js" />
/*
遮罩层
{
of:jquery object,default(window)
opacity:number,default(0.8)
bgColor:color default(gray),
zIndex:number default(1000),
show:true/false default(true)
}
*/
if (!$.joverlay) {
    $.joverlay = function (obj) {
        if (!obj) obj = {};
        if (!obj.of) obj.of = $(window);
        if (!obj.opacity) obj.opacity = 0.8;
        if (!obj.bgColor) obj.bgColor = "gray";
        if (!obj.zIndex) obj.zIndex = 1000;
        if (!obj.show) obj.show = true;

        var overlay = $("<div></div>");
        var css = {
            position: "absolute",
            backgroundColor: obj.bgColor,
            width: obj.of.outerWidth(),
            height: obj.of.outerHeight(),
            top: obj.of.offset() ? obj.of.offset().top : 0,
            left: obj.of.offset() ? obj.of.offset().left : 0,
            opacity: obj.opacity,
            zIndex: obj.zIndex,
            display: obj.show ? "block" : "none"
        };
        overlay.css(css);
        overlay.appendTo(document.body);
        return overlay;
    };
}
/// <reference path="../jq/jquery-1.9.1.min.js" />
/// <reference path="joverlay.js" />
/// <reference path="jposition.js" />

/*
单例,整个loading只能有一个loading
*/
/*
{
url:img url ,required

of:jquery object, default(window)

opacity:number,default(0.8)
bgColor:color default(gray),
zIndex:number default(1000),
show:true/false default(true) it's alway true

my:center/left/right/top/bottom (default:center)
at:center/top/bottom/left/right (default:center)
}
*/
if (!$.jloading) {
    $.jloading = function (obj) {
        if (!obj || !obj.url) return;
        if (!obj.of) obj.of = $(window);
        var img = $("<img data-role='loading'  src='" + obj.url + "'/>");
        img.bind("load", function (evt) {
            $(this).jposition({
                of: obj.of
            }).appendTo(document.body);
            var showOverlay = obj.opacity || obj.bgColor || obj.zIndex || obj.show;
            if (showOverlay) {
                var overlay = $.joverlay(obj);
                overlay.attr("data-role", "loading");
                $(this).css("z-index", obj.zIndex + 1);
            }
        });
    };
}
if (!$.jloaded) {
    $.loaded = function () {
        $("[data-role=loading]").remove();
    };
}

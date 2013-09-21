/// <reference path="jquery-1.9.1.min.js" />
/*
如果不是html5,需要引用json2.js,否则不需要引用
*/
$.fn.extend({
    jformSerialize: function () {
        if (!$(this).is("form")) return null;
        var obj = {};
        $(this).find("[name]").each(function () {
            obj[$(this).attr("name")] = $(this).val();
        });
        return obj;
    }
});
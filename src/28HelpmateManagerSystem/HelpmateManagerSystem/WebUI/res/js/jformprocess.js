/// <reference path="jquery-1.9.1.min.js" />
/// <reference path="jformserialize.js" />
$.fn.extend({
    formProcess: function (obj) {
        var me = $(this);
        if (!me.is("form")) return;
        if (!obj) obj = {};
        obj.url = me.attr("action");
        obj.type = me.attr("method");
        var data = me.jformToJson();
        $.extend(data, { action: me.attr("data-action") });
        obj.data = data;
        obj.dataType = obj.dataType || "json";
        console.info(obj);
        $.ajax(obj);
    }
});
///<reference path="jquery-2.1.3.js">

//复制样式
(function ($) {
    $.fn.getStyleObject = function () {
        var dom = this.get(0);
        var style;
        var returns = {};
        if (window.getComputedStyle) {
            var camelize = function (a, b) {
                return b.toUpperCase();
            };
            style = window.getComputedStyle(dom, null);
            for (var i = 0, l = style.length; i < l; i++) {
                var prop = style[i];
                var camel = prop.replace(/\-([a-z])/g, camelize);
                var val = style.getPropertyValue(prop);
                returns[camel] = val;
            };
            return returns;
        };
        if (style = dom.currentStyle) {
            for (var prop in style) {
                returns[prop] = style[prop];
            };
            return returns;
        };
        return this.css();
    }
})(jQuery);

function IsPC() {
    var userAgentInfo = navigator.userAgent;
    var Agents = ["Android", "iPhone",
                "SymbianOS", "Windows Phone",
                "iPad", "iPod"];
    var flag = true;
    for (var v = 0; v < Agents.length; v++) {
        if (userAgentInfo.indexOf(Agents[v]) > 0) {
            flag = false;
            break;
        }
    }
    return flag;
}

$(document).ready(function () {
    if (!IsPC())
    {
        //Mobile加载会破坏页面
        $(document).bind("mobileinit", function () {
            $.mobile.ajaxEnabled = false;
            $.mobile.autoInitializePage = false;
            $.mobile.hashListeningEnabled = false;
            $.mobile.pushStateEnabled = false;

            //调节滑动翻页的敏捷度
            $.event.special.swipe.scrollSupressionThreshold = 200;
            $.event.special.swipe.durationThreshold = 300;
            $.event.special.swipe.horizontalDistanceThreshold = 210;
            $.event.special.swipe.verticalDistanceThreshold = 50;
        });

        //Iphone webApp
        $("head").append("<meta name='viewport' content='user-scalable=yes, initial-scale=1.0, width=device-width, minimal-ui'>");
        $("head").append("<meta name='apple-mobile-web-app-status-bar-style' content='black'>");
        $("head").append("<meta name='apple-mobile-web-app-capable' content='yes'>");
        $("head").append("<meta name='format-detection' content='telephone=no'>");
        $("head").append("<link rel='apple-touch-icon' sizes='114x114' href='imgs/iphoneLogo.png' />");
        //拦截超链接
        $("a").click(function (event) {
            if (this.href != "#" && this.href) {
                event.preventDefault(); window.document.location.href = this.href;
            }
        });

        //将包含子菜单的一级菜单的链接上的onclick去掉
        $("#mn_main a[href='#']").removeAttr("onclick").removeAttr("href");
        //将当前菜单的字体加粗
        var cName = $(window.location.pathname.split("/")).last()[0];
        var mni = $("#mn_main a[href='" + cName + "']");
        $("#mn_main > ul > li").has(mni).find(">a").css("font-weight", "bold");
        mni.css("font-weight", "bold");

        //加载jquerymobile
        $.getScript("jquery.mobile-1.4.5/jquery.mobile-1.4.5.js", function ()
        {
            //左右滑动，代表后退前进
            $(document).on("swipeleft", function () {
                history.back();
            });
            $(document).on("swiperight", function () {
                history.forward();
            });
        });
    }
});
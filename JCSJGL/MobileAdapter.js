///<reference path="jquery-2.1.3.js">

$(document).ready(function () {
    if (!IsPC())
    {
        //Mobile加载会破坏页面
        //$(document).bind("mobileinit", function () {
        //    $.mobile.ajaxEnabled = false;
        //    $.mobile.autoInitializePage = false;
        //    $.mobile.hashListeningEnabled = false;
        //    $.mobile.pushStateEnabled = false;


        //    //调节滑动翻页的敏捷度
        //    $.event.special.swipe.scrollSupressionThreshold = 200;
        //    $.event.special.swipe.durationThreshold = 300;
        //    $.event.special.swipe.horizontalDistanceThreshold = 210;
        //    $.event.special.swipe.verticalDistanceThreshold = 50;
        //});

        //Iphone webApp
        $("head").append("<meta name='viewport' content='user-scalable=no, initial-scale=1.0, width=device-width, minimal-ui'>");
        $("head").append("<meta name='apple-mobile-web-app-status-bar-style' content='black'>");
        $("head").append("<meta name='apple-mobile-web-app-capable' content='yes'>");
        $("head").append("<meta name='format-detection' content='telephone=no'>");
        $("head").append("<link rel='apple-touch-icon' sizes='114x114' href='images/iphoneLogo.png' />");
        //拦截超链接
        $("a").click(function (event)
        {
            if (this.href != "#" && this.href)
            {
                event.preventDefault(); window.document.location.href = this.href;
            }
        });
        $("area").click(function (event)
        {
            if (this.href != "#" && this.href)
            {
                event.preventDefault(); window.document.location.href = this.href;
            }
        });

        $("#div_body").css("overflow", "scroll").css("width", screen.availWidth + "px");

        ////将包含子菜单的一级菜单的链接上的onclick去掉
        //$("#mn_main a[href='#']").removeAttr("onclick").removeAttr("href");
        ////将当前菜单的字体加粗
        //var cName = $(window.location.pathname.split("/")).last()[0];
        //var mni = $("#mn_main a[href='" + cName + "']");
        //$("#mn_main > ul > li").has(mni).find(">a").css("font-weight", "bold");
        //mni.css("font-weight", "bold");

        //去掉toptitle
        $("#div_tophead").css("display", "none");

        //显示当前页面的title
        var title = document.title;
        var divTitle = $("<div id='div_title'>" + title + "<div></div></div>");
        divTitle.css("width", document.body.clientWidth);
        $("#div_head").prepend(divTitle);

        //生成手机菜单
        var mobileMenu = $("<div id='div_mobileMenu'></div>");
        mobileMenu.css("display", "none").css("z-index", "1");
        var inner = $("<div></div>");
        inner.css("position", "fixed").css("top", "31px").css("height", screen.availHeight - 31 + "px").css("overflow", "scroll");
        inner.css("-webkit-overflow-scrolling", "touch");
        mobileMenu.append(inner);
        $(".mn_main > ul > li > ul > li").find(">a").each(function ()
        {
            $(this).css("width", document.body.clientWidth);
            inner.append(this);
        });
        //退出登录
        var lo = $("<a href='Login.aspx'>退出登录</a>");
        lo.css("width", document.body.clientWidth);
        inner.append(lo);
        divTitle.after(mobileMenu);

        ////点击，显示菜单       
        divTitle.click(function ()
        {
            if (mobileMenu.attr('data-click-state') == 1)
            {
                mobileMenu.attr('data-click-state', 0);
                mobileMenu.attr("class", "mobileMenuHide");
                mobileMenu.css("display", "none");
            }
            else
            {
                mobileMenu.attr('data-click-state', 1);
                mobileMenu.attr("class", "mainMenuExpand");
                mobileMenu.css("display", "");
            }
        });


        //grid让开title的距离
        $("#div_body").css("top", "31px").css("position", "absolute").css("height", screen.availHeight - 61 + "px");
        $("#div_body").css("-webkit-overflow-scrolling", "touch");
        var startY;
        $(document).bind('touchstart', function (e)
        {
            startY = e.originalEvent.touches[0].clientY;
        });
        $(document).bind('touchmove', function (e)
        {
            var cdiv;
            if ($("#div_mobileMenu").css("display") != "none")
            {
                cdiv = $("#div_mobileMenu").children().first()[0];
            }
            else if ($("#div_edit").length != 0 && $("#div_edit").css("display") != "none")
            {
                cdiv = $("#div_edit")[0];
            }
            else if ($("#div_body").css("display") != "none")
            {
                cdiv = $("#div_body")[0];
            }

            var sp = cdiv.scrollTop;
            var sh = cdiv.scrollHeight;
            var oh = cdiv.offsetHeight;
            var currentY = e.originalEvent.touches[0].clientY;
            if (currentY - startY > 10)
            {
                if (sp == 0)
                {
                    e.preventDefault();
                }
            } else if (currentY - startY < -10)
            {
                if (sp + oh == sh)
                {
                    e.preventDefault();
                }
            }
        });

        //底部工具栏
        var ftb = $("<div id='div_bottom_toolbar'><div id='div_showsearch'></div><div id='div_back'></div></div>");
        ftb.css("width", screen.availWidth + "px");
        $("#div_foot").append(ftb);
        $("#div_back").click(function () { history.back(); });

        //查询工具栏
        var schTool = $("#div_sch");
        schTool.attr("class", "div_sch_mobile");
        schTool.css("display", "none");

        $("#div_foot").prepend(schTool);
        //点击，显示查询项    
        $("#div_showsearch").click(function ()
        {
            if (schTool.css("display") == "none")
            {
                $(".div_sch_mobile").css("display", "none");
                $(".div_edit_mobile").css("display", "none");
                schTool.css("display", "");
            }
            else
            {
                schTool.css("display", "none");
            }
        });

        //编辑
        var editTool = $(".div_edit");
        editTool.attr("class", "div_edit_mobile");
        editTool.css("display", "none");
        editTool.css("max-height", screen.availHeight - 61 + "px");
        //editTool.css("height", "200px");
        editTool.css("overflow", "auto");

        $("#div_foot").prepend(editTool);

        //grid 翻页
        //隐藏原翻页控件
        var oPager = $(".gridPager");
        if (oPager.length != 0)
        {
            oPager.css("display", "none");
            var pageCount = $("#hid_pageCount").attr("value");
            var pageIndex = $("#hid_pageIndex").attr("value");
            var oPrev = oPager.find("a").filter(function () { return $(this).text() == "Prev"; });
            var oNext = oPager.find("a").filter(function () { return $(this).text() == "Next"; });

            var divPager = $("<div id='div_pager'></div>");
            var divPrev = $("<div class='prev'></div>");
            var divNext = $("<div class='next'></div>");
            var divPageNum = $("<div class='pagenum'>" + (Number(pageIndex) + 1) + "/" + pageCount + "</div>");

            if (oPrev.length != 0)
            {
                divPager.append(divPrev);
                divPrev.click(function () { oPrev.trigger("click") });
            }
            if (oNext.length != 0)
            {
                divPager.append(divNext);
                divNext.click(function () { oNext.trigger("click") });
            }

            divPager.append(divPageNum);

            ftb.append(divPager);
        }

        //加载jquerymobile
        //$.getScript("jquery.mobile-1.4.5/jquery.mobile-1.4.5.js", function ()
        //{
        //    //左右滑动，代表后退前进
        //    $(document).on("swipeup", function () {
        //        alert(0);
        //    });
        //    $(document).on("swipedown", function () {
        //        alert(1);
        //    });
        //});

    }
    else
    {
        $(".grid").parent().css("width", "100%").css("overflow-x","auto");
    }
});
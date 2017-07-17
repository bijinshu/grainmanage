
(function ($) {
    $.fn.extend({
        pagination: function (startPage, pageSize, pageNum) {
            if (startPage < 1) { startPage = 1; }
            if (!pageNum) { pageNum = 10; }
            var totalRecord = parseInt($(this).attr("data-total"));
            if (totalRecord > 0) {
                var totalPage = parseInt((totalRecord - 1) / pageSize) + 1;
                if (startPage <= totalPage) {
                    var pageHtml = "<ul class=\"pagination\">";
                    //pageHtml += "<li><a data-value=\"1\">首页</a></li>";
                    if (startPage == 1) {
                        pageHtml += "<li class=\"disabled\" id=\"previous\"><a>&lt;&lt;</a></li>";
                    }
                    else {
                        pageHtml += "<li id=\"previous\"><a>&lt;&lt;</a></li>";
                    }

                    for (var i = startPage; i < startPage + pageNum && i <= totalPage; i++) {
                        if (i == 1) {
                            pageHtml += "<li class=\"active\"><a data-value=\"" + i + "\">" + i + "</a></li>";
                        } else {
                            pageHtml += "<li><a data-value=\"" + i + "\">" + i + "</a></li>";
                        }
                    }
                    if (startPage + pageNum > totalPage) { pageHtml += "<li class=\"disabled\" id=\"next\"><a>&gt;&gt;</a></li>"; }
                    else { pageHtml += "<li id=\"next\"><a>&gt;&gt;</a></li>"; }
                    //pageHtml += "<li><a data-value=\"" + totalPage + "\">尾页</a></li>";
                    pageHtml += "</ul>";
                    $(this).html(pageHtml);
                }
            }
        }
    });
})(jQuery);

function bindPaginationClick(selector, pageSizeSelector, clickHandller) {
    var pageNum = 10;
    $(selector).on("click", "li", function (eventObject) {
        var idName = $(this).attr("id");
        var pageSize = $(pageSizeSelector).val();
        if (idName) {
            if (idName == "next") {
                var currentMaxPage = parseInt($(selector + " ul li#" + idName).prev().children(":first-child").attr("data-value"));
                $(selector).pagination(currentMaxPage + 1, pageSize, pageNum);
            }
            else if (idName == "previous") {
                var currentMinPage = parseInt($(selector + " ul li#" + idName).next().children(":first-child").attr("data-value"));
                $(selector).pagination(currentMinPage - pageNum - 1, pageSize, pageNum);
            }
        }
        else {
            $(this).addClass("active").siblings().removeClass("active");
            var currentPage = parseInt($(this).children("a:first-child").attr("data-value"));
            if (clickHandller) { clickHandller(currentPage, pageSize); }
        }
    });
}
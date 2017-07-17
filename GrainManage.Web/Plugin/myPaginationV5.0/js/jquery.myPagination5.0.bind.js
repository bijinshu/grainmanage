function BindMyPaginationClick(resultSelector, searchApiUrl, requestParameter) {
    var pageSize = 5;
    if (!isNaN(requestParameter.pageSize) && requestParameter.pageSize > 0) {
        pageSize = requestParameter.pageSize;
    }
    else {
        var pageSize2 = parseInt($("#mypagination").attr("data-page-size"));
        if (!isNaN(pageSize2) && pageSize2 > 0) {
            pageSize = pageSize2;
        }
    }

    requestParameter.pageSize = pageSize;
    $.post(searchApiUrl, requestParameter, function (data) {
        $(resultSelector).html(data);
        //var pageCount = parseInt($("table[data-page-count]").attr("data-page-count"));
        var totalCount = parseInt($("table[data-total]").attr("data-total"));
        var pageCount = parseInt((totalCount - 1) / pageSize + 1);
        $("#mypagination").myPagination({
            //cssStyle:"grayr",
            panel:{tipInfo_on:true},
            currPage: 1,
            pageCount: pageCount,
            ajax: {
                onClick: function (page) {
                    requestParameter.pageIndex = page - 1;
                    $(resultSelector).load(searchApiUrl, requestParameter);
                }
            }
        });
    });
}

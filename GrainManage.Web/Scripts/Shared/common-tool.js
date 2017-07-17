(function ($) {
    $.fn.extend({
        getFormData: function (returnStr) {
            var obj = {};
            var typeArray = ["text", "password", "textarea", "date", "select"];
            $(this).first().find(':text,:password,textarea,input[type="date"],select,:radio:checked,:checkbox:checked').filter("[name]").each(function (index, e) {
                var name = $(e).attr("name");
                if ($.inArray(e.type, typeArray) >= 0 || $.inArray(e.localName, typeArray) >= 0) {
                    obj[name] = $(e).val();
                }
                else if (e.type == "radio" && $(e).checked) {
                    obj[name] = $(e).val();
                }
                else if (e.type == "checkbox") {
                    if (obj[name] == undefined || obj[name] == "") {
                        obj[name] = $(e).val();
                    } else {
                        if ($(e).val() != "") {
                            obj[name] += "," + $(e).val();
                        }
                    }
                }
            });
            if (returnStr) {
                var str = "";
                for (var name in obj) {
                    str += name + "=" + encodeURI(obj[name]) + "&";
                }
                if (str && str.length > 0) {
                    str = str.substr(0, str.length - 1);
                }
                return str;
            }
            return obj;
        },
        setFormData: function (jsonData) {
            if (jsonData) {
                var typeArray = ["text", "password", "textarea", "date", "select"];
                $(this).first().find(':text,:password,textarea,input[type="date"],select,:radio:checked,:checkbox:checked').filter("[name]").each(function (index, e) {
                    var name = $(e).attr("name");
                    var data = jsonData[name];
                    if ($.inArray(e.type, typeArray) >= 0 || $.inArray(e.localName, typeArray) >= 0) {
                        if (data != undefined) {
                            $(e).val(data);
                        }
                    }
                    else if (e.type == "radio") {
                        if ($(e).val() == data) {
                            $(e).checked = true;
                        } else {
                            $(e).checked = false;
                        }
                    }
                    else if (e.type == "checkbox") {
                        var dataArray = data.split(',');
                        if ($.inArray($(e).val(), dataArray)) {
                            $(e).checked = true;
                        } else {
                            $(e).checked = false;
                        }
                    }
                });
            }
        }
    });
})(jQuery);
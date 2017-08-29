$(function () {
    Vue.mixin({
        methods: {
            showAlert: function (title, msg, selector) {
                var id = selector ? selector : '#myModal';
                if (title && !msg && !selector) {
                    msg = title;
                    title = null;
                }
                this.AlertTitle = title ? title : '提示';
                this.msg = msg;
                $(id).modal({ backdrop: 'static' });
            },
            showPanel: function (title, selector) {
                if (title && !selector) {
                    selector = title;
                    title = null;
                }
                if (title) {
                    this.PanelTitle = title;
                }
                $(selector).modal({ backdrop: 'static' });
            },
            hidePanel: function (selector) {
                $(selector).modal('hide');
            },
            toFlow: function (value) {
                if (value < 1024) {
                    return value + 'M';
                } else if (value < 1024 * 1024) {
                    var result = value / 1024;
                    return result ? (this.isNumber(result) ? result : result.toFixed(2)) + 'G' : 0;
                }
                else {
                    var result = value / (1024 * 1024);
                    return result ? (this.isNumber(result) ? result : result.toFixed(2)) + 'T' : 0;
                }
            },
            isNumber: function (obj) {
                return typeof obj === 'number' && obj % 1 === 0
            }
        },
        filters: {
            formatTime: function (value) {
                return value.replace('T', ' ');
            }
        }
    })
})
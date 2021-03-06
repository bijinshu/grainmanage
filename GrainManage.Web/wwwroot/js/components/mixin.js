﻿$(function () {
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
            isNumber: function (obj) {
                return typeof obj === 'number' && obj % 1 === 0
            },
            toFixed: function (value) {
                if (!isNaN(parseFloat(value)) && isFinite(value)) {
                    var result = parseFloat(value).toFixed(2);
                    return parseFloat(result);
                }
                return '';
            }
        },
        filters: {
            formatTime: function (value) {
                return value ? value.replace('T', ' ') : '';
            }
        }
    })
})
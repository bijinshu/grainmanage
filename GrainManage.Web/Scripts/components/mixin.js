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
            }
        },
        filters: {
            formatTime: function (value) {
                return value.replace('T', ' ');
            }
        }
    })
})
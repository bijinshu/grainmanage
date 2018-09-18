(function ($) {
    "use strict";
    $.signin = function (config) {
        var modal = $.modal(
        {
            text: '<p class="weui-prompt-text">' + (config.text || '') + '</p>' +
                  '<input type="text" class="weui-input weui-prompt-input" id="weui-prompt-username" value="' + (config.username || '') + '" placeholder="请输入用户名" />' +
                  '<input type="password" class="weui-input weui-prompt-input" id="weui-prompt-password" value="' + (config.password || '') + '" placeholder="请输入密码" />',
            title: config.title,
            autoClose: false,
            buttons: [
            {
                text: '取消',
                className: "default",
                onClick: function () {
                    $.closeModal();
                    config.onCancel && config.onCancel.call(modal);
                }
            },
            {
                text: '确定',
                className: "primary",
                onClick: function () {
                    var username = $("#weui-prompt-username").val();
                    var password = $("#weui-prompt-password").val();
                    if (!config.empty && (username === "" || username === null)) {
                        modal.find('#weui-prompt-username').focus()[0].select();
                        return false;
                    }
                    if (!config.empty && (password === "" || password === null)) {
                        modal.find('#weui-prompt-password').focus()[0].select();
                        return false;
                    }
                    $.closeModal();
                    config.onOK && config.onOK.call(modal, username, password);
                }
            },
            {
                text: '微信登录',
                className: "primary",
                onClick: function () {
                    $.closeModal();
                    config.onWeixin && config.onWeixin.call(modal);
                }
            }]
        }, function () {
            this.find('#weui-prompt-username').focus()[0].select();
        });

        return modal;
    };
})($);
$(function () {
    new Vue({
        el: '#app',
        data: {
            UserName: '',
            Pwd: '',
            RememberMe: localStorage.RememberMe,
            IsDisabled: false,
            msg: ''
        },
        methods: {
            loginOn: function (event) {
                if (!this.isUserNameValid) {
                    $("#UserName").popover('show');
                }
                else if (!this.isPwdValid) {
                    $("#Pwd").popover('show');
                }
                else {
                    this.IsDisabled = true;
                    var returnUrl = this.getReturnUrl();
                    $.post(url.sign_in + '?' + returnUrl, { UserName: this.UserName, Pwd: new sha1().encrypt(this.Pwd) }).always(function (result, status) {
                        if (result.code == 1) {
                            this.changeRemember();
                            window.location.href = returnUrl ? returnUrl.split('=')[1] : url.home;
                        }
                        else {
                            this.IsDisabled = false;
                            this.msg = result.msg;
                            $("#myModal").modal({ backdrop: 'static' });
                        }
                    }.bind(this));
                }
            },
            changeRemember: function () {
                if (this.RememberMe) {
                    var base = new base64();
                    localStorage.UserName = base.encode(this.UserName);
                    localStorage.Pwd = base.encode(this.Pwd);
                    localStorage.RememberMe = this.RememberMe;
                }
                else {
                    localStorage.removeItem("UserName");
                    localStorage.removeItem("Pwd");
                    localStorage.removeItem("RememberMe");
                }
            },
            getReturnUrl: function () {
                var returnUrl = '';
                var arrays = window.location.href.split('?');
                if (arrays.length > 1 && arrays[1]) {
                    returnUrl = arrays[1];
                }
                return returnUrl;
            }
        },
        computed: {
            isUserNameValid: function () {
                return (/^[a-zA-Z]\w{1,20}$/g).test(this.UserName) || (/^1[34578]\d{9}$/g).test(this.UserName);
            },
            isPwdValid: function () {
                return (/^.{6,20}$/g).test(this.Pwd);
            }
        },
        created: function () {
            var base = new base64();
            this.UserName = localStorage.UserName ? base.decode(localStorage.UserName) : '';
            this.Pwd = localStorage.Pwd ? base.decode(localStorage.Pwd) : '';
        }
    })
    $("html").click(function () { $('[data-toggle="popover"]').popover('hide') });
})
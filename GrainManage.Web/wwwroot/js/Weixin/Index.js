/// <reference path="../../lib/jquery/dist/jquery.js" />
var vm = new Vue({
    el: '#app',
    data: {
        search: { Name: '', PageIndex: 0, PageSize: 20 },
        list: [],
        productList: [],
        frm: { CompId: 0, CompName: '', Mobile: '', Address: '', Remark: '', Details: [] },
        loading: true,
        logined: false
    },
    watch: {
        'search.Name': function (newVal, oldVal) {
            this.getData();
        }
    },
    methods: {
        getData: function (append) {
            this.loading = true;
            $.post(url.weixin_index, this.search).always(function (result, status) {
                this.loading = false;
                if (result.code != 1 && result.code != 9) {
                    $.alert(result.msg);
                    return;
                }
                if (append && result.data && result.data.length > 0) {
                    this.list.append(result.data);
                } else {
                    this.list = result.data;
                }
            }.bind(this));
        },
        showAction: function (item) {
            if (this.logined) {
                this.frm.CompId = item.Id;
                this.frm.CompName = item.CompanyName;
                $.post(url.simple_info).done(function (result, status) {
                    this.frm.Mobile = result.data.Mobile;
                    this.frm.Address = result.data.Address;
                }.bind(this));
                this.productList = [];
                for (var i = 0; i < item.Products.length; i++) {
                    var currentProduct = item.Products[i];
                    var product = { Id: currentProduct.Id, Name: currentProduct.Name, Price: currentProduct.Price, PreWeight: '' };
                    this.productList.push(product);
                }
                $.actions({
                    title: "选择操作",
                    actions: [
                        {
                            text: "我要卖粮", className: "color-primary", onClick: function () {
                                $("#full").popup();
                            }
                        },
                        {
                            text: "商家介绍", className: "color-warning", onClick: function () {
                                //do something
                            }
                        }
                    ]
                })
            } else {
                this.showLogin();
            }
        },
        showLogin: function () {
            var base = new base64();
            var self = this;
            $.login({
                title: '登录',
                text: '',
                username: localStorage.UserName ? base.decode(localStorage.UserName) : '',  // 默认用户名
                password: localStorage.Pwd ? base.decode(localStorage.Pwd) : '',  // 默认密码
                onOK: function (username, password) {
                    if (!(/^[a-zA-Z]\w{1,20}$/g).test(username) && !(/^1[34578]\d{9}$/g).test(username)) {
                        $.alert('用户名：只能由2-20个英文字符、数字、下划线或合法的手机号码组成');
                    }
                    else if (!(/^.{6,20}$/g).test(password)) {
                        $.alert('密码：字符个数只能为6-20个');
                    }
                    else {
                        $.post(url.sign_in + '?agent=1', { UserName: username, Pwd: new sha1().encrypt(password) }).always(function (result, status) {
                            if (result.code == 1) {
                                localStorage.UserName = base.encode(username);
                                localStorage.Pwd = base.encode(password);
                                self.logined = true;
                                $.toptip('登录成功', 'success');
                            }
                            else {
                                $.alert(result.msg);
                            }
                        });
                    }
                },
                onCancel: function () {
                    //点击取消
                }
            });
        },
        sendOrder: function () {
            var detail = [];
            $("#full .modal-content :checkbox:checked").each(function (index, ele) {
                var str = $(ele).val();
                var array = str.split(':');
                var productName = '';
                for (var index in this.productList) {
                    if (this.productList[index].Id == array[0]) {
                        productName = this.productList[index].Name;
                        break;
                    }
                }
                detail.push({ ProductId: parseInt(array[0]), ProductName: productName, Price: parseFloat(array[1]), PreWeight: array.length > 2 ? array[2] : 0 });
            }.bind(this));
            this.frm.Details = detail;
            $.post(url.order_new, this.frm).done(function (result, status) {
                $.alert(result.msg);
                if (result.code == 1) {
                    $("#closePopup").trigger("click");
                }
            }.bind(this));
        }
    },
    computed: {
        isPhoneValid: function () {
            return (/^1[34578]\d{9}$/g).test(this.frm.Mobile);
        },
        isRemarkValid: function () {
            return (/^.{0,200}$/g).test(this.frm.Remark);
        }
    },
    filters: {
        imgUrl: function (value) {
            if (value) {
                return url.img_base + value;
            }
            return "#";
        },
        productName: function (value, index, length) {
            if (index == length - 1) {
                return value.Name + '(' + value.Price + ')'
            }
            else {
                return value.Name + '(' + value.Price + ')、'
            }
        }
    },
    created: function () {
        this.getData(false);
        $.post(url.test).always(function (result, status) {
            if (result == "success") {
                this.logined = true;
            } else {
                this.logined = false;
            }
        }.bind(this));
    }
});
$("#tab1,#tab2").pullToRefresh({
    onRefresh: function () {
        $(this.container).pullToRefreshDone();
        $(this.container).css('transform', 'translateY(-50px)');
        vm.getData();
    },
    onPull: function (percent) {
        if (percent < 100) {
            var self = this;
            setTimeout(function () {
                $(self.container).pullToRefreshDone();
                $(self.container).css('transform', 'translateY(-50px)');
            }, 2000)
        }
    }
});
$("#tab1").infinite().on("infinite", function () {
    vm.search.PageIndex++;
    vm.getData(true);
}.bind(this));
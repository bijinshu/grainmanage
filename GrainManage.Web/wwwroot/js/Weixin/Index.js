/// <reference path="../../lib/jquery/dist/jquery.js" />
$(function () {
    new Vue({
        el: '#app',
        data: {
            search: { Name: '', PageIndex: 0, PageSize: 20 },
            list: [],
            productList: [],
            frm: { CompId: 0, CompName: '', Mobile: '', Address: '', Remark: '', Details: [] },
            loading: true
        },
        methods: {
            getData: function (append) {
                this.loading = true;
                $.post(weixin_index_url, this.search).always(function (result, status) {
                    this.loading = false;
                    if (result.code != 1) {
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
                this.frm.CompId = item.Id;
                this.frm.CompName = item.CompanyName;
                this.frm.Mobile = '';
                this.frm.Address = '';
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
            },
            sendOrder: function () {
                var detail = [];
                $("#full .modal-content :checkbox:checked").each(function (index, ele) {
                    var str = $(ele).val();
                    var array = str.split(':');
                    detail.push({ ProductId: parseInt(array[0]), Price: parseFloat(array[1]), PreWeight: array.length > 2 ? array[2] : 0 });
                }.bind(this));
                this.frm.Details = detail;
                $.post(order_new_url, this.frm).done(function (result, status) {
                    $.alert(result.msg);
                    if (result.code == 1) {
                        $("#closePopup").trigger("click");
                    }
                }.bind(this));
            },
            //showOrder: function (item) {
            //    if ($globalUserInfo) {
            //        this.productList = item.Products;
            //        this.frm.CompId = item.Id;
            //        this.frm.CompName = item.CompanyName;
            //        this.frm.Mobile = $globalUserInfo.Mobile;
            //        this.frm.Address = $globalUserInfo.Address;
            //        this.frm.Remark = '';
            //        this.frm.Details = [];
            //        this.addNewDetailForm();
            //        this.showPanel("#newOrderModal");
            //    }
            //    else {
            //        window.location.href = '@UrlVar.User_SignIn' + '?returnUrl=' + encodeURI(window.location.pathname);
            //    }
            //},
            //setPrice: function (detail) {
            //    var existedItem = null;
            //    for (var i = 0; i < this.productList.length; i++) {
            //        if (this.productList[i].Id == detail.ProductId) {
            //            existedItem = this.productList[i];
            //            break;
            //        }
            //    }
            //    detail.Price = existedItem ? existedItem.Price : '';
            //    detail.ProductName = existedItem ? existedItem.Name : '';
            //},
            //save: function () {
            //    if (this.isPhoneValid && this.isRemarkValid) {
            //        this.IsDisabled = true;
            //        var data = { CompId: this.frm.CompId, CompName: this.frm.CompName, Mobile: this.frm.Mobile, Address: this.frm.Address, Remark: this.frm.Remark, Details: [] };
            //        for (var i = 0; i < this.frm.Details.length; i++) {
            //            var item = this.frm.Details[i];
            //            data.Details.push({ ProductId: item.ProductId, ProductName: item.ProductName, Price: item.Price, Weight: item.Weight });
            //        }
            //        $.post('@UrlVar.Order_New', data).done(function (result, status) {
            //            this.IsDisabled = false;
            //            if (result.code == 1) {
            //                this.hidePanel("#newOrderModal");
            //                window.location.href = '@UrlVar.Order_GetMyOrderList';
            //            } else {
            //                this.showAlert(result.msg);
            //            }
            //        }.bind(this));
            //    } else {
            //        this.showAlert("电话号码或备注信息格式不正确");
            //    }
            //},
            //addNewDetailForm: function () {
            //    var productId = this.productList[0].Id;
            //    var newDetail = { ProductId: productId, ProductName: '', Price: 0, Weight: '', TotalMoney: 0, ProductList: [] };
            //    newDetail.ProductList = this.productList.concat();
            //    this.frm.Details.push(newDetail);
            //    this.setPrice(newDetail);
            //},
            //delDetailForm: function (index) {
            //    if (this.frm.Details.length > 1) {
            //        this.frm.Details.splice(index, 1);
            //    }
            //},
            //getMoney: function (detail) {
            //    if (detail && detail.Weight && detail.Price) {
            //        var result = (detail.Weight * detail.Price).toFixed(2);
            //        return parseInt(result) == result ? parseInt(result) : result;
            //    }
            //    return 0;
            //}
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
                    return img_server_logo_path + value;
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
            $("#tab1").infinite().on("infinite", function () {
                this.search.PageIndex++;
                this.getData(true);
            }.bind(this));
        }
    })
})
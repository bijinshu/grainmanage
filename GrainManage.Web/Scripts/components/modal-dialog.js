Vue.component('modal-dialog', {
    template: ' <div class="dialogs">\
                <div class="dialog" v-bind:class="{"dialog-active":show,"dialog-info":true}">\
                <div class="dialog-content">\
                    <div class="close rotate">\
                        <span class="iconfont icon-close" v-on:click="close"></span>\
                    </div>\
                    <slot name="header">\
                    <header class="dialog-header">\
                    <h1 class="dialog-title">提示信息</h1>\
                    </header>\
                    </slot>\
                    <slot name="body"></slot>\
                    <slot name="footer">\
                    <footer class="dialog-footer">\
                    <button class="btn" v-on:click="close">关闭</button>\
                    </footer>\
                    </slot>\
              </div>\
              </div>\
              </div>',
    props: ['show'],
    methods: {
        close: function () {
            this.show = false;
        }
    }
})
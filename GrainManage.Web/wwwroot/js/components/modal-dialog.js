$(function () {
    Vue.component('modal-dialog', {
        template: ' <div class="modal fade" v-bind:id="myId" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">\
        <div v-bind:class="[\'modal-dialog\',otherClass]">\
            <div class="modal-content">\
                <div class="modal-header bg-info">\
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>\
                    <slot name="header"><h4 class="modal-title text-danger text-center" id="myModalLabel" style="font-weight:bold;">{{title}}</h4></slot>\
                </div>\
                <div class="modal-body">\
                  <slot name="body"><p class="text-info text-center">{{msg}}</p></slot>\
                </div>\
                <div class="modal-footer">\
                    <slot name="footer"><button type="button" class="btn btn-info" data-dismiss="modal">关闭</button></slot>\
                </div>\
            </div>\
        </div>\
    </div>',
        props: ['title', 'msg', 'id', 'otherClass'],
        computed: {
            myId: function () {
                return this.id ? this.id : 'myModal';
            }
        }
    })
})
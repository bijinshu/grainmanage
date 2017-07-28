$(function () {
    Vue.component('modal-dialog', {
        template: ' <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">\
        <div class="modal-dialog">\
            <div class="modal-content">\
                <div class="modal-header bg-info">\
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>\
                    <h4 class="modal-title text-danger text-center" id="myModalLabel" style="font-weight:bold;">{{title}} </h4>\
                </div>\
                <div class="modal-body text-center">\
                    <p class="text-info ">{{msg}}</p>\
                </div>\
                <div class="modal-footer">\
                    <button type="button" class="btn btn-info" data-dismiss="modal">关闭</button>\
                </div>\
            </div>\
        </div>\
    </div>',
        props: ['title', 'msg']
    })
})
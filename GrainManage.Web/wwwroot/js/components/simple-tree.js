$(function () {
    Vue.component('simple-tree', {
        template: ' <ul v-if="items&&items.length>0" style="list-style:none">\
                       <li v-for="item in items">\
                            <span v-on:click="changeState(item)" v-bind:class="[\'glyphicon\',getStateClass(item)]"></span>\
                            <span v-on:dragstart="dragStart(item)" v-on:drop="drop(item)" v-on:dragover.prevent draggable="true" style="cursor:move;" v-bind:class="[\'glyphicon\',getFolderClass(item)]"></span>\
                            <span style="cursor:pointer;" v-on:click="change(item)" v-bind:class="[getCurrentClass(item)]">{{item.text}}</span>\
                       <simple-tree v-show="item.expanded" v-bind:items="item.children" v-bind:currentItem="currentItem" v-bind:dragObj="dragObj"> </simple-tree>  \
                       </li>\
                    </ul>',
        props: ['items', 'currentItem', 'dragObj'],
        methods: {
            changeState: function (item) {
                item.expanded = !item.expanded;
            },
            getStateClass: function (item) {
                if (item.children && item.children.length > 0) {
                    return item.expanded ? 'glyphicon-minus' : 'glyphicon-plus';
                }
                else {
                    return '';
                }
            },
            getCurrentClass: function (item) {
                return item.id == this.currentItem.id ? { 'lead': true, 'text-danger': true } : '';
            },
            getFolderClass: function (item) {
                if (item.children && item.children.length > 0) {
                    return item.expanded ? 'glyphicon-folder-open' : 'glyphicon-folder-close';
                }
                else {
                    return 'glyphicon-leaf';
                }
            },
            change: function (item) {
                this.currentItem.id = item.id;
                this.currentItem.text = item.text;
            },
            dragStart: function (item) {
                if (this.dragObj) {
                    this.dragObj.destId = null;
                    this.dragObj.srcId = item.id;
                }
            },
            drop: function (item) {
                if (this.dragObj) {
                    this.dragObj.destId = item.id;
                }
            }
        }
    })
})
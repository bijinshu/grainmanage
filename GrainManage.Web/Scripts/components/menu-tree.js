$(function () {
    Vue.component('menu-tree', {
        name: 'menu-tree',
        template: ' <ul v-if="items&&items.length>0" style="list-style:none">\
                       <li v-for="item in items">\
                            <span v-on:click="changeState(item)" v-bind:class="[\'glyphicon\',getStateClass(item)]"></span>\
                            <span v-on:click="changeCheckedState(item)" v-bind:class="[\'glyphicon\',getCheckedClass(item)]"></span>\
                            <span v-bind:class="[\'glyphicon\',getFolderClass(item)]"></span>\
                            <span>{{item.text}}</span>\
                       <menu-tree v-on:refresh="refresh" v-show="item.expanded" v-bind:items="item.children" v-bind:allItems="allItems" v-bind:selectedItems="selectedItems"> </menu-tree>  \
                       </li>\
                    </ul>',
        props: ['items', 'allItems', 'selectedItems'],
        methods: {
            indexOf: function (currentItem, array) {
                if (array && array.length > 0) {
                    for (var j = 0; j < array.length; j++) {
                        if (array[j] == currentItem) {
                            return j;
                        }
                    }
                }
                return -1;
            },
            getStateClass: function (item) {
                if (item.children && item.children.length > 0) {
                    return item.expanded ? 'glyphicon-minus' : 'glyphicon-plus';
                }
                else {
                    return '';
                }
            },
            getCheckedClass: function (item) {
                return this.indexOf(item.id, this.selectedItems) < 0 ? 'glyphicon-unchecked' : 'glyphicon-check';
            },
            getFolderClass: function (item) {
                if (item.children && item.children.length > 0) {
                    return item.expanded ? 'glyphicon-folder-open' : 'glyphicon-folder-close';
                }
                else {
                    return 'glyphicon-leaf';
                }
            },
            changeState: function (item) {
                item.expanded = !item.expanded;
            },
            getItem: function (items, id) {
                var current = null;
                if (items && id) {
                    for (var i = 0; i < items.length; i++) {
                        if (items[i].id == id) {
                            current = items[i];
                            break;
                        } else if (items[i].children && items[i].children.length > 0) {
                            current = this.getItem(items[i].children, id);
                            if (current) {
                                break;
                            }
                        }
                    }
                }
                return current;
            },
            refresh: function (type, id) {
                this.$emit('refresh', type, id);
            },
            changeCheckedState: function (item) {
                var type = this.indexOf(item.id, this.selectedItems) < 0 ? 'add' : 'delete'
                this.$emit('refresh', type, item.id);
                this.changeCheckedStateDownward(item, type);
                this.changeCheckdStateUpward(item.id, item.parentId);
            },
            changeCheckedStateDownward: function (item, type) {
                if (item.children && item.children.length > 0) {
                    for (var i in item.children) {
                        this.$emit('refresh', type, item.children[i].id);
                        this.changeCheckedStateDownward(item.children[i], type);
                    }
                }
            },
            changeCheckdStateUpward: function (currentId, parentId) {
                var parent = this.getItem(this.allItems, parentId);
                if (parent) {
                    if (this.indexOf(currentId, this.selectedItems) >= 0) {
                        this.$emit('refresh', 'add', parentId);
                    }
                    else {
                        var index = -1;
                        for (var i = 0; i < parent.children.length; i++) {
                            index = this.indexOf(parent.children[i].id, this.selectedItems);
                            if (index >= 0) { break; }
                        }
                        if (index < 0) {
                            this.$emit('refresh', 'delete', parentId);
                        }
                    }
                    this.changeCheckdStateUpward(parentId, parent.parentId);
                }
            }
        }
    })
})
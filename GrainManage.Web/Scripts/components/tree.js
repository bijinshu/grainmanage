$(function () {
    Vue.component('role-tree', {
        template: ' <ul v-if="items&&items.length>0" style="list-style:none">\
                       <li v-for="item in items">\
                            <span v-on:click="changeState(item)" v-bind:class="[\'glyphicon\',getStateClass(item)]"></span>\
                            <span v-on:click="changeCheckedState(item)"><input type="checkbox" v-model="item.selected"></span>\
                            <span v-bind:class="[\'glyphicon\',getFolderClass(item)]"></span>\
                            <span>{{item.text}}</span>\
                       <role-tree v-show="item.expanded" v-bind:items="item.children" v-bind:allItems="allItems" v-bind:selectedItems="selectedItems"> </role-tree>  \
                       </li>\
                    </ul>',
        props: ['items', 'allItems', 'selectedItems'],
        methods: {
            getStateClass: function (item) {
                if (item.children && item.children.length > 0) {
                    return item.expanded ? 'glyphicon-minus' : 'glyphicon-plus';
                }
                else {
                    return '';
                }
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
            changeCheckedState: function (item) {
                this.changeCheckedStateDownward(item);
                this.changeCheckdStateUpward(item.selected, item.parent);
                this.getSelectedItem();
            },
            changeCheckedStateDownward: function (item) {
                if (item.children && item.children.length > 0) {
                    for (var i in item.children) {
                        item.children[i].selected = item.selected;
                        this.changeCheckedStateDownward(item.children[i]);
                    }
                }
            },
            changeCheckdStateUpward: function (selected, parentId) {
                var parent = this.getItem(this.allItems, parentId);
                if (parent) {
                    if (selected) {
                        parent.selected = selected;
                    }
                    else {
                        var hasOtherSelected = false;
                        for (var i = 0; i < parent.children.length; i++) {
                            if (parent.children[i].selected) {
                                hasOtherSelected = true;
                                break;
                            }
                        }
                        if (!hasOtherSelected) {
                            parent.selected = selected;
                        }
                    }
                    this.changeCheckdStateUpward(selected, parent.parent);
                }
            },
            getSelectedItem: function () {
                this.selectedItems.splice(0, this.selectedItems.length);
                this.pushSelectedItem(this.allItems, this.selectedItems);
            },
            pushSelectedItem: function (items, selectedItems) {
                if (items && items.length > 0) {
                    for (var i in items) {
                        if (items[i].selected) {
                            selectedItems.push(items[i].id);
                            this.pushSelectedItem(items[i].children, selectedItems);
                        }
                    }
                }
            }
        },
        created: function () {
            this.getSelectedItem();
        }
    })
})
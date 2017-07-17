Vue.component('pager', {
    template: ' \
       <div> \
       <nav style="float:left">\
            <ul class="pagination ">\
                <li v-on:click="changePage(-1)"><a href="#">&laquo;</a></li>\
                <li v-on:click="changePage(num)" v-for="num in pageNumbers" v-bind:class="{active:pageIndex==num-1}" style="font-weight:bold;"><a href="#">{{num}}</a></li>\
                <li v-on:click="changePage(-2)"><a href="#">&raquo;</a></li>\
            </ul>\
        </nav>\
        <div style="float:right;margin:20px;">\
        共<span style="color:red;font-weight:bold;">{{totalPage}}</span>页 每页<input v-on:keyup.enter="changePageSize" type="textbox" v-model="currentPageSize" style="color:red;font-weight:bold;width:40px;" />条数据 \
        </div>\
      </div> ',
    props: {
        total: Number,
        pageIndex: Number,
        pageSize: Number
    },
    data: function () {
        return {
            maxSize: 20,
            pageNumbers: [],
            currentPageSize: this.pageSize
        }
    },
    methods: {
        changePage: function (num) {
            if (num == -1) {
                var minPage = this.pageNumbers[0];
                var maxPage = this.pageNumbers[this.pageNumbers.length - 1];
                var startPage = 0;
                var endPage = 0;
                if (minPage > this.maxSize) {
                    startPage = minPage - this.maxSize;
                    endPage = minPage - 1;
                }
                else {
                    startPage = 1;
                    endPage = this.totalPage > this.maxSize ? this.maxSize : this.totalPage;
                }
                this.pageNumbers = [];
                for (var i = startPage; i <= endPage; i++) {
                    this.pageNumbers.push(i);
                }
            }
            else if (num == -2) {
                var minPage = this.pageNumbers[0];
                var maxPage = this.pageNumbers[this.pageNumbers.length - 1];
                var startPage = 0;
                var endPage = 0;
                if (this.totalPage > maxPage) {
                    startPage = maxPage + 1;
                    endPage = this.totalPage > maxPage + this.maxSize ? maxPage + this.maxSize : this.totalPage;
                    this.pageNumbers = [];
                    for (var i = startPage; i <= endPage; i++) {
                        this.pageNumbers.push(i);
                    }
                }
            }
            else {
                this.$emit('update:pageIndex', num - 1);
                this.$emit('reload');
            }
        },
        refreshPage: function () {
            var showPageNum = this.totalPage > this.maxSize ? this.maxSize : this.totalPage;
            this.pageNumbers = [];
            for (var i = 0; i < showPageNum; i++) {
                this.pageNumbers.push(i + 1);
            }
        },
        changePageSize: function () {
            if (!isNaN(this.currentPageSize)) {
                this.$emit('update:pageSize', parseInt(this.currentPageSize));
                this.$emit('reload');
            }
        }
    },
    computed: {
        totalPage: function () {
            return parseInt((this.total - 1) / this.pageSize) + 1;
        }
    },
    created: function () {
        this.$watch('total', function () {
            this.refreshPage();
        });
        this.$watch('pageSize', function () {
            this.refreshPage();
        });
    }
});

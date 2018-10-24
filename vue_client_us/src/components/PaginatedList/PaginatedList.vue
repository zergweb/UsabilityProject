<template>
    <div>
        <table class="table table-dark table-striped table-bordered table-hover">
            <thead>
                <tr>
                    <th scope="col">#</th>
                    <th scope="col"  @click="sortParam=='sortByNameASC' ? sortParam='sortByNameDESC' : sortParam='sortByNameASC' ">Name</th>
                    <th scope="col" @click="sortParam=='sortByPulseASC' ? sortParam='sortByPulseDESC' : sortParam='sortByPulseASC' ">Pulse</th>
                    <th scope="col">Temperature</th>
                    <th scope="col" @click="sortParam=='sortByDateASC' ? sortParam='sortByDateDESC' : sortParam='sortByDateASC' ">Date</th>
                </tr>
            </thead>
            <tbody>

                <template v-for="item in current_list" >
                    <slot v-bind="item">
                    </slot>
                </template>
            </tbody>
        </table>  
            <div class="d-flex justify-content-center col-md-12" v-if="isNeeded">
                <nav aria-label="...">
                    <ul class="pagination">
                        <li :class="{disabled: pageNumber==0,'page-item':true}">
                            <a class="page-link" aria-label="Previous" @click="prevPage">
                                <span aria-hidden="true">&laquo;</span>
                                <span class="sr-only">Previous</span>
                            </a>
                        </li>
                        <template v-for="n in page_count">
                            <li :class="{'page-item':true, active:n==pageNumber+1}">
                                <a class="page-link" @click="request_page(n-1)">{{n}}</a>
                            </li>
                        </template>
                        <li :class="{disabled: pageNumber >=page_count-1,'page-item':true}">
                            <a class="page-link" aria-label="Next" @click="nextPage">
                                <span aria-hidden="true">&raquo;</span>
                                <span class="sr-only">Next</span>
                            </a>
                        </li>
                    </ul>
                </nav>
            </div>
        </div>
</template>

<script>
    import Vue from 'vue'
    import { mapGetters } from 'vuex';
    export default {
        name: 'PaginatedList',
        props: {
            List_data: Array,
            Page_size: Number

        },
        data() {
            return {
                pageNumber: 0,
                sortParam: ''
            }
        },
        components: {
           
        },
        computed: {           
            page_count() {
                let l = this.List_data.length,
                    s = this.Page_size;
                return Math.ceil(l / s);
            },
            current_list() {
               const start = this.pageNumber * this.Page_size,
                    end = start + this.Page_size;
                return this.sorted_list.slice(start, end)
            },
            sorted_list() {
                switch (this.sortParam) {
                    case 'sortByNameASC': return this.List_data.sort(sortByNameASC);
                    case 'sortByNameDESC': return this.List_data.sort(sortByNameDESC);
                    case 'sortByPulseASC': return this.List_data.sort(sortByPulseASC);
                    case 'sortByPulseDESC': return this.List_data.sort(sortByPulseDESC);
                    case 'sortByDateASC': return this.List_data.sort(sortByDateASC);
                    case 'sortByDateDESC': return this.List_data.sort(sortByDateDESC);
                    default: return this.List_data;                                      
                }
            },
            isNeeded() {
                if (this.page_count <= 1) {
                    return false;
                }
                else {
                    return true;
                }
            },
          
        },
        methods: {
            nextPage() {
                this.pageNumber++;
            },
            prevPage() {
                this.pageNumber--;
            },
            request_page(n) {
                this.pageNumber = n;
            }
        }
    }
    var sortByNameASC = function (d1, d2) { return (d1.user.name.toLowerCase() > d2.user.name.toLowerCase()) ? 1 : -1 };
    var sortByNameDESC = function (d1, d2) { return (d1.user.name.toLowerCase() < d2.user.name.toLowerCase()) ? 1 : -1 };
    var sortByPulseASC = function (d1, d2) { return (d1.pulse > d2.pulse) ? 1 : -1 };
    var sortByPulseDESC = function (d1, d2) { return (d1.pulse < d2.pulse) ? 1 : -1 };
    var sortByDateASC = function (d1, d2) { return (d1.date > d2.date) ? 1 : -1 };
    var sortByDateDESC = function (d1, d2) { return (d1.date < d2.date) ? 1 : -1 };
</script>
<style scoped>
    .page-link {
        color: #864DD9;
    }

    .page-item.active .page-link {
        background-color: #864DD9;
        border-color: #864DD9;
    }

    .page-link:focus {
        -webkit-box-shadow: 0 0 0 0.2rem rgba(134, 77, 217,.25);
        box-shadow: 0 0 0 0.2rem rgba(134, 77, 217,.25);
    }
</style>

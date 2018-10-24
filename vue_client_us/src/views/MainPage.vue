<template> 
    <div>
        <template v-if="this.isLoad">
            <vue-frappe id="test"
                        :labels="this.labels_c"
                        title="Pulse Chart"
                        type="line"
                        :height="300"
                        :colors="['purple', '#ffa3ef', 'light-blue']"
                        :dataSets="this.datasets_c">
            </vue-frappe>
            <PaginatedList :List_data="samples"
                           :Page_size=10>
                <SampleTableItem slot-scope="prop" :item="prop" />
            </PaginatedList>
        </template>

    </div>
</template>
<script>// @ is an alias to /src
    import { mapGetters } from 'vuex'
    import { mapActions } from 'vuex'
    import { HTTP } from '@/http/http'
    import PaginatedList from '@/components/PaginatedList/PaginatedList'
    import SampleTableItem from '@/components/PaginatedList/SampleTableItem'


export default {
        name: 'MainPage',
        data() {
            return {
                labels: ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"],
                datasets: [
                    { name: "Pulses", values: [30, 50, -10, 15, 18, 32, 27, 14] }
                    //{ name: "Dataset 2", values: [30, 50, -10, 15, 18, 32, 27, 14] }
                ]
            }
        },
        components: {
            PaginatedList,
            SampleTableItem
        },
        computed: {
            ...mapGetters('samples', {
                samples: 'samples',
                isLoad:'isLoad'
            }),
            labels_c() {           
                let ar = [];
                for (let i = 0; i < 50; i++) {
                      ar.push(this.samples[i].user.name);
                    }
                return ar;                       
           },
            datasets_c() {
                return [{ name: "Pulses", values: this.values_c }];
            },
            values_c() {
                let ar = [];
                for (let i = 0; i < 50; i++) {
                    ar.push(this.samples[i].pulse);
                }
                return ar;
            }

        },
        methods: {
                     
        }
    }
    </script>
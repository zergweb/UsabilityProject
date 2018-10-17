<template> 
    <div>
        <h1>
            main page
        </h1>
        <vue-frappe id="test"
                    :labels="this.labels_c"
                    title="Pulse Chart"
                    type="line"
                    :height="300"
                    :colors="['purple', '#ffa3ef', 'light-blue']"
                    :dataSets="this.datasets_c">
        </vue-frappe>
        <table class="table table-dark table-striped table-bordered table-hover">
            <thead>
                <tr>
                    <th scope="col">#</th>
                    <th scope="col">Name</th>
                    <th scope="col">Pulse</th>
                    <th scope="col">Temperature</th>
                    <th scope="col">Date</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in samples">
                    <th scope="col">{{item.id}}</th>
                    <th scope="col">{{item.user.name}}</th>
                    <th scope="col">{{item.pulse}}</th>
                    <th scope="col">{{item.temperature}}</th>
                    <th scope="col">{{item.date}}</th>
                </tr>
            </tbody>
        </table>
    </div>
</template>
<script>// @ is an alias to /src
    import { mapGetters } from 'vuex'
    import { mapActions } from 'vuex'
    import { HTTP } from '@/http/http'


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

        },
        computed: {
            ...mapGetters('samples', {
               samples: 'samples'
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
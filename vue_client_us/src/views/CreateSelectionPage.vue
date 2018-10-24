<template> 
    <div>
        <h1>
            Selection page
        </h1>
        <input type="text" v-model="user_name" placeholder="name" class="form-control" /><br>
        <input type="date" v-model="start_date" placeholder="start date" class="form-control" />
        <input type="date" v-model="end_date" placeholder="start date" class="form-control" />
        <input type="text" v-model="start_pulse" placeholder="start date" class="form-control" />

        <button class="btn btn-sm btn-outline-secondary" v-on:click="getSamples" v-bind:disabled="btnDisabled">getSamples</button>
    </div>
</template>
<script>// @ is an alias to /src
    import { mapGetters } from 'vuex'
    import { mapActions } from 'vuex'
    import { HTTP } from '@/http/http'

export default {
        name: 'SelectionPage',
        data() {
            return {
                user_name: '',
                start_date: '',
                end_date: '',
                start_pulse: '',
                btnDisabled: false,
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

        },
        methods: {
            getSamples: function () {
                this.btnDisabled = true;
                // Store.dispatch('token/get_token', token);
                var formData = new FormData();
                formData.append("UserName", this.user_name);
                formData.append("StartPulse", this.start_pulse);
                HTTP.post("/samples/custom_samples/", formData)
                    .then(response => {
                        console.log(response);
                        //  Store.dispatch('auth/set_token', response.data.access_token);
                        //  Store.dispatch('auth/set_roles', response.data.role);
                        this.btnDisabled = false;
                    })
                    .catch(response => {
                        this.btnDisabled = false;
                        console.log(response);
                    })

            }
        }
    }
    </script>
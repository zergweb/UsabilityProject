<template> 
    
        <div class="row">
            <div class="col-md-6">
                <label class="row select_block ">
                    <h3 class="col-md-12 text-left">Date</h3>
                    <div class="col-md-2 label_for_input">Min: </div>
                    <input type="date" v-model="start_date" placeholder="Min" class="form-control col-md-4" />
                    <div class="col-md-2 label_for_input">Max: </div>
                    <input type="date" v-model="end_date" placeholder="Max" class="form-control col-md-4" />
                </label>
                <label class="row select_block ">
                    <h3 class="col-md-12 text-left">Pulse</h3>
                    <div class="col-md-2 label_for_input">Min: </div>
                    <input type="text" v-model="start_pulse" placeholder="Min" class="form-control col-md-4" />
                    <div class="col-md-2 label_for_input">Max: </div>
                    <input type="text" v-model="end_pulse" placeholder="Max" class="form-control col-md-4" />
                </label>
                <label class="row select_block ">
                    <h3 class="col-md-12 text-left">Temperature</h3>
                    <div class="col-md-2 label_for_input">Min: </div>
                    <input type="text" v-model="start_temperature" placeholder="Min" class="form-control col-md-4" />
                    <div class="col-md-2 label_for_input">Max: </div>
                    <input type="text" v-model="end_temperature" placeholder="Max" class="form-control col-md-4" />
                </label>
            </div>
            <div class="col-md-6">
                <label class="row select_block ">
                    <h3 class="col-md-12 text-left">Name</h3>
                    <input type="text" v-model="user_name" placeholder="name" class="form-control" /><br>
                </label>
                <label class="row select_block ">
                    <h3 class="col-md-12 text-left">Depertment</h3>
                    <select class="form-control" v-model="user_department">
                        <option value="1">Depertment1</option>
                        <option value="2">Depertment2</option>
                        <option value="3">Depertment3</option>
                        <option value="4">Depertment4</option>
                        <option value="5">Depertment5</option>
                    </select>
                </label>
                <button class="btn btn-sm btn-outline-secondary col-md-10 col-md-offset-1 sample_btn" v-on:click="getSamples" v-bind:disabled="btnDisabled">getSamples</button>
            </div>  
            <div class="col-md-12" v-if="this.isLoad">                                 
                    <PaginatedList :List_data="samples"
                                   :Page_size=10>
                        <SampleTableItem slot-scope="prop" :item="prop" />
                    </PaginatedList>             
            </div>
        </div>
       
        
        

        

</template>
<script>// @ is an alias to /src
    import { mapGetters } from 'vuex'
    import { mapActions } from 'vuex'
    import { HTTP } from '@/http/http'
    import PaginatedList from '@/components/PaginatedList/PaginatedList'
    import SampleTableItem from '@/components/PaginatedList/SampleTableItem'

export default {
        name: 'SelectionPage',
        data() {
            return {
                isLoad:false,
                user_name: '',
                user_department: '',
                start_date: '',
                end_date: '',
                start_pulse: '',
                end_pulse: '',
                start_temperature: '',
                end_temperature: '',
                btnDisabled: false,
                samples:[]
            }
        },
        components: {
            PaginatedList,
            SampleTableItem
        },
        computed: {

        },
        methods: {
            getSamples: function () {
                this.btnDisabled = true;
                var formData = new FormData();
                formData.append("UserName", this.user_name);
                formData.append("DepertmentId", this.user_depertment);
                formData.append("StartPulse", this.start_pulse);
                formData.append("EndPulse", this.end_pulse);
                formData.append("StartTemperature", this.start_temperature);
                formData.append("EndTemperature", this.end_temperature);
                formData.append("StartDate", this.start_date);
                formData.append("EndDate", this.end_date);
                HTTP.post("/samples/custom_samples/", formData)
                    .then(response => {
                        this.samples = response.data;
                        this.btnDisabled = false;
                        this.isLoad = true;
                    })
                    .catch(response => {
                        this.btnDisabled = false;
                        console.log(response);
                    })
            }
        }
    }
    </script>
<style>
    .label_for_input{
        font-size:22px;
    }
    .select_block {
        padding: 20px;
        border-bottom: 1px solid #34373d;
    }
    .sample_btn {
        padding: 10px;
        font-size: 20px;
        margin-top: 35px;
    }
</style>
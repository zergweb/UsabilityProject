<template>
    <section id="login" class="col-md-12">
        <div class="d-flex justify-content-center">
            <div class="col-md-3">
                <label>Login:</label>
                <input type="text" v-model="login" placeholder="login" class="form-control" /><br>
                <label>Pass</label>
                <input type="password" v-model="password" placeholder="pass" class="form-control" /><br>
                <button class="btn btn-sm btn-outline-secondary" v-on:click="loginbtn" v-bind:disabled="btnDisabled">Login</button>
            </div>
        </div>     
    </section>
</template>

<script>
    import Vue from 'vue'
    import { mapActions } from 'vuex'
    import { mapGetters } from 'vuex'
    import Store from '@/store/store';
    import { HTTP } from '@/http/http.js'
    export default {
        name: 'Login',
        data() {
            return {
                login: '',
                password: '',
                btnDisabled:false
            }           
        },
        computed: {
            ...mapGetters('auth', {
                tokenUrl: 'getTokenURL'
            })
        },
        methods: {
            ...mapActions('animate', {
                set_token: 'set_token'
            }),
            loginbtn: function () {
                this.btnDisabled = true;
               // Store.dispatch('token/get_token', token);
                var formData = new FormData();
                formData.append("username", this.login);
                formData.append("password", this.password);
                HTTP.post(this.tokenUrl, formData)
                    .then(response => {
                        console.log(response);
                        Store.dispatch('auth/set_token', response.data.access_token);
                        Store.dispatch('auth/set_roles', response.data.role);
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

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  #login{
      padding-top:100px;
  }
</style>

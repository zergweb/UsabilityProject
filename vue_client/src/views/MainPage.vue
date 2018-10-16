<template> 
    <div>
        <h1>
            Main page
        </h1>
    </div>
</template>
<script>// @ is an alias to /src
    import { mapGetters } from 'vuex'
    import { mapActions } from 'vuex'
    import { HTTP } from '@/http/http'

export default {
        name: 'MainPage',
        components: {

        },
        computed: {

        },
        methods: {
            ...mapActions('token', {
                log_out: 'remove_token',
                get_role: 'get_role',
                get_name: 'get_name'
            })           
        }
    }
    </script>
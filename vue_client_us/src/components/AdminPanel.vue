<template>
    <section class="main">
        
        <AdminSidebar />
        <nav class="navbar navbar-dark bg-dark d-flex justify-content-end nav_main ">
            <button class="btn btn-sm btn-outline-secondary" v-on:click="log_out">logout</button>
        </nav>
        <div class="page-content">
            <router-view />
        </div>
    </section>
</template>

<script>
    import { mapGetters } from 'vuex'
    import { mapActions } from 'vuex'
    import AdminSidebar from '@/components/AdminSidebar.vue'

    export default {
        name: 'AdminPanel',
        components: {
            AdminSidebar
        },
        props: {
            msg: String
        },
        computed: {
            ...mapGetters('auth', {
                token: 'token'
            }),
        },
        methods: {
            ...mapActions('auth', {
                log_out: 'log_out'
            })

        }
    }
</script>

<style>

    .main {
        width: 100%;
    }
    .page-content {
        overflow: hidden;
        background: #22252a;
        min-height: 100vh;
        width: calc(100% - 280px);
        padding: 0;
        padding-top: 40px;
        margin-left: 280px;
    }
</style>

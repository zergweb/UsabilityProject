<template>
    <section class="main">
        <AdminPanel v-if="isAdmin" />
        <UserPanel v-else />
    </section>
</template>

<script>
    import { mapGetters } from 'vuex'
    import { mapActions } from 'vuex'
    import AdminPanel from '@/components/AdminPanel.vue'
    import UserPanel from '@/components/UserPanel.vue'

    export default {
        name: 'MainPanel',
        components: {
            AdminPanel,
            UserPanel
        },
        props: {
            msg: String
        },
        computed: {
            ...mapGetters('auth', {
                isAdmin: 'isAdmin'
            }),
        },
        methods: {
            ...mapActions('auth', {
                log_out: 'remove_token'
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
        margin-left: 280px;
    }
</style>

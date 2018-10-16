<template>
    <div id="app" class="d-flex align-items-stretch">
        <Login v-if="!isAuth"/>
        <MainPanel  v-else  />
    </div>
</template>
<script>
   
    import { mapGetters } from 'vuex'
    import Login from '@/components/LoginForm.vue'
    import MainPanel from '@/views/MainPanel.vue'
    import 'bootstrap/dist/css/bootstrap.min.css'
    import './css/custom.css'
    require('vue2-animate/dist/vue2-animate.min.css')
    export default {
        name: 'app',
        components: {
            Login,
            MainPanel
        },
        data() {
            return {
                animate: {}
            }
        },
        computed: {
            ...mapGetters('auth', {
                isAuth: 'isAuth'
            })
        }
    }
</script>
<style>
p {
        line-height: 1.7;
}
#app {
    font-family: 'Avenir', Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
   
}
.align-items-stretch {
    -ms-flex-align: stretch!important;
    -webkit-box-align: stretch!important;
    align-items: stretch!important;
}
    .d-flex {
        display: -ms-flexbox !important;
        display: -webkit-box !important;
        display: flex !important;
    }
    
    .btn-outline-secondary:active, .btn-outline-secondary.active, .show > .btn-outline-secondary.dropdown-toggle {
        color: #fff;
        background-color: #864DD9 !important;
        border-color: #868e96;
    }
    .btn-outline-secondary:hover {
        color: #fff;
        background-color: #864DD9 !important;
        border-color: #864DD9;
    }
    .btn-outline-secondary:focus {
        color: #fff;
        background-color: #864DD9 !important;
        border-color: #864DD9;
    }
    .btn-sm {
        padding: 0.25rem 0.5rem;
        font-size: 0.875rem;
        line-height: 1.5;
        border-radius: 0.2rem;
    }
    .btn-outline-secondary {
        color: #868e96;
        background-color: transparent;
        background-image: none;
        border-color: #868e96;
    }
        .dashtext-1 {
        color: #864DD9 !important;
    }

    .d-block {
        display: block !important;
    }
    .statistic-block {
        background: #2d3035 !important;
        color: #8a8d93 !important;
    }
    .card-body {
        -ms-flex: 1 1 auto;
        flex: 1 1 auto;
        padding: 1.25rem;
        text-align:left;
    }
</style>

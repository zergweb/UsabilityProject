<template>
    <nav id="sidebar">       
        <ul class="list-unstyled" >
            <li>               
                <router-link to="/manage_bot"
                             active-class="active"
                             class="nav_item"
                              v-on:click.native="change_animate"
                             >
                    <font-awesome-icon icon="dove" />
                    <span class="sidebar_text">Manage Bot</span>
                </router-link>
            </li>
            <li>
                <router-link to="/labs"
                             active-class="active"
                             class="nav_item"
                             v-on:click.native="change_animate"
                             >
                    <font-awesome-icon icon="atom" />
                    <span class="sidebar_text">Labs</span>
                </router-link>
            </li>            
        </ul>
    </nav>
</template>

<script>
    import Vue from 'vue'
    import { library } from '@fortawesome/fontawesome-svg-core'
    import { faAtom } from '@fortawesome/free-solid-svg-icons'
    import { faDove } from '@fortawesome/free-solid-svg-icons'
    import { faCode } from '@fortawesome/free-solid-svg-icons'
    import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
    import { mapActions } from 'vuex'
    library.add(faAtom, faDove, faCode)
    Vue.component('font-awesome-icon', FontAwesomeIcon)
    export default {
        name: 'AdminSidebar',
        methods: {

        }
    }
</script>
<style scoped>
    a.router-link-exact-active.active {
        color: #864DD9 !important;
        background-color: #22252a;
    }
    .nav_item{
        transition: all linear .3s;
    }
    .nav_item:hover {
        color: #864DD9 !important;
        background-color: #22252a;
    }
        .list-unstyled > li > a {
        text-align: left;
        font-size: 1.2em;
    }

        .list-unstyled > li > a > svg {
            margin-right: 30px;
        }

    .sidebar_text {
        border-left: 1px solid #454649;
        padding-left: 20px;
    }
    nav#sidebar span.heading {
        font-weight: 700;
        margin-left: 20px;
        color: #494d53;
        font-size: 1.2rem;
        margin-bottom: 15px;
    }

    nav#sidebar {
        position: fixed;
        height: 100%;
        width: 280px;
        background: #1b1d21;
        color: #6a6c70;
        border-right: 1px solid #34373d;
        z-index:5;
    }

        nav#sidebar ul {
            max-height: none;
        }

    .list-unstyled {
        padding-left: 0;
        list-style: none;
    }

    nav#sidebar li {
        position: relative;
    }`
        nav#sidebar li.active a {
            background: #34373d;
            color: #bfc1c4;
        }
nav#sidebar ul a {
    padding: 18px 20px;
    display: block;
    font-weight: 400;
}
nav#sidebar a {
    color: inherit;
    text-decoration: none;
    position: relative;
}
.list-unstyled > li > a[data-v-7d622f5c] {
    text-align: left;
    font-size: 1.2em;
}
</style>

import Vue from 'vue'
import {HTTP} from '@/http/http.js'
export default {
    namespaced: true,
    state: {
        token: localStorage.getItem("accessToken"),
        endpoints: {
            getTokenURL: '/token/',
            refreshJWT: 'http://0.0.0.0:10000/auth/refresh_token',
            getRoleURL: '/api/values/getrole',
            getNameURL: '/api/values/getlogin',
        },
        roles: []
    },
    getters: {
         token(state) {
             return state.token;
        },
        isAuth(state) {
            if (state.token!=null) {
                return true;
            }
            else {
                return false;
            }            
        },
        isAdmin(state) {   
            if (state.roles.some(function (item) {
                return item == "admin";
            })) {
                return true;
            } else {
                return false;
            }      
        },
        getTokenURL(state) {
            return state.endpoints.getTokenURL;
        }
    },
    mutations: {
        set_roles(state, roles) {
            state.roles = roles;
        },
        updateToken(state, newToken) {
            localStorage.setItem('accessToken', newToken);
            state.token = newToken;
        },
        removeToken(state) {
            localStorage.removeItem('accessToken');
            state.token = null;
        },
        removeRoles(state) {
            state.roles = null;
        }

    },
    actions: {
        set_token(store, token) {         
           store.commit('updateToken', token);
        },
        set_roles(store, roles) {
            store.commit('set_roles', roles);
        },
        get_role(store) {
            HTTP.get(store.state.endpoints.getRoleURL)
                .then(resp => {
                    console.log(resp);
                }).catch(response => {
                    console.log(response);
                })
        },
        get_name(store) {
            HTTP.get(store.state.endpoints.getNameURL)
                .then(resp => {
                    console.log(resp);
                }).catch(response => {
                    console.log(response);
                })
        },
        log_out(store) {
            store.commit('removeToken');
            store.commit('removeRoles');
        },
        
    }
};
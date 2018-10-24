import Vue from 'vue'
import { HTTP } from '@/http/http.js'
export default {
    namespaced: true,
    state: {
        isLoad:false,
        samples: [{ user: {name:' '}}]
    },
    getters: {
        samples(state) {
            return state.samples;
        },
        isLoad(state) {
            return state.isLoad;
        }
    },
    mutations: {
        load_data(state, data) {
            state.samples = data;
        },
        Load_True(state) {
            state.isLoad = true;
        }
    },
    actions: {
        load_data(store) {
            console.log("loaded samples");
            HTTP.get('/samples/last_samples/')
               // .then(response => response.json())
                .then(data => {
                    store.commit('load_data', data.data);
                    store.commit('Load_True');
                });
        }
    }
};
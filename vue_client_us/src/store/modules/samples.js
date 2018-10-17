import Vue from 'vue'
import { HTTP } from '@/http/http.js'
export default {
    namespaced: true,
    state: {
        samples: []
    },
    getters: {
        samples(state) {
            return state.samples;
        }
    },
    mutations: {
        load_data(state, data) {
            state.samples = data;
        }
    },
    actions: {
        load_data(store) {
            console.log("loaded samples");
            HTTP.get('/samples/last_samples/')
               // .then(response => response.json())
                .then(data => {
                    store.commit('load_data', data.data);
                });
        }
    }
};
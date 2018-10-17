import Vue from 'vue'
import VueResource from 'vue-resource'
import App from './App.vue'
import router from './router'
import store from '@/store/store'
import bootstrap from 'vue-cli-plugin-bootstrap' 
import Chart from 'vue2-frappe'
import { HTTP } from '@/http/http'
Vue.config.productionTip = false
Vue.use(bootstrap)
Vue.use(Chart)

HTTP.interceptors.request.use((config) => {
    const token = store.getters['auth/token'];
    if (token) {
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
});
new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')

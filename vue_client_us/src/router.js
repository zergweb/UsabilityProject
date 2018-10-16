import Vue from 'vue'
import Router from 'vue-router'
import Store from './store/store';
Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/main_page',
      name: '/main_page',
      component: () => import('./views/MainPage.vue'),
      beforeEnter(from, to, next) {
             // Store.dispatch('labs/load_data');
              next();
          }
      }
   
    ],
    mode:'history'
})

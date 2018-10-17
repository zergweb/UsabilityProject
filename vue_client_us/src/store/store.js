import Vue from 'vue'
import Vuex from 'vuex'
import auth from './modules/auth'
import samples from './modules/samples'
Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
      auth,
      samples
    },
  state: {
   
  },
  mutations: {

  },
  actions: {

  }
})

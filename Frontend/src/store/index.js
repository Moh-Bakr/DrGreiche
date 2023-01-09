import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    client: "",
    sample: "",
    mode: "add",
  },
  mutations: {
    saveClient(state, client) {
      state.client = client;
    },

    saveSample(state, sample) {
      state.sample = sample;
    },

    setMode(state, mode) {
      state.mode = mode;
    },
  },
  actions: {},
  modules: {},
  getters: {
    getClient(state) {
      return state.client;
    },
    getSample(state) {
      return state.sample;
    },
  },
});

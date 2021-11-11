import App from './App.vue'
import router from './router'
import Vue from 'vue'
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'

import money from 'v-money'
Vue.use(money, {precision: 4})

// Import Bootstrap an BootstrapVue CSS files (order is important)
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

import {
  localize,
  extend,
  ValidationProvider,
  ValidationObserver,
  configure,
} from "vee-validate";
import {
  required,
  email,
  min,
  max,
  confirmed,
  min_value,
  max_value,
} from "vee-validate/dist/rules";

extend("confirmed", confirmed);
extend("min", min);
extend("max", max);
extend("required", required);
extend("email", email);
extend("min_value", min_value);
extend("max_value", max_value);
//Regras customizadas

import pt_BR from "vee-validate/dist/locale/pt_BR.json";
localize("pt_BR", pt_BR);
configure({
  classes: {
    // valid: 'is-valid',
    invalid: "is-invalid",
  },
});
Vue.component("ValidationObserver", ValidationObserver);
Vue.component("ValidationProvider", ValidationProvider);

// Make BootstrapVue available throughout your project
Vue.use(BootstrapVue)
// Optionally install the BootstrapVue icon components plugin
Vue.use(IconsPlugin)

//Vue Mask
//======================================================
import VueTheMask from "vue-the-mask";
Vue.use(VueTheMask);

Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')


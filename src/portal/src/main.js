import Vue from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify'
import axios from "axios"

Vue.config.productionTip = false


axios.defaults.baseURL = process.env.VUE_APP_BASE_URL;
axios.interceptors.request.use((request)=>{
  // const header = getHttpHeader();
  // request.headers = header;
  return request;
});

axios.interceptors.response.use((response)=>{
  return {
    data : response.data,
    hasError : false,
    error:[]
  }
},(error)=>{
  switch(error.response.status){
    case 400: return {
      data:null,
      hasError:true,
      error:[error.response.data]
    }
    case 401:
    console.log(401);  
    break;
  }
})

new Vue({
  vuetify,
  render: h => h(App)
}).$mount('#app')

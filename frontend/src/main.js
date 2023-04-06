import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
// axios.defaults.headers.common['Authorization']='Bearer ' + localStorage.getItem('token');
createApp(App).use(store).use(router).mount('#app')

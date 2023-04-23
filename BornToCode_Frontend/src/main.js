import {createApp} from 'vue'
import App from './App.vue'
import router from './router/router'
import '/css/profile.css'
import '/css/main.css'

const app = createApp(App);

app.use(router);
app.mount('#app')




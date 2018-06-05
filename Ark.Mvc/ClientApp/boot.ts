import './css/site.css';
import 'bootstrap';
import Vue from 'vue';
import VueRouter from 'vue-router';
import Vuetify from 'vuetify';
import 'vuetify/dist/vuetify.min.css';

Vue.use(VueRouter);
Vue.use(Vuetify);

const routes = [
    { path: '/', component: require('./components/home/home.vue') },
    { path: '/counter', component: require('./components/counter/counter.vue') },
    { path: '/fetchdata', component: require('./components/fetchdata/fetchdata.vue') },
    { path: '/comment', component: require('./components/comment/comment.vue') },

    //accounts
    { path: '/login', component: require('./components/account/login.vue') }
];

new Vue({
    el: '#app-root',
    router: new VueRouter({ mode: 'history', routes: routes }),
    render: h => h(require('./components/app/app.vue'))
});

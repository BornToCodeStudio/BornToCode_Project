import Vue from 'vue'
import { createRouter, createWebHistory } from 'vue-router';

import HomePage from '../components/Home-Page.vue'
import SignUp from '../components/SignUp.vue'
import SignIn from '../components/SignIn.vue'
import Profile from '../components/Profile.vue'


const routes = [
    {
        path: '/SignUp',
        name: 'SignUp',
        component: SignUp
    },
    {
        path: '/SignIn',
        name: 'SignIn',
        component: SignIn
    },
    {
        path: '/Profile',
        name: 'Profile',
        component: Profile
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});
export default router;
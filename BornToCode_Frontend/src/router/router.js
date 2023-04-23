import {createRouter, createWebHistory} from 'vue-router';

import SignIn from '../components/SignIn.vue'
import LogIn from '../components/LogIn.vue'
import Profile from '../components/Profile.vue'
import Tasks from '../components/Tasks.vue'


const routes = [
    {
        path: '/SignIn',
        name: 'SignIn',
        component: SignIn
    },
    {
        path: '/LogIn',
        name: 'LogIn',
        component: LogIn
    },
    {
        path: '/Profile',
        name: 'Profile',
        component: Profile
    },
    {
        path: '/Tasks',
        name: 'Tasks',
        component: Tasks
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});
export default router;
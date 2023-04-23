<template>
    <nav class="nav_bar">
        <section class="left__head">
            <router-link to="/Home">
                <button id="home">Home</button>
            </router-link>
        </section>

        <section class="center__head">
            <router-link to="/Tasks">
                <button id="tasks">Tasks</button>
            </router-link>
        </section>

        <section class="right__head">
            <section class="log__sign">
                <router-link to="/SignIn">
                    <button id="sign_in">Sign In</button>
                </router-link>

                <router-link to="/LogIn">
                    <button id="log_in">Log In</button>
                </router-link>
            </section>

            <router-link to="/Profile">
                <button id="profile">Profile</button>
            </router-link>

            <button id="notifications"></button>
        </section>
    </nav>

    <hr>

    <router-view></router-view>
</template>

<script>
import LogIn from './LogIn.vue';
import SignIn from './SignIn.vue';
import Profile from './Profile.vue'
import Tasks from './Tasks.vue'

export default {
    name: "Home-Page",
    components: {
        LogIn,
        SignIn,
        Profile,
        Tasks
    }
}
</script>
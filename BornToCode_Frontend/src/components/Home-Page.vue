<template>  
    <nav class="nav__bar">
        <div class="nav__bar-left">
            <router-link to="/Home">
                <button id="home__button">Home</button>
            </router-link>
        </div>

        <div class="nav__bar-right">

            <div class="auth__block">
                <router-link to="/SignUp">
                    <button id="sign-up__button">Sign Up</button>
                </router-link>

                <router-link to="/SignIn">
                    <button id="sign-in__button">Sign In</button>
                </router-link>
            </div>

            <router-link to="/Profile">
                <button id="profile__button">Profile</button>
            </router-link>

            <button id="notifications__button"></button>
        </div>
    </nav>

    <hr>

    <router-view></router-view>
</template>

<script>
import SignIn from './SignIn.vue';
import SignUp from './SignUp.vue';
import Profile from './Profile.vue'

    export default{
        name: "Home-Page",
        components: {
            SignIn,
            SignUp,
            Profile
        }
}
</script>
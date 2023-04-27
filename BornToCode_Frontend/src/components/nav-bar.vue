<template>
  <nav class="nav__bar">
    <div class="nav__bar-left">
        <router-link to="/">
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
</template>

<script>
export default {
  name: "nav-bar"
};
</script>

<style lang="scss" scoped>
    .nav__bar {
        display: flex;
        flex-direction: row;
        gap: 20px;
        justify-content:space-between;
        padding-left: 15px;
        padding-right: 15px;
        padding-top: 10px;

        .nav__bar-right {
            display: flex;
            gap: 10px;
            flex-direction: row;
        }
    }

    .auth__block {
        display: flex;
        gap: 10px;
        flex-direction: column;
    }

    body {
        margin: 0;
        padding: 0;
    }

    hr {
        background-color: #A0C6F8;
        height: 0.4px;
    }

    #home__button {
        border-radius: 30px;
        border-width: 0px;
        width: 200px;
        height: 50px;
    }

    #sign-up__button {
        border-radius: 15px;
        border-width: 0px;
        width: 70px;
        background-color: #A0C6F8;
    }

    #sign-in__button {
        border-radius: 15px;
        border-width: 0px;
        width: 70px;
        background-color: #A0C6F8;
    }

    #profile__button {
        border-radius: 15px;
        border-width: 0px;
        height: 50px;
        width: 50px;
    }

    #notifications__button {
        border-radius: 10px;
        border-width: 0px;
        height: 50px;
        width: 30px;
        background-color: #99B0ED;
    }
</style>
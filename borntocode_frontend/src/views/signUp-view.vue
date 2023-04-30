<template>
    <div class="SignUp">
        <head>
            <meta charset="utf-8">
            <title>Вход</title>
        </head>
        <div>
            <h1>Регистрация</h1>
            <div class="Block__registration">
                <input class="Login" type="text" ref="login" placeholder="Логин">
                <input class="Password" type="password" ref="password" placeholder="Пароль">
                <input class="Confirmpassword" type="password" ref="confirmPassword" placeholder="Подтверждение пароля">
                <button class="Signup" @click="signUp()">Зарегистрироваться</button>
            </div>
        </div> 
    </div>
</template>

<script>
import axios from 'axios';

export default{
    name: "SignUp",
    components: {

    },
    methods: {
        async signUp() {
            try {
                let login = this.$refs.login.value;
                let password = this.$refs.password.value;
                let confirmPassword = this.$refs.confirmPassword.value;

                if (password != confirmPassword) {
                    alert("Пароли не совпадают");

                    return;
                }

                let dto = {
                    login: login,
                    password: password
                };

                await axios({
                    method: 'post',
                    url: process.env.VUE_APP_API_URL,
                    responseType: 'json',
                    data: dto
                }).then((response) => response).catch((error) => {
                    alert("Ошибка при создании профиля. " + error.response.data);
                });
            } catch (error) {
                console.log(error);
            }
        }
    }
}
</script>


<style lang="scss" scoped>

.Block__registration{
    display: flex;
    justify-content:left;
    gap: 2px;
}

.Login, .Password, .Confirmpassword{
    display: flex;
    flex-direction: column;
    border-radius: 15px;
    border: 2px solid black;
    text-align: center;
    height: 20px;
}

.Signup{
    display: flex;
    flex-direction: column;
    border-radius: 15px;
    border: none;
    height: 26px;
    width: auto;
    text-align: center;
    padding-top: 3px;
    transition: 0.5s;
}

</style>
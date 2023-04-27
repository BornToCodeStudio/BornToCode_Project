<template>
    <div class="SignUp">
        <head>
            <meta charset="utf-8">
            <title>Вход</title>
        </head>
        <div>
            <h1>Регистрация</h1>
            <input type="text" ref="login" placeholder="Логин">
            <input type="password" ref="password" placeholder="Пароль">
            <input type="password" ref="confirmPassword" placeholder="Подтверждение пароля">
            <button @click="signUp()">Зарегистрироваться</button>
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



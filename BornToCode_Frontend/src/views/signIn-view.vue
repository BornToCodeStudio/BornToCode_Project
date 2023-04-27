<template>
    <div class="log__in">
        <h1>Вход</h1>
        <input type="text" ref="login" placeholder="Логин">
        <input type="password" ref="password" placeholder="Пароль">
        <button type="submit" @click="signIn()">Войти</button>
        <p><a href ="">Нету аккаунта? Зарегистрируйтесь</a></p>
    </div>
</template>

<script>
import axios from 'axios';

export default{
    name: "SignIn",
    components: {

    },
    methods: {
        async signIn() {
            try {
                let dto = {
                    login: this.$refs.login.value,
                    password: this.$refs.password.value
                };

                let data = await axios({
                    method: 'post',
                    url: process.env.VUE_APP_API_URL,
                    responseType: 'json',
                    data: dto
                }).then((response) => response).catch((error) => {
                    alert("Не удалось авторизоваться. " + error.response.data);
                });

                if (data.status == 200)
                    alert("Вы успешно авторизованы")
                else if (data.status == 404)
                    alert("Такого профиля не существует")
            } catch (error) {
                console.log(error);
            }
        }
    }
}
</script>
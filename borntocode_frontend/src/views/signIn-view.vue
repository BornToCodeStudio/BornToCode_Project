<template>
    <div class="Main__text">
        <h1>Вход</h1>
    </div>
    <div class="log__in">
        <input class="Login" type="text" ref="login" placeholder="Логин">
        <input class="Password" type="password" ref="password" placeholder="Пароль">
        <button class="Submit" type="submit" @click="signIn()">Войти</button>
        <p><a class="href" href ="">Нету аккаунта? Зарегистрируйтесь</a></p>
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

<style lang="scss" scoped>

.log__in{
    display: flex;
    justify-content:left;
    gap: 2px;
}

.Login, .Password{
    display: flex;
    flex-direction: column;
    border-radius: 15px;
    border: 2px solid black;
    height: 20px;
    text-align: center;
}

.Submit{
    display: flex;
    flex-direction: column;
    border-radius: 15px;
    border: none;
    border-bottom: 10px;
    width: 60px;
    height: 28px;
    padding: 4px;
    transition: 0.5s;
}

.href{
    display: flex;
    flex-direction: column;
    text-align: center;
    margin-top: -12px;
}


</style>
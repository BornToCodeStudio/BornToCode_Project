<template>
    <div class="main__text">Вход</div>
    <a class="href" href ="">Нету аккаунта? Зарегистрируйтесь</a>
    <div class="log__in">
        <input class="login" type="text" ref="login" placeholder="Логин">
        <input class="password" type="password" ref="password" placeholder="Пароль">
        <button class="submit" type="submit" @click="signIn()">Войти</button>
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

.main__text{
    display: flex;
    justify-content: center;
    font-size: 40px;
}

.href{
    display: flex;
    flex-direction: column;
    text-align: center;
    margin-top: -12px;
    font-size: 18px;
}

.log__in{
    display: row;
    position: relative;
    flex-wrap: wrap;
    gap: 2px;
}

.login, .password{
    display: flex;
    flex-direction: column;
    border-radius: 15px;
    border: 2px solid black;
    height: 20px;
    text-align: center;
    margin: auto;
    margin-top: 4px;
}

.submit{
    display: flex;
    flex-direction: column;
    border-radius: 15px;
    border: none;
    border-bottom: 10px;
    width: 60px;
    height: 28px;
    padding: 4px;
    transition: 0.5s;
    margin: auto;
    margin-top: 4px;
}




</style>
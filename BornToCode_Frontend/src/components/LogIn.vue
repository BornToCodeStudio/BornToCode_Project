<template>
    <body>
    <form class="log__in" action="Home-Page.vue" method="get">
        <h1>Вход</h1>
        <input type="text" name="userLogin" placeholder="Логин">
        <input type="password" name="userPassword" placeholder="Пароль">
        <input type="submit" name="" value="Войти">
        <p><a href="">Нету аккаунта? Зарегистрируйтесь</a></p>
    </form>
    </body>
</template>

<script>
export default {
    name: "LogIn",
    components: {}
}
</script>
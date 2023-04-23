<template>
    <div class="SignIn">
        <head>
        <meta charset="utf-8">
        <title>Вход</title>
    </head>
    <body>
        <form class ="sign__in" action="Home-Page.vue" method="get">
            <h1>Регистрация</h1>
            <input type="text" name ="userLogin" placeholder="Логин">
            <input type="password" name ="userPassword" placeholder="Пароль">
            <input type="password" name ="userConfirmPassword" placeholder="Подтверждение пароля">
            <input type="submit" name = "submit" value="Зарегистрироваться">
        </form>
    </body>       
    </div>
</template>

<script>
    export default{
        name: "SignIn",
        components: {

        }
}
</script>



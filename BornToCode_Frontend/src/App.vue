<template>
  <nav-bar/>
  <router-view></router-view>
</template>

<script>
import NavBar from './components/nav-bar.vue'
export default {
  name: 'App',
  components: {
    NavBar
  }
}
</script>
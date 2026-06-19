<script setup>
import Login from './components/Login.vue'
import Productos from './components/Productos.vue'

const token = window.localStorage.getItem('token')
</script>

<template>
  <Productos v-if="token" />
  <Login v-else />
</template>
<script setup>
import { RouterLink, RouterView } from "vue-router";
</script>

<template>
  <header class="header">
    <nav class="navbar">
      <div class="container">
        <RouterLink class="navbar-brand" to="/"> MovieDb </RouterLink>
        <ul class="flex-row gap-2 navbar-nav">
          <li class="nav-item">
            <RouterLink class="nav-link" to="/">Home</RouterLink>
          </li>
          <li class="nav-item">
            <RouterLink class="nav-link" to="/about">About</RouterLink>
          </li>
        </ul>
      </div>
    </nav>
  </header>

  <RouterView />
</template>

<style lang="scss" scoped>
.header {
  background-color: rgba(white, 0.6);
  margin-bottom: 2rem;
  position: fixed;
  width: 100%;
  top: 0;
}
</style>

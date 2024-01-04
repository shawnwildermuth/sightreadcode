<script setup lang="ts">
  import { useRouter } from "vue-router";
</script>

<template>
  <main class="container 
               mx-auto 
               min-h-screen 
               w-full"
               data-theme="business">
    <header class="p-2 
                    flex 
                    justify-between">
      <h1 class="font-bold text-2xl">Sight Read Code</h1>
      <ul class="flex">
        <li class="mx-2"><RouterLink to="/" class="menu-button">Home</RouterLink></li>
        <li class="mx-2"><RouterLink to="/code" class="menu-button">Read Code</RouterLink></li>
      </ul>
    </header>
    <section class="border p-1">
      <RouterView />
    </section>
  </main>
</template>

<style scoped>
.menu-button {
  @apply p-3 bg-gray-500 hover:bg-transparent;
}
</style>


<script setup>
  import { ref, onMounted } from "vue";
  const code = ref("");
  const message = ref("");

  onMounted(async () => {
    const result = await fetch("/api/getcode");
    if (result.status === 200) {
      const data = await result.json();
      code.value = data.code;
    } else {
      message.value = "Don't work";
    }
  });
</script>

<template>
  <h1>Code</h1>
  <div v-if="message">{{  message }}</div>
  <pre>
    {{  code }}
  </pre>
</template>
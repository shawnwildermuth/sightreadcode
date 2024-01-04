<script setup lang="ts">
import { ref, onMounted, reactive } from "vue";
import axios from "axios";
import { type CodeBlock } from "@/models/CodeBlock";

const code = ref("");
const message = ref("");
const answer = reactive({
  answerText: "",
  rating: 5
});

onMounted(async () => {
  const result = await axios.get<CodeBlock>("/api/codeblocks/random");
  if (result.status === 200) {
    const data = await result.data;
    code.value = data.theCode;
  } else {
    message.value = "Don't work";
  }
});

function saveAnswer() {
  alert(answer.answerText);
}
</script>

<template>
  <h1>Code</h1>
  <div v-if="message">{{ message }}</div>
  <pre>
    {{ code }}
  </pre>
  <div class="flex flex-col">
    <h3>Describe what the code does:</h3>
    <div>Rating: </div>
    <textarea rows="8" v-model="answer.answerText"></textarea>

    <div><button @click="saveAnswer" class="btn">Save Answer</button></div>
  </div>
  <pre>
    {{ answer }}
  </pre>
</template>
<script setup>
import { ref } from 'vue';

const msg = ref('hello world');
</script>

<template>
  <h1 className="text-3xl font-bold underline">
    {{ msg }}
  </h1>
</template>

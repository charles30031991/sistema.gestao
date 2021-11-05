<template>
  <div style="background-color: #212529">
    <MenuSuperior msg="Welcome to Your Vue.js App" />
  </div>
</template>

<script>
// @ is an alias to /src
import MenuSuperior from "@/components/MenuSuperior.vue";

export default {
  name: "Home",
  components: {
    MenuSuperior,
  },
};
</script>

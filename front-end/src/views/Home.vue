<template>
  <div style="background-color: #212529">
    <MenuSuperior msg="Welcome to Your Vue.js App" />
  </div>
</template>

<script>
// @ is an alias to /src
import MenuSuperior from "@/components/MenuSuperior.vue";
import auth from "../auth";

export default {
  name: "Home",
  components: {
    MenuSuperior,
  },
  data() {
    return {};
  },
  //   beforeRouteEnter(to, from, next) {
  //   var usuario = auth.getUserInfo();

  //   if (usuario?.userInfo?.nome) {
  //     next();
  //   } else {
  //     next("/login");
  //   }
  // },
  created() {
    var usuario = auth.getUserInfo();

    if (usuario?.userInfo?.nome) {
      this.$router.replace("/");
    } else {
      this.$router.replace("/login");
    }
  },
};
</script>

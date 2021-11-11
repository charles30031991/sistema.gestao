<template>
  <div class="container menuSuperior">
    <b-navbar type="dark" variant="dark">
      <b-navbar-nav class="">
        <b-nav-item href="EmpresaListar">Empresa </b-nav-item>

        <b-nav-item href="FuncionarioListar"> Funcionário</b-nav-item>
      </b-navbar-nav>
    </b-navbar>
  </div>
</template>

<script>
export default {
  name: "MenuSuperior",
  props: {
    msg: String,
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}

.menuSuperior {
  font-size: 20px;
  color: rgb(255, 255, 255) !important;
}
.navbar-dark .navbar-nav .nav-link {
  color: #ffff;
}
</style>

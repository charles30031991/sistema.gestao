<template>
  <div class="page bg-purple-gradient">
    <form class="form-signin">
      <div class="text-center mt-5">
        <a href="#" style="color: white">
          <img
            src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQEzLY__gZ-O6dFM7WKKJfqMWh7oC-UyK901Q&usqp=CAU"
            style="width: 200px; color: white"
          />
          <br />
        </a>
      </div>
      <h1 class="h1 mb-4 font-weight-normal">Olá =)</h1>
      <h1 class="h5 font-weight-normal">Acesso</h1>
      <div class="upik-gradient-thin mb-3"></div>

      <input
        type="email"
        id="inputEmail"
        class="form-control form-control-lg"
        placeholder="Nome"
        v-model="usuario"
        autofocus
      />
      <label for="inputPassword" class="sr-only"></label>
      <input
        type="password"
        id="inputPassword"
        class="form-control form-control-lg"
        placeholder="Senha"
        v-model="senha"
      />

      <button
        @click.prevent="onClickLogin"
        :disabled="loading"
        class="btn bg-yellow btn-lg btn-block"
      >
        <span v-if="!loading">Entrar</span>
        <span v-if="loading">
          <img
            src="https://www.mostdiesel.com/assets/img/loading-double-ring.svg"
            width="32"
          />
          <small class="text-purple">Entrando...</small>
        </span>
      </button>
      <router-link
        to="/esqueciSenha"
        style="
          color: white;
          text-decoration: underline;
          margin-top: 20px;
          display: block;
        "
        >Esqueceu-se da senha?</router-link
      >
    </form>
  </div>
</template>

<script>
import Swal from "sweetalert2";
import axios from "axios";

import Auth from "../auth";
import config from "../config";

export default {
  data() {
    return {
      //config,

      loading: false,
      usuario: "",
      senha: "",
      qtdErroLogin: 0,
    };
  },
  methods: {
    async onClickLogin() {
      if (!this.usuario || !this.senha) {
        return;
      }
      this.loading = true;
      try {
        var data = { nome: this.usuario, senha: this.senha };
        var response = await axios.post(`${config.API_URL}/auth/logar`, data);
        debugger
        Auth.setUserInfo(response.data, response.data.userInfo.token);
        var returnUrl = this.$route.query.returnUrl;
        if (returnUrl) {
          this.$router.replace(decodeURIComponent(returnUrl));
        } else {
          this.$router.replace("/");
        }
      } catch (e) {
        console.error(e);
        this.loading = false;
        if (e.response && e.response.data && e.response.data.invalido) {
          Swal.fire({
            type: "error",
            title: "Oops...",
            text: "O usuário ou senha estão incorretos.",
          });
          this.qtdErroLogin++;
          if (this.qtdErroLogin >= 2) {
            this.$router.push("/esqueciSenha");
          }
          return;
        }
        Swal.fire({
          type: "error",
          title: "Oops...",
          text: "Não foi possível fazer o login. Tente novamente mais tarde ou contate o suporte.",
        });
      }
    },
  },
};
</script>


<style>
.bg-yellow {
  background-color: #ffd503;
  color: #7f0ba4;
}
.form-signin {
  width: 100%;
  max-width: 420px;
  padding: 16px;
  margin: 0 auto;
  margin-top: 120px;
}

.form-signin input[type="email"] {
  margin-bottom: -1px;
  border-bottom-right-radius: 0;
  border-bottom-left-radius: 0;
}

.form-signin input[type="password"] {
  margin-bottom: 10px;
  border-top-left-radius: 0;
  border-top-right-radius: 0;
}

@media (max-width: 992px) {
  .form-signin {
    margin-top: 0;
  }
}
</style>
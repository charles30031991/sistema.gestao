<template>
  <div>
    <div style="background-color: #212529">
      <MenuSuperior msg="Welcome to Your Vue.js App" />
    </div>
    <div class="container">
      <h4 class="my-5">Lista de Funcionários</h4>
      <div class="row">
        <div class="col-6">
          <b-input-group prepend="Nome" class="mb-5">
            <b-form-input aria-label="First name" v-model="nome"></b-form-input>
          </b-input-group>
        </div>
      </div>

      <div class="row">
        <div class="text-center">
          <b-button class="mb-5" variant="success" @click="abrirModal()"
            >Cadastrar</b-button
          >
        </div>
        <div class="col-lg-12 order-lg-2">
          <div>
            <table id="my-table" class="table table-bordered border-primary">
              <thead>
                <tr>
                  <th>Nome</th>
                  <th>Cargo</th>
                  <th>Salário</th>
                  <th>Empresa</th>
                  <th>Ações</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="(item, index) in Funcionarios" :key="index">
                  <td>
                    {{ item.nome }}
                  </td>
                  <td>
                    {{ item.nomeCargo }}
                  </td>
                  <td>
                    {{ item.salario }}
                  </td>
                  <td>
                    {{ item.nomeEmpresa }}
                  </td>
                  <td>
                    <div class="mb-1">
                      <b-button
                        variant="success"
                        @click.prevent="editarModal(item)"
                        >Editar</b-button
                      >
                      <b-button variant="danger" @click.prevent="excluir(item)"
                        >Excluir</b-button
                      >
                      <b-button
                        variant="warning"
                        @click.prevent="visualizarModal(item)"
                        >Visualizar</b-button
                      >
                    </div>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
      <FormularioFuncionario
        @hide="hideModalDados"
        :showModal="showModal"
        :dados="dados"
        :desabilitar="desabilitar"
        :tituloFormulario="tituloFormulario"
      />
    </div>
    <Rodape />
  </div>
</template>

<script>
import Swal from "sweetalert2";
import axios from "axios";
import config from "../config";
import auth from "../auth";
import FormularioFuncionario from "@/components/FormularioFuncionario.vue";
import MenuSuperior from "@/components/MenuSuperior.vue";
import Rodape from "@/components/Rodape.vue";

export default {
  components: {
    FormularioFuncionario,
    MenuSuperior,
    Rodape,
  },
  data() {
    return {
      nome: "",
      Funcionarios: [],
      dados: [],
      tituloFormulario: "",
      showModal: false,
      desabilitar: false,
    };
  },
  beforeRouteEnter(to, from, next) {
    debugger;
    var usuario = auth.getUserInfo();

    if (usuario?.userInfo?.nome) {
      next();
    } else {
      next("/login");
    }
  },
  created() {
    this.carregarDados();
  },
  watch: {
    nome: function (newVal, oldVal) {
      if (newVal != oldVal) {
        this.carregarDados();
      }
    },
  },
  methods: {
    async excluir(item) {
      try {
        let token = auth.getUserInfo().userInfo.token;
        await axios.delete(`${config.API_URL}/Funcionario?id=` + item.id, {
          headers: { Authorization: `Bearer ${token}` },
        });
        Swal.fire("", "Registro Excluido com sucesso", "success");
      } catch (e) {
        Swal.fire({
          type: "error",
          title: "Oops...",
          text: "Erro ao excluir o registro",
        });
        return;
      }
      this.carregarDados();
    },
    hideModalDados() {
      this.showModal = false;
    },
    popular(item) {
      this.dados = {
        nome: item.nome,
        cargo: item.cargo,
        salario: item.salario,
        id: item.id,
        empresa: item.empresaId,
        nomeEmpresa: item.nomeEmpresa,
      };
    },
    editarModal(item) {
      this.popular(item);
      this.showModal = true;
      this.tituloFormulario = "Alterar Funcionario";
      this.desabilitar = false;
    },
    visualizarModal(item) {
      this.popular(item);
      this.showModal = true;
      this.tituloFormulario = "Visualizar Funcionario";
      this.desabilitar = true;
    },
    abrirModal() {
      this.tituloFormulario = "Cadastrar Funcionario";
      this.showModal = true;
      this.desabilitar = false;
    },
    async carregarDados() {
      try {
        let token = auth.getUserInfo().userInfo.token;
        var response = await axios.get(
          `${config.API_URL}/Funcionario?nome=` + this.nome,
          { headers: { Authorization: `Bearer ${token}` } }
        );
        this.Funcionarios = response.data;
      } catch (e) {
        Swal.fire({
          type: "error",
          title: "Oops...",
          text: "Erro ao buscar os dados",
        });
        return;
      }
    },
  },
};
</script>
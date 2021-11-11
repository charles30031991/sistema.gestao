<template>
  <div>
    <div style="background-color: #212529">
      <MenuSuperior msg="Welcome to Your Vue.js App" />
    </div>
    <div class="container">
      <h4 class="my-5">Lista de Empresas</h4>
      <div class="row">
        <div class="col-6">
          <b-input-group prepend="Nome da Empresa" class="mb-5">
            <b-form-input
              aria-label="First name"
              v-model="nomeEmpresa"
            ></b-form-input>
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
                  <th>Telefone</th>
                  <th>Endereco</th>
                  <th>CEP</th>
                  <th>Numero</th>
                  <th>Complemento</th>
                  <th>UF</th>
                  <th>Bairro</th>
                  <th>Cidade</th>
                  <th>Ações</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="(item, index) in empresas" :key="index">
                  <td>
                    {{ item.nome }}
                  </td>
                  <td>
                    {{ item.telefone }}
                  </td>
                  <td>
                    {{ item.endereco }}
                  </td>
                  <td>
                    {{ item.cep }}
                  </td>
                  <td>
                    {{ item.numero }}
                  </td>
                  <td>
                    {{ item.complemento }}
                  </td>
                  <td>
                    {{ item.uf }}
                  </td>
                  <td>
                    {{ item.bairro }}
                  </td>
                  <td>
                    {{ item.localidade }}
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
      <FormularioEmpresa
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
import MenuSuperior from "@/components/MenuSuperior.vue";
import Swal from "sweetalert2";
import axios from "axios";
import config from "../config";
import auth from "../auth";
import FormularioEmpresa from "@/components/FormularioEmpresa.vue";
import Rodape from "@/components/Rodape.vue";

export default {
  components: {
    FormularioEmpresa,
    MenuSuperior,
    Rodape,
  },
  data() {
    return {
      nomeEmpresa: "",
      empresas: [],
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
    nomeEmpresa: function (newVal, oldVal) {
      if (newVal != oldVal) {
        this.carregarDados();
      }
    },
  },
  methods: {
    async excluir(item) {
      try {
        let token = auth.getUserInfo().userInfo.token;
        await axios.delete(`${config.API_URL}/empresa?id=` + item.id, {
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
      debugger;
      this.dados = {
        nome: item.nome,
        telefone: item.telefone,
        endereco: item.endereco,
        numero: item.numero,
        complemento: item.complemento,
        bairro: item.bairro,
        localidade: item.localidade,
        cep: item.cep,
        uf: item.uf,
        id: item.id,
        funcionario: item.funcionario,
        salarioFormatado: item.salarioFormatado,
      };
    },
    editarModal(item) {
      this.popular(item);
      this.showModal = true;
      this.tituloFormulario = "Alterar Empresa";
      this.desabilitar = false;
    },
    visualizarModal(item) {
      this.popular(item);
      this.showModal = true;
      this.tituloFormulario = "Visualizar Empresa";
      this.desabilitar = true;
    },
    abrirModal() {
      this.tituloFormulario = "Cadastrar Empresa";
      this.showModal = true;
      this.desabilitar = false;
    },
    async carregarDados() {
      try {
        let token = auth.getUserInfo().userInfo.token;
        var response = await axios.get(
          `${config.API_URL}/empresa?nome=` + this.nomeEmpresa,
          { headers: { Authorization: `Bearer ${token}` } }
        );
        this.empresas = response.data;
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
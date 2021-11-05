<template>
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
        <b-button class="mb-5" variant="success" @click.prevent="abrirModal()"
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
                  <div class="mb-1">
                    <b-button variant="success">Editar</b-button>
                    <b-button variant="danger">Excluir</b-button>
                    <b-button variant="warning">Visualizar</b-button>
                  </div>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>
    <FormularioEmpresa :showModal="showModal" />
  </div>
</template>

<script>
import Swal from "sweetalert2";
import axios from "axios";
import config from "../config";
import FormularioEmpresa from "@/components/FormularioEmpresa.vue";

export default {
  components: {
    FormularioEmpresa,
  },
  data() {
    return {
      nomeEmpresa: "",
      empresas: [],
      showModal: false,
    };
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
    abrirModal() {
      this.showModal = true;
    },
    async carregarDados() {
      try {
        var response = await axios.get(
          `${config.API_URL}/empresa?nome=` + this.nomeEmpresa
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
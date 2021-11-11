<template>
  <div>
    <b-modal
      :visible="showModal"
      :title="tituloFormulario"
      :hide-footer="true"
      size="lg"
      @hide="hideModal"
    >
      <ValidationObserver v-slot="{ handleSubmit, invalid }">
        <form @submit.prevent="handleSubmit(salvar)">
          <div class="row">
            <div class="col-6">
              <div class="form-group">
                <label>Nome</label>
                <ValidationProvider
                  name="nome"
                  rules="required|min:3"
                  v-slot="{ errors, classes }"
                >
                  <input
                    type="text"
                    class="form-control"
                    v-model="nome"
                    :class="classes"
                    placeholder="Nome"
                    maxlength="200"
                    :disabled="desabilitar"
                  />
                  <span class="invalid-feedback">{{ errors[0] }}</span>
                </ValidationProvider>
              </div>
            </div>

            <div class="col-6">
              <div class="form-group">
                <label>Cargo</label>
                <ValidationProvider
                  name="cargo"
                  rules="required"
                  v-slot="{ errors, classes }"
                >
                  <select
                    class="form-control"
                    v-model="cargo"
                    :class="classes"
                    data-test-id="input-uf"
                    :disabled="desabilitar"
                  >
                    <option value="1">Programador</option>
                    <option value="2">Designer</option>
                    <option value="3">Administração</option>
                  </select>
                  <span class="invalid-feedback">{{ errors[0] }}</span>
                </ValidationProvider>
              </div>
            </div>

            <div class="col-6">
              <b-form-group label="Salário">
                <ValidationProvider
                  name="valor"
                  :rules="'required'"
                  v-slot="{ errors, classes }"
                >
                  <money
                    v-model="salario"
                    v-bind="{
                      decimal: ',',
                      thousands: '.',
                      prefix: 'R$ ',
                      suffix: '',
                      precision: 0,
                    }"
                    :class="['form-control', classes]"
                    data-test-id="input-valor"
                    :disabled="desabilitar"
                  ></money>
                  <span class="invalid-feedback">{{ errors[0] }}</span>
                </ValidationProvider>
              </b-form-group>
            </div>

            <div class="col-6">
              <div class="form-group">
                <label>Empresas</label>
                <ValidationProvider
                  name="uf"
                  rules="required"
                  v-slot="{ errors, classes }"
                >
                  <select
                    class="form-control"
                    v-model="empresa"
                    :class="classes"
                    data-test-id="input-uf"
                    :disabled="desabilitar"
                  >
                    <option
                      v-for="(item, index) in empresas"
                      :key="index"
                      :value="item.id"
                    >
                      {{ item.nome }}
                    </option>
                  </select>
                  <span class="invalid-feedback">{{ errors[0] }}</span>
                </ValidationProvider>
              </div>
            </div>
          </div>

          <hr class="mt-3 mb-3" />
          <di v-show="!desabilitar">
            <button
              class="btn btn-success btn-block"
              type="submit"
              :disabled="loading || invalid"
            >
              <span v-if="loading">Enviando...</span>
              <span v-else>Salvar</span>
            </button>
          </di>
        </form>
      </ValidationObserver>
    </b-modal>
  </div>
</template>

<script>
import Swal from "sweetalert2";
import axios from "axios";
import config from "../config";
import auth from "../auth";

export default {
  props: ["showModal", "dados", "tituloFormulario", "desabilitar"],
  name: "FormularioFuncionario",
  data() {
    return {
      empresa: null,
      empresas: null,
      nome: "",
      id: 0,
      abrirModal: false,
      dadosCompleto: [],
      cargo: 0,
      salario: 0,
      nameState: null,
      loading: false,
      exibirCamposEndereco: false,
    };
  },
  mounted: function () {
    this.carregarDados();
  },
  watch: {
    dados: function (newVal) {
      this.dadosCompleto = newVal;
      debugger;
      this.cargo = this.dadosCompleto?.cargo;
      this.nome = this.dadosCompleto?.nome;
      this.salario = this.dadosCompleto?.salario;
      this.id = this.dadosCompleto?.id;
      this.empresa = this.dadosCompleto?.empresa;
    },
  },
  methods: {
    async carregarDados() {
      try {
        let token = auth.getUserInfo().userInfo.token;
        var response = await axios.get(`${config.API_URL}/empresa?nome=` + "", {
          headers: { Authorization: `Bearer ${token}` },
        });
        this.empresas = response.data;
      } catch (e) {
        Swal.fire({
          type: "error",
          title: "Oops...",
          text: "Erro ao buscar da empresa",
        });
        return;
      }
    },
    hideModal() {
      this.$emit("hide");

      this.cargo = null;
      this.nome = null;
      this.salario = null;
      this.id = null;
      this.empresa = null;
    },
    async salvar() {
      debugger;
      this.loading = true;
      var data = {
        Id: this.id,
        Nome: this.nome,
        Cargo: this.cargo,
        Salario: this.salario,
        EmpresaId: this.empresa,
      };
      let token = auth.getUserInfo().userInfo.token;
      try {
        var resposta = await axios.post(`${config.API_URL}/funcionario`, data, {
          headers: { Authorization: `Bearer ${token}` },
        });
        if (resposta.status == 200) {
          if (this.id > 0)
            Swal.fire("", "Funcionario alterada com sucesso", "success");
          else Swal.fire("", "Funcionario salvar com sucesso", "success");
        } else {
          Swal.fire("", "Erro ao salvar a Funcionario", "error");
        }
      } catch (error) {
        Swal.fire("", "Erro ao salvar a Funcionario", "error");
      }
      this.loading = false;
      this.hideModal();
    },
    checkFormValidity() {
      const valid = this.$refs.form.checkValidity();
      this.nameState = valid;
      return valid;
    },
  },
};
</script>
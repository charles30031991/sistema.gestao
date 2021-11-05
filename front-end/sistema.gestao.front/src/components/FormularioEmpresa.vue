<template>
  <div>
    <b-modal
      :visible="showModal"
      title="Cadastrar Empresa"
      :hide-footer="true"
      @hide="hideModal"
      size="lg"
    >
      <ValidationObserver v-slot="{ handleSubmit, invalid }">
        <form @submit.prevent="handleSubmit(realizarResgate)">
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
                  />
                  <span class="invalid-feedback">{{ errors[0] }}</span>
                </ValidationProvider>
              </div>
            </div>

            <div class="col-6">
              <div class="form-group">
                <label>Telefone</label>
                <ValidationProvider
                  name="telefone"
                  rules="required"
                  v-slot="{ errors, classes }"
                >
                  <input
                    type="tel"
                    class="form-control"
                    v-model="telefone"
                    :class="classes"
                    placeholder="Nome"
                  />
                  <span class="invalid-feedback">{{ errors[0] }}</span>
                </ValidationProvider>
              </div>
            </div>

            <div class="row">
              <div class="col-md-4">
                <div class="form-group">
                  <label>CEP</label>
                  <ValidationProvider
                    name="CEP"
                    rules="required|min:9"
                    v-slot="{ errors, classes }"
                  >
                    <input
                      type="tel"
                      class="form-control"
                      :class="classes"
                      v-model="cep"
                      v-mask="'#####-###'"
                      autocomplete="nope"
                      data-test-id="input-cep"
                    />
                    <span class="invalid-feedback">{{ errors[0] }}</span>
                  </ValidationProvider>
                  <div v-if="loadingCep">
                    <small>Carregando...</small>
                  </div>
                </div>
              </div>
              <div class="col-md-4">
                <div class="form-group">
                  <label>Cidade</label>
                  <ValidationProvider
                    name="cidade"
                    rules="required|min:3"
                    v-slot="{ errors, classes }"
                  >
                    <input
                      type="text"
                      class="form-control"
                      :class="classes"
                      v-model="cidade"
                      autocomplete="nope"
                      maxlength="50"
                      data-test-id="input-cidade"
                    />
                    <span class="invalid-feedback">{{ errors[0] }}</span>
                  </ValidationProvider>
                </div>
              </div>
              <div class="col-md-4">
                <div class="form-group">
                  <label>Estado</label>
                  <ValidationProvider
                    name="estado"
                    rules="required"
                    v-slot="{ errors, classes }"
                  >
                    <select
                      class="form-control"
                      v-model="estado"
                      :class="classes"
                      data-test-id="input-estado"
                    >
                      <option value>Selecione...</option>
                      <option>AC</option>
                      <option>AL</option>
                      <option>AM</option>
                      <option>AP</option>
                      <option>BA</option>
                      <option>CE</option>
                      <option>DF</option>
                      <option>ES</option>
                      <option>GO</option>
                      <option>MA</option>
                      <option>MG</option>
                      <option>MS</option>
                      <option>MT</option>
                      <option>PA</option>
                      <option>PB</option>
                      <option>PE</option>
                      <option>PI</option>
                      <option>PR</option>
                      <option>RJ</option>
                      <option>RN</option>
                      <option>RO</option>
                      <option>RR</option>
                      <option>RS</option>
                      <option>SC</option>
                      <option>SE</option>
                      <option>SP</option>
                      <option>TO</option>
                    </select>
                    <span class="invalid-feedback">{{ errors[0] }}</span>
                  </ValidationProvider>
                </div>
              </div>
            </div>

            <div class="row">
              <div class="col-md-8">
                <div class="form-group">
                  <label>Endereço</label>
                  <ValidationProvider
                    name="endereço"
                    rules="required|min:3"
                    v-slot="{ errors, classes }"
                  >
                    <input
                      type="text"
                      class="form-control"
                      :class="classes"
                      v-model="logradouro"
                      autocomplete="nope"
                      maxlength="100"
                      data-test-id="input-endereco"
                    />
                    <span class="invalid-feedback">{{ errors[0] }}</span>
                  </ValidationProvider>
                </div>
              </div>
              <div class="col-md-4">
                <div class="form-group">
                  <label>Número</label>
                  <ValidationProvider
                    name="número"
                    rules="required"
                    v-slot="{ errors, classes }"
                  >
                    <input
                      type="tel"
                      v-model="numEndereco"
                      class="form-control"
                      :class="classes"
                      autocomplete="nope"
                      maxlength="10"
                      v-mask="'##########'"
                      data-test-id="input-numero-endereco"
                    />
                    <span class="invalid-feedback">{{ errors[0] }}</span>
                  </ValidationProvider>
                </div>
              </div>
            </div>

            <div class="row">
              <div class="col-md-8">
                <div class="form-group">
                  <label>Complemento</label>
                  <input
                    type="text"
                    class="form-control"
                    v-model="complemento"
                    autocomplete="nope"
                    maxlength="100"
                    data-test-id="input-complemento"
                  />
                </div>
              </div>
              <div class="col-md-4">
                <div class="form-group">
                  <label>Bairro</label>
                  <ValidationProvider
                    name="bairro"
                    rules="required|min:3"
                    v-slot="{ errors, classes }"
                  >
                    <input
                      type="text"
                      class="form-control"
                      :class="classes"
                      v-model="bairro"
                      autocomplete="nope"
                      maxlength="100"
                      data-test-id="input-bairro"
                    />
                    <span class="invalid-feedback">{{ errors[0] }}</span>
                  </ValidationProvider>
                </div>
              </div>
            </div>
          </div>
          <hr class="mt-3 mb-3" />
          <button
            class="btn btn-success btn-block"
            type="submit"
            :disabled="loading || invalid"
          >
            <span v-if="loading">Enviando...</span>
            <span v-else>Enviar pedido de resgate</span>
          </button>
        </form>
      </ValidationObserver>
    </b-modal>
  </div>
</template>

<script>
import Swal from "sweetalert2";
import axios from "axios";
import config from "../config";

export default {
  props: ["showModal"],
  name: "FormularioEmpresa",
  data() {
    return {
      name: "",
      telefone: undefined,
      nameState: null,
      //Endereço
      cep: undefined,
      logradouro: undefined,
      cidade: undefined,
      bairro: undefined,
      estado: undefined,
      numEndereco: undefined,
      complemento: undefined,
      loadingCep: false,
      loading: false,
      exibirCamposEndereco: false,
      //Informações pessoais
      idCliente: undefined,
      nome: undefined,
    };
  },
  watch: {
    cep: function (value) {
      clearTimeout(window["debounceCep"]);
      window["debounceCep"] = setTimeout(() => {
        this.buscarEnderecoCep(value);
      }, 700);
    },
  },
  methods: {
    buscarEnderecoCep: function (cep) {
      //Busca apenas se tiver digitado o cep completo
      if (!cep || cep.length < 9) {
        return;
      }

      this.loadingCep = true;

      axios
        .get(`${config.API_URL}/v1/empresa/BuscarEndereco?cep=${cep}`)
        .then((response) => {
          this.loadingCep = false;
          this.exibirCamposEndereco = true;

          //Se não veio os dados
          if (!response.data || !response.data.logradouro) {
            Swal.fire(
              "Atenção!",
              "Não encontramos o CEP informado em nossa base. Por favor, preencha o endereço completo.",
              "warning"
            );
            return;
          }

          //console.log(response);
          this.logradouro = response.data.logradouro;
          this.cidade = response.data.localidade;
          this.bairro = response.data.bairro;
          this.estado = response.data.uf;
        })
        .catch(() => {
          this.loadingCep = false;
          this.exibirCamposEndereco = true;
        });
    },
    hideModal() {
      this.$emit("hide");
    },
    checkFormValidity() {
      const valid = this.$refs.form.checkValidity();
      this.nameState = valid;
      return valid;
    },
  },
};
</script>
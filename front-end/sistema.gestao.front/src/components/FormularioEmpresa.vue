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
                    v-mask="'(##) ####-#####'"
                    placeholder="(00) 0000-00000"
                    :disabled="desabilitar"
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
                      :disabled="desabilitar"
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
                      :disabled="desabilitar"
                    />
                    <span class="invalid-feedback">{{ errors[0] }}</span>
                  </ValidationProvider>
                </div>
              </div>

              <div class="col-md-4">
                <div class="form-group">
                  <label>Estado</label>
                  <ValidationProvider
                    name="uf"
                    rules="required"
                    v-slot="{ errors, classes }"
                  >
                    <select
                      class="form-control"
                      v-model="uf"
                      :class="classes"
                      data-test-id="input-uf"
                      :disabled="desabilitar"
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
                      :disabled="desabilitar"
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
                      v-model="numeroEndereco"
                      class="form-control"
                      :class="classes"
                      autocomplete="nope"
                      maxlength="10"
                      v-mask="'##########'"
                      data-test-id="input-numero-endereco"
                      :disabled="desabilitar"
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
                  <ValidationProvider
                    name="número"
                    rules="required"
                    v-slot="{ errors }"
                  >
                    <input
                      type="text"
                      class="form-control"
                      v-model="complemento"
                      autocomplete="nope"
                      maxlength="100"
                      data-test-id="input-complemento"
                      :disabled="desabilitar"
                    />
                    <span class="invalid-feedback">{{ errors[0] }}</span>
                  </ValidationProvider>
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
                      :disabled="desabilitar"
                    />
                    <span class="invalid-feedback">{{ errors[0] }}</span>
                  </ValidationProvider>
                </div>
              </div>
              <div class="col-md-4">
                <div class="form-group">
                  <label>Senha</label>
                  <ValidationProvider
                    name="senha"
                    rules="required"
                    v-slot="{ errors, classes }"
                  >
                    <input
                      type="password"
                      class="form-control"
                      :class="classes"
                      v-model="senha"
                      autocomplete="nope"
                      data-test-id="input-senha"
                      :disabled="desabilitar"
                    />
                    <span class="invalid-feedback">{{ errors[0] }}</span>
                  </ValidationProvider>
                </div>
              </div>

              <div class="col-md-12">
                <h4>Lista de Funcionários</h4>
                <div class="col-lg-12 order-lg-2">
                  <div>
                    <table
                      id="my-table"
                      class="table table-bordered border-primary"
                    >
                      <thead>
                        <tr>
                          <th>Nome</th>
                          <th>Salário</th>
                        </tr>
                      </thead>
                      <tbody>
                        <tr v-for="(item, index) in Funcionarios" :key="index">
                          <td>
                            {{ item.nome }}
                          </td>

                          <td>
                            {{ item.salario }}
                          </td>
                        </tr>
                      </tbody>
                    </table>
                  </div>
                </div>
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
  name: "FormularioEmpresa",
  data() {
    return {
      nome: "",
      id: 0,
      abrirModal: false,
      dadosCompleto: [],
      telefone: null,
      numeroEndereco: undefined,
      nameState: null,
      senha: null,
      Funcionarios: [],
      //Endereço
      cep: undefined,
      logradouro: undefined,
      cidade: undefined,
      bairro: undefined,
      uf: undefined,
      complemento: undefined,
      loadingCep: false,
      loading: false,
      exibirCamposEndereco: false,
    };
  },
  watch: {
    cep: function (value) {
      clearTimeout(window["debounceCep"]);
      window["debounceCep"] = setTimeout(() => {
        this.buscarEnderecoCep(value);
      }, 700);
    },
    dados: function (newVal) {
      this.dadosCompleto = newVal;
      debugger;
      this.telefone = this.dadosCompleto?.telefone;
      this.nome = this.dadosCompleto?.nome;
      this.numeroEndereco = this.dadosCompleto?.numero;
      this.complemento = this.dadosCompleto?.complemento;
      this.bairro = this.dadosCompleto?.bairro;
      this.cidade = this.dadosCompleto?.localidade;
      this.cep = this.dadosCompleto?.cep;
      this.uf = this.dadosCompleto?.uf;
      this.id = this.dadosCompleto?.id;
      this.Funcionarios = this.dadosCompleto?.funcionario;
    },
  },
  methods: {
    hideModal() {
      this.$emit("hide");

      this.telefone = null;
      this.nome = null;
      this.numeroEndereco = null;
      this.complemento = null;
      this.bairro = null;
      this.cidade = null;
      this.cep = null;
      this.uf = null;
      this.senha = null;
      this.id = 0;
      this.logradouro = null;
      this.Funcionarios = null;
    },
    async salvar() {
      this.loading = true;
      var data = {
        Nome: this.nome,
        Telefone: this.telefone,
        senha: this.senha,
        Endereco: this.logradouro,
        Numero: this.numeroEndereco,
        Complemento: this.complemento,
        Bairro: this.bairro,
        Localidade: this.cidade,
        CEP: this.cep,
        UF: this.uf,
        id: this.id,
      };
      let token = auth.getUserInfo().userInfo.token;
      try {
        var resposta = await axios.post(`${config.API_URL}/empresa`, data, {
          headers: { Authorization: `Bearer ${token}` },
        });
        if (resposta.status == 200) {
          if (this.id > 0)
            Swal.fire("", "Empresa alterada com sucesso", "success");
          else Swal.fire("", "Empresa salvar com sucesso", "success");
        } else {
          Swal.fire("", "Erro ao salvar a empresa", "error");
        }
      } catch (error) {
        Swal.fire("", "Erro ao salvar a empresa", "error");
      }
      this.loading = false;
      this.hideModal();
    },
    buscarEnderecoCep: function (cep) {
      //Busca apenas se tiver digitado o cep completo
      if (!cep || cep.length < 9) {
        return;
      }

      this.loadingCep = true;

      axios
        .get(`${config.API_URL}/empresa/BuscarEndereco?cep=${cep}`)
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

          this.logradouro = response.data.logradouro;
          this.cidade = response.data.localidade;
          this.bairro = response.data.bairro;
          this.uf = response.data.uf;
        })
        .catch(() => {
          this.loadingCep = false;
          this.exibirCamposEndereco = true;
          Swal.fire(
            "Atenção!",
            "Não encontramos o CEP informado em nossa base. Por favor, preencha o endereço completo.",
            "warning"
          );
        });
    },
    checkFormValidity() {
      const valid = this.$refs.form.checkValidity();
      this.nameState = valid;
      return valid;
    },
  },
};
</script>
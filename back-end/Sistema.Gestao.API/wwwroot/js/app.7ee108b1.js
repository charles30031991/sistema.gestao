(function(e){function t(t){for(var o,r,s=t[0],l=t[1],u=t[2],d=0,c=[];d<s.length;d++)r=s[d],Object.prototype.hasOwnProperty.call(n,r)&&n[r]&&c.push(n[r][0]),n[r]=0;for(o in l)Object.prototype.hasOwnProperty.call(l,o)&&(e[o]=l[o]);m&&m(t);while(c.length)c.shift()();return i.push.apply(i,u||[]),a()}function a(){for(var e,t=0;t<i.length;t++){for(var a=i[t],o=!0,r=1;r<a.length;r++){var s=a[r];0!==n[s]&&(o=!1)}o&&(i.splice(t--,1),e=l(l.s=a[0]))}return e}var o={},r={app:0},n={app:0},i=[];function s(e){return l.p+"js/"+({about:"about"}[e]||e)+"."+{about:"9d7c5bf3","chunk-71367435":"c0721c19"}[e]+".js"}function l(t){if(o[t])return o[t].exports;var a=o[t]={i:t,l:!1,exports:{}};return e[t].call(a.exports,a,a.exports,l),a.l=!0,a.exports}l.e=function(e){var t=[],a={"chunk-71367435":1};r[e]?t.push(r[e]):0!==r[e]&&a[e]&&t.push(r[e]=new Promise((function(t,a){for(var o="css/"+({about:"about"}[e]||e)+"."+{about:"31d6cfe0","chunk-71367435":"cbb772ae"}[e]+".css",n=l.p+o,i=document.getElementsByTagName("link"),s=0;s<i.length;s++){var u=i[s],d=u.getAttribute("data-href")||u.getAttribute("href");if("stylesheet"===u.rel&&(d===o||d===n))return t()}var c=document.getElementsByTagName("style");for(s=0;s<c.length;s++){u=c[s],d=u.getAttribute("data-href");if(d===o||d===n)return t()}var m=document.createElement("link");m.rel="stylesheet",m.type="text/css",m.onload=t,m.onerror=function(t){var o=t&&t.target&&t.target.src||n,i=new Error("Loading CSS chunk "+e+" failed.\n("+o+")");i.code="CSS_CHUNK_LOAD_FAILED",i.request=o,delete r[e],m.parentNode.removeChild(m),a(i)},m.href=n;var p=document.getElementsByTagName("head")[0];p.appendChild(m)})).then((function(){r[e]=0})));var o=n[e];if(0!==o)if(o)t.push(o[2]);else{var i=new Promise((function(t,a){o=n[e]=[t,a]}));t.push(o[2]=i);var u,d=document.createElement("script");d.charset="utf-8",d.timeout=120,l.nc&&d.setAttribute("nonce",l.nc),d.src=s(e);var c=new Error;u=function(t){d.onerror=d.onload=null,clearTimeout(m);var a=n[e];if(0!==a){if(a){var o=t&&("load"===t.type?"missing":t.type),r=t&&t.target&&t.target.src;c.message="Loading chunk "+e+" failed.\n("+o+": "+r+")",c.name="ChunkLoadError",c.type=o,c.request=r,a[1](c)}n[e]=void 0}};var m=setTimeout((function(){u({type:"timeout",target:d})}),12e4);d.onerror=d.onload=u,document.head.appendChild(d)}return Promise.all(t)},l.m=e,l.c=o,l.d=function(e,t,a){l.o(e,t)||Object.defineProperty(e,t,{enumerable:!0,get:a})},l.r=function(e){"undefined"!==typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(e,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(e,"__esModule",{value:!0})},l.t=function(e,t){if(1&t&&(e=l(e)),8&t)return e;if(4&t&&"object"===typeof e&&e&&e.__esModule)return e;var a=Object.create(null);if(l.r(a),Object.defineProperty(a,"default",{enumerable:!0,value:e}),2&t&&"string"!=typeof e)for(var o in e)l.d(a,o,function(t){return e[t]}.bind(null,o));return a},l.n=function(e){var t=e&&e.__esModule?function(){return e["default"]}:function(){return e};return l.d(t,"a",t),t},l.o=function(e,t){return Object.prototype.hasOwnProperty.call(e,t)},l.p="/",l.oe=function(e){throw console.error(e),e};var u=window["webpackJsonp"]=window["webpackJsonp"]||[],d=u.push.bind(u);u.push=t,u=u.slice();for(var c=0;c<u.length;c++)t(u[c]);var m=d;i.push([0,"chunk-vendors"]),a()})({0:function(e,t,a){e.exports=a("56d7")},"034f":function(e,t,a){"use strict";a("85ec")},1554:function(e,t,a){},"1ab6":function(e,t,a){"use strict";a("e9c4"),a("ac1f"),a("1276");var o=a("bc3a"),r=a.n(o),n=a("2b0e"),i=new n["default"],s=i;t["a"]={setUserInfo:function(e,t){if(e){var a=JSON.stringify(e);window.localStorage.setItem("UserInfo",a),this.applyAuthorizationHeader(t)}s.$emit("update-login")},getUserName:function(){var e=void 0,t=this.getUserInfo();return t&&t.token&&(e=t.nome?t.nome.split(" ")[0]:"Usuário",t.nomeFantasia&&(e=t.nomeFantasia.length>15?t.nomeFantasia.substring(0,15)+"...":t.nomeFantasia)),e},getUserInfo:function(){var e={},t=window.localStorage.getItem("UserInfo");if(t){e=JSON.parse(t);var a=e.token;this.applyAuthorizationHeader(a)}return e},logout:function(){window.localStorage.removeItem("UserInfo"),this.applyAuthorizationHeader(void 0),s.$emit("update-login")},applyAuthorizationHeader:function(e){r.a.defaults.headers.common["Authorization"]=e?"Bearer ".concat(e):""},isLoggedIn:function(){var e=this.getUserInfo(),t=null===e||void 0===e?void 0:e.token;return!!t&&!!t}}},"56d7":function(e,t,a){"use strict";a.r(t);a("e260"),a("e6cf"),a("cca6"),a("a79d");var o=function(){var e=this,t=e.$createElement,a=e._self._c||t;return a("div",{attrs:{id:"app"}},[a("router-view")],1)},r=[],n=(a("034f"),a("2877")),i={},s=Object(n["a"])(i,o,r,!1,null,null,null),l=s.exports,u=(a("d3b7"),a("3ca3"),a("ddb0"),a("2b0e")),d=a("8c4f"),c=function(){var e=this,t=e.$createElement,a=e._self._c||t;return a("div",{staticStyle:{"background-color":"#212529"}},[a("MenuSuperior",{attrs:{msg:"Welcome to Your Vue.js App"}})],1)},m=[],p=(a("ac1f"),a("5319"),function(){var e=this,t=e.$createElement,a=e._self._c||t;return a("div",{staticClass:"container menuSuperior"},[a("b-navbar",{attrs:{type:"dark",variant:"dark"}},[a("b-navbar-nav",{},[a("b-nav-item",{attrs:{href:"EmpresaListar"}},[e._v("Empresa ")]),a("b-nav-item",{attrs:{href:"FuncionarioListar"}},[e._v(" Funcionário")])],1)],1)],1)}),v=[],f={name:"MenuSuperior",props:{msg:String}},h=f,b=(a("8189"),Object(n["a"])(h,p,v,!1,null,"4c3b1eef",null)),g=b.exports,_=a("1ab6"),C={name:"Home",components:{MenuSuperior:g},data:function(){return{}},created:function(){var e,t=_["a"].getUserInfo();null!==t&&void 0!==t&&null!==(e=t.userInfo)&&void 0!==e&&e.nome?this.$router.replace("/"):this.$router.replace("/login")}},w=C,k=Object(n["a"])(w,c,m,!1,null,null,null),y=k.exports,x=function(){var e=this,t=e.$createElement,a=e._self._c||t;return a("div",[a("div",{staticStyle:{"background-color":"#212529"}},[a("MenuSuperior",{attrs:{msg:"Welcome to Your Vue.js App"}})],1),a("div",{staticClass:"container"},[a("h4",{staticClass:"my-5"},[e._v("Lista de Empresas")]),a("div",{staticClass:"row"},[a("div",{staticClass:"col-6"},[a("b-input-group",{staticClass:"mb-5",attrs:{prepend:"Nome da Empresa"}},[a("b-form-input",{attrs:{"aria-label":"First name"},model:{value:e.nomeEmpresa,callback:function(t){e.nomeEmpresa=t},expression:"nomeEmpresa"}})],1)],1)]),a("div",{staticClass:"row"},[a("div",{staticClass:"text-center"},[a("b-button",{staticClass:"mb-5",attrs:{variant:"success"},on:{click:function(t){return e.abrirModal()}}},[e._v("Cadastrar")])],1),a("div",{staticClass:"col-lg-12 order-lg-2"},[a("div",[a("table",{staticClass:"table table-bordered border-primary",attrs:{id:"my-table"}},[e._m(0),a("tbody",e._l(e.empresas,(function(t,o){return a("tr",{key:o},[a("td",[e._v(" "+e._s(t.nome)+" ")]),a("td",[e._v(" "+e._s(t.telefone)+" ")]),a("td",[e._v(" "+e._s(t.endereco)+" ")]),a("td",[e._v(" "+e._s(t.cep)+" ")]),a("td",[e._v(" "+e._s(t.numero)+" ")]),a("td",[e._v(" "+e._s(t.complemento)+" ")]),a("td",[e._v(" "+e._s(t.uf)+" ")]),a("td",[e._v(" "+e._s(t.bairro)+" ")]),a("td",[e._v(" "+e._s(t.localidade)+" ")]),a("td",[a("div",{staticClass:"mb-1"},[a("b-button",{attrs:{variant:"success"},on:{click:function(a){return a.preventDefault(),e.editarModal(t)}}},[e._v("Editar")]),a("b-button",{attrs:{variant:"danger"},on:{click:function(a){return a.preventDefault(),e.excluir(t)}}},[e._v("Excluir")]),a("b-button",{attrs:{variant:"warning"},on:{click:function(a){return a.preventDefault(),e.visualizarModal(t)}}},[e._v("Visualizar")])],1)])])})),0)])])])]),a("FormularioEmpresa",{attrs:{showModal:e.showModal,dados:e.dados,desabilitar:e.desabilitar,tituloFormulario:e.tituloFormulario},on:{hide:e.hideModalDados}})],1),a("Rodape")],1)},E=[function(){var e=this,t=e.$createElement,a=e._self._c||t;return a("thead",[a("tr",[a("th",[e._v("Nome")]),a("th",[e._v("Telefone")]),a("th",[e._v("Endereco")]),a("th",[e._v("CEP")]),a("th",[e._v("Numero")]),a("th",[e._v("Complemento")]),a("th",[e._v("UF")]),a("th",[e._v("Bairro")]),a("th",[e._v("Cidade")]),a("th",[e._v("Ações")])])])}],F=a("1da1"),S=(a("96cf"),a("3d20")),P=a.n(S),M=a("bc3a"),O=a.n(M),A=a("db49"),I=function(){var e=this,t=e.$createElement,a=e._self._c||t;return a("div",[a("b-modal",{attrs:{visible:e.showModal,title:e.tituloFormulario,"hide-footer":!0,size:"lg"},on:{hide:e.hideModal}},[a("ValidationObserver",{scopedSlots:e._u([{key:"default",fn:function(t){var o=t.handleSubmit,r=t.invalid;return[a("form",{on:{submit:function(t){return t.preventDefault(),o(e.salvar)}}},[a("div",{staticClass:"row"},[a("div",{staticClass:"col-6"},[a("div",{staticClass:"form-group"},[a("label",[e._v("Nome")]),a("ValidationProvider",{attrs:{name:"nome",rules:"required|min:3"},scopedSlots:e._u([{key:"default",fn:function(t){var o=t.errors,r=t.classes;return[a("input",{directives:[{name:"model",rawName:"v-model",value:e.nome,expression:"nome"}],staticClass:"form-control",class:r,attrs:{type:"text",placeholder:"Nome",maxlength:"200",disabled:e.desabilitar},domProps:{value:e.nome},on:{input:function(t){t.target.composing||(e.nome=t.target.value)}}}),a("span",{staticClass:"invalid-feedback"},[e._v(e._s(o[0]))])]}}],null,!0)})],1)]),a("div",{staticClass:"col-6"},[a("div",{staticClass:"form-group"},[a("label",[e._v("Telefone")]),a("ValidationProvider",{attrs:{name:"telefone",rules:"required"},scopedSlots:e._u([{key:"default",fn:function(t){var o=t.errors,r=t.classes;return[a("input",{directives:[{name:"model",rawName:"v-model",value:e.telefone,expression:"telefone"},{name:"mask",rawName:"v-mask",value:"(##) ####-#####",expression:"'(##) ####-#####'"}],staticClass:"form-control",class:r,attrs:{type:"tel",placeholder:"(00) 0000-00000",disabled:e.desabilitar},domProps:{value:e.telefone},on:{input:function(t){t.target.composing||(e.telefone=t.target.value)}}}),a("span",{staticClass:"invalid-feedback"},[e._v(e._s(o[0]))])]}}],null,!0)})],1)]),a("div",{staticClass:"row"},[a("div",{staticClass:"col-md-4"},[a("div",{staticClass:"form-group"},[a("label",[e._v("CEP")]),a("ValidationProvider",{attrs:{name:"CEP",rules:"required|min:9"},scopedSlots:e._u([{key:"default",fn:function(t){var o=t.errors,r=t.classes;return[a("input",{directives:[{name:"model",rawName:"v-model",value:e.cep,expression:"cep"},{name:"mask",rawName:"v-mask",value:"#####-###",expression:"'#####-###'"}],staticClass:"form-control",class:r,attrs:{type:"tel",autocomplete:"nope","data-test-id":"input-cep",disabled:e.desabilitar},domProps:{value:e.cep},on:{input:function(t){t.target.composing||(e.cep=t.target.value)}}}),a("span",{staticClass:"invalid-feedback"},[e._v(e._s(o[0]))])]}}],null,!0)}),e.loadingCep?a("div",[a("small",[e._v("Carregando...")])]):e._e()],1)]),a("div",{staticClass:"col-md-4"},[a("div",{staticClass:"form-group"},[a("label",[e._v("Cidade")]),a("ValidationProvider",{attrs:{name:"cidade",rules:"required|min:3"},scopedSlots:e._u([{key:"default",fn:function(t){var o=t.errors,r=t.classes;return[a("input",{directives:[{name:"model",rawName:"v-model",value:e.cidade,expression:"cidade"}],staticClass:"form-control",class:r,attrs:{type:"text",autocomplete:"nope",maxlength:"50","data-test-id":"input-cidade",disabled:e.desabilitar},domProps:{value:e.cidade},on:{input:function(t){t.target.composing||(e.cidade=t.target.value)}}}),a("span",{staticClass:"invalid-feedback"},[e._v(e._s(o[0]))])]}}],null,!0)})],1)]),a("div",{staticClass:"col-md-4"},[a("div",{staticClass:"form-group"},[a("label",[e._v("Estado")]),a("ValidationProvider",{attrs:{name:"uf",rules:"required"},scopedSlots:e._u([{key:"default",fn:function(t){var o=t.errors,r=t.classes;return[a("select",{directives:[{name:"model",rawName:"v-model",value:e.uf,expression:"uf"}],staticClass:"form-control",class:r,attrs:{"data-test-id":"input-uf",disabled:e.desabilitar},on:{change:function(t){var a=Array.prototype.filter.call(t.target.options,(function(e){return e.selected})).map((function(e){var t="_value"in e?e._value:e.value;return t}));e.uf=t.target.multiple?a:a[0]}}},[a("option",{attrs:{value:""}},[e._v("Selecione...")]),a("option",[e._v("AC")]),a("option",[e._v("AL")]),a("option",[e._v("AM")]),a("option",[e._v("AP")]),a("option",[e._v("BA")]),a("option",[e._v("CE")]),a("option",[e._v("DF")]),a("option",[e._v("ES")]),a("option",[e._v("GO")]),a("option",[e._v("MA")]),a("option",[e._v("MG")]),a("option",[e._v("MS")]),a("option",[e._v("MT")]),a("option",[e._v("PA")]),a("option",[e._v("PB")]),a("option",[e._v("PE")]),a("option",[e._v("PI")]),a("option",[e._v("PR")]),a("option",[e._v("RJ")]),a("option",[e._v("RN")]),a("option",[e._v("RO")]),a("option",[e._v("RR")]),a("option",[e._v("RS")]),a("option",[e._v("SC")]),a("option",[e._v("SE")]),a("option",[e._v("SP")]),a("option",[e._v("TO")])]),a("span",{staticClass:"invalid-feedback"},[e._v(e._s(o[0]))])]}}],null,!0)})],1)])]),a("div",{staticClass:"row"},[a("div",{staticClass:"col-md-8"},[a("div",{staticClass:"form-group"},[a("label",[e._v("Endereço")]),a("ValidationProvider",{attrs:{name:"endereço",rules:"required|min:3"},scopedSlots:e._u([{key:"default",fn:function(t){var o=t.errors,r=t.classes;return[a("input",{directives:[{name:"model",rawName:"v-model",value:e.logradouro,expression:"logradouro"}],staticClass:"form-control",class:r,attrs:{type:"text",autocomplete:"nope",maxlength:"100","data-test-id":"input-endereco",disabled:e.desabilitar},domProps:{value:e.logradouro},on:{input:function(t){t.target.composing||(e.logradouro=t.target.value)}}}),a("span",{staticClass:"invalid-feedback"},[e._v(e._s(o[0]))])]}}],null,!0)})],1)]),a("div",{staticClass:"col-md-4"},[a("div",{staticClass:"form-group"},[a("label",[e._v("Número")]),a("ValidationProvider",{attrs:{name:"número",rules:"required"},scopedSlots:e._u([{key:"default",fn:function(t){var o=t.errors,r=t.classes;return[a("input",{directives:[{name:"model",rawName:"v-model",value:e.numeroEndereco,expression:"numeroEndereco"},{name:"mask",rawName:"v-mask",value:"##########",expression:"'##########'"}],staticClass:"form-control",class:r,attrs:{type:"tel",autocomplete:"nope",maxlength:"10","data-test-id":"input-numero-endereco",disabled:e.desabilitar},domProps:{value:e.numeroEndereco},on:{input:function(t){t.target.composing||(e.numeroEndereco=t.target.value)}}}),a("span",{staticClass:"invalid-feedback"},[e._v(e._s(o[0]))])]}}],null,!0)})],1)])]),a("div",{staticClass:"row"},[a("div",{staticClass:"col-md-8"},[a("div",{staticClass:"form-group"},[a("label",[e._v("Complemento")]),a("ValidationProvider",{attrs:{name:"número",rules:"required"},scopedSlots:e._u([{key:"default",fn:function(t){var o=t.errors;return[a("input",{directives:[{name:"model",rawName:"v-model",value:e.complemento,expression:"complemento"}],staticClass:"form-control",attrs:{type:"text",autocomplete:"nope",maxlength:"100","data-test-id":"input-complemento",disabled:e.desabilitar},domProps:{value:e.complemento},on:{input:function(t){t.target.composing||(e.complemento=t.target.value)}}}),a("span",{staticClass:"invalid-feedback"},[e._v(e._s(o[0]))])]}}],null,!0)})],1)]),a("div",{staticClass:"col-md-4"},[a("div",{staticClass:"form-group"},[a("label",[e._v("Bairro")]),a("ValidationProvider",{attrs:{name:"bairro",rules:"required|min:3"},scopedSlots:e._u([{key:"default",fn:function(t){var o=t.errors,r=t.classes;return[a("input",{directives:[{name:"model",rawName:"v-model",value:e.bairro,expression:"bairro"}],staticClass:"form-control",class:r,attrs:{type:"text",autocomplete:"nope",maxlength:"100","data-test-id":"input-bairro",disabled:e.desabilitar},domProps:{value:e.bairro},on:{input:function(t){t.target.composing||(e.bairro=t.target.value)}}}),a("span",{staticClass:"invalid-feedback"},[e._v(e._s(o[0]))])]}}],null,!0)})],1)]),a("div",{staticClass:"col-md-4"},[a("div",{staticClass:"form-group"},[a("label",[e._v("Senha")]),a("ValidationProvider",{attrs:{name:"senha",rules:"required"},scopedSlots:e._u([{key:"default",fn:function(t){var o=t.errors,r=t.classes;return[a("input",{directives:[{name:"model",rawName:"v-model",value:e.senha,expression:"senha"}],staticClass:"form-control",class:r,attrs:{type:"password",autocomplete:"nope","data-test-id":"input-senha",disabled:e.desabilitar},domProps:{value:e.senha},on:{input:function(t){t.target.composing||(e.senha=t.target.value)}}}),a("span",{staticClass:"invalid-feedback"},[e._v(e._s(o[0]))])]}}],null,!0)})],1)]),a("div",{staticClass:"col-md-12"},[a("h4",[e._v("Lista de Funcionários")]),a("div",{staticClass:"col-lg-12 order-lg-2"},[a("div",[a("table",{staticClass:"table table-bordered border-primary",attrs:{id:"my-table"}},[a("thead",[a("tr",[a("th",[e._v("Nome")]),a("th",[e._v("Salário")])])]),a("tbody",e._l(e.Funcionarios,(function(t,o){return a("tr",{key:o},[a("td",[e._v(" "+e._s(t.nome)+" ")]),a("td",[e._v(" "+e._s(t.salarioFormatado)+" ")])])})),0)])])])])])]),a("hr",{staticClass:"mt-3 mb-3"}),a("di",{directives:[{name:"show",rawName:"v-show",value:!e.desabilitar,expression:"!desabilitar"}]},[a("button",{staticClass:"btn btn-success btn-block",attrs:{type:"submit",disabled:e.loading||r}},[e.loading?a("span",[e._v("Enviando...")]):a("span",[e._v("Salvar")])])])],1)]}}])})],1)],1)},N=[],R=(a("99af"),{props:["showModal","dados","tituloFormulario","desabilitar"],name:"FormularioEmpresa",data:function(){return{nome:"",id:0,abrirModal:!1,dadosCompleto:[],telefone:null,numeroEndereco:void 0,nameState:null,senha:null,Funcionarios:[],cep:void 0,logradouro:void 0,cidade:void 0,bairro:void 0,uf:void 0,complemento:void 0,loadingCep:!1,loading:!1,exibirCamposEndereco:!1}},watch:{cep:function(e){var t=this;clearTimeout(window["debounceCep"]),window["debounceCep"]=setTimeout((function(){t.buscarEnderecoCep(e)}),700)},dados:function(e){var t,a,o,r,n,i,s,l,u,d;this.dadosCompleto=e,this.telefone=null===(t=this.dadosCompleto)||void 0===t?void 0:t.telefone,this.nome=null===(a=this.dadosCompleto)||void 0===a?void 0:a.nome,this.numeroEndereco=null===(o=this.dadosCompleto)||void 0===o?void 0:o.numero,this.complemento=null===(r=this.dadosCompleto)||void 0===r?void 0:r.complemento,this.bairro=null===(n=this.dadosCompleto)||void 0===n?void 0:n.bairro,this.cidade=null===(i=this.dadosCompleto)||void 0===i?void 0:i.localidade,this.cep=null===(s=this.dadosCompleto)||void 0===s?void 0:s.cep,this.uf=null===(l=this.dadosCompleto)||void 0===l?void 0:l.uf,this.id=null===(u=this.dadosCompleto)||void 0===u?void 0:u.id,this.Funcionarios=null===(d=this.dadosCompleto)||void 0===d?void 0:d.funcionario}},methods:{hideModal:function(){this.$emit("hide"),this.telefone=null,this.nome=null,this.numeroEndereco=null,this.complemento=null,this.bairro=null,this.cidade=null,this.cep=null,this.uf=null,this.senha=null,this.id=0,this.logradouro=null,this.Funcionarios=null},salvar:function(){var e=this;return Object(F["a"])(regeneratorRuntime.mark((function t(){var a,o,r;return regeneratorRuntime.wrap((function(t){while(1)switch(t.prev=t.next){case 0:return e.loading=!0,a={Nome:e.nome,Telefone:e.telefone,senha:e.senha,Endereco:e.logradouro,Numero:e.numeroEndereco,Complemento:e.complemento,Bairro:e.bairro,Localidade:e.cidade,CEP:e.cep,UF:e.uf,id:e.id},o=_["a"].getUserInfo().userInfo.token,t.prev=3,t.next=6,O.a.post("".concat(A["a"].API_URL,"/empresa"),a,{headers:{Authorization:"Bearer ".concat(o)}});case 6:r=t.sent,200==r.status?e.id>0?P.a.fire("","Empresa alterada com sucesso","success"):P.a.fire("","Empresa salvar com sucesso","success"):P.a.fire("","Erro ao salvar a empresa","error"),t.next=13;break;case 10:t.prev=10,t.t0=t["catch"](3),P.a.fire("","Erro ao salvar a empresa","error");case 13:e.loading=!1,e.hideModal();case 15:case"end":return t.stop()}}),t,null,[[3,10]])})))()},buscarEnderecoCep:function(e){var t=this;!e||e.length<9||(this.loadingCep=!0,O.a.get("".concat(A["a"].API_URL,"/empresa/BuscarEndereco?cep=").concat(e)).then((function(e){t.loadingCep=!1,t.exibirCamposEndereco=!0,e.data&&e.data.logradouro?(t.logradouro=e.data.logradouro,t.cidade=e.data.localidade,t.bairro=e.data.bairro,t.uf=e.data.uf):P.a.fire("Atenção!","Não encontramos o CEP informado em nossa base. Por favor, preencha o endereço completo.","warning")})).catch((function(){t.loadingCep=!1,t.exibirCamposEndereco=!0,P.a.fire("Atenção!","Não encontramos o CEP informado em nossa base. Por favor, preencha o endereço completo.","warning")})))},checkFormValidity:function(){var e=this.$refs.form.checkValidity();return this.nameState=e,e}}}),j=R,U=Object(n["a"])(j,I,N,!1,null,null,null),V=U.exports,D=function(){var e=this,t=e.$createElement,a=e._self._c||t;return a("div",[a("footer",{staticClass:"footer"},[a("div",{staticClass:"container"},[a("div",{staticClass:"text-white"},[e._v(" Desenvolvido por Charles "),a("a",{staticClass:"text-white",attrs:{href:"https://github.com/charles30031991?tab=repositories"}},[a("b-icon",{attrs:{icon:"github"}}),e._v(" GitHub")],1)])])])])},L=[],z=(a("5c42"),{}),$=Object(n["a"])(z,D,L,!1,null,"224ae38d",null),B=$.exports,q={components:{FormularioEmpresa:V,MenuSuperior:g,Rodape:B},data:function(){return{nomeEmpresa:"",empresas:[],dados:[],tituloFormulario:"",showModal:!1,desabilitar:!1}},beforeRouteEnter:function(e,t,a){var o,r=_["a"].getUserInfo();null!==r&&void 0!==r&&null!==(o=r.userInfo)&&void 0!==o&&o.nome?a():a("/login")},created:function(){this.carregarDados()},watch:{nomeEmpresa:function(e,t){e!=t&&this.carregarDados()}},methods:{excluir:function(e){var t=this;return Object(F["a"])(regeneratorRuntime.mark((function a(){var o;return regeneratorRuntime.wrap((function(a){while(1)switch(a.prev=a.next){case 0:return a.prev=0,o=_["a"].getUserInfo().userInfo.token,a.next=4,O.a.delete("".concat(A["a"].API_URL,"/empresa?id=")+e.id,{headers:{Authorization:"Bearer ".concat(o)}});case 4:P.a.fire("","Registro Excluido com sucesso","success"),a.next=11;break;case 7:return a.prev=7,a.t0=a["catch"](0),P.a.fire({type:"error",title:"Oops...",text:"Erro ao excluir o registro"}),a.abrupt("return");case 11:t.carregarDados();case 12:case"end":return a.stop()}}),a,null,[[0,7]])})))()},hideModalDados:function(){this.showModal=!1},popular:function(e){this.dados={nome:e.nome,telefone:e.telefone,endereco:e.endereco,numero:e.numero,complemento:e.complemento,bairro:e.bairro,localidade:e.localidade,cep:e.cep,uf:e.uf,id:e.id,funcionario:e.funcionario,salarioFormatado:e.salarioFormatado}},editarModal:function(e){this.popular(e),this.showModal=!0,this.tituloFormulario="Alterar Empresa",this.desabilitar=!1},visualizarModal:function(e){this.popular(e),this.showModal=!0,this.tituloFormulario="Visualizar Empresa",this.desabilitar=!0},abrirModal:function(){this.tituloFormulario="Cadastrar Empresa",this.showModal=!0,this.desabilitar=!1},carregarDados:function(){var e=this;return Object(F["a"])(regeneratorRuntime.mark((function t(){var a,o;return regeneratorRuntime.wrap((function(t){while(1)switch(t.prev=t.next){case 0:return t.prev=0,a=_["a"].getUserInfo().userInfo.token,t.next=4,O.a.get("".concat(A["a"].API_URL,"/empresa?nome=")+e.nomeEmpresa,{headers:{Authorization:"Bearer ".concat(a)}});case 4:o=t.sent,e.empresas=o.data,t.next=12;break;case 8:return t.prev=8,t.t0=t["catch"](0),P.a.fire({type:"error",title:"Oops...",text:"Erro ao buscar os dados"}),t.abrupt("return");case 12:case"end":return t.stop()}}),t,null,[[0,8]])})))()}}},T=q,H=Object(n["a"])(T,x,E,!1,null,null,null),J=H.exports,G=function(){var e=this,t=e.$createElement,a=e._self._c||t;return a("div",[a("div",{staticStyle:{"background-color":"#212529"}},[a("MenuSuperior",{attrs:{msg:"Welcome to Your Vue.js App"}})],1),a("div",{staticClass:"container"},[a("h4",{staticClass:"my-5"},[e._v("Lista de Funcionários")]),a("div",{staticClass:"row"},[a("div",{staticClass:"col-6"},[a("b-input-group",{staticClass:"mb-5",attrs:{prepend:"Nome"}},[a("b-form-input",{attrs:{"aria-label":"First name"},model:{value:e.nome,callback:function(t){e.nome=t},expression:"nome"}})],1)],1)]),a("div",{staticClass:"row"},[a("div",{staticClass:"text-center"},[a("b-button",{staticClass:"mb-5",attrs:{variant:"success"},on:{click:function(t){return e.abrirModal()}}},[e._v("Cadastrar")])],1),a("div",{staticClass:"col-lg-12 order-lg-2"},[a("div",[a("table",{staticClass:"table table-bordered border-primary",attrs:{id:"my-table"}},[e._m(0),a("tbody",e._l(e.Funcionarios,(function(t,o){return a("tr",{key:o},[a("td",[e._v(" "+e._s(t.nome)+" ")]),a("td",[e._v(" "+e._s(t.nomeCargo)+" ")]),a("td",[e._v(" "+e._s(t.salarioFormatado)+" ")]),a("td",[e._v(" "+e._s(t.nomeEmpresa)+" ")]),a("td",[a("div",{staticClass:"mb-1"},[a("b-button",{attrs:{variant:"success"},on:{click:function(a){return a.preventDefault(),e.editarModal(t)}}},[e._v("Editar")]),a("b-button",{attrs:{variant:"danger"},on:{click:function(a){return a.preventDefault(),e.excluir(t)}}},[e._v("Excluir")]),a("b-button",{attrs:{variant:"warning"},on:{click:function(a){return a.preventDefault(),e.visualizarModal(t)}}},[e._v("Visualizar")])],1)])])})),0)])])])]),a("FormularioFuncionario",{attrs:{showModal:e.showModal,dados:e.dados,desabilitar:e.desabilitar,tituloFormulario:e.tituloFormulario},on:{hide:e.hideModalDados}})],1),a("Rodape")],1)},W=[function(){var e=this,t=e.$createElement,a=e._self._c||t;return a("thead",[a("tr",[a("th",[e._v("Nome")]),a("th",[e._v("Cargo")]),a("th",[e._v("Salário")]),a("th",[e._v("Empresa")]),a("th",[e._v("Ações")])])])}],Y=function(){var e=this,t=e.$createElement,a=e._self._c||t;return a("div",[a("b-modal",{attrs:{visible:e.showModal,title:e.tituloFormulario,"hide-footer":!0,size:"lg"},on:{hide:e.hideModal}},[a("ValidationObserver",{scopedSlots:e._u([{key:"default",fn:function(t){var o=t.handleSubmit,r=t.invalid;return[a("form",{on:{submit:function(t){return t.preventDefault(),o(e.salvar)}}},[a("div",{staticClass:"row"},[a("div",{staticClass:"col-6"},[a("div",{staticClass:"form-group"},[a("label",[e._v("Nome")]),a("ValidationProvider",{attrs:{name:"nome",rules:"required|min:3"},scopedSlots:e._u([{key:"default",fn:function(t){var o=t.errors,r=t.classes;return[a("input",{directives:[{name:"model",rawName:"v-model",value:e.nome,expression:"nome"}],staticClass:"form-control",class:r,attrs:{type:"text",placeholder:"Nome",maxlength:"200",disabled:e.desabilitar},domProps:{value:e.nome},on:{input:function(t){t.target.composing||(e.nome=t.target.value)}}}),a("span",{staticClass:"invalid-feedback"},[e._v(e._s(o[0]))])]}}],null,!0)})],1)]),a("div",{staticClass:"col-6"},[a("div",{staticClass:"form-group"},[a("label",[e._v("Cargo")]),a("ValidationProvider",{attrs:{name:"cargo",rules:"required"},scopedSlots:e._u([{key:"default",fn:function(t){var o=t.errors,r=t.classes;return[a("select",{directives:[{name:"model",rawName:"v-model",value:e.cargo,expression:"cargo"}],staticClass:"form-control",class:r,attrs:{"data-test-id":"input-uf",disabled:e.desabilitar},on:{change:function(t){var a=Array.prototype.filter.call(t.target.options,(function(e){return e.selected})).map((function(e){var t="_value"in e?e._value:e.value;return t}));e.cargo=t.target.multiple?a:a[0]}}},[a("option",{attrs:{value:"1"}},[e._v("Programador")]),a("option",{attrs:{value:"2"}},[e._v("Designer")]),a("option",{attrs:{value:"3"}},[e._v("Administração")])]),a("span",{staticClass:"invalid-feedback"},[e._v(e._s(o[0]))])]}}],null,!0)})],1)]),a("div",{staticClass:"col-6"},[a("b-form-group",{attrs:{label:"Salário"}},[a("ValidationProvider",{attrs:{name:"valor",rules:"required"},scopedSlots:e._u([{key:"default",fn:function(t){var o=t.errors,r=t.classes;return[a("money",e._b({class:["form-control",r],attrs:{"data-test-id":"input-valor",disabled:e.desabilitar},model:{value:e.salario,callback:function(t){e.salario=t},expression:"salario"}},"money",{decimal:",",thousands:".",prefix:"R$ ",suffix:"",precision:0},!1)),a("span",{staticClass:"invalid-feedback"},[e._v(e._s(o[0]))])]}}],null,!0)})],1)],1),a("div",{staticClass:"col-6"},[a("div",{staticClass:"form-group"},[a("label",[e._v("Empresas")]),a("ValidationProvider",{attrs:{name:"uf",rules:"required"},scopedSlots:e._u([{key:"default",fn:function(t){var o=t.errors,r=t.classes;return[a("select",{directives:[{name:"model",rawName:"v-model",value:e.empresa,expression:"empresa"}],staticClass:"form-control",class:r,attrs:{"data-test-id":"input-uf",disabled:e.desabilitar},on:{change:function(t){var a=Array.prototype.filter.call(t.target.options,(function(e){return e.selected})).map((function(e){var t="_value"in e?e._value:e.value;return t}));e.empresa=t.target.multiple?a:a[0]}}},e._l(e.empresas,(function(t,o){return a("option",{key:o,domProps:{value:t.id}},[e._v(" "+e._s(t.nome)+" ")])})),0),a("span",{staticClass:"invalid-feedback"},[e._v(e._s(o[0]))])]}}],null,!0)})],1)])]),a("hr",{staticClass:"mt-3 mb-3"}),a("di",{directives:[{name:"show",rawName:"v-show",value:!e.desabilitar,expression:"!desabilitar"}]},[a("button",{staticClass:"btn btn-success btn-block",attrs:{type:"submit",disabled:e.loading||r}},[e.loading?a("span",[e._v("Enviando...")]):a("span",[e._v("Salvar")])])])],1)]}}])})],1)],1)},K=[],Q={props:["showModal","dados","tituloFormulario","desabilitar"],name:"FormularioFuncionario",data:function(){return{empresa:null,empresas:null,nome:"",id:0,abrirModal:!1,dadosCompleto:[],cargo:0,salario:0,nameState:null,loading:!1,exibirCamposEndereco:!1}},mounted:function(){this.carregarDados()},watch:{dados:function(e){var t,a,o,r,n;this.dadosCompleto=e,this.cargo=null===(t=this.dadosCompleto)||void 0===t?void 0:t.cargo,this.nome=null===(a=this.dadosCompleto)||void 0===a?void 0:a.nome,this.salario=null===(o=this.dadosCompleto)||void 0===o?void 0:o.salario,this.id=null===(r=this.dadosCompleto)||void 0===r?void 0:r.id,this.empresa=null===(n=this.dadosCompleto)||void 0===n?void 0:n.empresa}},methods:{carregarDados:function(){var e=this;return Object(F["a"])(regeneratorRuntime.mark((function t(){var a,o;return regeneratorRuntime.wrap((function(t){while(1)switch(t.prev=t.next){case 0:return t.prev=0,a=_["a"].getUserInfo().userInfo.token,t.next=4,O.a.get("".concat(A["a"].API_URL,"/empresa?nome=")+"",{headers:{Authorization:"Bearer ".concat(a)}});case 4:o=t.sent,e.empresas=o.data,t.next=12;break;case 8:return t.prev=8,t.t0=t["catch"](0),P.a.fire({type:"error",title:"Oops...",text:"Erro ao buscar da empresa"}),t.abrupt("return");case 12:case"end":return t.stop()}}),t,null,[[0,8]])})))()},hideModal:function(){this.$emit("hide"),this.cargo=null,this.nome=null,this.salario=null,this.id=null,this.empresa=null},salvar:function(){var e=this;return Object(F["a"])(regeneratorRuntime.mark((function t(){var a,o,r;return regeneratorRuntime.wrap((function(t){while(1)switch(t.prev=t.next){case 0:return e.loading=!0,a={Id:e.id,Nome:e.nome,Cargo:e.cargo,Salario:e.salario,EmpresaId:e.empresa},o=_["a"].getUserInfo().userInfo.token,t.prev=4,t.next=7,O.a.post("".concat(A["a"].API_URL,"/funcionario"),a,{headers:{Authorization:"Bearer ".concat(o)}});case 7:r=t.sent,200==r.status?e.id>0?P.a.fire("","Funcionario alterada com sucesso","success"):P.a.fire("","Funcionario salvar com sucesso","success"):P.a.fire("","Erro ao salvar a Funcionario","error"),t.next=14;break;case 11:t.prev=11,t.t0=t["catch"](4),P.a.fire("","Erro ao salvar a Funcionario","error");case 14:e.loading=!1,e.hideModal();case 16:case"end":return t.stop()}}),t,null,[[4,11]])})))()},checkFormValidity:function(){var e=this.$refs.form.checkValidity();return this.nameState=e,e}}},X=Q,Z=Object(n["a"])(X,Y,K,!1,null,null,null),ee=Z.exports,te={components:{FormularioFuncionario:ee,MenuSuperior:g,Rodape:B},data:function(){return{nome:"",Funcionarios:[],dados:[],tituloFormulario:"",showModal:!1,desabilitar:!1}},beforeRouteEnter:function(e,t,a){var o,r=_["a"].getUserInfo();null!==r&&void 0!==r&&null!==(o=r.userInfo)&&void 0!==o&&o.nome?a():a("/login")},created:function(){this.carregarDados()},watch:{nome:function(e,t){e!=t&&this.carregarDados()}},methods:{excluir:function(e){var t=this;return Object(F["a"])(regeneratorRuntime.mark((function a(){var o;return regeneratorRuntime.wrap((function(a){while(1)switch(a.prev=a.next){case 0:return a.prev=0,o=_["a"].getUserInfo().userInfo.token,a.next=4,O.a.delete("".concat(A["a"].API_URL,"/Funcionario?id=")+e.id,{headers:{Authorization:"Bearer ".concat(o)}});case 4:P.a.fire("","Registro Excluido com sucesso","success"),a.next=11;break;case 7:return a.prev=7,a.t0=a["catch"](0),P.a.fire({type:"error",title:"Oops...",text:"Erro ao excluir o registro"}),a.abrupt("return");case 11:t.carregarDados();case 12:case"end":return a.stop()}}),a,null,[[0,7]])})))()},hideModalDados:function(){this.showModal=!1},popular:function(e){this.dados={nome:e.nome,cargo:e.cargo,salario:e.salario,id:e.id,empresa:e.empresaId,nomeEmpresa:e.nomeEmpresa}},editarModal:function(e){this.popular(e),this.showModal=!0,this.tituloFormulario="Alterar Funcionario",this.desabilitar=!1},visualizarModal:function(e){this.popular(e),this.showModal=!0,this.tituloFormulario="Visualizar Funcionario",this.desabilitar=!0},abrirModal:function(){this.tituloFormulario="Cadastrar Funcionario",this.showModal=!0,this.desabilitar=!1},carregarDados:function(){var e=this;return Object(F["a"])(regeneratorRuntime.mark((function t(){var a,o;return regeneratorRuntime.wrap((function(t){while(1)switch(t.prev=t.next){case 0:return t.prev=0,a=_["a"].getUserInfo().userInfo.token,t.next=4,O.a.get("".concat(A["a"].API_URL,"/Funcionario?nome=")+e.nome,{headers:{Authorization:"Bearer ".concat(a)}});case 4:o=t.sent,e.Funcionarios=o.data,t.next=12;break;case 8:return t.prev=8,t.t0=t["catch"](0),P.a.fire({type:"error",title:"Oops...",text:"Erro ao buscar os dados"}),t.abrupt("return");case 12:case"end":return t.stop()}}),t,null,[[0,8]])})))()}}},ae=te,oe=Object(n["a"])(ae,G,W,!1,null,null,null),re=oe.exports;u["default"].use(d["a"]);var ne=[{path:"/",name:"Home",component:y},{path:"/empresaListar",name:"EmpresaListar",component:J},{path:"/funcionarioListar",name:"FuncionarioListar",component:re},{path:"/about",name:"About",component:function(){return a.e("about").then(a.bind(null,"f820"))}},{path:"/login",name:"Login",component:function(){return a.e("chunk-71367435").then(a.bind(null,"a55b"))}}],ie=new d["a"]({mode:"history",base:"/",routes:ne}),se=ie,le=a("5f5b"),ue=a("b1e0"),de=a("716b"),ce=a.n(de),me=(a("f9e3"),a("2dd8"),a("7bb1")),pe=a("4c93"),ve=a("38a9"),fe=a("3a60"),he=a.n(fe);u["default"].use(ce.a,{precision:4}),Object(me["d"])("confirmed",pe["a"]),Object(me["d"])("min",pe["e"]),Object(me["d"])("max",pe["c"]),Object(me["d"])("required",pe["g"]),Object(me["d"])("email",pe["b"]),Object(me["d"])("min_value",pe["f"]),Object(me["d"])("max_value",pe["d"]),Object(me["e"])("pt_BR",ve),Object(me["c"])({classes:{invalid:"is-invalid"}}),u["default"].component("ValidationObserver",me["a"]),u["default"].component("ValidationProvider",me["b"]),u["default"].use(le["a"]),u["default"].use(ue["a"]),u["default"].use(he.a),u["default"].config.productionTip=!1,new u["default"]({router:se,render:function(e){return e(l)}}).$mount("#app")},"5c42":function(e,t,a){"use strict";a("f89d")},8189:function(e,t,a){"use strict";a("1554")},"85ec":function(e,t,a){},db49:function(e,t,a){"use strict";t["a"]={API_URL:"http://sistemagestao.azurewebsites.net/api"}},f89d:function(e,t,a){}});
//# sourceMappingURL=app.7ee108b1.js.map
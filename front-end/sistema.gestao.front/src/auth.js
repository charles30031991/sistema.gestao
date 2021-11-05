import axios from "axios";
import EventBus from "./eventBus";

export default {
  setUserInfo(userInfo, token) {
    if (userInfo) {
      var v = JSON.stringify(userInfo);
      window.localStorage.setItem("UserInfo", v);

      this.applyAuthorizationHeader(token);
    }
    EventBus.$emit("update-login");
  },
  getUserName() {
    var userName = undefined;
    var userInfo = this.getUserInfo();
    if (userInfo && userInfo.token) {
      userName = userInfo.nome ? userInfo.nome.split(" ")[0] : "Usuário";

      if (userInfo.nomeFantasia)
        userName =
          userInfo.nomeFantasia.length > 15
            ? userInfo.nomeFantasia.substring(0, 15) + "..."
            : userInfo.nomeFantasia;
    }

    return userName;
  },

  getUserInfo() {
    var userInfo = {};

    var value = window.localStorage.getItem("UserInfo");
    if (value) {
      userInfo = JSON.parse(value);
      var token = userInfo.token;
      debugger
      this.applyAuthorizationHeader(token);
    }
    return userInfo;
  },

  logout() {
    window.localStorage.removeItem("UserInfo");
    this.applyAuthorizationHeader(undefined);
    EventBus.$emit("update-login");
  },
  applyAuthorizationHeader(token) {
    debugger
    axios.defaults.headers.common["Authorization"] = token
      ? `Bearer ${token}`
      : "";
  },
  isLoggedIn() {
    var userInfo = this.getUserInfo();
    var token = userInfo?.token;

    if (!token) {
      return false;
    }

    return !!token;
  },
};
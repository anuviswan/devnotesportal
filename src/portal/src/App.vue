<template>
  <v-app id="inspire">
    <Navbar v-on:drawerSelectionChanged="drawerSelectionChangedHandler" />

    <Menu :drawer="drawer" />

    <v-main class="grey lighten-2">
      <Home />
    </v-main>
  </v-app>
</template>

<script>
import Home from "./components/Home.vue";
import Navbar from "./components/Navbar.vue";
import Menu from "./components/Menu.vue";
export default {
  name: "App",

  components: {
    Home,
    Navbar,
    Menu,
  },

  data: () => ({ drawer: null }),
  methods: {
    drawerSelectionChangedHandler() {
      this.drawer = !this.drawer;
    },
  },
};
</script>

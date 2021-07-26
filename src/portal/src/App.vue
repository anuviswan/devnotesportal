<template>
  <v-app id="inspire">
    <Navbar v-on:drawerSelectionChanged="drawerSelectionChangedHandler" />

    <Menu :drawer="drawer" v-on:itemSelectionChanged="onItemSelectionChanged" />

    <v-main class="grey lighten-2">
      <Home
        v-on:sketchesLoaded="onSketchesLoaded"
        :selectedTag="currentSelectedTag"
      />
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

  data() {
    return {
      drawer: null,
      currentSelectedTag: "",
    };
  },
  methods: {
    drawerSelectionChangedHandler() {
      this.drawer = !this.drawer;
    },
    onSketchesLoaded() {},
    onItemSelectionChanged(item) {
      this.currentSelectedTag = item;
    },
  },
};
</script>

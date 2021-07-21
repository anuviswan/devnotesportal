<template>
  <v-app id="inspire">
    <v-app-bar app color="blue" dense dark>
      <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>

      <v-toolbar-title>Developer Sketch Notes</v-toolbar-title>
      <v-btn icon>
        <v-icon>mdi-bird</v-icon>
      </v-btn>
      <v-subheader>Sketch your learnings</v-subheader>
    </v-app-bar>

    <v-navigation-drawer v-model="drawer" fixed temporary>
      <!--  -->
    </v-navigation-drawer>

    <v-main class="grey lighten-2">
      <Home />
    </v-main>
  </v-app>
</template>

<script>
import Home from "./components/Home.vue";
export default {
  name: "App",

  components: {
    Home,
  },

  data: () => ({ drawer: null }),
};
</script>

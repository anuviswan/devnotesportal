<template>
  <v-app>
    <v-app-bar color="blue" dense dark app>
      <Navbar />
    </v-app-bar>

    <v-main>
      <Home />
    </v-main>
  </v-app>
</template>

<script>
import Home from "./components/Home";
import Navbar from "./components/Navbar";
export default {
  name: "App",

  components: {
    Home,
    Navbar,
  },

  data: () => ({
    //
  }),
};
</script>

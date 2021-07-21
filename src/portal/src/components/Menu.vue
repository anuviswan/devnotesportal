<template>
  <v-navigation-drawer v-model="drawer" fixed temporary>
    <!--  -->
  </v-navigation-drawer>
</template>

<script>
export default {
  name: "Menu",
  data() {
    return {
      items: [
        { title: "Home", icon: "mdi-view-dashboard" },
        { title: "About", icon: "mdi-forum" },
        { title: "About1", icon: "mdi-forum" },
      ],
    };
  },
  props: {
    drawer: null,
  },
};
</script>

<style></style>

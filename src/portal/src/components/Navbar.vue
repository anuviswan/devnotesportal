<template>
  <v-app-bar app color="blue" dense dark>
    <v-app-bar-nav-icon @click="notifyShowDrawer"></v-app-bar-nav-icon>

    <v-toolbar-title>Developer Sketch Notes</v-toolbar-title>
    <v-btn icon>
      <v-icon>mdi-bird</v-icon>
    </v-btn>
    <v-subheader>Sketch your learnings</v-subheader>
  </v-app-bar>
</template>

<script>
export default {
  name: "Navbar",
  methods: {
    notifyShowDrawer() {
      this.$emit("drawerSelectionChanged");
    },
  },
};
</script>

<style></style>

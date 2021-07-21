<template>
  <v-app-bar color="blue" dense dark app elevate-on-scroll>
    <v-app-bar-title>Developer Sketch Notes</v-app-bar-title>
    <v-btn icon>
      <v-icon>mdi-bird</v-icon>
    </v-btn>
    <v-subheader :inset="inset">Sketch your learnings</v-subheader>
    <v-spacer />
    <v-btn icon>
      <v-icon>mdi-magnify</v-icon>
    </v-btn>
  </v-app-bar>
</template>

<script>
export default {
  name: "Navbar",
};
</script>

<style></style>

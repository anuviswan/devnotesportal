<template>
  <v-container>
    <v-row>
      <v-col
        v-for="item in sketchesCollection"
        :key="item.title"
        cols="6"
        md="2"
      >
        <v-sheet height="150">Data {{ item.title }}</v-sheet>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import { getSketches } from "../apis/sketches";
export default {
  name: "Home",
  data: () => {
    return {
      sketchesCollection: [],
    };
  },
  props: ["selectedTag"],
  methods: {
    async loadImages(tag) {
      this.sketchesCollection = await getSketches(tag);
      console.log(this.sketchesCollection);
    },
  },
  watch: {
    selectedTag: function(tag) {
      this.loadImages(tag);
    },
  },
};
</script>

<style></style>

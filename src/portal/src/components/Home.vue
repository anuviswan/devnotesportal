<template>
  <v-container>
    <v-row>
      <template v-for="n in 4">
        <v-col :key="n" class="mt-2" cols="12">
          <strong>Category {{ n }}</strong>
        </v-col>

        <v-col v-for="j in 6" :key="`${n}${j}`" cols="6" md="2">
          <v-sheet height="150">Data {{ j }}</v-sheet>
        </v-col>
      </template>
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

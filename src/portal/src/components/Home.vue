<template>
  <v-container>
    <v-row>
      <v-col v-for="item in sketchesCollection" :key="item.id" cols="6" md="2">
        <v-sheet height="150">
          <v-card>
            <v-img max-height="120" v-bind:src="item.url"></v-img>
            <v-card-subtitle>{{ item.title }}</v-card-subtitle>
            <v-card-text class="text--disabled">{{
              item.description
            }}</v-card-text>
          </v-card>
        </v-sheet>
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
      if (tag) {
        this.sketchesCollection = await getSketches(tag);
        console.log(this.sketchesCollection);
      }
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

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
  async created() {
    this.sketchesCollection = await getSketches("DotNet");
    this.$emit("sketchesLoaded");
    console.log(this.sketchesCollection);
  },
};
</script>

<style></style>

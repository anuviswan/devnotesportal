<template>
  <v-navigation-drawer v-model="drawer" fixed temporary dense nav>
    <v-list dense nav>
      <v-list-item v-for="item in items" :key="item" link>
        <v-list-item-content>
          <v-list-item-title>
            {{ item }}
          </v-list-item-title>
        </v-list-item-content>
      </v-list-item>
    </v-list>
  </v-navigation-drawer>
</template>

<script>
import { getTags } from "../apis/sketches";
export default {
  name: "Menu",
  data() {
    return {
      items: [],
    };
  },
  props: {
    drawer: null,
  },
  async created() {
    this.items = await getTags();
    this.$emit("itemSelectionChanged");
    console.log(this.items);
  },
};
</script>

<style></style>

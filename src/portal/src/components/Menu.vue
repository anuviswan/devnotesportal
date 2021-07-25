<template>
  <v-navigation-drawer app fixed permanent dense nav clipped>
    <v-list dense nav>
      <v-list-item v-for="item in items" :key="item" link>
        <v-list-item-content>
          <v-list-item-title @click="onSelection(item)">
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
      currentSelection: "",
    };
  },
  async created() {
    this.items = await getTags();
    this.$emit("itemSelectionChanged", this.items[0]);
  },
  methods: {
    onSelection(item) {
      if (this.currentSelection !== item) {
        this.currentSelection = item;
        this.$emit("itemSelectionChanged", item);
        return;
      }

      console.log("reselection");
    },
  },
};
</script>

<style></style>

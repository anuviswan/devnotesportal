<template>
  <v-navigation-drawer app fixed permanent dense nav clipped>
    <v-list dense nav>
      <v-list-item v-for="item in items" :key="item.id" link>
        <v-list-item-content>
          <v-list-item-title @click="onSelection(item.id)">
            {{ item.title }}
          </v-list-item-title>
        </v-list-item-content>
      </v-list-item>
    </v-list>
    <v-divider></v-divider>
    <v-list dense nav>
      <v-list-item link>
        <v-list-item-content>
          <v-list-item-title>
            About
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
      currentSelection: 0,
    };
  },
  async created() {
    this.items = await getTags();
    this.$emit("itemSelectionChanged", this.items[0]);
  },
  methods: {
    onSelection(selectedId) {
      if (this.currentSelection !== selectedId) {
        this.currentSelection = selectedId;
        console.log(this.currentSelection);
        this.$emit("itemSelectionChanged", this.currentSelection);
        return;
      }

      console.log("reselection");
    },
  },
};
</script>

<style></style>

<script>
import rssItems from "@/assets/data/rss.json";
import CardItem from "./CardItem.vue";
import Masonry from "masonry-layout";

export default {
  data() {
    return {
      cardItems: rssItems,
    };
  },
  components: { CardItem },
  mounted() {
    // initialize masonry
    var row = document.querySelector("[data-masonry]");
    new Masonry(row, {
      // options
      percentPosition: true,
    });
  },
};
</script>

<template>
  <div
    class="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-3"
    data-masonry='{"percentPosition": true }'
  >
    <div class="col" v-for="item in cardItems" v-bind:key="item.ImageUrl">
      <CardItem
        :img="item.ImageName"
        v-bind:title="item.Title"
        v-bind:link="item.Link"
      ></CardItem>
    </div>
  </div>
</template>

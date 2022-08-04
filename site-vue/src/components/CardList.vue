<script>
import rssItems from "@/assets/data/rss.json";
import CardItem from "./CardItem.vue";

export default {
  data() {
    return {
      cardItems: rssItems,
    };
  },
  components: { CardItem },
};
</script>

<template>
  <div class="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-3">
    <div class="col" v-for="item in cardItems" v-bind:key="item.ImageUrl">
      <CardItem
        :img="item.ImageName"
        v-bind:title="item.Title"
        v-bind:link="item.Link"
      ></CardItem>
    </div>
  </div>
</template>

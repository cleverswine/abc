<script>
import rssItems from "@/assets/data/rss.json";
import VueMasonryWall from "@yeger/vue-masonry-wall";

export default {
  data() {
    return {
      cardItems: rssItems,
    };
  },
  components: { VueMasonryWall },
};
</script>

<template>
  <vue-masonry-wall :items="cardItems" :gap="10" :column-width="300">
    <template v-slot:default="{ item }">
      <div class="item">
        <div class="card shadow-sm">
          <a :href="item.Link">
            <img
              :src="`/images/` + item.ImageName"
              class="card-img-top img-fluid"
              :alt="item.Title"
            />
          </a>
          <div class="card-body">
            <h6 class="card-subtitle mb-2 text-muted">{{ item.Title }}</h6>
          </div>
        </div>
      </div>
    </template>
  </vue-masonry-wall>
</template>

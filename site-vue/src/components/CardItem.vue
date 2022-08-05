<script>
export default {
  props: {
    title: String,
    img: String,
    link: String,
  },
};
</script>
<template>
  <div class="card shadow-sm">
    <a :href="link">
      <img :src="`/images/` + img" class="card-img-top img-fluid" :alt="title" />
    </a>
    <div class="card-body">
      <h6 class="card-subtitle mb-2 text-muted">{{ title }}</h6>
    </div>
  </div>
</template>

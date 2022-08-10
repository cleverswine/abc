<script setup>
import CardList from "./components/CardList.vue";
</script>

<template>
  <main>
    <section class="text-center container">
      <div class="row py-lg-2">
        <div class="col-lg-10 col-md-8 mx-auto">
          <img
            src="@/assets/logo.jpg"
            class="img-fluid"
            alt="Auntie Boo Crafts"
          />
          <p class="lead" style="color: #00567b">
            Welcome to Auntie Boo Crafts!
          </p>
          <p class="text-muted">
            I'm passionate about creating handcrafted and personalized items. I
            specialize in tumblers, mugs, glitter pens, key chains, badge reels,
            phone grips and bag charms. I have something for every price point.
            Almost all items can be customized. I love working with customers to
            create something unique and personal.
          </p>
          <p class="lead">
            <a
              href="https://www.etsy.com/shop/AuntieBooCrafts"
              style="color: #00567b"
              >Visit my shop on Etsy</a
            >
          </p>
        </div>
      </div>
    </section>

    <div class="pb-5 pt-2 bg-light">
      <div class="container">
        <div class="text-center">
          <h2 class="border-bottom border-top py-2 my-4" style="color: #00567b">
            Recent Work
          </h2>
        </div>
        <CardList />
      </div>
    </div>
  </main>

  <footer class="text-muted py-5">
    <div class="container">
      <div class="row">
        <div class="col-xs-12 col-md-4 text-sm-center text-md-start">
          &#169; Auntie Boo Crafts 2022
        </div>
        <div class="col-xs-12 col-md-4 text-sm-center text-md-center">
          <button
            href="https://www.etsy.com/shop/AuntieBooCrafts"
            type="button"
            class="btn rounded-circle btn-outline-secondary me-2"
          >
            <i class="fa-brands fa-etsy"></i>
          </button>
          <button
            href="https://www.etsy.com/shop/auntieboocrafts/rss"
            type="button"
            class="btn rounded-circle btn-outline-secondary me-2"
          >
            <i class="fa-solid fa-rss"></i>
          </button>
        </div>
        <div class="col-xs-12 col-md-4 text-sm-center text-md-end">
          <a href="#" style="color: #00567b">Back to top</a>
        </div>
      </div>
    </div>
  </footer>
</template>

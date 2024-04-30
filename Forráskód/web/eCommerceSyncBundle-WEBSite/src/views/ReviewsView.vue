<script setup>
//get comments to forms tag
import axios from 'axios';

import { ref, onMounted } from 'vue';

//db settings
const reviews = ref([]);

onMounted(() => {
    axios.get("http://localhost:3000/reviews")
    .then((resp) => {
        reviews.value = resp.data
    });
});

</script>

<template>
  <!--here are the comments-->
  <div class="flex justify-center">
    <RouterLink to="/AddReview">
      <button class="bg-red-700 hover:bg-red-900 text-white font-bold py-2 px-4 rounded text-center  my-4">
           Véleményírás
      </button>
   </RouterLink>
  </div>

<div class="w-full sm:max-w-xs md:max-w-lg lg:max-w-xl xl:max-w-2xl mt-1 mx-auto" v-for="r in reviews">
  <form class="bg-white shadow-md rounded px-8 pt-6 pb-8 mb-4">

    <div class="mb-4">
      <label class="block text-gray-700 text-sm font-bold mb-2" for="email">{{ r.email }}</label>
    </div>

    <div class="mb-6">
      <label class="block text-gray-700 text-sm font-bold mb-2" for="review">{{ r.review }}</label>
    </div>
    
  </form>
</div>
</template>


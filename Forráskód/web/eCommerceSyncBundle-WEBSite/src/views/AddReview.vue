<script setup>
import axios from 'axios';

import { reactive } from 'vue';

import { useRouter } from 'vue-router';

//userout navigation to reviews page
const router = useRouter();

//db settings
const newreview = () => {
    axios.post("http://localhost:3000/reviews", review)
    .then(() => {
    router.push("/ReviewsView");
   });
};

//add review 
const review = reactive({
  email:'',
  review:''

});

//email validation
const validemail = (email) =>
{
  const regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

  return regex.test(email);
};

</script>

<!--post forms setting-->
<template>
<div class="w-full max-w-xs mt-3 mx-auto">
  <form @submit.prevent="newreview">
    <div class="mb-4">
      <label class="block text-gray-700 text-sm font-bold mb-2" for="reviewername">E-mail cím </label>
      <input v-model="review.email" class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="reviewername" type="text">
      <p v-if="review.email && !validemail(review.email)">Kérlek érvényes e-mail címet adj meg</p>
    </div>
    
    <div class="mb-6">
      <label class="block text-gray-700 text-sm font-bold mb-2" for="reviewtxt" v-if="review.email != ''">Vélemény</label>
      <input v-model="review.review" class="shadow appearance-none border border rounded w-full py-2 px-3 text-gray-700 mb-3 
      leading-tight focus:outline-none focus:shadow-outline" id="reviewtxt" type="text" v-if="review.email != ''" >
    </div>

      <button class="bg-red-500 hover:bg-red-300 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" 
      type="submit" v-if="review.review != '' && validemail(review.email) ">
        Küldés!
      </button>

  </form>
</div>
</template>

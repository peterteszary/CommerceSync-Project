
<template>
    <!--pages footer elements-->
    <footer class="container  mx-auto p-5 lg:px-15 h-[100%] md:h-[80%] flex
    flex-col-reverse md:flex-row justify-center md:justify-between items-center gap-8">
            <div class="w-full flex items-center flex-col md:items-start">
                <h2 class="text-xl  md:text-3xl text-pink-500">{{ name }} <br>
                    <strong class="text-pink-500 text-2xl lg:text-4xl my-1">SyncBundle</strong>
                </h2>
            </div>
            <div class="companyLogo">
                <img :src="imgsrc" alt="a cég logoja" class="w-[80%] h-[80%] mt-6">
            </div>
    </footer>
</template>

<script setup>
import { defineProps } from 'vue';

const props = defineProps(['name', 'imgsrc']);
</script>

<style scoped>
footer
{
    min-width: 100%;
    background-color: hsla(225, 8%, 10%, 0.8);
}
</style>
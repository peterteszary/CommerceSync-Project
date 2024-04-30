<template>
    <!--create navigation line-->
    <header class="flex justify-between bg-slate-200 shadow-sm h-[80px] px-6 lg:px-18 relative z-10">
     <div class="text-xl my-1 font-bold text-pink-500 hover:text-red-500 cursor-pointer">
         <RouterLink to="/"><i class="bi bi-code p-2"></i>SyncBundle</RouterLink>
     </div>
     <nav class="flex flex-col md:flex-row p-1 text-center gap-6 md:gap-6 md:static absolute bg-slate-200 md:w-auto
     md:my-0 left-0 w-full duration-500 md:bg-transparent" :class="[hamburgerMenu ? 'top-0' : 'top-[-390%]']">
         <RouterLink @click="openHamburgerMenu()" to="/" class=" text-pink-500 py-1 hover:text-red-500 cursor-pointer font-bold">Csomaginformáció</RouterLink>
         <RouterLink @click="openHamburgerMenu()" to="/DatabaseView" class=" text-pink-500 py-1 hover:text-red-500 cursor-pointer font-bold">Adatbázis</RouterLink>
         <RouterLink @click="openHamburgerMenu()" to="/AboutView" class=" text-pink-500 py-1 hover:text-red-500 cursor-pointer font-bold">Csapatunk</RouterLink>
         <RouterLink @click="openHamburgerMenu()" to="/HelpView" class=" text-pink-500 py-1 hover:text-red-500 cursor-pointer font-bold">Kapcsolat</RouterLink>
         <RouterLink @click="openHamburgerMenu()" to="/DownloadView" class=" text-pink-500 py-1 hover:text-red-500 cursor-pointer font-bold">Letöltés</RouterLink>
         <RouterLink @click="openHamburgerMenu()" to="/ReviewsView" class=" text-pink-500 py-1 hover:text-red-500 cursor-pointer font-bold">Vélemények</RouterLink>
    </nav>
    <!--create hamburger menu element-->
    <div class="text-4xl text-black font-bold cursor-pointer md:hidden z-20" @click="openHamburgerMenu()">
         <i :class="[hamburgerMenu ? 'bi bi-x' : 'bi bi-list']" ></i>
    </div>
    </header>
 </template>
 
 <script setup>
 import { RouterLink, } from 'vue-router';
 import { ref } from 'vue';
 
 // default setting
 const hamburgerMenu = ref(false);
 
 //event listener
 const openHamburgerMenu = () =>
 {
     hamburgerMenu.value = !hamburgerMenu.value;
 };
 </script>
 
 
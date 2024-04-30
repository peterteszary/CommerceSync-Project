<script setup>
import { RouterView } from 'vue-router'
import AppNavbar from './components/AppNavbar.vue';
</script>

<template>
  <!--navigation to pages-->
    <header>
     <AppNavbar/>
    </header>
   <RouterView />
 </template>
 
 
 <style >
 /*css variables */
 :root
 {
   --font-color: hsl(180, 3%, 7%);
   --wrapper-background-color: hsla(200, 4%, 73%, 0.8);
   --font-weight: 700;
   --secondary-font-weight: 600;
   --letter-spacing: 2px;
   --carousel-inner-border-radius: .4rem;
 }
 /*pages default style*/
 *
 {
   margin: 0;
   padding: 0;
   box-sizing: border-box;
 }
 body
 {
   background-color: hsla(203, 40%, 81%, 0.8);
 }
 </style>
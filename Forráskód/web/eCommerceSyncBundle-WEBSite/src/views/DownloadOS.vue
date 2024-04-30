<script setup>
import companyLogo from '../images/syncbundlelogo.png';

import AppFooter from '../components/AppFooter.vue';

import { ref, onMounted} from 'vue';

//dbsettings
import axios from 'axios';

const os = ref([]);

onMounted(() => {
    axios.get('http://localhost:3000/choiceos')
    .then(resp => os.value = resp.data);
});

</script>

<template>
       <div v-for="o in os" >
        <div class="wrapper-downloadOS">
            <h1>{{ o.choice }}
                <strong>{{ o.choicestrong }}</strong></h1>
            <div class="windows">
                <RouterLink to="/">{{ o.windows11 }}</RouterLink>
            </div>
            <div class="ios">
                <RouterLink to="/">{{ o.windows10 }}</RouterLink>
            </div>
            <div class="linux">
                <RouterLink to="/">{{ o.windows8 }}</RouterLink>
            </div>
        </div>
       </div>
          <!--all pages footer to equal-->
     <footer>
        <AppFooter :name="'Egyszerűsítsd vállalkozásod velünk'" :imgsrc="companyLogo" />
    </footer>
</template>


<style  scoped>
.wrapper-downloadOS
{
    max-width: 90%;
    display: grid;
    grid-template-columns: repeat(12, 1fr);
    grid-template-rows: auto;
    gap: 10px;
    justify-content: space-around;
    align-items: center;
    padding: 14px;
    background-color: var(--wrapper-background-color);
    border-radius: 5px;
    margin: 15px auto;
}

h1
{
    grid-column: span 12;
    text-align: justify;
    font-size: 22px;
    letter-spacing: var(--letter-spacing);
    padding-bottom: 10px;
}

.windows
{
    grid-column: span 5;
    grid-row: 2;
    letter-spacing: var(--letter-spacing);
    text-align: center;
    font-size: 20px;
    padding-bottom: 10px;
}

.ios
{
    grid-column: span 5;
    grid-row: 3;
    letter-spacing: var(--letter-spacing);
    text-align: center;
    font-size: 20px;
    padding-bottom: 10px;
}

.linux
{
    grid-column: span 5;
    grid-row: 4;
    letter-spacing: var(--letter-spacing);
    text-align: center;
    font-size: 20px;
    padding-bottom: 10px;
}

.windows:hover
{
    text-decoration: underline;
    color: hsl(340, 49%, 32%);
}

.ios:hover
{
    text-decoration: underline;
    color: hsl(340, 49%, 32%);
}

.linux:hover
{
    text-decoration: underline;
    color: hsl(340, 49%, 32%);
}

/*breakpoint one: tablet and smaller laptop */
@media (max-width: 1033px)
{
    .wrapper-downloadOS
    {
        max-width: 95%;
        align-items: stretch;
    }
}

/*breakpoint two: smaller  tablet and bigger phone */
@media (max-width: 886px)
{
    .wrapper-downloadOS
    {
        max-width: 96%;
        gap: 8px;
        align-items: flex-start;
        padding: 10px;
    }
}

/*breakpoint three: phone */
@media (max-width: 768px)
{
    .wrapper-downloadOS
    {
        max-width: 97%;
        gap: 8px;
        justify-content: stretch;
        padding: 8px;
    }
}
</style>
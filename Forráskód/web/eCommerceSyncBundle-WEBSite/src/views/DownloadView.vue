<script setup>
import companyLogo from '../images/syncbundlelogo.png';

import AppFooter from '../components/AppFooter.vue';

import { ref, onMounted } from 'vue';

//dbsettings
import axios from 'axios';

const downloadinfo = ref([]);

onMounted(() => {
    axios.get('http://localhost:3000/downloadinfo')
    .then(resp => downloadinfo.value = resp.data);
});
</script>

<template>
    <div v-for="d in downloadinfo">
        <div class="wrapper-download">
        <h1>{{ d.download }}</h1>
        <table>
            <tr>
                <th style="text-align: left;" rowspan="3">{{ d.capacity }}</th>
                <th style="text-align: center;">{{ d.ram }}</th>
                <th style="text-align: center;">{{ d.ssd }}</th>
            </tr>
            <tr>
                <td style="text-align: center;">{{ d.minram }}</td>
                <td style="text-align: center;">{{ d.minssd }}</td>
            </tr>
        </table>
        <RouterLink to="/DownloadOS"><div class="downloados"><button>{{ d.choice }}</button></div></RouterLink>
    </div>
    </div>
    
     <!--all pages footer to equal-->
     <footer>
        <AppFooter :name="'Egyszerűsítsd vállalkozásod velünk'" :imgsrc="companyLogo" />
    </footer>
</template>

<style scoped>
.wrapper-download
{
    max-width: 95%;
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
    grid-column: 1 / 12;
    text-align: center;
    font-size: 22px;
    letter-spacing: var(--letter-spacing);
}

table
{
    grid-column: span 12;
    margin: 5px;
    letter-spacing: var(--letter-spacing);
}

table th 
{
    font-size: 24px;
    padding: 3px;
}

table td 
{
    font-size: 20px;
}

table tr td 
{
    margin: 20px;
}

table, th, td
{
  border: 1px solid hsl(323, 79%, 64%);
}

.downloados
{
    margin: 10px;
    background-color: hsl(323, 79%, 64%);
    border-radius: 5px;
    color: var(--font-color);
    text-align: center;
    padding: 10px;
    font-size: 20px;
    color: var(--font-color);
    font-weight:var(--secondary-font-weight);
    letter-spacing: var(--letter-spacing);
}

.downloados:hover
{
    color: hsl(323, 79%, 64%);
    background-color: var(--font-color);
    font-style: inherit;

}

/*breakpoint one: tablet and smaller laptop */
@media (max-width: 1033px)
{
    .wrapper-download
    {

        align-items: stretch;
    }
}

/*breakpoint two: smaller  tablet and bigger phone */
@media (max-width: 886px)
{
    .wrapper-download
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
    .wrapper-download
    {
        max-width: 98%;
        gap: 8px;
        justify-content: stretch;
        
    }
}
</style>
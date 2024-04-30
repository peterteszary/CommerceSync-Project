  <script setup>
    import companyLogo from '../images/syncbundlelogo.png';

    import AppFooter from '../components/AppFooter.vue';

   import { ref, onMounted } from 'vue';

    //dbsettings
    import axios from 'axios';

    const helpinfo = ref([]);

    onMounted(() => {
        axios.get('http://localhost:3000/helpinfo')
        .then(resp => helpinfo.value = resp.data);
    });
 </script>

<template>
    <div v-for="h in helpinfo">
        <div style="background-color: var(--wrapper-background-color); padding: 25px; margin: 15px auto;">
        <section>
            <p>{{ h.messages }}<small>{{ h.messagessmall }}</small></p>
            <table>
                <tr>
                    <th>
                        <button><a href="mailto:bsze2teszpet@vasvari.org">{{ h.messagesboss }}</a></button>
                        <button><a href="mailto:bsze2perdan@vasvari.org">{{ h.messagesdev1 }}</a></button>
                        <button><a href="mailto:bsze2bagpet@vasvari.org">{{ h.messagesdev2 }}</a></button>
                    </th>
                </tr>
            </table>
        </section>
    </div>
    </div>
       <!--all pages footer to equal-->
       <footer>
        <AppFooter :name="'Egyszerűsítsd vállalkozásod velünk'" :imgsrc="companyLogo" />
    </footer>
    </template>
    
    <style scoped>
    /*header settings whit css grid */
    header
    {
        display: grid;
        grid-template-columns: repeat(12, 1fr);
        grid-template-rows: auto;
        gap: 15px;
    }

    img
    {
        grid-column: 1 / 5;
        grid-row: auto;
    }

    p
    {
        grid-column: 1 / 10;
        font-size: 20px;
        font-weight: var(--secondary-font-weight);
        color: var(--font-color);
        letter-spacing: var(--letter-spacing);
    }

    /*table settings flexbox */
    table
    {
        display: flex;
        text-align: center;
        justify-content: center;
        gap: 25px;
        padding-top: 25px;  
    }

    table tr
    {
        display: flex;
        gap: 20px;
    }

    table tr th 
    {
        display: flex;
        flex-direction: column;
        font-weight: var(--secondary-font-weight);
        color: var(--font-color);
    }

    section table tr th button
    {
        margin-bottom: 15px;
    }

    section table tr th button a
    {
        letter-spacing: var(--letter-spacing);
        font-size: 17px;
    }

    section table tr th button a:hover
    {
        text-decoration: underline;
        color: hsl(340, 49%, 32%);
    }

    @media (max-width: 739px)
    {
        p 
        {
            grid-column: 3 / 11;
            grid-row: 2;
        }

    }
    
    @media (max-width: 556px)
    {
        p 
        {
            grid-column: 1 / 11;
            grid-row: 2;
        }

    }
    
    </style>
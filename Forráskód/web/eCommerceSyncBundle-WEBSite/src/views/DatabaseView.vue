<script setup>
import { ref, onMounted } from 'vue';

import AppFooter from '../components/AppFooter.vue';

import companyLogo from '../images/syncbundlelogo.png';

//dbsettings
import axios from 'axios';

let databaseinfo = ref([]);
onMounted(() => {
    axios.get('http://localhost:3000/databaseinfo')
    .then(resp => databaseinfo.value = resp.data);
});

const visible = ref(false);

const mariadbproperty = () =>
{
    property.value = !property.value
};

const property = ref(false);

const clickicon = () =>
{
    visible.value = !visible.value

};
</script>

<template>
   <div v-for="d in databaseinfo">
    <main>
      <div class="wrapper">
        <h1>{{ d.dbinfo }}</h1> <button class="clickanimate"><i @click="clickicon()" class="bi bi-arrow-clockwise"></i></button>
        <Transition name="bounce" mode="in-out">
            <div class="mariadb-description" v-if="visible">
                {{ d.dbdesc }}
            </div>
            <div class="mariadb-description-hidden" v-else>
                {{ d.dbdeschidden }}
           </div>
        </Transition>
      </div>
      <div class="wrapper-mariadb-property">
        <div class="mariadb-property-description">
                <ul>
                    <Transition>
                        <li>
                            <button @click="mariadbproperty()"><strong>{{ d.dbprop1 }}</strong>
                                <i :class="[property ? 'bi bi-x p-2' : 'bi bi-three-dots p-2']"></i> 
                            </button> 
                            <p v-show="property">{{ d.dbprop1desc }}</p>
                        </li>
                    </Transition>
                    <Transition>
                        <li>
                            <p v-show="property"> {{ d.dbprop2desc }}</p>
                        </li>
                    </Transition>
                    <Transition>
                        <li>
                            <button @click="mariadbproperty()"><strong>{{ d.dbprop3 }}</strong>
                            </button> 
                            <p v-show="property">{{ d.dbprop3desc }}</p>
                        </li>
                    </Transition>
                    <Transition>
                        <li>
                            <button @click="mariadbproperty()"><strong>{{ d.dbprop4 }}</strong>
                            </button> 
                            <p v-show="property">{{ d.dbprop4desc }}</p>
                        </li>
                    </Transition>
                    
                        <li>
                         <p style="color: dimgrey;">{{ d.mariadb }}</p>
                        </li>   
            </ul>
        </div>
      </div>
    </main>
   </div>
     <!--all pages  footer to equal-->
     <footer>
        <AppFooter :name="'Egyszerűsítsd vállalkozásod velünk'" :imgsrc="companyLogo" />
    </footer>
</template>


<style scoped>
/* database page settings with css grid */
.wrapper
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
    grid-column: 1 / 6;
    grid-row: 1;
    background-color: hsl(323, 79%, 64%);
    color: var(--font-color);
    font-weight: var(--font-weight);
    font-size: 24px;
    padding: 10px;
    text-align: center;
    border-radius: 5px;
}

.clickanimate
{
    grid-column: 6 / 7;
    grid-row: 1;
    font-size: 24px;
    font-weight: bold;
}

/*description animation */
.bounce-enter-active
{
    animation: bounce-in .3s ease;
}

.bounce-leave-active
{
    animation: bounce-in .3s reverse;
}

@keyframes bounce-in
{
    0%
    {
        transform: scale(0);
    }
    100%
    {
        transform: scale(1);
    }
}

.mariadb-description
{
    grid-column: 1 / 12;
    grid-row: 2;
    margin: 10px;
    font-size: 20px;
    font-weight: var(--secondary-font-weight);
    color: var(--font-color);
    text-align: justify;
    letter-spacing: var(--letter-spacing);
}

.mariadb-description-hidden
{
    grid-column: 1 / 12;
    grid-row: 2;
    margin: 10px;
    border-radius: 3px;
    font-size: 20px;
    font-weight: var(--secondary-font-weight);
    color: var(--font-color);
    text-align: justify;
    letter-spacing: var(--letter-spacing);
}

.wrapper-mariadb-property
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

.mariadb-property-description
{
    grid-column: 5 / 9;
    justify-content: center;
    text-align: center;
    align-items: center;
    text-align: justify;
    
}

.mariadb-property-description ul li
{
    margin-top: 10px;
    font-size: 20px;
}

/*breakpoint one: tablet and smaller laptop */
@media (max-width: 1033px)
{
    .wrapper
    {
        align-items: stretch;  
    }
   h1
    {
        grid-column: 2 / 9;
        text-align: start;
    }
    .clickanimate
    {
        grid-column: 11 / 11;
        grid-row: 1;
    }
    .mariadb-description
    {
        grid-column: 1  / 12;
        grid-row: 3;
       
    }
    .mariadb-description-hidden
    {
        grid-column: 1  / 12;
        grid-row: 3;
      
    }

}

/*breakpoint two: smaller  tablet and bigger phone */
@media (max-width: 886px)
{
    .wrapper
    {
        max-width: 98%;
        gap: 8px;
        align-items: flex-start;
       
    }
    h1
    {
        grid-column: 1 / 10;
    }
    .mariadb-description
    {
        grid-column: 1  / 12;
        grid-row: 2;
       
    }
    .mariadb-description-hidden
    {
        grid-column: 1  / 12;
        grid-row: 2;
      
    }
    .mariadb-property-description
    {
        grid-column: 4 / 11;
        justify-content: center;
        text-align: center;
        align-items: center;
        text-align: justify;
    }
}

/*breakpoint three: phone */
@media (max-width: 768px)
{
    .wrapper
    {
        gap: 7px;
        justify-content: stretch;
        padding: 3px;
    }
    h1
    {
        grid-column: 1 / 12;
        
    }
    .clickanimate
    {
        grid-column: 11 / 11;
        grid-row: 2;
    }
    .mariadb-description
    {
        grid-column: 1  / 12;
        grid-row: 3;
        font-size: 19.5px;
       
    }
    .mariadb-description-hidden
    {
        grid-column: 1  / 12;
        grid-row: 3;
        font-size: 19.5px;
      
    }
    .mariadb-property-description
    {
        grid-column: 1 / 12;
        justify-content: center;
        text-align: center;
        align-items: center;
        text-align: justify;
    }
}
</style>
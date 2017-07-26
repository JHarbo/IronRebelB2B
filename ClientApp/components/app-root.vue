<template>
    <div id="app" class="container-fluid">
        <div>
            <nav-menu></nav-menu>
        </div>
        <div style="margin-top: 60px">
            <router-view></router-view>
        </div>
    </div>

</template>

<script>
import Vue from 'vue'
import CounterExample from './counter-example'
import FetchData from './fetch-data'
import HomePage from './home-page'
import NavMenu from './nav-menu'
import ProductPage from './product-page'
import ProductCard from './product-card'

Vue.component('counter-example', CounterExample);
Vue.component('fetch-data', FetchData);
Vue.component('home-page', HomePage);
Vue.component('nav-menu', NavMenu);
Vue.component('product-page', ProductPage);

export default {
    data() {
        return {
        }
    }
}
</script>

<style>
</style>

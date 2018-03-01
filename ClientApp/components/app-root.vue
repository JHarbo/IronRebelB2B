<template>
    <v-app id="app">
        <nav-menu></nav-menu>
        <main>
            <v-container fluid>
                <transition name="fade">
                    <router-view></router-view>
                </transition>
            </v-container>
        </main>
    </v-app>
</template>

<script>
import Vue from 'vue'
import NavMenu from './nav-menu'
import ProductPage from './product-page'

Vue.component('nav-menu', NavMenu);
Vue.component('product-page', ProductPage);

export default {
    data() {
        return {
        }
    }
}
</script>

<style scoped>
.fade-enter-active,
.fade-leave-active {
    transition-property: opacity;
    transition-duration: .10s;
}

.fade-enter-active {
    transition-delay: .10;
}

.fade-enter,
.fade-leave-active {
    opacity: 0
}
</style>

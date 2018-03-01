<template>
    <v-toolbar fixed dark>
        <v-toolbar-title>
            <router-link to="/">
                <img src="~assets/logo.png" />
            </router-link>
        </v-toolbar-title>
        <v-toolbar-items id="main-nav">
            <v-btn flat v-for="item in navs" router :to="item.link">
                {{ item.title }}
            </v-btn>
        </v-toolbar-items>
        <v-spacer></v-spacer>
        <v-toolbar-items>
            <v-btn flat slot="activator" class="blue darken-3">
                Sign In
            </v-btn>
        </v-toolbar-items>
    </v-toolbar>
</template>

<script>
import { routes } from '../routes'
import router from '../router'
import SignIn from './sign-in.vue'

export default {
    data() {
        return {
            routes,
            sideNav: false,
            navs: [
                { link: '/collection', title: 'Iron Rebel' },
                { link: '/granite', title: 'Granite' },
                { link: '/download', title: 'Download' },
                { link: '/pressroom', title: 'Pressroom' },
                { link: '/history', title: 'History' }
            ]
        }
    },

    methods: {
    },

    components: {
        SignIn
    }
}
</script>

<style scoped>
img {
    max-height: 60px;
    margin-top: 5px;
    margin-right: 20px;
}
</style>

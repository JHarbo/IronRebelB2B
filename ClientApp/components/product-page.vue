<template>
    <v-container fluid>
        <v-layout>
            <v-flex id="content" xs8 offset-xs1>
                <product-card v-for="product in products" :product="product"></product-card>
                <div id="action">
                    <v-btn primary @click="getNextPage()" v-if="isEmpty" :disabled="isLastPage"> Show more </v-btn>
                </div>
            </v-flex>
            <v-flex id="cart" xs3>
                <shopping-cart></shopping-cart>
            </v-flex>
        </v-layout>
    </v-container fluid>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
import * as type from '../store/mutation-types'
import ProductCard from './product-card.vue'
import ShoppingCart from './cart.vue'

export default {

    data() {
        return {
        }
    },

    components: {
        ProductCard,
        ShoppingCart
    },

    computed: {
        ...mapGetters({
            products: 'allProducts',
            pageNr: 'pageNr',
            pageCount: 'pageCount'
        }),
        isEmpty() {
            return this.products.length > 0;
        },
        isLastPage() {
            return this.pageNr >= this.pageCount;
        }
    },


    methods: {
        getPageCount() {
            this.$store.dispatch('getPageCount');
        },

        getNextPage() {
            let pageToFetch = this.pageNr + 1;
            this.$store.commit(type.PRODUCT_PAGE.SET_CURRENT_PAGE, { pageNr: pageToFetch });
            this.$store.dispatch('getProductPage', { pageNr: pageToFetch });
        }
    },

    created() {
        this.getNextPage();
        this.getPageCount();
        document.title = 'Iron Rebel | Collection';
    },

}
</script>

<style scoped>
#action {
    margin-top: 10px;
    text-align: center;
}
</style>

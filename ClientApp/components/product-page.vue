<template>
    <div>
        <shopping-cart></shopping-cart>
        <div class="container">
            <product-card v-for="product in products" :product="product" track-by="id"></product-card>
        </div>
        <div class="text-center" style="margin: 10px">
            <button class="btn btn-primary" @click="getNextPage()" v-if="products.length > 0"> Load more shit yo </button>
        </div>
    </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
import * as type from '../store/mutation-types'
import ProductCard from './product-card.vue'
import ShoppingCart from './cart.vue'

export default {

    data() {
        return {
            //productVariants: []
        }
    },

    components: {
        ProductCard,
        ShoppingCart
    },

    computed: mapGetters({
        products: 'allProducts',
        pageNr: 'pageNr'
    }),


    methods: {
        getNextPage() {
            let pageToGet = this.pageNr + 1;
            this.$store.commit(type.PRODUCT_PAGE_SET_PAGE_NR, { pageNr: pageToGet });
            this.$store.dispatch('getProductPage', { pageNr: pageToGet });
        }
    },

    created() {
        this.getNextPage();
    }

}
</script>

<style>

</style>

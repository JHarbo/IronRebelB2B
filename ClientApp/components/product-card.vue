<template>
    <div class="product-card raised">
        <div class="text-center title">
            {{ product.title }}
        </div>
        <div class="content">
            <div class="image">
                <img :src="product.imageSrc" alt="" />
            </div>
            <div class="variants">
                <table class="table table-xtra-condensed">
                    <thead>
                        <tr>
                            <th>Variant</th>
                            <th>Order</th>
                            <th>Stock</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="variant in product.variants">
                            <td>{{ variant.title }}</td>
                            <td>
                                <input class="form-control" type="text" />
                            </td>
                            <td>{{ variant.inventoryQuantity }}</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <div class="action">
            <button class="btn btn-success pull-right" @click="addToCart(product.id)">
                <i class="glyphicon glyphicon-shopping-cart" aria-hidden="true"></i>
                Add to Cart
            </button>
        </div>
    </div>
</template>


<script>
import { mapActions, mapGetters } from 'vuex'
import * as type from '../store/mutation-types'


export default {
    props: {
        product: Object
    },

    methods: {
        addToCart(productId) {
            let item = this.$store.state.products.products.find(product => product.id == productId);
            console.log(item);
            this.$store.commit(type.CART_ADD_ITEM, { item: item });
        }
    }
}
</script>

<style scoped>
.product-card {
    width: 370px;
    height: 330px;
    display: inline-block;
    margin: 5px;
}

.title {
    padding: 4px;
    font-weight: bold;
    font-size: 16px;
}

.content {
    height: 255px;
    overflow-y: hidden;
}

.image,
.variants {
    width: 50%;
    float: left;
    padding: 0 5px 0 5px;
}

img {
    max-height: 100%;
    max-width: 100%;
}

.variants {
    overflow-y: auto;
    overflow-x: hidden;
    max-height: 100%;
}

.variants input {
    width: 50px;
    border-radius: 0;
}


/*.action {
    }*/

button {
    margin: 4px;
}

.table-xtra-condensed>thead>tr>th,
.table-xtra-condensed>tbody>tr>th,
.table-xtra-condensed>tfoot>tr>th,
.table-xtra-condensed>thead>tr>td,
.table-xtra-condensed>tbody>tr>td,
.table-xtra-condensed>tfoot>tr>td {
    padding: 2px;
}
</style>

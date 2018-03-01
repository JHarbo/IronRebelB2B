<template>
    <v-card class="product-card raised">
        <v-card-title class="title">
            {{ product.title }}
        </v-card-title>
        <div class="content">
            <v-container fluid>
                <v-layout>
                    <v-flex xs6>
                        <img :src="product.imageSrc" alt="" />
                    </v-flex>
                    <v-flex xs6 id="variant">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>variant</th>
                                    <th>order</th>
                                    <th>stock</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr v-for="variant in product.variants">
                                    <td>{{ variant.title }}</td>
                                    <td>
                                        <div class="group">
                                            <input type="text">
                                            <span class="bar"></span>
                                        </div>
                                    </td>
                                    <td>{{ variant.inventoryQuantity }}</td>
                                </tr>
                            </tbody>
                        </table>
                    </v-flex>
                </v-layout>
            </v-container>
        </div>
        <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn class="green darken-1" flat @click="addToCart()">
                Add to Cart
            </v-btn>
        </v-card-actions>
    </v-card>
</template>


<script>
import { mapActions, mapGetters } from 'vuex'
import * as type from '../store/mutation-types'


export default {

    data() {
        return {
            test: []
        }
    },

    props: {
        product: Object
    },

    computed: {
        ...mapGetters({
            products: 'allProducts',
        })
    },

    methods: {
        addToCart() {
            let item = this.products.find(product => product.id == this.product.id);
            this.$store.commit(type.CART.ADD_ITEM, {
                item: {
                    id: item.id,
                    title: item.title,
                    imageSrc: item.imageSrc,
                    variants: this.test
                }
            });
            console.log(this.test);
        }
    }
}
</script>

<style scoped>
.product-card {
    width: 390px;
    display: inline-block;
    margin: 5px;
}

.product-card .title {
    padding-bottom: 10px;
    font-size: 16px !important;
}

.content {
    height: 300px;
    overflow-y: hidden;
}

.content .container {
    padding: 5px;
    height: 100%;
}

.content .container .layout {
    height: 100%;
}

img {
    max-height: 100%;
    max-width: 100%;
}

#variant {
    overflow-y: auto;
    overflow-x: hidden;
}

table.table thead tr {
    height: 20px;
}

table.table thead th,
table.table tbody td {
    padding: 0;
    text-align: left;
}

.group {
    position: relative;
}

input {
    font-size: 18px;
    display: block;
    width: 40px;
    border: none;
    border-bottom: 1px solid #757575;
}

input:focus {
    outline: none;
}

.bar {
    position: relative;
    display: block;
    width: 40px;
}

.bar:before,
.bar:after {
    content: '';
    height: 2px;
    width: 0;
    bottom: 0;
    position: absolute;
    background: #5264AE;
    transition: 0.2s ease all;
}

.bar:before {
    left: 50%;
}

.bar:after {
    right: 50%;
}

input:focus~.bar:before,
input:focus~.bar:after {
    width: 50%;
}
</style>

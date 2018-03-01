<template>
    <v-card class="cart">
        <v-card-title>
            Order summary
        </v-card-title>
        <v-list>
            <v-list-tile avatar v-for="item in cart">
                <v-list-tile-avatar>
                    <img :src="item.imageSrc" />
                </v-list-tile-avatar>
                <v-list-tile-content>
                    <v-list-tile-title v-text="item.title"></v-list-tile-title>
                </v-list-tile-content>
                <v-list-tile-action>
                    <v-btn icon @click="removeItem(item.id)">
                        <v-icon>clear</v-icon>
                    </v-btn>
                </v-list-tile-action>
            </v-list-tile>
        </v-list>
        <v-card-actions>
            <v-btn block id="checkout" flat class="red darken-1">
                CHECKOUT
                <v-icon>keyboard_arrow_right</v-icon>
            </v-btn>
        </v-card-actions>
    </v-card>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
import * as type from '../store/mutation-types'

export default {

    computed: mapGetters({
        cart: 'cartItems'
    }),

    methods: {
        removeItem(itemId) {
            let item = this.cart.indexOf(item => item.id == itemId);
            this.$store.commit(type.CART.REMOVE_ITEM, { index: item });
        }
    }
}
</script>

<style scoped>
.cart {
    width: 380px;
    margin-top: 5px;
    position: fixed;
    right: 40px;
}

.cart-item {
    display: flex;
}

.cart-item .item-title {
    margin-right: auto;
    margin-top: auto;
    margin-bottom: auto;
    max-width: 300px;
    overflow-x: hidden;
}

.cart-item .remove {
    margin-left: auto;
}

.cart-item .btn-remove {
    cursor: pointer;
}

#checkout {
    font-weight: 700;
    letter-spacing: 2px;
}

</style>

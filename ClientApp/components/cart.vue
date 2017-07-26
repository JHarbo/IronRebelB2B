<template>
    <div>
        <div class="container cart pull-right raised">
            <div class="row title">
                Summary
            </div>
            <div v-for="item in cart">
                {{ item.title }}
            </div>
            <div class="row action">
                <button class="btn btn-danger">CHECKOUT</button>
            </div>
        </div>
    </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
import * as type from '../store/mutation-types'

export default {

    computed: mapGetters({
        cart: 'allItems'
    }),

    methods: {
        removeItem(itemId) {
            let item = this.$store.state.cart.items.indexOf(item => item.id == itemId);
            console.log(item);
            this.$store.commit(type.CART_REMOVE_ITEM, { index: item });
        }
    }
}
</script>

<style scoped>
.cart {
    width: 300px;
    margin-top: 5px;
    position: fixed;
    right: 40px;
}

.title {
    background-color: #f2f2f2;
    padding: 10px
}

.list-group {
    max-height: 782px;
    overflow-y: auto;
}

.action {
    padding: 0 10px 10px 10px;
}

.action button {
    width: 100%;
    font-weight: 600;
}

a {
    border: none;
}

.glyphicon-remove {
    cursor: pointer;
}
</style>



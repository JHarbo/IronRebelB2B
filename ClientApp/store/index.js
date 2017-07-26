import Vue from 'vue'
import Vuex from 'vuex'
import products from './modules/products'
import cart from './modules/cart'
import * as type from './mutation-types'

Vue.use(Vuex)

const Counter = {

    state: {
        counter: 0
    },

    mutations: {
        [type.MAIN_SET_COUNTER](state, obj) {
            state.counter = obj.counter
        }
    },

    actions: {
        setCounter({ commit }, obj) {
            commit(type.MAIN_SET_COUNTER, obj)
        },

    }
}

export default new Vuex.Store({
    modules: {
        products,
        cart,
        counter: Counter
    }
});

import * as type from '../mutation-types'

const state = {
    items: []
}

const mutations = {
    [type.CART_ADD_ITEM](state, payload) {
        state.items.push(payload.item);
    },
    [type.CART_REMOVE_ITEM](state, payload) {
        state.items.splice(payload.index, 1);
    }
}

const actions = {

}

const getters = {
    allItems: state => state.items
}

export default {
    state,
    mutations,
    actions,
    getters
}

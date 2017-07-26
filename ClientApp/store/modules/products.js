import * as type from '../mutation-types'
import axios from 'axios'

const state = {
    pageNr: 0,
    products: []
}

const mutations = {
    [type.PRODUCT_PAGE_ADD_PRODUCTS](state, payload) {
        state.products.push(...payload.data);
    },
    [type.PRODUCT_PAGE_SET_PAGE_NR](state, payload) {
        state.pageNr = payload.pageNr;
    }
}

const actions = {
    async getProductPage(context, payload) {
        try {
            let response = await axios.get('/api/collection/getnextpage?pageNr=' + payload.pageNr);
            context.commit(type.PRODUCT_PAGE_ADD_PRODUCTS, response)
        } catch (error) {
            console.log(error)
        }
    }
}

const getters = {
    allProducts: state => state.products,
    pageNr: state => state.pageNr,
    productById(id) {
        return state.products.find(product => product.id == id);
    }
}

export default {
    state,
    mutations,
    actions,
    getters
}


import * as type from '../mutation-types'
import axios from 'axios'

const state = {
    currentPage: 0,
    pageCount: 0,
    products: []
}

const mutations = {
    [type.PRODUCT_PAGE.ADD_PRODUCTS](state, payload) {
        state.products.push(...payload.data);
    },
    [type.PRODUCT_PAGE.SET_CURRENT_PAGE](state, payload) {
        state.currentPage = payload.pageNr;
    },
    [type.PRODUCT_PAGE.SET_PAGE_COUNT](state, payload) {
        state.pageCount = payload.data.count;
    }
}

const actions = {
    async getProductPage(context, payload) {
        try {
            let response = await axios.get('/api/collection/getpage?page=' + payload.pageNr);
            context.commit(type.PRODUCT_PAGE.ADD_PRODUCTS, response);
        } catch (error) {
            console.log(error);
        }
    },
    async getPageCount(context, payload) {
        try {
            let response = await axios.get('api/collection/getpagecount');
            context.commit(type.PRODUCT_PAGE.SET_PAGE_COUNT, response);
        } catch (error) {
            console.log(error);
        }
    }
}

const getters = {
    allProducts: state => state.products,
    pageNr: state => state.currentPage,
    pageCount: state => state.pageCount
}

export default {
    state,
    mutations,
    actions,
    getters
}


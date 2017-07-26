import CounterExample from 'components/counter-example'
import FetchData from 'components/fetch-data'
import HomePage from 'components/home-page'
import ProductPage from 'components/product-page'

export const routes = [
    { path: '/', component: HomePage },
    { path: '/counter', component: CounterExample },
    { path: '/fetch-data', component: FetchData },
    { path: '/collection', component: ProductPage }
]
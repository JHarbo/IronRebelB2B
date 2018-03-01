import ProductPage from 'components/product-page'
import SigninPage from 'components/sign-in'

export const routes = [
    { path: '/collection', name: 'Iron Rebel', component: ProductPage },
    { path: '/granite', name: 'Granite' },
    { path: '/download', name: 'Download' },
    { path: '/pressroom', name: 'Pressroom' },
    { path: '/history', name: 'History' },
    { path: '/sign-in', name: 'Sign in', component: SigninPage }
]

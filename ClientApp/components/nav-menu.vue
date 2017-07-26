<template>
    <div class="main-nav">
        <div class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                    <a class="navbar-brand" href="/"><img src="~assets/logo.png" /></a>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                            <li>
                                <router-link to="/collection" :exact="true">
                                    IRON REBEL
                                </router-link>
                            </li>
                            <li>
                                <router-link to="/fetch-data">
                                    Granite
                                </router-link>
                            </li>
                            <li>
                                <router-link to="/">
                                    Download
                                </router-link>
                            </li>
                            <li>
                                <router-link to="/">
                                    Pressroom
                                </router-link>
                            </li>
                            <li>
                                <router-link to="/">
                                    History
                                </router-link>
                            </li>
                            <li id="cart-link">
                                <router-link to="/">
                                    Cart
                                </router-link>
                            </li>
                        </ul>
                        <ul class="nav navbar-nav navbar-right">
                            <li class="navbar-btn"><button class="btn btn-primary"><span class="glyphicon glyphicon-lock"/> Sign In</button></li>
                        </ul>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { routes } from '../routes'

export default {
    data() {
        return {
            routes
        }
    }
}
</script>

<style>

.navbar {
    margin-bottom: 0;
    z-index: 9999;
    border: 0;
    font-size: 14px !important;
    line-height: 1.42857143 !important;
    letter-spacing: 1px;
}

.navbar-brand {
    padding: 4px;
}

.nav.navbar-nav li a {
    color: white;
    font-weight: 600;
}

.navbar-nav li a:hover, .navbar-nav li.active a {
    color: red !important;
    background-color: #fff !important;

    transition: background-color 0.4s ease;
}

.navbar img {
    height: 100%;
}

#cart-link {
    background-color: #d9534f;
}

.btn {
    border-radius: 0;
}
</style>
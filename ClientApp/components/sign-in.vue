<template>
    <v-menu>
        <v-card>
            <v-card-title>
                <span class="headline">Sign In</span>
            </v-card-title>
            <v-card-text>
                <v-text-field label="Email" required></v-text-field>
                <v-text-field label="Password" type="password" required></v-text-field>
            </v-card-text>
            <v-card-actions>
                <v-btn block class="blue--text darken-1" flat @click.native="dialog = false">Sign in</v-btn>
            </v-card-actions>
        </v-card>
    </v-menu>
</template>

<script>
export default {
    data() {
        return {
        }
    }
}
</script>

<style scoped>

</style>

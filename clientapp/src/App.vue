<template>
    <div id="app">
        <v-app>
            <v-toolbar dark
                       prominent
                       src="https://cdn.vuetifyjs.com/images/backgrounds/vbanner.jpg">
                <v-toolbar-title>Погода в городе N на ближайшие 10 дней:</v-toolbar-title>
                <v-spacer></v-spacer>
                <v-btn>Обновить</v-btn>
            </v-toolbar>
            <v-data-table :headers="headers"
                          :items="desserts"
                          :items-per-page="10"
                          class="elevation-1">

            </v-data-table>
        </v-app>
    </div>
</template>



<script>
export default {
  name: 'App'
 
}
</script>

<template>
    <v-app>
        <div id="app">

            <v-toolbar dark
                       prominent
                       src="https://cdn.vuetifyjs.com/images/backgrounds/vbanner.jpg">
                <v-toolbar-title id="tableLabel">Погода в городе N на ближайшие 10 дней:</v-toolbar-title>
                <v-spacer></v-spacer>
                <v-btn @click="refreshInfo">Обновить данные</v-btn>
            </v-toolbar>
            <p v-if="!forecasts"><em>Loading...</em></p>
            <!--<v-data-table :headers="headers"
                  :items="forecasts"
                  :items-per-page="10"
                  hide-default-footer>-->
            <table class='table table-striped' aria-labelledby="tableLabel" v-if="forecasts">
                <thead>
                    <tr>
                        <th>Дата</th>
                        <th>Температура (C)</th>
                        <th>-(C) Температура</th>
                        <th>Давление (мм.рт.ст).</th>
                        <th>Влажность (%)</th>
                        <th>Сила ветра (м/с)</th>
                        <th>Направление ветра</th>
                        <th>Осадки</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="forecast of forecasts" v-bind:key="forecast">
                        <td>{{ forecast.date }}</td>
                        <td>{{ forecast.temperatureMin }}</td>
                        <td>{{ forecast.temperatureMax }}</td>
                        <td>{{ forecast.pressure }}</td>
                        <td>{{ forecast.humidity }}</td>
                        <td>{{ forecast.windSpeed }}</td>
                        <td>{{ forecast.windDirection }}</td>
                        <td>{{ forecast.summary }}</td>
                    </tr>
                </tbody>
            </table>


            <!-- </v-data-table>-->

        </div>
    </v-app>
</template>

<style>
    #app {
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #2c3e50;
        margin-top: 60px;
    }
</style>

<script>
    import axios from 'axios'
    export default {
        name: "App",
        data() {
            return {
               /* headers: [
                    {
                        text: 'Дата',
                        align: 'start',
                        sortable: false,
                        value: 'Date',
                    },
                    { text: 'Температура (C)', value: 'TemperatureMin' },
                    { text: '(C) Температура', value: 'TemperatureMax' },
                    { text: 'Давление (мм.рт.ст).', value: 'Pressure' },
                    { text: 'Влажность (%)', value: 'Humidity' },
                    { text: 'Сила ветра (м/с)', value: 'WindSpeed' },
                    { text: 'Направление ветра', value: 'WindDirection' },
                    { text: 'Осадки', value: 'Summary' },
                ], */
                forecasts: []
            }
        },
        methods: {
            getWeatherForecasts() {
                axios.get('/weatherforecast')
                    .then((response) => {
                        this.forecasts = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            }
        },
        mounted() {
            this.getWeatherForecasts();
        },
        refreshInfo() {
            this.getWeatherForecasts();
        }
    }

</script>

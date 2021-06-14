<template>
    <div id="app">
        <v-app>
            <v-toolbar dark
                       prominent
                       src="https://cdn.vuetifyjs.com/images/backgrounds/vbanner.jpg">
                <v-toolbar-title>Погода в городе N на ближайшие 10 дней:</v-toolbar-title>
                <v-spacer></v-spacer>
                <v-btn @click="refreshinfo">Обновить данные</v-btn>
            </v-toolbar>
            <p v-if="!forecasts"><em>Loading...</em></p>
            <v-data-table :headers="headers"
                          :items="forecasts"
                          :items-per-page="10"
                          hide-default-footer>
               <!--<template slot="headers">
                   <tr>
                       <th>Date</th>
                       <th>Temp.Min (C)</th>
                       <th>Temp.Max (C)</th>
                       <th>Pressure (mm Hg)</th>
                       <th>Humidity (%)</th>
                       <th>Wind speed (m/sec)</th>
                       <th>Wind Direction</th>
                       <th>Summary</th>
                   </tr>
                 </template>-->


               <!--<template slot="items">
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
                </template>-->


            </v-data-table>
        </v-app>
    </div>
</template>



<script>
    import axios from 'axios'
    export default {
        name: "App",
        data() {
            return {
                headers: [
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
                ], 
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
        refreshinfo() {
            this.getWeatherForecasts();
        }
    }

</script>

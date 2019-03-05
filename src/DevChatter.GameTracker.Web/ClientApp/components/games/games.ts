import Vue from 'vue';
import { Component } from 'vue-property-decorator';

interface Game {
    title: string;
}

@Component
export default class GamesComponent extends Vue {
    games: Game[] = [];

    mounted() {
        fetch('api/SampleData/Games')
            .then(response => response.json() as Promise<Game[]>)
            .then(data => {
                this.games = data;
            });
    }
}

import Vue from 'vue';
import { Component } from 'vue-property-decorator';

interface Player {
    firstName: string;
    lastName: string;
    isMember: boolean;
}

@Component
export default class PlayersComponent extends Vue {
    players: Player[] = [];

    mounted() {
        fetch('api/SampleData/Players')
            .then(response => response.json() as Promise<Player[]>)
            .then(data => {
                this.players = data;
            });
    }
}

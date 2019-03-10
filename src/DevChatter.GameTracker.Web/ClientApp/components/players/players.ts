import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import * as $ from 'jquery';

interface Player {
    firstName: string;
    lastName: string;
    isMember: boolean;
}

@Component
export default class PlayersComponent extends Vue {
    players: Player[] = [];
    editPlayer: any = {};

    mounted() {
        fetch('api/SampleData/Players')
            .then(response => response.json() as Promise<Player[]>)
            .then(data => {
                this.players = data;
            });
    };
    edit(id: number) {
        fetch(`api/SampleData/Players/${id}`)
            .then(response => response.json() as Promise<Player>)
            .then(data => {
                this.editPlayer = data;
            });
    };
    save() {
    };
    cancel() {

    };
}

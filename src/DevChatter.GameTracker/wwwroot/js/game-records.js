Vue.component('vue-multiselect', window.VueMultiselect.default);

var gameRecords = new Vue({
    components: {
        Multiselect: window.VueMultiselect.default
    },
    el: '#app',
    data: {
        gamePlayedId: document.getElementById('gamePlayedId').value,
        model: null,
        isLoadingTags: false,

        games: [],
        players: [],

        selectedPlayers: [],
        winningPlayers: [],
        teachingPlayers: [],
    },
    mounted() {
        this.fetchAllGames();
        this.fetchAllPlayers();
    },
    methods: {
        gameSearch: function (filter) {
            axios.get(`/api/Games/?filter=${encodeURIComponent(filter)}`)
                .then(response => {
                    this.games = response.data;
                })
                .catch(error => {
                    console.log(error.statusText);
                });
        },
        playerSearch: function (filter) {
            axios.get(`/api/Players/?filter=${encodeURIComponent(filter)}`)
                .then(response => {
                    this.players = response.data;
                })
                .catch(error => {
                    console.log(error.statusText);
                });
        },
        saveGamePlayed: function () {
            console.log(this.model);
            axios.post(`/api/GameRecords/`, this.model)
                .then(response => {
                    console.log("Saved it!");
                    //TODO: Show a success toast or do a redirect;
                })
                .catch(error => {
                    console.log(error.statusText);
                });
        },
    }
})

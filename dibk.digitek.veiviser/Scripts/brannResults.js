

var vueBrannModel = new Vue({
    el: '#vue-brann-results',
    data: {
        resultData: null,
        dmnNames: null,
        dmnRules: null
    },
    created: function () {
        this.getDmnNames();
        this.getDmnRules();
        this.getDummyResults();
    },
    methods: {
        getDmnNames: function () {
            Promise.resolve(getDmnNames())
                .then((dmnNames) => {
                    this.dmnNames = dmnNames;
                });
        },
        getDmnRules: function () {
            Promise.resolve(getDmnRules())
                .then((dmnRules) => {
                    this.dmnRules = dmnRules;
                });
        },
        getDummyResults: function () {
            axios.get('/Data/dummyResults.json')
                .then(function (response) {
                    this.resultData = response.data.value;
                }.bind(this))
                .catch(function (error) {
                    console.log(error)
                });
        },
        getCallName: function (key) {
            return getCallName(key) ? getCallName(key) : key;
        },
        getDescription: function (key) {
            return getDescription(key) ? getDescription(key) : key;
        },
        getDescriptionUrl: function (key) {
            return getDescriptionUrl(key) ? getDescriptionUrl(key) : null;
        },
        getChapter: function (key) {
            return getChapter(key) ? getChapter(key) : key;
        },
        getTableName: function (key) {
            return getTableName(key) ? getTableName(key) : key;
        }
    }
});

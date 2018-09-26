

var vueBrannModel = new Vue({
    el: '#vue-brann-results',
    data: {
        resultData: null,
        dmnNames: null,
        dmnRules: null,
        variables: null,
        modelOutput: null,
        loadingModelOutput: true
    },
    created: function () {
        this.getDmnNames();
        this.getDmnRules();
        this.getResultsFromLocalStorage();
        this.postApiData();
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
        postApiData: function () {
            Promise.resolve(postApiData({ variables: this.variables }))
                .then((executionId) => {
                    console.log(executionId);
                    console.warn(executionId);
                    this.getModelOutput(executionId);
                })
        },
        getModelOutput: function (executionId, requestAttemptCount) {
            var attemptCount = requestAttemptCount !== undefined ? requestAttemptCount : 0;
            Promise.resolve(GETVariablesByExecutionId(executionId))
                .then((modelOutput) => {
                    if (!modelOutput && attemptCount < 20) {
                        setTimeout(function() {
                                attemptCount++;
                                this.getModelOutput(executionId, attemptCount);
                            }.bind(this),
                            1000);
                    } else {
                        this.modelOutput = modelOutput;
                        this.loadingModelOutput = false;
                    }
                    this.modelOutput = modelOutput;
                    this.loadingModelOutput = false;
                });
        },
        getCallName: function (key) {
            return getCallName(key) ? getCallName(key) : key;
        },
        getDescription: function (key) {
            return getDescription(key) ? getDescription(key) : null;
        },
        getDescriptionUrl: function (key) {
            return getDescriptionUrl(key) ? getDescriptionUrl(key) : null;
        },
        getChapter: function (key) {
            return getChapter(key) ? getChapter(key) : key;
        },
        getTableName: function (key) {
            return getTableName(key) ? getTableName(key) : key;
        },
        getResultsFromLocalStorage: function () {
            this.variables = JSON.parse(localStorage.variables);
        }
    }
});

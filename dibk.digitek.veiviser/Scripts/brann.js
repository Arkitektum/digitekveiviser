var vueBrannModel = new Vue({
    el: '#vue-brann',
    data: {
        listElements: [],
        schemaTypes: schemaTypes,
        selectedSchemaType: {},
        milestones: milestones,
        enterpriseTerms: enterpriseTerms,
        selectedMilestone: '',
        selectedEnterpriseterms: [],
        listOfSelectedKeys: []
    },
    components: {
        listElement: ListElement
    },
    methods: {
        getActivities: function () {
            showLoadingAnimation();
            var queryString = '/api/sjekkliste/' + this.selectedSchemaType.Value;

            axios.get(queryString)
                .then(function (response) {
                    console.log(response);
                    if (response.data !== undefined) {
                        this.listElements = response.data;
                    }
                    hideLoadingAnimation();
                }.bind(this))
                .catch(function (error) {
                    console.log(error);
                    hideLoadingAnimation();
                });
        },

        showDescription: function () {
            console.log(listElement.Beskrivelse);
        },


    }
});


var vueBrannModel = new Vue({
    el: '#vue-brann',
    data: {
        schemaTypes: [
            { key: '1', name: 'Risikoklasser', number: 1 },
            { key: '2', name: 'Brannklasser', number: 2 },
            { key: '3', name: 'Brannspredning mellom byggverk', number: 3 }
        ],
        selectedSchemaType: { key: '1', name: 'Risikoklasser', number: 1 },
        variables: {
            typeVirksomhet: { value: null, type: "String" },
            antallEtasjer: { value: null, type: "long" },
            brtArealPrEtasje: { value: null, type: "long" },
            utgangTerrengAlleBoenheter: { value: null, type: "boolean" },
            bareSporadiskPersonopphold: { value: null, type: "String" },
            alleKjennerRomningsVeiene: { value: null, type: "boolean" },
            beregnetForOvernatting: { value: null, type: "boolean" },
            liteBrannfarligAktivitet: { value: null, type: "boolean" },
            konsekvensAvBrann: { value: null, type: "String" },
            brannBelastning: { value: null, type: "long" },
            brannEnergi: { value: null, type: "long" },
            bygningOffentligUnderTerreng: { value: null, type: "boolean" },
            arealBrannseksjonPrEtasje: { value: null, type: "long" }
        },
        descriptions: null
    },
    created: function () {

    },
    methods: {
        setSelectedSchemaType(schemaType) {
            this.selectedSchemaType = schemaType;
        },
        getNextSchemaType: function () {
            var nextSchemaTypeNumber = this.selectedSchemaType.number + 1;
            var nextSchemaType = null;
            this.schemaTypes.forEach(function (schemaType) {
                if (schemaType.number == nextSchemaTypeNumber) {
                    nextSchemaType = schemaType;
                }
            }.bind(this));
            return nextSchemaType;
        },
        getPreviousSchemaType: function () {
            var previousSchemaTypeNumber = this.selectedSchemaType.number - 1;
            var previousSchemaType = null;
            this.schemaTypes.forEach(function (schemaType) {
                if (schemaType.number == previousSchemaTypeNumber) {
                    previousSchemaType = schemaType;
                }
            }.bind(this));
            return previousSchemaType;
        }
    }
});
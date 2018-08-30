var dmnRules = null;
var dmnNames = null;

function getDmnNames() {
    return axios.get('/Data/dmnNames.json')
        .then(function (response) {
            dmnNames = response.data;
            return response.data;
        })
        .catch(function (error) {
            console.log(error)
        });
}

function getDmnRules() {
    return axios.get('/Data/dmnRules.json')
        .then(function (response) {
            dmnRules = response.data;
            return response.data;
        })
        .catch(function (error) {
            console.log(error)
        });
}

function getCallName(key) {
    if (dmnRules[key] && dmnRules[key].CallName) {
        return dmnRules[key].CallName;
    }
    else {
        console.warn("CallName for '" + key + "' is not defined");
    }
}

function getDescription(key) {
    if (dmnRules[key] && dmnRules[key].Description) {
        return dmnRules[key].Description;
    }
    else {
        console.warn("Description for '" + key + "' is not defined");
    }
}

function getDescriptionUrl(key) {
    if (dmnRules[key] && dmnRules[key].URL) {
        return dmnRules[key].URL;
    }
    else {
        console.warn("Description URL for '" + key + "' is not defined");
    }
}


function getChapter(key) {
    if (dmnNames[key] && dmnNames[key].Chapter) {
        return dmnNames[key].Chapter;
    }
    else {
        console.warn("Chapter for '" + key + "' is not defined");
    }
}

function getTableName(key) {
    if (dmnNames[key] && dmnNames[key].TableName) {
        return dmnNames[key].TableName;
    }
    else {
        console.warn("TableName for '" + key + "' is not defined");
    }
}

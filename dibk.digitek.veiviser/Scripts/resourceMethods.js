var resourceData = null;

function getResourceData() {
    axios.get('/Data/brannkrav.json')
        .then(function (response) {
            resourceData = response.data;
        }.bind(this))
        .catch(function (error) {
            console.log(error)
        });
}

function getCallName(key) {
    if (resourceData[key] && resourceData[key].CallName) {
        return resourceData[key].CallName;
    }
    else {
        console.warn("CallName for '" + key + "' is not defined");
    }
}

function getDescription(key) {
    if (resourceData[key] && resourceData[key].Description) {
        return resourceData[key].Description;
    }
    else {
        console.warn("Description for '" + key + "' is not defined");
    }
}

function getDescriptionUrl(key) {
    if (resourceData[key] && resourceData[key].URL) {
        return resourceData[key].URL;
    }
    else {
        console.warn("Description URL for '" + key + "' is not defined");
    }
}

document.addEventListener('DOMContentLoaded', getResourceData, false);

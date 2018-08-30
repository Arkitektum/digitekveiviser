﻿function postApiData(apiData) {
    axios.post('http://localhost:8080/engine-rest/process-definition/key/BranntekniskProsjekteringAPIV01/start', apiData)
        .then(function (response) {
            if (response && response.data) {
                this.GETVariablesByExecutionId(response.data.id);
                this.GETAllTaskByExecutionId(response.data.id);
                return response.data;
            } else {
                console.warn("'response.data' is not defined");
            }
        }.bind(this))
        .catch(function (error) {
            console.log(error)
        });
}

function GETVariablesByExecutionId(executionId) {
    axios.get('http://localhost:8080/engine-rest/process-instance/' + executionId + '/variables')
        .then(function (taskVariables) {
            if (taskVariables && taskVariables.data && taskVariables.data.modelOutputs) {
                return taskVariables.data.modelOutputs;
            } else {
                console.warn("'taskVariables.data.modelOutputs' is not defined")
            }
        }.bind(this))
        .catch(function (error) {
            console.warn(error)
        });
}

function GetAllTaskByExecutionId(executionId) {
    axios.get('http://localhost:8080/engine-rest/task?processInstanceId=' + executionId)
        .then(function (openTask) {
            if (openTask && openTask.data) {
                var taskList = openTask.data.map(a => a.id);
                postCompleteTaskList(taskList);
            } else {
                console.warn("'openTask.data' is not defined");
            }
        })
        .catch(function (error) {
            console.warn(error)
        });
}

function postCompleteTaskList(taskList, taskListIndex) {
    var taskListIndex = taskListIndex ? taskListIndex : 0;
    if (taskList && index < taskList.length) {
        postCompleteTask(taskList, taskListIndex);
    }
}

function postCompleteTask(taskList, taskIdListIndex) {
    var taskId = taskList[taskIdListIndex];
    axios.post('http://localhost:8080/engine-rest/task/' + taskId + '/complete', '{}')
        .then(function (response) {
            postCompleteTaskList(taskIdListIndex + 1);
        })
        .catch(function (error) {
            console.warn(error)
        });
}
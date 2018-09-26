using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CamundaClient;
using CamundaClient.Dto;
using dibk.digitek.veiviser.Models;
using Xunit;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VeiviserTest.Builders;

namespace VeiviserTest
{
    public class WorkersTest
    {
        [Fact]
        [DeploymentItem("BPMNSubmodelTestDotNet.bpmn")]
        public void TestMethod1()
        {

            string solutionPath = Directory
                .GetParent(Assembly.GetExecutingAssembly().Location)
                .Parent.Parent.Parent.FullName;
            string pluginPath = Path.Combine(solutionPath, "CamundaModels");


            // Engine client should point to a dedicated Camunda instance for test, preferrably locally available

            var camunda = new CamundaEngineClient(new System.Uri("http://localhost:8080/engine-rest/engine/default/"), null, null);

            // Deploy the models under test
            string deploymentId = camunda.RepositoryService.Deploy("testcase", new List<object> {
                    FileParameter.FromManifestResource(Assembly.GetExecutingAssembly(), "VeiviserTest.TestData.CamundaModels.BPMNSubmodelTest_NET.bpmn")});
            try
            {
                var inputsVariables = new Dictionary<string, object>()
                {
                    {"antallEtasjer", 4}
                    //{"typeVirksomhet", "Casa"},
                    //{"utgangTerrengAlleBoenheter", true},
                    //{"brtArealPrEtasje", 400},
                    //{"_rkl", "RKL4"}
                };
                // Start Instance
                string processInstanceId = camunda.BpmnWorkflowService.StartProcessInstance("BPMNSubModelTest", inputsVariables);

                processInstanceId.Should().NotBeNullOrEmpty();

                // Check that External Task for policy created is there
                var externalTasks = camunda.ExternalTaskService.FetchAndLockTasks("testcase1", 100, "brannInputsValidationTest", 1000, new List<string>());
                //camunda.ExternalTaskService.FetchAndLockTasks("testcase", 100, "issuePolicy", 1000, new List<string>());
                externalTasks.Count.Should().Be(1);
                externalTasks.First().ActivityId.Should().Be("branninputsVariablesValidation");
                camunda.ExternalTaskService.Complete("testcase1", externalTasks.First().Id, new Dictionary<string, object>());

                var noko = camunda.HumanTaskService.LoadVariables("getModelOutputs");

                //// Check User Task
                //var tasks = camunda.HumanTaskService.LoadTasks(new Dictionary<string, string>() {
                //    { "processInstanceId", processInstanceId }
                //});
                //Assert.AreEqual(1, tasks.Count);
                //Assert.AreEqual("userTaskAntragEntscheiden", tasks.First().TaskDefinitionKey);

                //// Complete User Task, approve application
                //camunda.HumanTaskService.Complete(tasks.First().Id, new Dictionary<string, object>() {
                //    {"approved", true }
                //});

                //// Check that External Task for policy created is there
                //var externalTasks = camunda.ExternalTaskService.FetchAndLockTasks("testcase", 100, "issuePolicy", 1000, new List<string>());
                //Assert.AreEqual(1, externalTasks.Count);
                //Assert.AreEqual("ServiceTaskPoliceAusstellen", externalTasks.First().ActivityId);
                //camunda.ExternalTaskService.Complete("testcase", externalTasks.First().Id, new Dictionary<string, object>());

                //// Check that External Task for sending the policy is there
                //externalTasks = camunda.ExternalTaskService.FetchAndLockTasks("testcase", 100, "sendEmail", 1000, new List<string>());
                //Assert.AreEqual(1, externalTasks.Count);
                //Assert.AreEqual("ServiceTaskSendPolicy", externalTasks.First().ActivityId);
                //camunda.ExternalTaskService.Complete("testcase", externalTasks.First().Id, new Dictionary<string, object>());

                //// now the process instance has ended, TODO: Check state with History
            }
            finally
            {
                // cleanup after test case
                camunda.RepositoryService.DeleteDeployment(deploymentId);
            }
        }
        [Fact]
        public void GetListOfValueFromJsonObj()
        {
            const string file = "JsonInputVariables.json";
            var jsonFile = Path.Combine(Directory.GetCurrentDirectory() + @"..\..\..\TestData\", file);
            var jsonText = File.ReadAllText(jsonFile);
            //var sponsors = JsonConvert.DeserializeObject<object>(jsonText);
            //var table = GetValueFromJsonObj(sponsors, "risikoklasseFraTypeVirksomhet");
            //var jsonTable = JsonConvert.DeserializeObject<object>(table.ToString());
            var jo = JObject.Parse(jsonText);
            var id = jo["risikoklasseFraTypeVirksomhet"]["ValueInfo"]["objectTypeName"];


            jsonText.Should().NotBeNullOrEmpty();
        }
        [Fact]
        public void CreateModelDicionary()
        {

            var BranntekniskProsjektering = new Dictionary<string, TableInfo>();
            var BranncelleRomningUtgangVariables = new[]
            {
                new BranntekniskProsjekteringModelBuilder().AddVariableInfo("kravFriBreddeRomnVei","Fri bredde rømningsvei","Krav til fri bredde i rømningsvei, etter risikoklasse"),
                new BranntekniskProsjekteringModelBuilder().AddVariableInfo("kravMinFriDorBredde","Min fri dør bredde","Krav til minste fri bredde på dør, etter risikoklasse"),
                new BranntekniskProsjekteringModelBuilder().AddVariableInfo("kravMaxLengdeFluktvei","Lengste fluktvei","Maksimal lengde på fluktvei (m), etter risikoklasse"),
                new BranntekniskProsjekteringModelBuilder().AddVariableInfo("avstandDorIBranncelle1Dor","Avstand til dør (1)","Krav til lengste avstand til dør som er utgang fra branncelle eller til trapp, ved 1 dør, etter risikoklasse"),
                new BranntekniskProsjekteringModelBuilder().AddVariableInfo("kravAvstandDorIBranncelleflereDorer","Avstand til dør (>1)","Krav til lengste avstand til dør som er utgang fra branncelle eller til trapp, ved flere dører, etter risikoklasse"),
            };
            var BranncelleRomningUtgangTableInfo =  new BranntekniskProsjekteringModelBuilder().AddTableInfo("Utgang fra branncelle", "§ 11-13", "", "https://dibk.no/byggereglene/byggteknisk-forskrift-tek17/11/iv/11-13/",BranncelleRomningUtgangVariables);
            BranntekniskProsjektering.Add("BranncelleRomningUtgang", BranncelleRomningUtgangTableInfo);

            var brannDictionary = new BrannDictionaryModel().BranntekniskProsjekteringDictionary;
            brannDictionary = BranntekniskProsjektering;


            var JsonBrannDictionary = JsonConvert.SerializeObject(brannDictionary);

            JsonBrannDictionary.Should().NotBeNullOrEmpty();
        }
    }
}

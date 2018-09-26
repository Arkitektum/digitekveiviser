using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dibk.digitek.veiviser.Models;

namespace VeiviserTest.Builders
{
    public class BranntekniskProsjekteringModelBuilder
    {
        //private readonly BrannDictionaryModel _brannDictionaryModel = new BrannDictionaryModel();

        //public BranntekniskProsjekteringModelBuilder()
        //{
        //    _brannDictionaryModel.BranntekniskProsjekteringDictionary = new Dictionary<string, TableInfo>();
        //}

        //public BrannDictionaryModel Build()
        //{
        //    return _brannDictionaryModel;
        //}

        public VariablesInfo AddVariableInfo(string variableId, string variableName, string variableDescription)
        {
            var variableInfo = new VariablesInfo()
            {
                VariabelId = variableId,
                VariabelNavn = variableName,
                VariabelBeskrivelse = variableDescription
            };
            return variableInfo;
        }

        public TableInfo AddTableInfo(string tableName, string chapter, string ledd, string url, VariablesInfo[] variablesInfo)
        {
            var tableInfo = new TableInfo()
            {
                TekKapitel = "§ 11-12",
                TekLedd = "Tabell 3",
                DmnId = "Brannalarmkategori avhengig av risikoklasse",
                TekWebLink = "https://dibk.no/byggereglene/byggteknisk-forskrift-tek17/11/iv/11-12/",
                OutputVariablesInfo = variablesInfo
            };
            return tableInfo;
        }
    }
}

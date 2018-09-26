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
                VariableId = variableId,
                VariableName = variableName,
                VariableDescription = variableDescription
            };
            return variableInfo;
        }

        public TableInfo AddTableInfo(string tableName, string chapter, string ledd, string url, VariablesInfo[] variablesInfo)
        {
            var tableInfo = new TableInfo()
            {
                Chapter = "§ 11-12",
                Ledd = "Tabell 3",
                TableName = "Brannalarmkategori avhengig av risikoklasse",
                Url = "https://dibk.no/byggereglene/byggteknisk-forskrift-tek17/11/iv/11-12/",
                VariablesInfo = variablesInfo
            };
            return tableInfo;
        }
    }
}

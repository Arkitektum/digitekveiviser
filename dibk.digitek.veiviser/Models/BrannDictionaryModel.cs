using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dibk.digitek.veiviser.Models
{
    public class BrannDictionaryModel
    {
        public Dictionary<string, TableInfo> BranntekniskProsjekteringDictionary{ get; set;}
    }

    public class TableInfo {
        public string TableName { get; set; }
        public string Chapter { get; set; }
        public string Ledd { get; set; }
        public string Url { get; set; }
        public VariablesInfo[] VariablesInfo { get; set; }
    }

    public class VariablesInfo
    {
        public string VariableId { get; set; }
        public string VariableName { get; set; }
        public string VariableDescription { get; set; }
    }
}
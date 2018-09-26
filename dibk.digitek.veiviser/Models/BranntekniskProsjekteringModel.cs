using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dibk.digitek.veiviser.Models
{
    public class BranntekniskProsjekteringModel
    {
        //Opt1 to RKL and To Opt1 BKL
        public string _typeVirksomhet { get; set; }

        //Opt1 to BKL + RKL from Opt1 
        public long? _antallEtasjer { get; set; }
        public long? _brtArealPrEtasje { get; set; }
        public bool? _utgangTerrengAlleBoenheter { get; set; }

        //Opt2 to RKL

        public string _bareSporadiskPersonopphold { get; set; }
        public bool? _alleKjennerRomningsVeiene { get; set; }
        public bool? _beregnetForOvernatting { get; set; }
        public bool? _liteBrannfarligAktivitet { get; set; }

        //Opt2 to BKL
        public string _konsekvensAvBrann { get; set; }

        // Commun to all
        public long? _arealBrannseksjonPrEtasje { get; set; }
        public long? _brannenergi { get; set; }
        public bool? _bygningOffentligUnderTerreng { get; set; }
    }
}
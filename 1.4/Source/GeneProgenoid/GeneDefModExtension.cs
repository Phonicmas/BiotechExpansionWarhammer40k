using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;


namespace BEWH
{
    public class GeneProgenoidDefExtension : DefModExtension
    {
        public GeneDef requiredGeneAny;
        public GeneDef wantedGene;
        public float requriedSeverity;
    }
}
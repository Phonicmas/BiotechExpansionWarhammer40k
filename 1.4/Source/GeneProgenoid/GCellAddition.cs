using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;

namespace GeneProgenoid
{
    public class GCellAddition
    {
        private static bool HasGene (RecipeDef recipeDef, GeneDef geneDef, Pawn pawn)
        {
            if (recipeDef.HasModExtension<GeneProgenoidExtension>())
            {
                if (pawn.genes.HasXenogene(geneDef))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;
using VanillaPsycastsExpanded;
using RimWorld.Planet;

namespace Psyker
{
    public class PsykerPathDef : PsycasterPathDef
    {
        private List<GeneDef> requiredGeneAny;

        public override bool CanPawnUnlock(Pawn pawn)
        {
            return base.CanPawnUnlock(pawn) && PawnHasGene(pawn);
        }

        private bool PawnHasGene(Pawn pawn)
        {
            foreach (var gene in requiredGeneAny)
            {
                if (pawn.genes.HasXenogene(gene))
                    return true;
            }
            return false;
        }
    }
}
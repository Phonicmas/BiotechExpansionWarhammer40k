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

        private List<GeneDef> requiredGeneAll;

        public override bool CanPawnUnlock(Pawn pawn)
        {
            return base.CanPawnUnlock(pawn) && PawnHasGeneAny(pawn) && PawnHasGeneAll(pawn);
        }

        private bool PawnHasGeneAny(Pawn pawn)
        {
            if (requiredGeneAny.NullOrEmpty())
                return true;

            foreach (var gene in requiredGeneAny)
            {
                if (pawn.genes.HasXenogene(gene))
                    return true;
            }
            return false;
        }

        private bool PawnHasGeneAll(Pawn pawn)
        {
            if (requiredGeneAny.NullOrEmpty())
                return true;

            foreach (var gene in requiredGeneAll)
            {
                if (pawn.genes.HasXenogene(gene))
                    return true;
            }
            return false;
        }
    }
}
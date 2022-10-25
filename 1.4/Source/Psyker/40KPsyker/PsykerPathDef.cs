using System.Collections.Generic;
using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;
using VanillaPsycastsExpanded;

namespace Psyker
{
    public class PsykerPathDef : PsycasterPathDef
    {
        private GeneDef requiredGeneAny;

        public override bool CanPawnUnlock(Pawn pawn) => PawnHasGene(pawn);

        private bool PawnHasGene(Pawn pawn) => requiredGeneAny == null || pawn.genes.HasXenogene(requiredGeneAny);
    }
}
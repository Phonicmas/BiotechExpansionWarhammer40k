using System.Collections.Generic;
using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;
using VanillaPsycastsExpanded;

namespace Psyker;
public class PsycasterPathDef : VanillaPsycastsExpanded.PsycasterPathDef
{
    private GeneDef requiredGeneAny;

    public override bool CanPawnUnlock(Pawn pawn) => PawnHasCorrectBackstory(pawn) && PawnHasMeme(pawn) && PawnHasGene(pawn);

    //private bool PawnHasGene (Pawn pawn) => true;
    private bool PawnHasGene(Pawn pawn) => requiredGene == null || (pawn.genes.HasXenogene(requiredGeneAny) ?? false);

    /*private bool PawnHasGene(Pawn pawn)
    {
        if (requiredGene.NullOrEmpty()) return true;
        foreach (var requirement in requiredGeneAny)
            if (pawn.genes.HasXenogene(requirement.slot)?.spawnCategories is { } spawnCategories && spawnCategories.Contains(requirement.categoryName))
                return true;

        return false;
    }*/
}
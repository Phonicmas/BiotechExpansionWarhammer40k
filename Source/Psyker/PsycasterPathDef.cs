using System.Collections.Generic;
using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;

namespace Psyker

public GeneDef requiredGene;

public override bool CanPawnUnlock (Pawn pawn) => PawnHasCorrectBackstory(pawn) && PawnHasMeme(pawn) && PawnHasGene(pawn);

private bool PawnHasGene (Pawn pawn) => requiredGene == null || (pawn.gene.Contains(requiredMeme) ?? false);
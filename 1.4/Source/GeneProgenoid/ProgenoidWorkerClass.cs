using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace BEWH
{
    public class GeneProgenoidWorkerClass : Recipe_Surgery
    {
        public override bool AvailableOnNow(Thing thing, BodyPartRecord part = null)
        {
            if (!base.AvailableOnNow(thing, part) || !(thing is Pawn pawn))
                return false;
            Hediff hediff = pawn.health.hediffSet.hediffs.Find((Predicate<Hediff>)(x => x.def == this.recipe.addsHediff && x.Part == part && x.Visible));
            if (hediff == null)
            {
                if (pawn.genes.HasXenogene(this.recipe.GetModExtension<GeneProgenoidDefExtension>()?.requiredGeneAny))
                    return true;
            }
            return false;
        }

        public override void ApplyOnPawn(Pawn pawn, BodyPartRecord part, Pawn billDoer, List<Thing> ingredients, Bill bill)
        {
            if (billDoer != null)
            {
                if (this.CheckSurgeryFail(billDoer, pawn, ingredients, part, bill))
                    return;
                TaleRecorder.RecordTale(TaleDefOf.DidSurgery, (object)billDoer, (object)pawn);
            }
            pawn.health.AddHediff(this.recipe.addsHediff, part);
            this.OnSurgerySuccess(pawn, part, billDoer, ingredients, bill);
        }
    }

}
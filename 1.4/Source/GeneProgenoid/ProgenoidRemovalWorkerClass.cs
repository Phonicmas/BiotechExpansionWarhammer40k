using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace GeneProgenoid
{
    public class GeneProgenoidRemovalWorkerClass : Recipe_Surgery
    {
        public override bool AvailableOnNow(Thing thing, BodyPartRecord part = null)
        {
            if (!base.AvailableOnNow(thing, part) || !(thing is Pawn pawn))
                return false;
            List<Hediff> hediffs = pawn.health.hediffSet.hediffs;
            for (int index = 0; index < hediffs.Count; ++index)
            {
                if ((!this.recipe.targetsBodyPart || hediffs[index].Part != null) && hediffs[index].def == this.recipe.removesHediff && hediffs[index].Visible)
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
                if (PawnUtility.ShouldSendNotificationAbout(pawn) || PawnUtility.ShouldSendNotificationAbout(billDoer))
                    Messages.Message(this.recipe.successfullyRemovedHediffMessage.NullOrEmpty() ? (string)"MessageSuccessfullyRemovedHediff".Translate((NamedArgument)billDoer.LabelShort, (NamedArgument)pawn.LabelShort, this.recipe.removesHediff.label.Named("HEDIFF"), billDoer.Named("SURGEON"), pawn.Named("PATIENT")) : (string)this.recipe.successfullyRemovedHediffMessage.Formatted((NamedArgument)billDoer.LabelShort, (NamedArgument)pawn.LabelShort), (LookTargets)(Thing)pawn, MessageTypeDefOf.PositiveEvent);
            }
            Hediff hediff = pawn.health.hediffSet.hediffs.Find((Predicate<Hediff>)(x => x.def == this.recipe.removesHediff && x.Part == part && x.Visible));
            if (hediff == null)
                return;
            pawn.health.RemoveHediff(hediff);
            this.OnSurgerySuccess(pawn, part, billDoer, ingredients, bill);
            return;
        }

        protected override void OnSurgerySuccess(Pawn pawn, BodyPartRecord part, Pawn billDoer, List<Thing> ingredients, Bill bill)
        {
            if (GenPlace.TryPlaceThing(ThingMaker.MakeThing(ThingDefOf.ArchiteCapsule), pawn.PositionHeld, pawn.MapHeld, ThingPlaceMode.Near))
                return;
            Log.Error("Could not drop item near " + (object)pawn.PositionHeld);
        }

    }

}
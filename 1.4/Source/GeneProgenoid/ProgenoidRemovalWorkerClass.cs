using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Verse;
using Verse.AI;

namespace BEWH
{
    public class GeneProgenoidRemovalWorkerClass : Recipe_Surgery
    {
        public override bool AvailableOnNow(Thing thing, BodyPartRecord part = null)
        {
            if (!base.AvailableOnNow(thing, part) || !(thing is Pawn pawn))
                return false;
            if (!pawn.genes.HasXenogene(BEWHDefOf.BEWH_ProgenoidGlands))
                return false;
            if (recipe.defName == "BEWH_PrimarisPack" && !pawn.genes.HasXenogene(BEWHDefOf.BEWH_SinewCoil))
                return false;
            List<Hediff> hediffs = pawn.health.hediffSet.hediffs;
            for (int index = 0; index < hediffs.Count; ++index)
            {
                if ((!recipe.targetsBodyPart || hediffs[index].Part != null) && hediffs[index].def == recipe.removesHediff && hediffs[index].Visible)
                {
                    if (hediffs[index].Severity >= 1f)
                        return true;
                }
            }
            return false;
        }

        public override void ApplyOnPawn(Pawn pawn, BodyPartRecord part, Pawn billDoer, List<Thing> ingredients, Bill bill)
        {
            if (billDoer != null)
            {
                if (CheckSurgeryFail(billDoer, pawn, ingredients, part, bill))
                {
                    return;
                }
                TaleRecorder.RecordTale(TaleDefOf.DidSurgery, billDoer, pawn);
                if (PawnUtility.ShouldSendNotificationAbout(pawn) || PawnUtility.ShouldSendNotificationAbout(billDoer))
                {
                    string text = (recipe.successfullyRemovedHediffMessage.NullOrEmpty() ? ((string)"MessageSuccessfullyRemovedHediff".Translate(billDoer.LabelShort, pawn.LabelShort, recipe.removesHediff.label.Named("HEDIFF"), billDoer.Named("SURGEON"), pawn.Named("PATIENT"))) : ((string)recipe.successfullyRemovedHediffMessage.Formatted(billDoer.LabelShort, pawn.LabelShort)));
                    Messages.Message(text, pawn, MessageTypeDefOf.PositiveEvent);
                }
            }
            Hediff hediff = pawn.health.hediffSet.hediffs.Find((Hediff x) => x.def == recipe.removesHediff && x.Part == part && x.Visible);
            if (hediff != null)
            {
                pawn.health.RemoveHediff(hediff);
                OnSurgerySuccess(pawn, part, billDoer, ingredients, bill);
            }
        }

        protected override void OnSurgerySuccess(Pawn pawn, BodyPartRecord part, Pawn billDoer, List<Thing> ingredients, Bill bill)
        {
            Genepack genepack = (Genepack)ThingMaker.MakeThing(ThingDefOf.Genepack);
            List<GeneDef> genedef = new List<GeneDef>();
            if (recipe.defName == "BEWH_AstartesPack")
            {
                genedef = AstartesPack();
            }
            else if (recipe.defName == "BEWH_PrimarisPack")
            {
                genedef = PrimarisPack();
            }
            genepack.Initialize(genedef);
            if (GenPlace.TryPlaceThing(((Thing)genepack), pawn.PositionHeld, pawn.MapHeld, ThingPlaceMode.Near))
                return;
            Log.Error("Could not drop item near " + (object)pawn.PositionHeld);
        }

        private List<GeneDef> AstartesPack()
        {
            List<GeneDef> genedef = new List<GeneDef>();
            genedef.Add(BEWHDefOf.BEWH_SecondaryHeart);
            genedef.Add(BEWHDefOf.BEWH_Ossmodula);
            genedef.Add(BEWHDefOf.BEWH_Biscopea);
            genedef.Add(BEWHDefOf.BEWH_Haemastamen);
            genedef.Add(BEWHDefOf.BEWH_LarramansOrgan);
            genedef.Add(BEWHDefOf.BEWH_CatalepseanNode);
            genedef.Add(BEWHDefOf.BEWH_Preomnor);
            genedef.Add(BEWHDefOf.BEWH_Omophagea);
            genedef.Add(BEWHDefOf.BEWH_MultiLung);
            genedef.Add(BEWHDefOf.BEWH_Occulobe);
            genedef.Add(BEWHDefOf.BEWH_LymansEar);
            genedef.Add(BEWHDefOf.BEWH_SusAnMembrane);
            genedef.Add(BEWHDefOf.BEWH_Melanochrome);
            genedef.Add(BEWHDefOf.BEWH_OoliticKidney);
            genedef.Add(BEWHDefOf.BEWH_Neuroglottis);
            genedef.Add(BEWHDefOf.BEWH_Mucranoid);
            genedef.Add(BEWHDefOf.BEWH_BetchersGland);
            genedef.Add(BEWHDefOf.BEWH_ProgenoidGlands);
            genedef.Add(BEWHDefOf.BEWH_BlackCarapace);
            return genedef;
        }

        private List<GeneDef> PrimarisPack()
        {
            List<GeneDef> genedef = new List<GeneDef>();
            genedef.Add(BEWHDefOf.BEWH_SecondaryHeart);
            genedef.Add(BEWHDefOf.BEWH_Ossmodula);
            genedef.Add(BEWHDefOf.BEWH_Biscopea);
            genedef.Add(BEWHDefOf.BEWH_Haemastamen);
            genedef.Add(BEWHDefOf.BEWH_LarramansOrgan);
            genedef.Add(BEWHDefOf.BEWH_CatalepseanNode);
            genedef.Add(BEWHDefOf.BEWH_Preomnor);
            genedef.Add(BEWHDefOf.BEWH_Omophagea);
            genedef.Add(BEWHDefOf.BEWH_MultiLung);
            genedef.Add(BEWHDefOf.BEWH_Occulobe);
            genedef.Add(BEWHDefOf.BEWH_LymansEar);
            genedef.Add(BEWHDefOf.BEWH_SusAnMembrane);
            genedef.Add(BEWHDefOf.BEWH_Melanochrome);
            genedef.Add(BEWHDefOf.BEWH_OoliticKidney);
            genedef.Add(BEWHDefOf.BEWH_Neuroglottis);
            genedef.Add(BEWHDefOf.BEWH_Mucranoid);
            genedef.Add(BEWHDefOf.BEWH_BetchersGland);
            genedef.Add(BEWHDefOf.BEWH_ProgenoidGlands);
            genedef.Add(BEWHDefOf.BEWH_BlackCarapace);
            genedef.Add(BEWHDefOf.BEWH_SinewCoil);
            genedef.Add(BEWHDefOf.BEWH_Magnificat);
            genedef.Add(BEWHDefOf.BEWH_BelisarianFurnace);
            return genedef;
        }
    }

}
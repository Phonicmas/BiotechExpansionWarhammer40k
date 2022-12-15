using AnimalBehaviours;
using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Verse;


namespace BEWH
{
    public class HediffCompAura : HediffComp
    {
        public int tickCounter = 0;

        public HediffCompPropertiesAura Props => (HediffCompPropertiesAura)props;

        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);
            tickCounter++;
            if (tickCounter < Props.tickInterval)
            {
                return;
            }
            Pawn pawn = parent.pawn;
            if (pawn != null && pawn.Map != null && !pawn.Dead)
            {
                foreach (Thing item in GenRadial.RadialDistinctThingsAround(pawn.Position, pawn.Map, Props.radius, useCenter: true))
                {
                    if (item is Pawn otherPawn && !pawn.Dead && otherPawn != pawn)
                    {
                        otherPawn.health.AddHediff(Props.hediff);
                        //otherPawn.psychicEntropy.TryAddEntropy(999999);
                    }
                }

            }
            tickCounter = 0;
        }
    }
}
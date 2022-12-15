using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;


namespace BEWH
{
    public class HediffCompPropertiesAura : HediffCompProperties
    {

        public int radius = 1;

        public int tickInterval = 100;

        public HediffDef hediff;

        public float severity = 1f;

        public HediffCompPropertiesAura()
        {
            compClass = typeof(HediffCompAura);
        }

    }
}
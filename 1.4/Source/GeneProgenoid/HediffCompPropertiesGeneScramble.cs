using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;


namespace BEWH
{
    public class HediffCompPropertiesGeneScramble : HediffCompProperties
    {

        public int scrambleAmount;

        public HediffCompPropertiesGeneScramble()
        {
            compClass = typeof(HediffCompGeneScramble);
        }

    }
}
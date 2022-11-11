using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;


namespace GeneProgenoid
{
    public class ConditionalStatAffecter_PowerArmor : ConditionalStatAffecter
    {
        public override string Label => (string)"Wearing power armor";

        public override bool Applies(StatRequest req)
        {
            if (!ModsConfig.BiotechActive || !req.HasThing || !(req.Thing is Pawn thing1) || thing1.apparel == null)
                return false;
            foreach (Thing thing2 in thing1.apparel.WornApparel)
            {
                if (thing2.def.apparel.tags.Contains("PowerArmor"))
                    return true;
            }
            return false;
        }
    }
}
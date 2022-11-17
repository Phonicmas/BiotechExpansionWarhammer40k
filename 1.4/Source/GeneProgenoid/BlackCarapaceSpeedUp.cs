using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;


namespace BEWH
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
                if (thing2.def.apparel.tags.Contains("PowerArmor") || thing2.def.apparel.tags.Contains("AAPowerArmor") || thing2.def.apparel.tags.Contains("AAScoutArmor") || thing2.def.apparel.tags.Contains("AATerminatorArmor"))
                    return true;
            }
            return false;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;
using VanillaPsycastsExpanded;
using RimWorld.Planet;

namespace Psyker
{
    public class RemembranceAbility : Ability_TargetCorpse
    {
        public override void Cast(params GlobalTargetInfo[] targets)
        {
            base.Cast(targets);
            Hediff_CorpseTalk hediff_CorpseTalk = ApplyHediff(pawn) as Hediff_CorpseTalk;
            if (hediff_CorpseTalk.skillXPDifferences != null)
            {
                hediff_CorpseTalk.ResetSkills();
            }
            else
            {
                hediff_CorpseTalk.skillXPDifferences = new Dictionary<SkillDef, int>();
            }
            Corpse corpse = targets[0].Thing as Corpse;
            foreach (SkillDef allDef in DefDatabase<SkillDef>.AllDefs)
            {
                SkillRecord skill = pawn.skills.GetSkill(allDef);
                SkillRecord skill2 = corpse.InnerPawn.skills.GetSkill(allDef);
                int num = skill2.Level - skill.Level;
                if (num > 0)
                {
                    int level = skill.Level;
                    skill.Level = Mathf.Min(20, skill.Level + num);
                    hediff_CorpseTalk.skillXPDifferences[allDef] = skill.Level - level;
                }
            }
        }
    }
}
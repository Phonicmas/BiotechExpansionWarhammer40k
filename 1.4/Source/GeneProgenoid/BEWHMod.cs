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
    public class BEWHMod : Mod
    {
        public BEWHMod(ModContentPack content)
            : base(content)
        {
            new Harmony("BEWH.Mod").PatchAll();
        }
    }
}
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
    [DefOf]
    public static class BEWHDefOf
    {
        public static GeneDef BEWH_BlackCarapace;
        public static GeneDef BEWH_Custodes;
        public static GeneDef BEWH_Primarch;
        public static GeneDef BEWH_SigmaPariah;
        public static GeneDef BEWH_UpsilonPariah;
        public static GeneDef BEWH_OmegaPariah;

        static BEWHDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(BEWHDefOf));
        }
    }
}
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
        public static GeneDef BEWH_Custodes;
        public static GeneDef BEWH_Primarch;
        public static GeneDef BEWH_SigmaPariah;
        public static GeneDef BEWH_UpsilonPariah;
        public static GeneDef BEWH_OmegaPariah;

        public static GeneDef BEWH_SecondaryHeart;
        public static GeneDef BEWH_Ossmodula;
        public static GeneDef BEWH_Biscopea;
        public static GeneDef BEWH_Haemastamen;
        public static GeneDef BEWH_LarramansOrgan;
        public static GeneDef BEWH_CatalepseanNode;
        public static GeneDef BEWH_Preomnor;
        public static GeneDef BEWH_Omophagea;
        public static GeneDef BEWH_MultiLung;
        public static GeneDef BEWH_Occulobe;
        public static GeneDef BEWH_LymansEar;
        public static GeneDef BEWH_SusAnMembrane;
        public static GeneDef BEWH_Melanochrome;
        public static GeneDef BEWH_OoliticKidney;
        public static GeneDef BEWH_Neuroglottis;
        public static GeneDef BEWH_Mucranoid;
        public static GeneDef BEWH_BetchersGland;
        public static GeneDef BEWH_ProgenoidGlands;
        public static GeneDef BEWH_BlackCarapace;

        public static GeneDef BEWH_SinewCoil;
        public static GeneDef BEWH_Magnificat;
        public static GeneDef BEWH_BelisarianFurnace;

        public static RecipeDef BEWH_AstartesPack;
        public static RecipeDef BEWH_PrimarisPack;

        static BEWHDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(BEWHDefOf));
        }
    }
}
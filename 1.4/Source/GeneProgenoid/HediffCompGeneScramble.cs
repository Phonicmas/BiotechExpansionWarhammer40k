using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;


namespace BEWH
{

    public class HediffCompGeneScramble : HediffComp
    {
        static GeneDef psykerGene = DefDatabase<GeneDef>.GetNamed("BEWH_Psyker");
        //All mutation genes
        static List<GeneDef> mutations = new List<GeneDef> { 
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation1"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation2"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation3"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation4"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation5"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation6"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation7"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation8"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation9"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation10"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation11"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation12"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation13"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation14"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation15"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation16"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation17"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation18"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation19"),
            DefDatabase<GeneDef>.GetNamed("BEWH_Mutation20")};

        static ThingDef humanrace = DefDatabase<ThingDef>.GetNamed("Human");
        public HediffCompPropertiesGeneScramble Props => (HediffCompPropertiesGeneScramble)props;

        public override void CompPostMake()
        {
            //Lav check som sikre det er en pawn og ikke alt andet.
            Pawn pawn = base.Pawn;

            //Make it spawn a chaos spawn instead
            if (!(pawn.kindDef.race == humanrace))
            {
                return;
            }

            var rand = new Random();

            int scrambleAmount = Props.scrambleAmount;

            List<Gene> xenogenes = new List<Gene>(pawn.genes.Xenogenes);
            List<Gene> endogenes = new List<Gene>(pawn.genes.Endogenes);
            List<Gene> combinedGenes = xenogenes.Concat(endogenes).ToList();
            combinedGenes.RemoveAll(p => p.def == psykerGene);

            //List<GeneDef> allGeneDefs = DefDatabase<GeneDef>.AllDefs.ToList();
            //allGeneDefs.Remove(psykerGene);

            List<Gene> genesToRemove = new List<Gene>();
            List<GeneDef> genesToAdd = new List<GeneDef>();

            List<int> randomList = new List<int>();
            List<int> randomList2 = new List<int>();            

            int totalRemove = endogenes.Count + xenogenes.Count;

            if (totalRemove > scrambleAmount)
            {
                totalRemove = scrambleAmount;
            }

            int num = 0;

            //Adds unique random numbers
            while((randomList.Count < totalRemove) || (randomList2.Count < scrambleAmount))
            {
                if (randomList.Count < totalRemove)
                {
                    num = rand.Next(0, combinedGenes.Count);
                    if (!randomList.Contains(num))
                    {
                        randomList.Add(num);
                    }
                }

                if (randomList2.Count < scrambleAmount)
                {
                    num = rand.Next(0, mutations.Count);
                    if (!randomList2.Contains(num))
                    {
                        randomList2.Add(num);
                    }
                }
            }

            //Removes genes
            for (int i = 0; i < totalRemove; i++)
            {
                pawn.genes.RemoveGene(combinedGenes[randomList[i]]);
            }

            //Adds genes
            for (int i = 0; i < scrambleAmount; i++)
            {
                pawn.genes.AddGene(mutations[randomList2[i]], true);
            }

        }

    }

}
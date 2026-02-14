using RimWorld;
using UnityEngine;
using Verse;
using Verse.AI;

namespace VPEHerald.TrashEater
{
    public class JobGiver_TrashEater : ThinkNode_JobGiver
    {
        public override Job TryGiveJob(Pawn pawn)
        {
            CompTrashEater comp = pawn.TryGetComp<CompTrashEater>(); 
            if(comp == null)
            {
                return null;
            }
            if(comp.AmountToAutofill == 0)
            {
                return null;
            }
            Thing thingToEat = GetThingToEat(pawn, comp);
            if (thingToEat != null)
            {
                Job job = JobMaker.MakeJob(DefOfs.Herald_EatThing, thingToEat);
                job.count = Mathf.Min(thingToEat.stackCount, comp.AmountToAutofill);
                return job;
            }
            return null;
        }
        private Thing GetThingToEat(Pawn pawn, CompTrashEater comp)
        {
            Thing carriedThing = pawn.carryTracker.CarriedThing;
            if (carriedThing != null && carriedThing.def == comp.Props.thingToEat)
            {
                return carriedThing;
            }
            for (int i = 0; i < pawn.inventory.innerContainer.Count; i++)
            {
                if (pawn.inventory.innerContainer[i].def == comp.Props.thingToEat)
                {
                    return pawn.inventory.innerContainer[i];
                }
            }
            return GenClosest.ClosestThing_Global_Reachable(pawn.Position, pawn.Map, pawn.Map.listerThings.ThingsOfDef(comp.Props.thingToEat), PathEndMode.OnCell, TraverseParms.For(pawn), 9999f, (Thing t) => pawn.CanReserve(t) && !t.IsForbidden(pawn));
        }
    }
}

using Verse;
using Verse.AI.Group;
using VPEHerald.Comp;

namespace VPEHerald.PortalSpawner
{
    public class DeathActionWorker_Scrap : DeathActionWorker
    {
        public override void PawnDied(Corpse corpse, Lord prevLord)
        {
            if (corpse.Map != null)
            {
                Thing newThing = ThingMaker.MakeThing(DefOfs.Herald_ScrapPile);
                GenSpawn.Spawn(newThing, corpse.Position, corpse.Map);
                corpse.Destroy();
                CompSummonedEntity comp = corpse.InnerPawn.TryGetComp<CompSummonedEntity>();
                if (comp != null)
                {
                    comp.summonSource.RemoveSummon(corpse.InnerPawn);
                }
            }
        }
    }
}

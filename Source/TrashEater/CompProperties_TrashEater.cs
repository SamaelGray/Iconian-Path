using Verse;

namespace VPEHerald.TrashEater
{
    public class CompProperties_TrashEater : CompProperties
    {
        public int maxStored = 4;
        public PawnKindDef pawnToSpawn;
        public int spawnAbilityCooldownTicks = 300;
        public ThingDef thingToEat;
        public string gizmoIconeat;
        public string gizmoIconSummon;
        public CompProperties_TrashEater()
        {
            compClass = typeof(CompTrashEater);
        }
    }
}

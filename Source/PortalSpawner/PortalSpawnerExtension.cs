using Verse;

namespace VPEHerald.PortalSpawner
{
    public class PortalSpawnerExtension : DefModExtension
    {
        public PawnKindDef pawnKindToSpawn;
        public int maxSpawns = 5;
        public int spawnInterval = 6000;
    }
}

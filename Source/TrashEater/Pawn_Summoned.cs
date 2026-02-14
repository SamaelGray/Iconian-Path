using RimWorld.Planet;
using VanillaPsycastsExpanded;
using Verse;

namespace VPEHerald.TrashEater
{
    public class Pawn_Summoned : Pawn, IMinHeatGiver
    {
        public bool IsActive => base.Spawned || CaravanUtility.GetCaravan((Pawn)this) != null;

        public int MinHeat => 20;
    }
}

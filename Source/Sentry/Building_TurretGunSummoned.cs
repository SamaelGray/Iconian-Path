using RimWorld;
using VanillaPsycastsExpanded;

namespace VPEHerald.Sentry
{
    public class Building_TurretGunSummoned : Building_TurretGun, IMinHeatGiver
    {
        public bool IsActive => base.Spawned;

        public virtual int MinHeat => 15;

    }
}

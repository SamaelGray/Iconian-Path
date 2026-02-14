using System.Collections.Generic;
using System.Text;
using RimWorld;
using UnityEngine;
using Verse;
using VPEHerald.Comp;

namespace VPEHerald.Sentry
{
    public class Building_TurretSentry : Building_TurretGunSummoned
    {
        public CompBreakLinkBuilding compBreakLink => this.TryGetComp<CompBreakLinkBuilding>();
        public CompExplosive compExplosive => this.TryGetComp<CompExplosive>();
        public override int MinHeat => 25;
        public int Duration = 90000;
        public int halfHour = 1250;
        public int teleportCooldownTicksTotal = 1250;
        public int teleportCooldownTicksRemaining = 0;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref Duration, "Duration");
            Scribe_Values.Look(ref teleportCooldownTicksTotal, "teleportCooldownTicksTotal");
            Scribe_Values.Look(ref teleportCooldownTicksRemaining, "teleportCooldownTicksRemaining");
            
        }

        public override void Tick()
        {
            base.Tick();
            if (this.HitPoints == 0)
            {
                Destroy();
            }
            if (teleportCooldownTicksRemaining > 0)
            {
                teleportCooldownTicksRemaining--;
            }
            if (this.HitPoints > 0 && this.IsHashIntervalTick(Helper.TurretHealthTimeRatio))
            {
                this.HitPoints--;
            }

        }
        public override string GetInspectString()
        {
            StringBuilder sb = new StringBuilder(base.GetInspectString());
            sb.AppendLine("HeraldSentryOwner".Translate(compBreakLink.Pawn.LabelCap));
            sb.Append("HeraldSentryTimeLeft".Translate((HitPoints * Helper.TurretHealthTimeRatio).ToStringTicksToPeriod()));
            return sb.ToString();
        }
        public override IEnumerable<Gizmo> GetGizmos()
        {
            foreach (Gizmo gizmo in base.GetGizmos())
            {
                yield return gizmo;
            }
            yield return new Command_Action
            {
                defaultLabel = "HeraldSentryExplode".Translate(),
                defaultDesc = "HeraldSentryExplodeDesc".Translate(),
                icon = ContentFinder<Texture2D>.Get("Buildings/AlienLaserTurret_Top"),
                action = delegate
                {
                    if (compExplosive != null)
                    {
                        CompProperties_Explosive props = (CompProperties_Explosive)compExplosive.props;
                        props.damageAmountBase = (int)(props.damageAmountBase * (HitPoints / (float)Duration));
                        props.explosiveRadius *= HitPoints / (float)Duration;
                        compExplosive.StartWick();
                    }
                }
            };
            yield return new Command_Teleport
            {
                defaultLabel = "HeraldSentryTeleport".Translate(),
                defaultDesc = "HeraldSentryTeleportDesc".Translate(),
                icon = ContentFinder<Texture2D>.Get("UI/Commands/Attack"),
                turret = this,
                range = 54.9f
            };
        }
    }
}

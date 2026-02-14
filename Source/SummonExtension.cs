using System.Collections.Generic;
using RimWorld;
using RimWorld.Planet;
using UnityEngine;
using VanillaPsycastsExpanded;
using VEF.Abilities;
using Verse;
using VPEHerald.Comp;
using VPEHerald.Sentry;
using Ability = VEF.Abilities.Ability;

namespace VPEHerald
{
    public class SummonExtension : AbilityExtension_AbilityMod
    {
        public List<ThingDef> allowedBuildings;
        public ThingDef thingDef;
        public PawnKindDef pawnDef;
        public override void Cast(GlobalTargetInfo[] targets, Ability ability)
        {
            base.Cast(targets, ability);
            foreach (GlobalTargetInfo globalTargetInfo in targets)
            {
                if(thingDef != null)
                {
                    Thing thing = ThingMaker.MakeThing(thingDef);
                    if (thing.HasComp<CompBreakLinkBuilding>())
                    {
                        thing.TryGetComp<CompBreakLinkBuilding>().Pawn = ability.CasterPawn;
                    }
                    if (thing is Building_TurretSentry sentry)
                    {
                        sentry.HitPoints = ability.GetDurationForPawn() / Helper.TurretHealthTimeRatio;
                        sentry.Duration = ability.GetDurationForPawn() / Helper.TurretHealthTimeRatio;
                    }
                    IntVec3 cell = AdjustCell(ability, globalTargetInfo.Cell, thing);
                    Effecter portalEffecter = DefOfs.Herald_TeleportEffect.Spawn(globalTargetInfo.Cell, ability.Caster.Map, new Vector3(0, 3, 0));
                    ability.AddEffecterToMaintain(portalEffecter, globalTargetInfo.Cell, 180, ability.Caster.Map);
                    TeleportThing(ability, cell, thing);
                }
                if(pawnDef != null)
                {
                    Pawn thing = PawnGenerator.GeneratePawn(pawnDef, ability.Caster.Faction);
                    if (thing.HasComp<CompBreakLink>())
                    {
                        thing.TryGetComp<CompBreakLink>().Pawn = ability.pawn;
                    }
                    IntVec3 cell = AdjustCell(ability, globalTargetInfo.Cell, thing);
                    Effecter portalEffecter = DefOfs.Herald_TeleportEffect.Spawn(globalTargetInfo.Cell, ability.Caster.Map, new Vector3(0, 3, 0));
                    ability.AddEffecterToMaintain(portalEffecter, globalTargetInfo.Cell, 180, ability.Caster.Map);
                    TeleportThing(ability, cell, thing);
                }

            }
        }

        private void TeleportThing(Ability ability, IntVec3 cellToTeleport, Thing thing)
        {
            if (thing.def.CanHaveFaction)
            {
                Log.Message(thing == null);
                thing.SetFactionDirect(ability.pawn.Faction);
            }

            GenPlace.TryPlaceThing(thing, cellToTeleport, ability.pawn.Map, ThingPlaceMode.Direct);
        }

        private IntVec3 AdjustCell(Ability ability, IntVec3 cellToTeleport, Thing thing)
        {
            if (!CanTeleport(cellToTeleport))
            {
                RCellFinder.TryFindRandomCellNearWith(
                    cellToTeleport,
                    CanTeleport,
                    ability.pawn.Map,
                    out cellToTeleport,
                    1,
                    1000
                );
            }

            return cellToTeleport;


            bool CanTeleport(IntVec3 cell)
            {
                return CanTeleportThingTo(cell, ability);
            }
        }

        private bool CanTeleportThingTo(IntVec3 cell, Ability ability)
        {
            // check there is no building or it is an allowed building
            Building building = cell.GetFirstBuilding(ability.pawn.Map);
            if (building is not null && !allowedBuildings.Contains(building.def))
            {
                return false;
            }

            // check there is no item
            return cell.GetFirstItem(ability.pawn.Map) == null;
        }

    }
}

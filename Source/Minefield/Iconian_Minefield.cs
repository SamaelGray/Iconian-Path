using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;
using Ability = VEF.Abilities.Ability;

namespace VPEHerald.Minefield
{
    public class Herald_Minefield : ThingWithComps
    {
        public Ability ability;
        private List<Faction> affectedFactions;
        public Pawn Pawn;

        public override void Tick()
        {
            base.Tick();
            if (!Pawn.psychicEntropy.TryAddEntropy(1f, this) || Pawn.Downed)
            {
                Destroy();
                return;
            }
            if (affectedFactions == null)
            {
                affectedFactions = new List<Faction>();
            }
            List<Pawn> list2 = Map.mapPawns.AllPawnsSpawned.ToList();
            foreach (Pawn item2 in list2)
            {
                if (InAffectedArea(item2.Position))
                {
                    if (item2.IsHashIntervalTick(60))
                    {
                        DamageInfo dinfo = new DamageInfo(DefOfs.Herald_Flame, Rand.RangeInclusive(1, 6));
                        item2.TakeDamage(dinfo);
                    }
                    if (Pawn.Faction == Faction.OfPlayer)
                    {
                        AffectGoodwill(item2.HomeFaction, item2);
                    }
                }
            }
        }
        private void AffectGoodwill(Faction faction, Pawn p)
        {
            if (faction != null && !faction.IsPlayer && !faction.HostileTo(Faction.OfPlayer) && (p == null || !p.IsSlaveOfColony) && !affectedFactions.Contains(faction))
            {
                Faction.OfPlayer.TryAffectGoodwillWith(faction, ability.def.goodwillImpact, canSendMessage: true, canSendHostilityLetter: true, HistoryEventDefOf.UsedHarmfulAbility);
            }
        }
        public bool InAffectedArea(IntVec3 cell)
        {
            return cell.InHorDistOf(Position, ability.GetRadiusForPawn());
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_References.Look(ref Pawn, "pawn");
            Scribe_References.Look(ref ability, "ability");

        }

    }
}

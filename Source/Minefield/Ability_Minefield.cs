using RimWorld.Planet;
using VanillaPsycastsExpanded;
using VanillaPsycastsExpanded.Staticlord;
using VEF.Abilities;
using Verse;

namespace VPEHerald.Minefield
{
    [StaticConstructorOnStartup]
    public class Ability_Minefield : Ability, IAbilityToggle, IChannelledPsycast
    {
        private Herald_Minefield minefield;
        public bool IsActive => minefield?.Spawned ?? false;
        public bool Toggle
        {
            get
            {
                return minefield?.Spawned ?? false;
            }
            set
            {
                if (value)
                {
                    DoAction();
                }
                else
                {
                    minefield?.Destroy();
                }
            }
        }
        public string OffLabel => "Herald_StopMinefield".Translate();
        public override void Cast(params GlobalTargetInfo[] targets)
        {
            base.Cast(targets);
            for (int i = 0; i < targets.Length; i++)
            {
                Log.Message("Test");
                GlobalTargetInfo globalTargetInfo = targets[i];
                Log.Message("Test1");

                minefield = (Herald_Minefield)ThingMaker.MakeThing(DefOfs.Herald_Minefield);
                minefield.Pawn = pawn;
                minefield.ability = this;
                GenSpawn.Spawn(minefield, globalTargetInfo.Cell, globalTargetInfo.Map);
                Log.Message("Test2");


            }
        }
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_References.Look(ref minefield, "minefield");
        }
        public override Gizmo GetGizmo()
        {
            return new Command_AbilityToggle(pawn, this);
        }
    }

}

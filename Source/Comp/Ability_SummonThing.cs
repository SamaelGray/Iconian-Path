using System.Linq;
using Verse;

namespace VPEHerald.Comp
{
    public class Ability_SummonThing : VEF.Abilities.Ability
    {
        public override void Tick()
        {
            base.Tick();
            if (!maintainedEffecters.Any())
            {
                return;
            }


            foreach (Pair<Effecter, TargetInfo> item in maintainedEffecters)
            {
                AdjustPos(item.First, -0.01f);
            }
        }

        public static void AdjustPos(Effecter effecter, float offset)
        {
            foreach (SubEffecter_Sprayer sub in effecter.children.OfType<SubEffecter_Sprayer>())
            {
                if (sub.mote != null)
                {
                    sub.mote.yOffset += offset;
                }
            }
        }


    }
}

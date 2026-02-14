using RimWorld;
using Verse;

namespace VPEHerald.TrashEater
{
    public class CompProperties_ExplodeLeap : CompProperties_AbilityEffect
    {
        public float radius = 15.9f;
        public int damage = 50;
        public DamageDef damageDef = DefOfs.Herald_BombSmall;
        public CompProperties_ExplodeLeap()
        {
            compClass = typeof(CompAbilityEffect_ExplodeLeap);
        }
    }
}

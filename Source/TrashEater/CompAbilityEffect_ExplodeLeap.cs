using RimWorld;
using Verse;

namespace VPEHerald.TrashEater
{
    public class CompAbilityEffect_ExplodeLeap : CompAbilityEffect, ICompAbilityEffectOnJumpCompleted
    {
        private new CompProperties_ExplodeLeap Props => (CompProperties_ExplodeLeap)props;

        public void OnJumpCompleted(IntVec3 origin, LocalTargetInfo target)
        {
            GenExplosion.DoExplosion(target.Cell, target.Pawn.MapHeld, Props.radius, Props.damageDef, this.parent.pawn, Props.damage);
            this.parent.pawn.Destroy();

        }
    }
}

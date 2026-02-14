using System.Reflection;
using HarmonyLib;
using Verse;
using VPEHerald.TrashEater;

namespace VPEHerald.HarmonyPatches
{
    [HarmonyPatch]
    public static class Patch_InMechanitorCommandRange
    {
        public static MethodBase TargetMethod()
        {
            return AccessTools.Method(typeof(MechanitorUtility), nameof(MechanitorUtility.InMechanitorCommandRange));
        }

        public static bool Postfix(bool __result, Pawn mech)
        {
            if(mech is Pawn_Summoned)
            {
                return true;
            }
            return false;
        }
    }
}

using HarmonyLib;
using Verse;

namespace VPEHerald.HarmonyPatches
{
    [StaticConstructorOnStartup]
    public static class HarmonyStarter
    {
        static HarmonyStarter()
        {
            Harmony harmony = new Harmony("Nalzurin.HeraldPsycasts");
            harmony.PatchAll();
        }
    }
}

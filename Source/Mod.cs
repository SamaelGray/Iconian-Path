using UnityEngine;
using Verse;

namespace VPEHerald
{
    public class HeraldPsycasts_Mod : Mod
    {
        public static HeraldPsycasts_Settings settings;
        public HeraldPsycasts_Mod(ModContentPack content) : base(content)
        {
            settings = GetSettings<HeraldPsycasts_Settings>();
        }
        public override string SettingsCategory()
        {
            return "Herald Psycasts";
        }
        public override void DoSettingsWindowContents(Rect inRect)
        {
            settings.DoWindowContents(inRect);
        }
    }
}

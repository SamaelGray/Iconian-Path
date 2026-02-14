using System;
using UnityEngine;
using Verse;

namespace VPEHerald
{
    public class HeraldPsycasts_Settings : ModSettings
    {
        public float ChanceCommon = 0.5f;
        public float ChanceRare = 0.25f;
        public float ChanceEpic = 0.17f;
        public float ChanceLegendary = 0.9f;

        public float MovementSpeedBoostDurationSecondsCap = 60f;
        private string _MovementSpeedBoostDurationSecondsCap;
        public float AttackSpeedBoostDurationSecondsCap = 60f;
        private string _AttackSpeedBoostDurationSecondsCap;
        public override void ExposeData()
        {

            Scribe_Values.Look(ref ChanceCommon, "ChanceCommon", defaultValue: 0.5f);
            Scribe_Values.Look(ref ChanceRare, "ChanceRare", defaultValue: 0.25f);
            Scribe_Values.Look(ref ChanceEpic, "ChanceEpic", defaultValue: 0.17f);
            Scribe_Values.Look(ref ChanceLegendary, "ChanceLegendary", defaultValue: 0.9f);
            Scribe_Values.Look(ref MovementSpeedBoostDurationSecondsCap, "MovementSpeedBoostDurationSecondsCap", defaultValue: 60f);
            Scribe_Values.Look(ref AttackSpeedBoostDurationSecondsCap, "AttackSpeedBoostDurationSecondsCap", defaultValue: 60f);
            base.ExposeData();
        }

        public void DoWindowContents(Rect inRect)
        {
            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.Begin(inRect);
            listing_Standard.Label("SettingsBaseChanceCommon".Translate() + ": " + (ChanceCommon * 100f).ToString() + "%");
            Helper.AdjustWeights(ref ChanceCommon, ref ChanceRare, ref ChanceEpic, ref ChanceLegendary, "Common", (float)Math.Round((double)listing_Standard.Slider(ChanceCommon, 0f, 1f), 2));

            listing_Standard.Label("SettingsBaseChanceRare".Translate() + ": " + (ChanceRare * 100f).ToString() + "%");
            Helper.AdjustWeights(ref ChanceCommon, ref ChanceRare, ref ChanceEpic, ref ChanceLegendary, "Rare", (float)Math.Round((double)listing_Standard.Slider(ChanceRare, 0f, 1f), 2));
            
            listing_Standard.Label("SettingsBaseChanceEpic".Translate() + ": " + (ChanceEpic * 100f).ToString() + "%");
            Helper.AdjustWeights(ref ChanceCommon, ref ChanceRare, ref ChanceEpic, ref ChanceLegendary, "Epic", (float)Math.Round((double)listing_Standard.Slider(ChanceEpic, 0f, 1f), 2));

            listing_Standard.Label("SettingsBaseChanceLegendary".Translate() + ": " + (ChanceLegendary * 100f).ToString() + "%");
            Helper.AdjustWeights(ref ChanceCommon, ref ChanceRare, ref ChanceEpic, ref ChanceLegendary, "Legendary", (float)Math.Round((double)listing_Standard.Slider(ChanceLegendary, 0f, 1f), 2));

            listing_Standard.TextFieldNumericLabeled("SettingMovementSpeedBoostDurationSecondsCap".Translate(), ref MovementSpeedBoostDurationSecondsCap, ref _MovementSpeedBoostDurationSecondsCap, 1, 3000);
            listing_Standard.TextFieldNumericLabeled("SettingAttackSpeedBoostDurationSecondsCap".Translate(), ref AttackSpeedBoostDurationSecondsCap, ref _AttackSpeedBoostDurationSecondsCap, 1, 3000);


            listing_Standard.End();
        }
    }
}

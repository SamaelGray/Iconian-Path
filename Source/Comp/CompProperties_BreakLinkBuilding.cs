using Verse;

namespace VPEHerald.Comp
{
    public class CompProperties_BreakLinkBuilding : CompProperties
    {
        public string gizmoImage;

        public string gizmoLabel;

        public string gizmoDesc;

        public CompProperties_BreakLinkBuilding()
        {
            compClass = typeof(CompBreakLinkBuilding);
        }
    }
}

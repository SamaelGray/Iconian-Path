using Verse;
using Verse.AI;

namespace VPEHerald.TrashEater
{
    public class ThinkNode_ConditionalNeedsToEat : ThinkNode_Conditional
    {
        public override bool Satisfied(Pawn pawn)
        {
            CompTrashEater comp = pawn.TryGetComp<CompTrashEater>();
            if(comp == null)
            {
                return false;
            }
            if(comp.AmountToAutofill == 0)
            {
                return false;
            }
            return true;
        }
    }
}

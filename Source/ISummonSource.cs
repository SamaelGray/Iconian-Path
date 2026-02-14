using System.Collections.Generic;
using Verse;

namespace VPEHerald
{
    public interface ISummonSource
    {
        public List<Thing> SummonListForReading { get;}
        public void AddSummon(Thing thing);
        public void RemoveSummon(Thing thing);
    }
}

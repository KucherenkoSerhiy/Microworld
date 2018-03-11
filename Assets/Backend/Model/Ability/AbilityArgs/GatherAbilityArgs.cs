using System;
using System.Collections.Generic;

namespace Assets.Backend.Model
{
    [Serializable]
    public class GatherAbilityArgs
    {
        public List<string> TargetTagsToGather;
        public int AmountGathered { get; set; }
    }
}
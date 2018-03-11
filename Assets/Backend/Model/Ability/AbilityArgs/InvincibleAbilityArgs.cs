using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Backend.Model
{     
    [Serializable]
    public class InvincibleAbilityArgs
    {
        public int InvincibleTime;
        public bool IsInvincible { get; set; }
    }
}

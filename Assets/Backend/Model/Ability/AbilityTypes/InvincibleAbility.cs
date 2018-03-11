using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Backend.Model
{
    class InvincibleAbility: Ability
    {
        public InvincibleAbilityArgs AbilityArgs { get; set; }

        public InvincibleAbility(Character character, InvincibleAbilityArgs abilityArgs)
        {
            this.Character = character;
            this.AbilityArgs = abilityArgs;

        }

        public override void Activate()
        {
        }

        public override void Collide(Collision2D other)
        {
            // for now do nothing
        }
    }
}

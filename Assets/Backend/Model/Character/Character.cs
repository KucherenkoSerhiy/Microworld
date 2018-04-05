using Assets.Backend.Model.Control;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.Backend.Model
{
    public class Character
    {
        public GameObject Representation { get; set; }
        public List<Ability> Abilities { get; set; }
        public HumanPlayerControl HumanPlayerControl { get; set; }
        public BotPlayerControl BotPlayerControl { get; set; }

        public Character()
        {
            Abilities = new List<Ability>();
        }

        public IControl GetInput()
        {
            if (HumanPlayerControl != null) return HumanPlayerControl;
            if (BotPlayerControl != null) return BotPlayerControl;
            throw new IndexOutOfRangeException("The character has no human nor bot control!");
        }

        public void Act()
        {
            foreach (var ability in Abilities)
            {
                if (ability.IsActive())
                    ability.Activate();
            }
        }

        public void Collide(Collision2D other)
        {
            foreach (var ability in Abilities)
            {
                if (ability.IsActive())
                    ability.Collide(other);
            }

            // health loss on touch enemy
        }

        public void SetControl(IControl control)
        {
            foreach (var ability in Abilities)
            {
                if (ability.IsActive())
                    ability.Input = control;
            }
        }
    }
}
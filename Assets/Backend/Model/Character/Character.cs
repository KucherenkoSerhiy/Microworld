using Assets.Backend.Model.Control;
using System.Collections.Generic;
using UnityEngine;
using System;
using Backend.Model;
using Assets.Backend.GameCore.A.I;
using System.Threading;

namespace Assets.Backend.Model
{
    public enum EnHorizontalDirection {Left, Right}
    
    public class Character
    {
        private bool _isActive;

        public GameObject Representation { get; set; }
        public List<Ability> Abilities { get; set; }
        public HumanPlayerControl HumanPlayerControl { get; set; }
        public bool CanBePossessed { get; set; }
        public NpcIntelligenceBase BotPlayerControl { get; set; }
        public EnHorizontalDirection HorizontalDirection { get; set; }
        public Damage TouchDamage { get; set; }

        public Character()
        {
            Abilities = new List<Ability>();
        }
        
        public void Act()
        {
            if (_isActive)
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

        internal void Activate()
        {
            if (!_isActive)
            {
                if (BotPlayerControl != null)
                    BotPlayerControl.Activate();

                _isActive = true;
            }
        }
    }
}
using System;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace Assets.Backend.Model
{
    public class LifeAbility : Ability
    {
        public LifeAbilityArgs AbilityArgs { get; set; }

        public LifeAbility(Character character, LifeAbilityArgs abilityArgs)
        {
            this.Character = character;
            this.AbilityArgs = abilityArgs;

            Input = Character.GetInput();
        }

        public override void Activate()
        {
                
        }

        public override void Collide(Collision2D other)
        {
            double physicalDamage = 10;
            
            double hpToRemove = ApplyResistances(physicalDamage);
            
            if (AbilityArgs.IsAlive)
            {
                DecreaseHitPoints(hpToRemove);
            }
            else
            {
                Debug.WriteLine("Lo que esta muerto no puede morir");
            }
        }

        private double ApplyResistances(double physicalDamage)
        {
            return physicalDamage * Math.Max((100 - AbilityArgs.Resistance.PhysicalResistance_tpc) / 100, 0);
        }

        private void DecreaseHitPoints(double hpToRemove)
        {            
            AbilityArgs.ArmorPoints -= hpToRemove;
            if (AbilityArgs.ArmorPoints < 0)
            {
                AbilityArgs.HitPoints += AbilityArgs.ArmorPoints;
                AbilityArgs.ArmorPoints = 0;
            }

            if (AbilityArgs.HitPoints <= 0)
            {
                Debug.WriteLine("Rest In Peace");
                AbilityArgs.HitPoints = 0;
                AbilityArgs.IsAlive = false;
            }
        }
    }
}
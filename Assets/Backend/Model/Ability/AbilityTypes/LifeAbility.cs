using System;
using Assets.Backend.GameCore.Manager;
using Backend.Model;
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
            Character otherCharacter = CharacterManager.Instance.GetCharacterList().GetCharacterByGameObject(other.gameObject);

            if (otherCharacter != null && otherCharacter.TouchDamage != null && otherCharacter.TouchDamage.TotalDamage > 0)
            {
                Damage damage = otherCharacter.TouchDamage;
                double damageReceived = GetTotalDamageReceived(damage);
                
                if (AbilityArgs.IsAlive)
                {
                    DecreaseHitPoints(damageReceived);
                }
                else
                {
                    Debug.WriteLine("Lo que esta muerto no puede morir");
                }
            }
        }

        private double GetTotalDamageReceived(Damage damage)
        {
            double physicalDamage = ApplyResistance(damage.PhysicalDamage, AbilityArgs.Resistance.PhysicalResistance_tpc);
            double acidDamage = ApplyResistance(damage.AcidDamage, AbilityArgs.Resistance.AcidResistance_tpc);

            return physicalDamage + acidDamage;
        }

        private static double ApplyResistance(double damage, double resistance_tpc)
        {
            return damage * Math.Max((100 - resistance_tpc) / 100, 0);
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

                //FIXME: this just inactivates the GameObj, we want to destroy it
                // When trying to get the GameObj with
                // MonoBehaviorUtils.Destroy(Character.Representation) it complains;
                Character.Representation.SetActive(false);
            }
        }
    }
}
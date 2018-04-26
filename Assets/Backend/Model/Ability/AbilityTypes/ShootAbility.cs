using Assets.Backend.Model.Control;
using UnityEngine;

namespace Assets.Backend.Model
{
    public class ShootAbility : Ability
    {
        private MonoBehaviourUtils _monoBehaviourUtils;  
        public ShootAbilityArgs AbilityArgs { get; set; }

        public ShootAbility(Character character, ShootAbilityArgs abilityArgs)
        {
            this.Character = character;
            this.AbilityArgs = abilityArgs;
            _monoBehaviourUtils = new MonoBehaviourUtils(); 

            Input = Character.GetInput();

        }

        public override void Activate()
        {
            if (AbilityArgs.Projectile == null) return;
            if (Input.IsIntentingToShoot)
            {
                int potency = 5;
                var projectile = _monoBehaviourUtils.CreateAndThenDestroy(AbilityArgs.Projectile, AbilityArgs.bulletSpawn, 2.0f);

                
                if (Character.HorizontalDirection == EnHorizontalDirection.Right)
                {
                    projectile.GetComponent<Rigidbody2D>().velocity = projectile.transform.right * potency;
                }
                else
                {
                    projectile.GetComponent<Rigidbody2D>().velocity = projectile.transform.right * -potency;
                }

            }

        }

        public override void Collide(Collision2D other)
        {
            
        }
    }


}


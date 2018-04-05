using Assets.Backend.Model.Control;
using UnityEngine;

namespace Assets.Backend.Model
{
    public class ShootAbility : Ability
    {
        private ProjectileFactory projectileFactory;  
        public ShootAbilityArgs AbilityArgs { get; set; }

        public ShootAbility(Character character, ShootAbilityArgs abilityArgs)
        {
            this.Character = character;
            this.AbilityArgs = abilityArgs;
            projectileFactory = new ProjectileFactory(); 

            Input = Character.GetInput();

        }

        public override void Activate()
        {
            if (AbilityArgs.Projectile == null) return;
            //if (Input.IsShooting)
            var projectile = projectileFactory.Create(AbilityArgs.Projectile, AbilityArgs.bulletSpawn);
            projectile.GetComponent<Rigidbody2D>().velocity = projectile.transform.right * 5;

        }

        public override void Collide(Collision2D other)
        {
            
        }
    }


}


using Assets.Backend.Model.Control;
using Assets.Backend.GameCore.BusinessLogic.Factory;
using Backend.GameCore.BusinessLogic.Factory;
using UnityEngine;

namespace Assets.Backend.Model {
    public class ThrowChipAbility : Ability {
        private MonoBehaviourUtils _monoBehaviourUtils;
        public PossessionAbilityArgs PossessionAbilityArgs;
        public ThrowChipAbilityArgs AbilityArgs { get; set; }

        public ThrowChipAbility(Character character, ThrowChipAbilityArgs abilityArgs) {
            this.Character = character;
            this.AbilityArgs = abilityArgs;
            _monoBehaviourUtils = new MonoBehaviourUtils();

            Input = Character.HumanPlayerControl;

        }

        public override void Activate() {
            if (AbilityArgs.Chip == null) return;
            if (Input == null || Input.IsIntentingToThrowChip) {
                CreateChip();
               
            }

        }

        private void CreateChip() 
        {
            Debug.Log("ThrowChipAbility: CreateChip()");
            var projectile = _monoBehaviourUtils.CreateAndThenDestroy(AbilityArgs.Chip, AbilityArgs.chipSpawn, 8.0f);
            var projectileRigidBody = projectile.GetComponent<Rigidbody2D>();
            var moveVector = new Vector2(this.AbilityArgs.horizontalPotency, this.AbilityArgs.verticalPotency);

            if (Character.HorizontalDirection == EnHorizontalDirection.Left)
            {
                // Changing sign of horizontalPotency to shoot to the left
                moveVector = new Vector2(-this.AbilityArgs.horizontalPotency, this.AbilityArgs.verticalPotency);
            }
            projectileRigidBody.AddForce(moveVector);
            projectile.AddComponent<ChipController>();
        }


        public override void Collide(Collision2D other) {

        }
    }


}

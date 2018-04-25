using Assets.Backend.Model.Control;
using Assets.Backend.GameCore.BusinessLogic.Factory;
using Backend.GameCore.BusinessLogic.Factory;
using UnityEngine;

namespace Assets.Backend.Model {
    public class ThrowChipAbility : Ability {
        private MonoBehaviourUtils _monoBehaviourUtils;
        public PossessionAbilityArgs PossessionAbilityArgs;
        public ThrowChipAbilityArgs AbilityArgs { get; set; }
        public EnBotInputSource BotInput;

        public ThrowChipAbility(Character character, ThrowChipAbilityArgs abilityArgs) {
            this.Character = character;
            this.AbilityArgs = abilityArgs;
            _monoBehaviourUtils = new MonoBehaviourUtils();

            Input = Character.GetInput();

        }

        public override void Activate() {
            if (AbilityArgs.Chip == null) return;
            if (Input.IsIntentingToThrowChip) {
                CreateChip();
                
               
            }

        }

        private void CreateChip() 
        {
            Debug.Log("ThrowChipAbility: CreateChip()");
            var projectile = _monoBehaviourUtils.Create(AbilityArgs.Chip, AbilityArgs.chipSpawn);
            projectile.GetComponent<Rigidbody2D>().velocity = projectile.transform.right * 5;
            projectile.AddComponent<ChipController>();
        }

        public override void Collide(Collision2D other) {

        }
    }


}

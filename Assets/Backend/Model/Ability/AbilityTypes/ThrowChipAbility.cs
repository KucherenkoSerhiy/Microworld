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

            Input = Character.GetInput();

        }

        public override void Activate() {
            if (AbilityArgs.Chip == null) return;
            if (Input.IsIntentingToThrowChip) {
                Debug.Log("THROWING...");
                CreateChip();
                var projectile = _monoBehaviourUtils.CreateAndThenDestroy(AbilityArgs.Chip, AbilityArgs.chipSpawn, 2.0f);
                projectile.GetComponent<Rigidbody2D>().velocity = projectile.transform.right * 5;
            }

        }

        private void CreateChip() {
            Debug.Log("Creating Chip");
            //AbilityArgs.chipCharacter = CharacterFactory.Instance.CreateCharacter(AbilityArgs.Chip, null, null);
            //var possessAbility = AbilityFactory.Instance.CreatePossessAbility(AbilityArgs.chipCharacter, PossessionAbilityArgs);
            //AbilityArgs.chipCharacter.Abilities.Add(possessAbility);
            //Debug.Log(AbilityArgs.chipCharacter);
        }

        public override void Collide(Collision2D other) {

        }
    }


}

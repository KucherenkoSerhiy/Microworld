using Assets.Backend.Model.Control;
using UnityEngine;

namespace Assets.Backend.Model
{
    public class GatherAbility : Ability
    {
        public GatherAbilityArgs AbilityArgs { get; set; }

        private readonly Collider2D _collider;

        public GatherAbility(Character character, GatherAbilityArgs abilityArgs)
        {
            this.Character = character;
            this.AbilityArgs = abilityArgs;

            Input = Character.GetInput();
            _collider = Character.Representation.GetComponent<Collider2D>();
        }

        public override void Activate()
        {
            // for now do nothing
        }

        public override void Collide(Collision2D other)
        {
            if (Gatherable(other))
            {
                AbilityArgs.AmountGathered += 1;
                Object.Destroy(other.gameObject);
            }
        }

        private bool Gatherable(Collision2D other)
        {
            return AbilityArgs.TargetTagsToGather.Contains(other.collider.tag);
        }
    }
}

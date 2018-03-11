using Assets.Backend.Model.Control;
using UnityEngine;

namespace Assets.Backend.Model
{
    public class MoveAbility : Ability
    {
        public MoveAbilityArgs AbilityArgs { get; set; }

        private readonly Rigidbody2D _rigidBody;

        public MoveAbility(Character character, MoveAbilityArgs abilityArgs)
        {
            this.Character = character;
            this.AbilityArgs = abilityArgs;

            Input = Character.GetInput();
            _rigidBody = Character.Representation.GetComponent<Rigidbody2D>();
        }

        public override void Activate()
        {
            if (Input.IsIntentingToMoveLeft)
                _rigidBody.velocity = new Vector2(-AbilityArgs.MoveSpeed, _rigidBody.velocity.y);
            else if (Input.IsIntentingToMoveRight)
                _rigidBody.velocity = new Vector2(AbilityArgs.MoveSpeed, _rigidBody.velocity.y);
            else
                _rigidBody.velocity = new Vector2(0, _rigidBody.velocity.y);
        }

        public override void Collide(Collision2D other)
        {
            // for now do nothing
        }
    }
}

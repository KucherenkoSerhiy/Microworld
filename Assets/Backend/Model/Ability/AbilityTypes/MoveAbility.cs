using System;
using Assets.Backend.Model.Control;
using UnityEngine;

namespace Assets.Backend.Model
{
    public class MoveAbility : Ability
    {
        public MoveAbilityArgs AbilityArgs { get; set; }

        private readonly Rigidbody2D _rigidBody;
        private readonly Transform _transform;

        public MoveAbility(Character character, MoveAbilityArgs abilityArgs)
        {
            this.Character = character;
            this.AbilityArgs = abilityArgs;

            Input = Character.HumanPlayerControl;
            _rigidBody = Character.Representation.GetComponent<Rigidbody2D>();
            _transform = Character.Representation.GetComponent<Transform>();
        }

        public override void Activate()
        {
            if (Input == null || Input.IsIntentingToMoveLeft)
            {
                
                if(Character.HorizontalDirection == EnHorizontalDirection.Right)
                {
                    _transform.localScale = new Vector3(
                            _transform.localScale.x * -1,
                            _transform.localScale.y,
                            _transform.localScale.z);
                }

                Character.HorizontalDirection = EnHorizontalDirection.Left;

                _rigidBody.velocity = new Vector2(-AbilityArgs.MoveSpeed, _rigidBody.velocity.y);
            }
                
            else if (Input == null || Input.IsIntentingToMoveRight)
            {
                if (Character.HorizontalDirection == EnHorizontalDirection.Left)
                {
                    _transform.localScale = new Vector3(
                            _transform.localScale.x * -1,
                            _transform.localScale.y,
                            _transform.localScale.z);
                }

                Character.HorizontalDirection = EnHorizontalDirection.Right;
                _rigidBody.velocity = new Vector2(AbilityArgs.MoveSpeed, _rigidBody.velocity.y);
            }
            else
                _rigidBody.velocity = new Vector2(0, _rigidBody.velocity.y);
        }

        public override void Collide(Collision2D other)
        {
            // for now do nothing
        }

        internal void MoveTo(Vector3 position)
        {
            int dirInversor = position.x < _transform.position.x ? -1 : 1;
            _rigidBody.velocity = new Vector2(AbilityArgs.MoveSpeed * dirInversor, _rigidBody.velocity.y);
        }
    }
}

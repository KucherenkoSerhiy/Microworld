using Assets.Backend.Model.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Backend.Model
{
    public class DashAbility : Ability
    {
        public DashAbilityArgs AbilityArgs { get; set; }

        private readonly Rigidbody2D _rigidBody;
        private readonly BoxCollider2D _boxCollider2D;
        private readonly Transform _transform;

        public DashAbility(Character character, DashAbilityArgs abilityArgs)
        {
            this.Character = character;
            this.AbilityArgs = abilityArgs;

            Input = Character.GetInput();
            _rigidBody = Character.Representation.GetComponent<Rigidbody2D>();
            _boxCollider2D = Character.Representation.GetComponent<BoxCollider2D>();
            _transform = Character.Representation.GetComponent<Transform>();
        }

        public override void Activate()
        {
            if (!Input.IsIntentingToDash || CanNotDash()) return;

            if (Character.HorizontalDirection == EnHorizontalDirection.Right)
            {
                _rigidBody.velocity = new Vector2(AbilityArgs.DashForce, _rigidBody.velocity.y);
                Debug.Log("Dashing");
            }

            else if (Character.HorizontalDirection == EnHorizontalDirection.Left)
            {
                _rigidBody.velocity = new Vector2(-1 * AbilityArgs.DashForce, _rigidBody.velocity.y);
                Debug.Log("Dashing");
            }

            AbilityArgs.IsGrounded = false;
            AbilityArgs.DashDone++;
        }

        private bool CanNotDash()
        {
            return !AbilityArgs.IsGrounded && (AbilityArgs.DashDone >= AbilityArgs.DashMax);
        }

        public override void Collide(Collision2D other)
        {

            if (!IsGrounded()) return;

            AbilityArgs.IsGrounded = true;
            AbilityArgs.DashDone = 0;
        }

        private bool IsGrounded()
        {
            // took from here: https://answers.unity.com/questions/196381/how-do-i-check-if-my-rigidbody-player-is-grounded.html
            var distToGround = _boxCollider2D.bounds.extents.y;
            return Physics2D.Raycast(_transform.position, Vector3.down, distToGround + 0.1f);
        }
    }
}

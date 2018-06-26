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

            Input = Character.HumanPlayerControl;
            _rigidBody = Character.Representation.GetComponent<Rigidbody2D>();
            _boxCollider2D = Character.Representation.GetComponent<BoxCollider2D>();
            _transform = Character.Representation.GetComponent<Transform>();
        }

        public override void Activate()
        {
            if (Input != null && !Input.IsIntentingToDash) return; //Here, if you also check for a timer or something, this might work as intended 

            if (DashStatus())
                PerformDash();
        }

        private void PerformDash()
        {
            
            if (Character.HorizontalDirection == EnHorizontalDirection.Right)
            {
                //Debug.Log("oemege right " + _transform.right * AbilityArgs.DashForce );
                _rigidBody.velocity = _transform.right * AbilityArgs.DashForce * Time.deltaTime;
                //_rigidBody.velocity = new Vector2(AbilityArgs.DashForce, _rigidBody.velocity.y);
            }

            else if (Character.HorizontalDirection == EnHorizontalDirection.Left)
            {
                //Debug.Log("oemege left " + _transform.right * AbilityArgs.DashForce );
                _rigidBody.velocity = _transform.right * -AbilityArgs.DashForce *  Time.deltaTime;
                //_rigidBody.velocity = new Vector2(-1 * AbilityArgs.DashForce, _rigidBody.velocity.y);
            }

            if (!IsGrounded())
            {
                AbilityArgs.DashPerformed++;
                AbilityArgs.AirDashDone = true;
            }
        }

        private bool DashStatus()
        {
            return !AbilityArgs.AirDashDone || AbilityArgs.DashPerformed < AbilityArgs.DashMax;
        }

        public override void Collide(Collision2D other)
        {
            if (!IsGrounded()) return;

            AbilityArgs.AirDashDone = false;
            AbilityArgs.DashPerformed = 0;
        }

        private bool IsGrounded()
        {
            // took from here: https://answers.unity.com/questions/196381/how-do-i-check-if-my-rigidbody-player-is-grounded.html
            var distToGround = _boxCollider2D.bounds.extents.y;
            return Physics2D.Raycast(_transform.position, Vector3.down, distToGround + 0.1f);
        }
    }
}

﻿using Assets.Backend.Model.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Backend.Model
{
    public class JumpAbility : Ability
    {
        private JumpAbilityArgs AbilityArgs { get; set; }

        private readonly Rigidbody2D _rigidBody;
        private readonly BoxCollider2D _boxCollider2D;
        private readonly Transform _transform;

        public JumpAbility(Character character, JumpAbilityArgs abilityArgs)
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
            if (!Input.IsIntentingToJump) return;

            if (CanPerformWallJump())
                PerformWallJump();
                
            else if (CanJump())
                PerformJump();
        }

        private bool CanPerformWallJump()
        {
            return AbilityArgs.CanWallJump && !IsGrounded();
        }

        private void PerformWallJump()
        {
            _rigidBody.velocity = new Vector2(
                IsTouchingWallLeft()? AbilityArgs.JumpForce : -AbilityArgs.JumpForce, 
                AbilityArgs.JumpForce
            );
        }

        private bool CanJump()
        {
            return AbilityArgs.IsGrounded || AbilityArgs.JumpsDone < AbilityArgs.JumpsMax;
        }

        private void PerformJump()
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, AbilityArgs.JumpForce);

            AbilityArgs.IsGrounded = false;
            AbilityArgs.JumpsDone++;
        }

        public override void Collide(Collision2D other)
        {
            if (!IsGrounded()) return;

            AbilityArgs.IsGrounded = true;
            AbilityArgs.JumpsDone = 0;
        }

        private bool IsGrounded()
        {
            // took from here: https://answers.unity.com/questions/196381/how-do-i-check-if-my-rigidbody-player-is-grounded.html
            var distToGround = _boxCollider2D.bounds.extents.y;
            return Physics2D.Raycast(_transform.position, Vector3.down, distToGround + 0.1f);
        }

        private bool IsTouchingWallLeft()
        {
            bool collidesLeft = Physics2D.Raycast(_transform.position, Vector2.left, _boxCollider2D.bounds.extents.x + 0.1f);

            return collidesLeft;
        }
        
        private bool IsTouchingWallRight()
        {
            bool collidesRight = Physics2D.Raycast(_transform.position, Vector2.right, _boxCollider2D.bounds.extents.x + 0.1f);

            return collidesRight;
        }
    }
}

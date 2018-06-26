using Assets.Backend.Model.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Backend.Model
{
    public class StickAbility : Ability
    {
        private StickAbilityArgs AbilityArgs { get; set; }

        private readonly Rigidbody2D _rigidBody;
        private readonly BoxCollider2D _boxCollider2D;
        private readonly Transform _transform;

        public StickAbility(Character character, StickAbilityArgs abilityArgs)
        {
            this.Character = character;
            this.AbilityArgs = abilityArgs;

            _rigidBody = Character.Representation.GetComponent<Rigidbody2D>();
            _boxCollider2D = Character.Representation.GetComponent<BoxCollider2D>();
            _transform = Character.Representation.GetComponent<Transform>();
        }

        public override void Activate()
        {
            // Empty for now
        }

        public override void Collide(Collision2D other)
        {
            // Return if is Sticked: can only stick to "other" once!
            //           or if "other" is not Stickable
            if (AbilityArgs.IsSticked || !Stickable(other)) return;
            AbilityArgs.IsSticked = true;
            ReduceMovement(other);
            StickToOther(other);
        }

        private void ReduceMovement(Collision2D other) 
        {
            int OtherMoveSpeed = other.gameObject.GetComponent<PlayerController>().MoveAbilityArgs.MoveSpeed;
            OtherMoveSpeed = OtherMoveSpeed / AbilityArgs.SlowingFactor;
            other.gameObject.GetComponent<PlayerController>().MoveAbilityArgs.MoveSpeed = OtherMoveSpeed;
        }

        private void StickToOther(Collision2D other) 
        {
            UnityEngine.FixedJoint2D joint = Character.Representation.AddComponent<FixedJoint2D>();
            joint.connectedBody = other.rigidbody;
        }

        private bool Stickable(Collision2D other) 
        {
            return AbilityArgs.TargetTagsToStick.Contains(other.collider.tag);
        }


    }
}

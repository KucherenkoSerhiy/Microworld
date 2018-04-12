﻿using Assets.Backend.Model.Control;
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

            Input = Character.GetInput();
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
            // Return if is Sticked (can only stick to "other" once!
            //           or if "other" is not Stickable
            if (AbilityArgs.IsSticked || !Stickable(other)) return;

            AbilityArgs.IsSticked = true;
            // Get other MoveSpeed and divide it by SlowingFactor
            int OtherMoveSpeed = other.gameObject.GetComponent<PlayerController>().MoveAbilityArgs.MoveSpeed;
            OtherMoveSpeed = OtherMoveSpeed / AbilityArgs.SlowingFactor;
            other.gameObject.GetComponent<PlayerController>().MoveAbilityArgs.MoveSpeed = OtherMoveSpeed;

            Debug.Log("Stick");
            //Debug.Log(other.gameObject.GetComponent<PlayerController>().MoveAbilityArgs.MoveSpeed);
        }

        private bool Stickable(Collision2D other) 
        {
            return AbilityArgs.TargetTagsToStick.Contains(other.collider.tag);
        }


    }
}

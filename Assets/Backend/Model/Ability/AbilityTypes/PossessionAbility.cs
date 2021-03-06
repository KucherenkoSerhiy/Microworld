﻿using Assets.Backend.Model.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Backend.GameCore.Manager;
using UnityEngine;

namespace Assets.Backend.Model
{
    public class PossessionAbility : Ability
    {
        public PossessionAbilityArgs AbilityArgs { get; set; }

        private readonly Rigidbody2D _rigidBody;

        public PossessionAbility(Character character, PossessionAbilityArgs abilityArgs = null)
        {
            this.Character = character;
            this.AbilityArgs = abilityArgs;

            Input = Character.GetInput();
            _rigidBody = Character.Representation.GetComponent<Rigidbody2D>();
        }

        public override void Activate()
        {
            if (Input.IsIntentingToPosses && !AlreadyPossessed())
            {
                Possess();
            }

        }

        private bool AlreadyPossessed()
        {
            Character austin = CharacterManager.Instance.GetCharacterList().GetCharacterByName("Ostin Powers");
            return !austin.BotPlayerControl.IsActive && austin.HumanPlayerControl != null;
        }

        private void Possess()
        {
            var control = ControlManager.Instance.GetHumanPlayerControlList().GetPlayer(EnPlayerInputSource.PlayerTwo);
            // TODO: now possesses only Ostin Powers

            Character austin = CharacterManager.Instance.GetCharacterList().GetCharacterByName("Ostin Powers");

            austin.HumanPlayerControl = control;
            austin.BotPlayerControl.IsActive = false;
            austin.SetControl(control);
        }

        public override void Collide(Collision2D other)
        {
            // for now do nothing
        }
    }

}

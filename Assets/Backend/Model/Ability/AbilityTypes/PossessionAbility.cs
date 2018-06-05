using Assets.Backend.Model.Control;
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
            //if (Input.IsIntentingToPosses && !AlreadyPossessed())
            //{
             //   Possess();
            //}

        }

        public override void Collide(Collision2D other) 
        {
            if (!Possessable(other) || AlreadyPossessed(other)) return;
            Debug.Log("we in baby");
            Possess(other);
        }

        private bool AlreadyPossessed(Collision2D other)
        {
            Character otherCharacter = CharacterManager.Instance.GetCharacterList().GetCharacterByGameObject(other.gameObject);
            return !otherCharacter.BotPlayerControl.IsActive && otherCharacter.HumanPlayerControl != null;
        }

        private void Possess(Collision2D other)
        {
            var control = ControlManager.Instance.GetHumanPlayerControlList().GetPlayer(EnPlayerInputSource.PlayerTwo);
            Character otherCharacter = CharacterManager.Instance.GetCharacterList().GetCharacterByGameObject(other.gameObject);
            otherCharacter.HumanPlayerControl = control;
            otherCharacter.BotPlayerControl.IsActive = false;
            otherCharacter.SetControl(control);
            Debug.Log("POSSESSED");
        }

        private bool Possessable(Collision2D other) {
            Character otherCharacter = CharacterManager.Instance.GetCharacterList().GetCharacterByGameObject(other.gameObject);
            if (otherCharacter == null) 
            {
                return false;
            } 
            else 
            {
                return otherCharacter.CanBePossessed;
            }
        }

        
    }

}

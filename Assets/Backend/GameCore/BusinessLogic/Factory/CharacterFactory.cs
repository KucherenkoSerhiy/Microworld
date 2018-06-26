using System;
using Assets.Backend.GameCore.A.I;
using Assets.Backend.GameCore.Manager;
using Assets.Backend.Model;
using Assets.Backend.Model.Control;
using UnityEngine;

namespace Backend.GameCore.BusinessLogic.Factory
{
    public class CharacterFactory
    {
        #region Singleton

        private static CharacterFactory _instance;

        public static CharacterFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CharacterFactory();
                }
                return _instance;
            }
        }

        #endregion
        
        public Character CreatePlayer (GameObject representation, HumanPlayerControl humanPlayerControl)
        {
            var character = new Character
            {
                HumanPlayerControl = humanPlayerControl,
                Representation = representation,
            };

            CharacterManager.Instance.GetCharacterList().AddCharacter(character);

            return character;
        }

        public Character CreateNpc(GameObject representation, NpcIntelligenceBase botPlayerControl)
        {
            var character = new Character
            {
                BotPlayerControl = botPlayerControl,
                Representation = representation,
            };

            botPlayerControl.SetCharacter(character);

            CharacterManager.Instance.GetCharacterList().AddCharacter(character);

            return character;
        }
        
        internal Character CreateProjectile(GameObject representation)
        {
            var character = new Character
            {
                Representation = representation,
            };

            CharacterManager.Instance.GetCharacterList().AddCharacter(character);

            return character;
        }
    }
}

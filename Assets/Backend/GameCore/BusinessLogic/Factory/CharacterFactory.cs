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
        
        public Character CreateCharacter (GameObject representation, HumanPlayerControl humanPlayerControl = null, BotPlayerControl botPlayerControl = null)
        {
            var character = new Character
            {
                BotPlayerControl = botPlayerControl,
                HumanPlayerControl = humanPlayerControl,
                Representation = representation,
            };

            CharacterManager.Instance.GetCharacterList().AddCharacter(character);

            return character;
        }
    }
}

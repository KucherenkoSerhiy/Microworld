using Assets.Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Backend.GameCore.Manager
{
    public class CharacterManager
    {
        #region Singleton

        private static CharacterManager _instance;

        public static CharacterManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CharacterManager();
                }
                return _instance;
            }
        }

        #endregion

        private CharacterList _characterList;

        private CharacterManager()
        {
            _characterList = new CharacterList();
        }

        public CharacterList GetCharacterList()
        {
            return _characterList;
        }
    }
}

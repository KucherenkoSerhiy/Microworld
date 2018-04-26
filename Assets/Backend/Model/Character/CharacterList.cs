using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Backend.Model {
    public class CharacterList {
        public List<Character> Characters { get; private set; }

        public CharacterList() {
            Characters = new List<Character>();
        }

        public void AddCharacter(Character character) {
            Characters.Add(character);
        }

        public Character GetCharacterByName(string name)
        {
            return Characters.SingleOrDefault(x => x.Representation.name == name);
        }

        public Character GetCharacterByGameObject(GameObject gameObject)
        {
            return Characters.SingleOrDefault(x => x.Representation == gameObject);
        }
    }
}
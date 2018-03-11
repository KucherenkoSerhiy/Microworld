using System.Collections.Generic;
using System.Linq;

namespace Assets.Backend.Model
{
    public class CharacterList
    {
        public List<Character> Characters { get; private set; }

        public CharacterList()
        {
            Characters = new List<Character>();
        }

        public void AddCharacter(Character character)
        {
            Characters.Add(character);
        }

        public Character GetCharacterByName(string tag)
        {
            return Characters.SingleOrDefault(x => x.Representation.name == tag);
        }
    }
}
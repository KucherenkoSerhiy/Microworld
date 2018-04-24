using System;
using UnityEngine;

namespace Assets.Backend.Model {
    [Serializable]
    public class ThrowChipAbilityArgs {
        public GameObject Chip;
        public Character chipCharacter;
        public Transform chipSpawn;
    }
}

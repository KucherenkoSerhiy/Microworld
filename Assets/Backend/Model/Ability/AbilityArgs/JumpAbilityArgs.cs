using System;

namespace Assets.Backend.Model
{
    [Serializable]
    public class JumpAbilityArgs
    {
        public int JumpForce;
        public bool IsGrounded { get; set; }
        public int JumpsDone { get; set; }
        public int JumpsMax;
    }
}
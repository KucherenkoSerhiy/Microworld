using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Assets.Backend.Model
{
    [Serializable]
    public class JumpAbilityArgs
    {
        public int JumpForce;
        internal bool IsGrounded;
        internal int JumpsDone;
        public int JumpsMax;
        public float FallMultiplier;
        public bool CanWallJump;
    }
}
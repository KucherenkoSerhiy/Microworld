using System;

namespace Assets.Backend.Model
{
    [Serializable]
    public class DashAbilityArgs
    {
        public int DashForce;
        public bool IsGrounded { get; set; }
        public int DashDone { get; set; }
        public int DashMax;
        public int DashTime;
    }
}
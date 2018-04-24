using System;

namespace Assets.Backend.Model
{
    [Serializable]
    public class DashAbilityArgs
    {
        public int DashForce;
        public bool AirDashDone { get; set; }
        public int DashPerformed { get; set; }
        public int DashMax;
    }
}
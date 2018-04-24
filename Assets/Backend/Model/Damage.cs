using System;

namespace Backend.Model
{
    [Serializable]
    public class Damage
    {
        public double PhysicalDamage;
        public double AcidDamage;
        public double TotalDamage { get {return PhysicalDamage + AcidDamage; } }
    }
}
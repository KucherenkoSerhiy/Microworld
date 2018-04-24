using System;
 
 namespace Assets.Backend.Model
 {
     [Serializable]
     public class LifeAbilityArgs
     {
         internal bool IsAlive = true;
         public double HitPoints;
         public double ArmorPoints;
         public ResistanceLifeAbilityArgs Resistance;
     }
 }
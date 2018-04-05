using System;
using Assets.Backend.Model.Control;
using UnityEngine;

namespace Assets.Backend.Model
{
    public abstract class Ability
    {
        internal Character Character;
        internal IControl Input;
        protected AbilityLocker _abilityLocker = new AbilityLocker();

        public void DeactivateForTime(int time_ms)
        {
            _abilityLocker.DeactivateForTime(time_ms);
        }

        public bool IsActive()
        {
            return _abilityLocker.IsActive;
        }

        /// <summary>
        ///  Called from Update() method in Unity script
        /// </summary>
        public abstract void Activate();

        /// <summary>
        ///  Called from Collide() method in Unity script
        /// </summary>
        /// <param name="other">With whom this object has collided</param>
        public abstract void Collide(Collision2D other);
    }
}
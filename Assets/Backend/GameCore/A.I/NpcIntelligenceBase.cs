using Assets.Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Backend.GameCore.A.I
{
    public abstract class NpcIntelligenceBase
    {
        /* It will behave the next way
        
        1. Possible states: Sleep, Patrol, Fight, Protect, Flee.
        2. Possible state change triggers: received damage, seen enemy, heared noise
        3. Sleep
            a) Do nothing, slowly regenerates
            b) State change on receive damage or hear strong noise
        4. Patrol:
            a) Move around in the defined area. [Random factor in changing direction]
            b) State change on any trigger.
        5. Fight:
            a) Move to hit distance, can use Dash Ability. [Random factor in frequency]
            b) When on hit distance, attack.
            c) State change when does not see enemy for [X] seconds.
        6. Protect:
            a) Stay close to the object to protect, patrol near it.
            b) State change on any trogger.
        7. Flee: 
            a) Runs away from hazards (enemies, hostile environment), can use Dash Ability. 
            c) State change when does not see enemy and hazards for [X] seconds
        8. Jump Ability:
            a) Jump over an obstacle when it is near. Combined with Move Ability.
        */

        protected EnNpcState _state;
        protected Character _character;
        protected Character _enemy;

        public bool IsActive { get; set; }

        /// <summary>
        /// Activate the NPC
        /// </summary>
        public abstract void Activate();

        /// <summary>
        /// Decide which action the character will perform
        /// </summary>
        public abstract void Act();

        /// <summary>
        /// State change trigger 
        /// </summary>
        /// <param name="something"></param>
        public abstract void OnDamageReceived();

        /// <summary>
        /// State change trigger 
        /// </summary>
        /// <param name="something"></param>
        public abstract void Watch();

        /*
        /// <summary>
        /// State change trigger 
        /// </summary>
        /// <param name="something"></param>
        public abstract void Hear(Noise noise);
        */


        protected abstract void Sleep();

        protected abstract void Patrol();

        protected abstract void Fight();

        protected abstract void Protect();

        protected abstract void Flee();

        public void SetCharacter(Character character)
        {
            _character = character;
        }
    }
}

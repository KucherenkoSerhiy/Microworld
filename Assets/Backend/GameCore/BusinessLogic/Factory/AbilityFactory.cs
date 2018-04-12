using Assets.Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Backend.GameCore.BusinessLogic.Factory
{
    public class AbilityFactory
    {
        #region Singleton

        private static AbilityFactory _instance;

        public static AbilityFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AbilityFactory();
                }
                return _instance;
            }
        }

        #endregion

        public MoveAbility CreateMoveAbility (Character character, MoveAbilityArgs abilityArgs)
        {
            return new MoveAbility(character, abilityArgs);
        }

        internal Ability CreateJumpAbility(Character character, JumpAbilityArgs abilityArgs)
        {
            return new JumpAbility(character, abilityArgs);
        }

        internal Ability CreateShootAbility(Character character, ShootAbilityArgs abilityArgs)
        {
            return new ShootAbility(character, abilityArgs);
        }

        public Ability CreateGatherAbility(Character character, GatherAbilityArgs gatherAbilityArgs)
        {
            return new GatherAbility(character, gatherAbilityArgs);
        }

        public Ability CreatePossessAbility(Character character, PossessionAbilityArgs possessionAbilityArgs = null)
        {
            return new PossessionAbility(character, possessionAbilityArgs);
        }

        public Ability CreateDashAbility(Character character, DashAbilityArgs dashAbilityArgs = null)
        {
            return new DashAbility(character, dashAbilityArgs);
        }

        public Ability CreateStickAbility(Character character, StickAbilityArgs stickAbilityArgs = null) {
            return new StickAbility(character, stickAbilityArgs);
        }
    }
}

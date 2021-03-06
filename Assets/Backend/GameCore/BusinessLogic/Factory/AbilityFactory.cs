﻿using Assets.Backend.Model;
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

        public Ability CreateGatherAbility(Character character, GatherAbilityArgs gatherAbilityArgs)
        {
            return new GatherAbility(character, gatherAbilityArgs);
        }

        public Ability CreatePossessAbility(Character character, PossessionAbilityArgs possessionAbilityArgs = null)
        {
            return new PossessionAbility(character, possessionAbilityArgs);
        }
    }
}

using Assets.Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Backend.Model.Control
{
    public class BotPlayerControl : IControl
    {
        public EnBotInputSource BotInputSource { get; set; }
        public bool IsActive { get; set; }

        public bool IsIntentingToMoveLeft
        {
            get
            {
                return IsActive;
            }
        }

        public bool IsIntentingToMoveRight
        {
            get
            {
                return false;
            }
        }

        public bool IsIntentingToJump
        {
            get
            {
                return IsActive;
            }
        }

        public bool IsIntentingToDuck
        {
            get
            {
                return false;
            }
        }

        public bool IsIntentingToAttack
        {
            get
            {
                return false;
            }
        }

        public bool IsIntentingToShoot
        {
            get
            {
                return false;
            }
        }

        public bool IsIntentingToThrowChip {
            get {
                return false;
            }
        }

        public bool IsIntentingToPosses
        {
            get
            {
                return false;
            }
        }
        public bool IsIntentingToDash
        {
            get
            {
                return false;
            }
        }

        public BotPlayerControl Clone()
        {
            return new BotPlayerControl
            {
                BotInputSource = BotInputSource,
                IsActive = IsActive
            };
        }
    }
}

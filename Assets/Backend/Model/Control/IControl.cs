﻿namespace Assets.Backend.Model.Control
{
    public interface IControl
    {
        bool IsActive { get; set; }

        bool IsIntentingToMoveLeft { get; }
        bool IsIntentingToMoveRight { get; }
        bool IsIntentingToJump { get; }
        bool IsIntentingToDuck { get; }
        bool IsIntentingToAttack { get; }
        bool IsIntentingToPosses { get;  }
    }
}

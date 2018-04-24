namespace Assets.Backend.Model.Control
{
    public class HumanPlayerControl: IControl
    {
        public EnPlayerInputSource PlayerInputSource { get; set; }
        public PlayerInput Input { get; set; }
        public bool IsActive { get; set; }

        public bool IsIntentingToMoveLeft { get { return Input.IsIntentingToMoveLeft && IsActive; } }
        public bool IsIntentingToMoveRight { get { return Input.IsIntentingToMoveRight && IsActive; } }
        public bool IsIntentingToJump { get { return Input.IsIntentingToJump && IsActive; } }
        public bool IsIntentingToDuck { get { return Input.IsIntentingToDuck && IsActive; } }   
        public bool IsIntentingToAttack { get { return Input.IsIntentingToAttack && IsActive; } }
        public bool IsIntentingToShoot { get { return Input.IsIntentingToShoot && IsActive; } }
        public bool IsIntentingToThrowChip { get { return Input.IsIntentingToThrowChip && IsActive; } }
        public bool IsIntentingToPosses { get { return Input.IsIntentingToPossess && IsActive; } }
        public bool IsIntentingToDash { get { return Input.IsIntentingToDash && IsActive; } }
    }
}

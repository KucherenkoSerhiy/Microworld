using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput
{
    public KeyCode KeyMoveLeft { private get; set; }
    public KeyCode KeyMoveRight { private get; set; }
    public KeyCode KeyJump { private get; set; }
    public KeyCode KeyDuck { private get; set; }
    public KeyCode KeyAttack { private get; set; }
    public KeyCode KeyShoot { private get; set; }
    public KeyCode KeyPossess { private get; set; }
    public KeyCode KeyDash { private get; set; }

    public bool IsIntentingToMoveLeft { get { return Input.GetKey(KeyMoveLeft); } }
    public bool IsIntentingToMoveRight { get { return Input.GetKey(KeyMoveRight); } }
    public bool IsIntentingToJump { get { return Input.GetKeyDown(KeyJump); } }
    public bool IsIntentingToDuck { get { return Input.GetKeyDown(KeyDuck); } }
    public bool IsIntentingToAttack { get { return Input.GetKeyDown(KeyAttack); } }
    public bool IsIntentingToShoot { get { return Input.GetKeyDown(KeyShoot); } }
    public bool IsIntentingToPossess { get { return Input.GetKey(KeyPossess); } }
    public bool IsIntentingToDash { get { return Input.GetKeyDown(KeyDash); } }
}

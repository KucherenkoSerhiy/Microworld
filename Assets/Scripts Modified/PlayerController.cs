﻿using UnityEngine;
using Assets.Backend.Model;
using Assets.Backend.GameCore.BusinessLogic.Factory;
using System.Collections.Generic;
using Assets.Backend.Model.Control;

public class PlayerController : MonoBehaviour {

    public EnPlayerInputSource PlayerInput;
    private Character _character;

    public MoveAbilityArgs MoveAbilityArgs;
    public JumpAbilityArgs JumpAbilityArgs;
    public GatherAbilityArgs GatherAbilityArgs;

    #region Shoud be removed

    public float moveSpeed;
    public float jumpForce;
    public float roundCheckRadius;
    public bool isGrounded;
    public int jumpsMax;
    public int currGems = 0;
    public int health = 3;
    public KeyCode shoot;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    Animator anim;

    #endregion
    
	void Start ()
    {
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        var humanPlayerControl = ControlManager.Instance.GetHumanPlayerControlList().GetPlayer(PlayerInput);

        _character = CharacterFactory.Instance.CreateCharacter(this.gameObject, humanPlayerControl);
        AddAbilities();
    }

    private void AddAbilities()
    {
        var moveAbility = AbilityFactory.Instance.CreateMoveAbility(_character, MoveAbilityArgs);
        var jumpAbility = AbilityFactory.Instance.CreateJumpAbility(_character, JumpAbilityArgs);
        var gatherAbility = AbilityFactory.Instance.CreateGatherAbility(_character, GatherAbilityArgs);
        var possessAbility = AbilityFactory.Instance.CreatePossessAbility(_character);

        _character.Abilities.Add(moveAbility);
        _character.Abilities.Add(jumpAbility);
        _character.Abilities.Add(gatherAbility);
        _character.Abilities.Add(possessAbility);
    }

    void Update () {
        _character.Act();
	}

    void OnCollisionStay2D(Collision2D other) {
        //TODO Take damage when touching the enemy if not invincible        
	}

	void OnCollisionEnter2D(Collision2D other)
	{
        //Warning: Must set Unity parameter: https://answers.unity.com/questions/756380/raycast-ignore-itself.html

        _character.Collide(other);

        //TODO Take damage when touching the enemy if not invincible
    }
}

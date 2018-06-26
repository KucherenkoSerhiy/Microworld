﻿using System.Collections;
using System.Collections.Generic;
using Assets.Backend.GameCore.A.I;
using Assets.Backend.GameCore.BusinessLogic.Factory;
using Assets.Backend.GameCore.Manager;
using Assets.Backend.Model;
using Backend.GameCore.BusinessLogic.Factory;
using Backend.Model;
using UnityEngine;

public class ShooterEnemyController : MonoBehaviour {

    public Damage TouchDamage;
    private Character _character;

    public LifeAbilityArgs LifeAbilityArgs;
    public MoveAbilityArgs MoveAbilityArgs;
    public JumpAbilityArgs JumpAbilityArgs;
    public ShootAbilityArgs ShootAbilityArgs;
    public DashAbilityArgs DashAbilityArgs;

    void Start()
    {
        CreateBot();
    }

    private void CreateBot()
    {
        var motherFucker = CharacterManager.Instance.GetCharacterList().GetCharacterByName("Player1");
        var botPlayerControl = new ShooterNpc(motherFucker);

        _character = CharacterFactory.Instance.CreateNpc(this.gameObject, botPlayerControl);
        _character.CanBePossessed = true;

        AddAbilities();
        SetDamage();

        _character.Activate();
    }

    private void AddAbilities()
    {
        var lifeAbility = AbilityFactory.Instance.CreateLifeAbility(_character, LifeAbilityArgs);
        var moveAbility  = AbilityFactory.Instance.CreateMoveAbility(_character, MoveAbilityArgs);
        var jumpAbility  = AbilityFactory.Instance.CreateJumpAbility(_character, JumpAbilityArgs);
        var shootAbility = AbilityFactory.Instance.CreateShootAbility(_character, ShootAbilityArgs);
        var dashAbility = AbilityFactory.Instance.CreateDashAbility(_character, DashAbilityArgs);

        _character.Abilities.Add(lifeAbility);
        _character.Abilities.Add(moveAbility);
        _character.Abilities.Add(jumpAbility);
        _character.Abilities.Add(shootAbility);
        _character.Abilities.Add(dashAbility);
    }

    private void SetDamage()
    {
        _character.TouchDamage = TouchDamage;
    }

    void Update()
    {
        _character.BotPlayerControl.Watch();
        _character.BotPlayerControl.Act();
    }

    void OnCollisionStay2D(Collision2D other)
    {
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Warning: Must set Unity parameter: https://answers.unity.com/questions/756380/raycast-ignore-itself.html
        _character.Collide(other);
    }
}

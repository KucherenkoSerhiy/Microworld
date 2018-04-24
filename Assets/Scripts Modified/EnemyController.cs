using System.Collections;
using System.Collections.Generic;
using Assets.Backend.GameCore.BusinessLogic.Factory;
using Assets.Backend.Model;
using Backend.GameCore.BusinessLogic.Factory;
using Backend.Model;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public EnBotInputSource BotInput;
    public Damage TouchDamage;
    private Character _character;

    public LifeAbilityArgs LifeAbilityArgs;
    public MoveAbilityArgs MoveAbilityArgs;
    public JumpAbilityArgs JumpAbilityArgs;
    public StickAbilityArgs StickAbilityArgs;
    
    void Start()
    {
        CreateBot();
    }

    private void CreateBot()
    {
        var botPlayerControl = ControlManager.Instance.GetBotPlayerControlList().GetPlayer(BotInput);

        _character = CharacterFactory.Instance.CreateCharacter(this.gameObject, null, botPlayerControl); //TODO sic! Remove this antinatural null!
        AddAbilities();
        SetDamage();
    }

    private void AddAbilities()
    {
        var lifeAbility = AbilityFactory.Instance.CreateLifeAbility(_character, LifeAbilityArgs);
        var moveAbility  = AbilityFactory.Instance.CreateMoveAbility(_character, MoveAbilityArgs);
        var jumpAbility  = AbilityFactory.Instance.CreateJumpAbility(_character, JumpAbilityArgs);
        var stickAbility = AbilityFactory.Instance.CreateStickAbility(_character, StickAbilityArgs);

        _character.Abilities.Add(lifeAbility);
        _character.Abilities.Add(moveAbility);
        _character.Abilities.Add(jumpAbility);
        _character.Abilities.Add(stickAbility);
    }

    private void SetDamage()
    {
        _character.TouchDamage = TouchDamage;
    }

    void Update()
    {
        _character.Act();
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

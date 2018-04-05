using System.Collections;
using System.Collections.Generic;
using Assets.Backend.GameCore.BusinessLogic.Factory;
using Assets.Backend.Model;
using Backend.GameCore.BusinessLogic.Factory;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public EnBotInputSource BotInput;
    private Character _character;

    public MoveAbilityArgs MoveAbilityArgs;
    public JumpAbilityArgs JumpAbilityArgs;
    
    void Start()
    {
        CreateBot();
    }

    private void CreateBot()
    {
        var botPlayerControl = ControlManager.Instance.GetBotPlayerControlList().GetPlayer(BotInput);

        _character = CharacterFactory.Instance.CreateCharacter(this.gameObject, null, botPlayerControl); //TODO sic! Remove this antinatural null!
        AddAbilities();
    }

    private void AddAbilities()
    {
        var moveAbility = AbilityFactory.Instance.CreateMoveAbility(_character, MoveAbilityArgs);
        var jumpAbility = AbilityFactory.Instance.CreateJumpAbility(_character, JumpAbilityArgs);

        _character.Abilities.Add(moveAbility);
        _character.Abilities.Add(jumpAbility);
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

using System.Collections;
using System.Collections.Generic;
using Assets.Backend.GameCore.BusinessLogic.Factory;
using Assets.Backend.Model;
using Assets.Backend.Model.Control;
using Backend.GameCore.BusinessLogic.Factory;
using UnityEngine;

public class ChipController : MonoBehaviour {

    public EnBotInputSource BotInput;
    private Character _character;
    private MonoBehaviourUtils _monoBehaviourUtils;
    public PossessionAbilityArgs PossessionAbilityArgs;

    void Start()
    {
        CreateChip();
    }

    private void CreateChip()
    {
        var botPlayerControl = new BotPlayerControl(); // empty because it is a chip for fucks sake
        //Debug.Log(this.gameObject);
        _character = CharacterFactory.Instance.CreateCharacter(this.gameObject, null, botPlayerControl); //TODO sic! Remove this antinatural null!
        AddAbilities();
    }

    private void AddAbilities()
    {
        var possessionAbility = AbilityFactory.Instance.CreatePossessAbility(_character, PossessionAbilityArgs);
        _character.Abilities.Add(possessionAbility);
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
        // Destroy Chip when colliding with something that is not the Player1
        if (other.gameObject.name != "Player1")
        {
            UnityEngine.Object.Destroy(_character.Representation);
        }
    }
}

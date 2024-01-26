using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private AnimationController _animationController = null;
    private GameplayController _gameplayController = null;

    private string _playerChoices = null;

    void Awake()
    {
        _animationController = GetComponent<AnimationController>();
        _gameplayController = GetComponent<GameplayController>();
    }

    public void GetChoice()
    {
        string choiceName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        EGameChoices selectedChoice = EGameChoices.NONE;

        switch(choiceName)
        {
            case "Rock":
                selectedChoice = EGameChoices.ROCK;
                break;
            case "Paper":
                selectedChoice = EGameChoices.PAPER;
                break; 
            case "Scissors":
                selectedChoice = EGameChoices.SCISSORS;
                break;       
        }

        _gameplayController.SetChoices(selectedChoice);
        _animationController.PlayerMadeChoice();
    }
}

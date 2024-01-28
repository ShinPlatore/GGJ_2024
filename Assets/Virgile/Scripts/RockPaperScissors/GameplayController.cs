using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private Sprite _rockSprite = null;
    [SerializeField] private Sprite _paperSprite = null;
    [SerializeField] private Sprite _scissorsSprite = null;

    [SerializeField] private Image _playerChoiceImage = null;
    [SerializeField] private Image _opponentChoiceImage = null;

    [SerializeField] private TMP_Text _infoText = null;

    private EGameChoices _playerChoice = EGameChoices.NONE;
    private EGameChoices _opponentChoice = EGameChoices.NONE;

    private AnimationController _animationController = null;

    [SerializeField] private GameOver _gameOver = null;


    void Awake()
    {
        _animationController = GetComponent<AnimationController>();
    }

    public void SetChoices(EGameChoices gameChoices)
    {
        switch(gameChoices)
        {
            case EGameChoices.ROCK:
                _playerChoiceImage.sprite = _rockSprite;
                _playerChoice = EGameChoices.ROCK;
                break;
            case EGameChoices.PAPER:
                _playerChoiceImage.sprite = _paperSprite;
                _playerChoice = EGameChoices.PAPER;
                break;
            case EGameChoices.SCISSORS:
                _playerChoiceImage.sprite = _scissorsSprite;
                _playerChoice = EGameChoices.SCISSORS;
                break;
        }

        SetOpponentChoice();
        DetermineWinner();
    }

    private void SetOpponentChoice()
    {
        int random = Random.Range(0, 3);

        switch(random)
        {
            case 0:
                _opponentChoice = EGameChoices.ROCK;
                _opponentChoiceImage.sprite = _rockSprite;
                break;
            case 1:
                _opponentChoice = EGameChoices.PAPER;
                _opponentChoiceImage.sprite = _paperSprite;
                break;
            case 2:
                _opponentChoice = EGameChoices.SCISSORS;
                _opponentChoiceImage.sprite = _scissorsSprite;
                break;
        }
    }

    private void DetermineWinner()
    {
        if(_playerChoice == _opponentChoice)
        {
            _infoText.text = "It's a DRAW!";
            StartCoroutine(DisplayWinnerAndRestart());
            StartCoroutine(DisplayGameOver());

            return;
        }

        if(_playerChoice == EGameChoices.PAPER && _opponentChoice == EGameChoices.ROCK)
        {
            _infoText.text = "You WIN!";
            StartCoroutine(DisplayWinnerAndRestart());

            return;
        }
        if(_opponentChoice == EGameChoices.PAPER && _playerChoice == EGameChoices.ROCK)
        {
            _infoText.text = "You LOSE!";
            StartCoroutine(DisplayWinnerAndRestart());
            StartCoroutine(DisplayGameOver());

            return;
        }
        if(_playerChoice == EGameChoices.ROCK && _opponentChoice == EGameChoices.SCISSORS)
        {
            _infoText.text = "You WIN!";
            StartCoroutine(DisplayWinnerAndRestart());

            return;
        }
        if(_opponentChoice == EGameChoices.ROCK && _playerChoice == EGameChoices.SCISSORS)
        {
            _infoText.text = "You LOSE!";
            StartCoroutine(DisplayWinnerAndRestart());
            StartCoroutine(DisplayGameOver());

            return;
        }
        if(_playerChoice == EGameChoices.SCISSORS && _opponentChoice == EGameChoices.PAPER)
        {
            _infoText.text = "You WIN!";
            StartCoroutine(DisplayWinnerAndRestart());

            return;
        }
        if(_opponentChoice == EGameChoices.SCISSORS && _playerChoice == EGameChoices.PAPER)
        {
            _infoText.text = "You LOSE!";
            StartCoroutine(DisplayWinnerAndRestart());
            StartCoroutine(DisplayGameOver());

            return;
        }
    }

    IEnumerator DisplayWinnerAndRestart()
    {
        yield return new WaitForSeconds(2f);
        _infoText.gameObject.SetActive(true);

        /*yield return new WaitForSeconds(2f);
        _infoText.gameObject.SetActive(false);
        _animationController.ResetAnimations();*/
    }

    IEnumerator DisplayGameOver()
    {
        yield return new WaitForSeconds(3f);
        _gameOver.IsGameOver = true;
    }

}

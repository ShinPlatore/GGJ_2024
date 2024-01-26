using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [Header("Animations")]
    [SerializeField] private Animator _playerChoiceHandlerAnimation = null;
    [SerializeField] private Animator _choiceAnimation = null;


    public void ResetAnimations()
    {
        _playerChoiceHandlerAnimation.Play("ShowHandler");
        _choiceAnimation.Play("RemoveChoices");
    }

    public void PlayerMadeChoice()
    {
        _playerChoiceHandlerAnimation.Play("RemoveHandler");
        _choiceAnimation.Play("ShowChoices");
    }
}

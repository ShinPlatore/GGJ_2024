using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ResetEnding : MonoBehaviour
{
    [SerializeField] private GameObject _resetScreen = null;
    [SerializeField] private GameObject _fadeInSquare = null;
    private float _fadeAnimationTime = 1.95f;
    [SerializeField] private float _animationDuration = 3f;

    [SerializeField] private AudioSource _endingMusic = null;
    [SerializeField] private AudioSource _buttonSound = null;
    [SerializeField] private AudioSource _mainThemeMusic = null;

    private bool _hasFinishedMenuAnimation = false;
    private bool _hasFinishedRestartAnimation = false;

    private void Start()
    {

    }

    private void Update()
    {
        if(_hasFinishedMenuAnimation == true || _hasFinishedRestartAnimation == true && _fadeAnimationTime > 0 && _animationDuration <= 0)
        {
            _fadeInSquare.SetActive(true);
            _fadeAnimationTime -= Time.deltaTime;
        }

        if (_fadeAnimationTime <= 0 && _hasFinishedMenuAnimation == true)
        {
            SceneManager.LoadScene("MainMenu");
        }

        if (_fadeAnimationTime <= 0 && _hasFinishedRestartAnimation == true)
        {
            SceneManager.LoadScene("MainLevelDesignScene");
        }

        DisplayScreen();
    }

    private void DisplayScreen()
    {
        if(_animationDuration <= 0)
        {
            _resetScreen.SetActive(true);
            _mainThemeMusic.Stop();
            _endingMusic.Play(); 
        }
        else
        {
            _animationDuration -= Time.deltaTime;
        }
        
    }

    public void RestartLevel()
    {
        _buttonSound.Play();
        _hasFinishedRestartAnimation = true;
    }

    public void OpenMainMenu()
    {
        _buttonSound.Play();
        _hasFinishedMenuAnimation = true;
    }
}

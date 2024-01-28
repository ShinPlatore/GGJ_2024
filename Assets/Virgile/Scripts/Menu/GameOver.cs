using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen = null;
    [SerializeField] private GameObject _fadeInSquare = null;
    private float _fadeAnimationTime = 1.95f;

    [SerializeField] private AudioSource _gameOverMusic = null;
    [SerializeField] private AudioSource _buttonSound = null;
    [SerializeField] private AudioSource _mainThemeMusic = null;

    private bool _hasFinishedMenuAnimation = false;
    private bool _hasFinishedRestartAnimation = false;
    private bool _isGameOver = false;
    public bool IsGameOver
    {
        get
        {
            return _isGameOver;
        }
        set
        {
            _isGameOver = value;
        }
    }

    private void Start()
    {

    }

    private void Update()
    {
        if(_hasFinishedMenuAnimation == true || _hasFinishedRestartAnimation == true && _fadeAnimationTime > 0)
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
        if(IsGameOver)
        {
            _gameOverScreen.SetActive(true);
            _isGameOver = true;
            _mainThemeMusic.Stop();
            if (_gameOverMusic.clip == null)
            {
                Debug.Log("Audio clip not assigned to _gameOverMusic!");
                return;
            }
            else{
                _gameOverMusic.Play();
            }
            
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

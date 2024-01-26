using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;
using TMPro;

public class MainMenu : MonoBehaviour
{
    #region Fields
    [Header("Game Object")]
    [SerializeField] private GameObject _mainMenu = null;
    [SerializeField] private GameObject _settingsMenu = null;
    [SerializeField] private GameObject _creditsMenu = null;
    [SerializeField] private GameObject _quitCheck = null;
    [SerializeField] private GameObject _blur = null;
    [Header("Text")]
    [SerializeField] private TMP_Text _settings = null;
    private float _fontSize = 75f;
    [Header("Animation")]
    private float _fadeAnimationTime = 1.95f;
    private float _fadeAnimationTimePlay = 1.95f;
    [SerializeField] private GameObject _fadeOutSquare = null;
    [SerializeField] private GameObject _fadeInSquare = null;
    private bool _hasFinishedQuitAnimation = false;
    private bool _hasFinishedPlayAnimation = false;

    #endregion Fields

    #region Methods
    void Start()
    {
        _mainMenu.SetActive(true);
        _quitCheck.SetActive(false);
    }

    public void Play()
    {
        _hasFinishedPlayAnimation = true;
    }

    public void OpenSettings()
    {
        _mainMenu.SetActive(false);
        _settingsMenu.SetActive(true);
        _settings.fontSize = _fontSize;
    }

    public void OpenCredits()
    {
        _mainMenu.SetActive(false);
        _settingsMenu.SetActive(false);
        _creditsMenu.SetActive(true);
    }

    #region Quit Methods
    public void QuitChecking()
    {
        _quitCheck.SetActive(true);
        _blur.SetActive(true);
    }
    private void Update()
    {
        if (_hasFinishedQuitAnimation == true && _fadeAnimationTime > 0)
        {
            _fadeOutSquare.SetActive(true);
            _fadeAnimationTime -= Time.deltaTime;
        }

        if (_fadeAnimationTime <= 0 && _hasFinishedQuitAnimation == true)
        {
            Application.Quit();
        }

        if(_hasFinishedPlayAnimation == true && _fadeAnimationTimePlay > 0)
        {
            _fadeInSquare.SetActive(true);
            _fadeAnimationTimePlay -= Time.deltaTime;
        }

        if(_fadeAnimationTimePlay <= 0 && _hasFinishedPlayAnimation == true)
        {
            SceneManager.LoadScene("MiniGame");
        }
    }

    public void QuitY()
    {
        _hasFinishedQuitAnimation = true;
    }

    public void QuitN()
    {
        _quitCheck.SetActive(false);
        _blur.SetActive(false);
    }
    #endregion Quit Methods
    #endregion Methods
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;


public class SettingsMenu : MonoBehaviour
{
    #region Fields
    [Header("Game Object")]
    [SerializeField] private GameObject _mainMenu = null;
    [SerializeField] private GameObject _settingsMenu = null;
    [SerializeField] private Toggle _fullScreenToggle = null;
    [SerializeField] private Toggle _vSyncToggle = null;
    [SerializeField] private GameObject _resumeMenu = null;
    [SerializeField] private Scrollbar _scrollbar = null;
    [Header("Resolutions")]
    public int _selectedResolutions;
    public TMP_Text _resolutionsText = null;
    public List<ResolutionIndex> _resolutions = new List<ResolutionIndex>();
    [Header("Text")]
    [SerializeField] private TMP_Text _back = null;
    private float _fontSize = 75f;
    #endregion Fields

    #region Methods
    void Start()
    {
        if (QualitySettings.vSyncCount == 0)
        {
            _vSyncToggle.isOn = false;
        }
        else
        {
            _vSyncToggle.isOn = true;
        }

        _scrollbar.value = 1;
    }

    public void BackMainMenu()
    {
        _mainMenu.SetActive(true);
        _settingsMenu.SetActive(false);
        _back.fontSize = _fontSize;
    }

    public void BackResumeMenu()
    {
        _resumeMenu.SetActive(true);
        _settingsMenu.SetActive(false);
        _back.fontSize = _fontSize;
    }

    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetVsync()
    {
        if (_vSyncToggle.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }

    public void ResolutionsInf()
    {
        _selectedResolutions--;
        if (_selectedResolutions < 0)
        {
            _selectedResolutions = 0;
        }
        SetResolutionText();
        SetResolution();
    }

    public void ResolutionSup()
    {
        _selectedResolutions++;
        if (_selectedResolutions > _resolutions.Count - 1)
        {
            _selectedResolutions = _resolutions.Count - 1;
        }
        SetResolutionText();
        SetResolution();
    }

    public void SetResolutionText()
    {
        _resolutionsText.text = _resolutions[_selectedResolutions].horizontal.ToString() + "x" + _resolutions[_selectedResolutions].vertical.ToString();
    }

    public void SetResolution()
    {
        Screen.SetResolution(_resolutions[_selectedResolutions].horizontal, _resolutions[_selectedResolutions].vertical, _fullScreenToggle.isOn);
    }

    #endregion Methods
}

[System.Serializable]
public class ResolutionIndex
{
    public int horizontal;
    public int vertical;
}
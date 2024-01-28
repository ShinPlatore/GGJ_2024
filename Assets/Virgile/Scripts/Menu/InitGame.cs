using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGame : MonoBehaviour
{
    private float _fadeAnimationTime = 1.95f;
    [SerializeField] private GameObject _fadeOutSquare = null;
    [SerializeField] private AudioSource _mainThemeMusic = null;

    void Start()
    {
        _mainThemeMusic.Play();
        _fadeOutSquare.SetActive(true);
    }

    void Update()
    {
        if (_fadeAnimationTime > 0)
        {
            _fadeAnimationTime -= Time.deltaTime;
        }

        if (_fadeAnimationTime <= 0)
        {
            _fadeOutSquare.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BiomeTransition : MonoBehaviour
{
    [SerializeField] private AudioSource _mainTheme = null;
    [SerializeField] private AudioClip[] _biomeAudioClips = null;
    [SerializeField] private int _biomeNumber = 0;

    [SerializeField] private MeshRenderer _biomeMaterial = null;
    [SerializeField] private Material[] _backgroundTexture = null;

    private float _fadeAnimationTime = 1.95f;
    private float _fadeAnimationTimePlay = 1.95f;
    [SerializeField] private GameObject _fadeOutSquare = null;
    [SerializeField] private GameObject _fadeInSquare = null;
    private bool _hasFinishedQuitAnimation = false;
    private bool _hasFinishedPlayAnimation = false;

    private void Update()
    {
        if (_hasFinishedQuitAnimation == true && _fadeAnimationTime > 0)
        {

            _fadeInSquare.SetActive(true);
            _fadeAnimationTime -= Time.deltaTime;
        }

        if (_fadeAnimationTime <= 0 && _hasFinishedQuitAnimation == true)
        {
            _hasFinishedPlayAnimation = true;
            _fadeOutSquare.SetActive(true);
            _fadeInSquare.SetActive(false);
        }

        if (_hasFinishedPlayAnimation == true && _fadeAnimationTimePlay > 0)
        {
            _fadeOutSquare.SetActive(true);
            _fadeAnimationTimePlay -= Time.deltaTime;
            _biomeMaterial.material = _backgroundTexture[_biomeNumber];
            _mainTheme.clip = _biomeAudioClips[_biomeNumber];
            _mainTheme.Play();
        }
        if (_fadeAnimationTimePlay <= 0 && _hasFinishedPlayAnimation == true)
        {
            _fadeOutSquare.SetActive(false);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _hasFinishedQuitAnimation = true;
            _fadeInSquare.SetActive(true);


        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

        }

    }
}

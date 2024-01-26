using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitMainMenu : MonoBehaviour
{
    private float _fadeAnimationTime = 1.95f;
    [SerializeField] private GameObject _fadeInSquare = null;

    void Start()
    {
        _fadeInSquare.SetActive(true);
    }

    void Update()
    {
        if (_fadeAnimationTime > 0)
        {
            _fadeAnimationTime -= Time.deltaTime;
        }

        if (_fadeAnimationTime <= 0)
        {
            _fadeInSquare.SetActive(false);
        }
    }
}

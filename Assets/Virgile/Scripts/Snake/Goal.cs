using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject _canvas = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Hand")
        {
            _canvas.SetActive(true);
            Time.timeScale = 0;
        }
    }
}

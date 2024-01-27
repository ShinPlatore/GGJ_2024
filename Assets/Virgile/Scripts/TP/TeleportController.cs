using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    [SerializeField] private TestMovement _movement = null;
    [SerializeField] private Vector3 _posEnter;
    [SerializeField] private Vector3 _posExit;

    void Start()
    {            

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit");
        _movement.transform.position = _posExit;
        //_movement._direction = EHandDirection.Forward;
        if(other.CompareTag("Teleport"))
        {
            Debug.Log("Touched");
            _movement.transform.position = _posExit;
        }
    }
}

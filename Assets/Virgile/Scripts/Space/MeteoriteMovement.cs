using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteMovement : MonoBehaviour
{
    [SerializeField] private GameObject _hand = null;
    [SerializeField] private float _speed = 1.5f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _hand.transform.position, _speed * Time.deltaTime);
        transform.up = _hand.transform.position - transform.position;
    }
}

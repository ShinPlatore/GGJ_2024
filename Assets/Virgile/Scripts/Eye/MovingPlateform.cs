using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlateform : MonoBehaviour
{

    [SerializeField] private float _speed = 10f;
    [SerializeField] private int _startingPoint = 2;
    [SerializeField] private Transform[] _points;
    [SerializeField] private PlayerHand _playerHand = null;

    private int i;

    void Start()
    {
        transform.position = _points[_startingPoint].position;    
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, _points[i].position) < 0.02f)
        {
            i++;
            if(i == _points.Length)
            {
                i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, _points[i].position, _speed * Time.deltaTime);
        _playerHand._hasSpaced = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    [SerializeField] private Transform[] _posHand = null;
    [SerializeField] private int _index;
    private float _speed = 0.5f;


    void Start()
    {
        transform.position = _posHand[1].position;

    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(_index < _posHand.Length)
            {
                _index++;
                transform.position = _posHand[_index].position;
            }
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(_index > 0)
            {
                _index--;
                transform.position = _posHand[_index].position;
            }
        }

        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }
}

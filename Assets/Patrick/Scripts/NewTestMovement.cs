using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewTestMovement : MonoBehaviour
{
    [SerializeField] private GameObject _handObject;
    [SerializeField] private SpriteRenderer _Arm1 = null;
    [SerializeField] private SpriteRenderer _Arm2 = null;

    [SerializeField] private Sprite _NEArm;
    [SerializeField] private Sprite _NWArm;
    [SerializeField] private Sprite _SEArm;
    [SerializeField] private Sprite _SWArm;

    [SerializeField] private Sprite _ForwardArm;
    [SerializeField] private Sprite _VerticalArm;

    [SerializeField] private Transform _spawnTransform;

    [SerializeField] private EHandDirection _direction = EHandDirection.Forward;

    private Vector3 _movePosition;
    [SerializeField] private float _bendSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (_direction == EHandDirection.Up)
            {
                _handObject.transform.position = new Vector3(-0.64f, 0.64f, 0f);
                _handObject.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                

            }

            else if(_direction == EHandDirection.Down)
            {


            }

            else
            {
                
            }

            _direction = EHandDirection.Up;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (_direction == EHandDirection.Down)
            {
                
            }

            else
            {
                
            }

            _direction = EHandDirection.Down;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (_direction == EHandDirection.Up)
            {
                

            }
            else if(_direction == EHandDirection.Down)
            {
                

            }

            else
            {
                
            }


            _direction = EHandDirection.Forward;

        }

    }

    


}

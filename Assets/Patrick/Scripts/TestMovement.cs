using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    [SerializeField] private GameObject _handObject;
    [SerializeField] private GameObject _NEArm;
    [SerializeField] private GameObject _NWArm;
    [SerializeField] private GameObject _SEArm;
    [SerializeField] private GameObject _SWArm;

    [SerializeField] private GameObject _ForwardArm;
    [SerializeField] private GameObject _VerticalArm;

    [SerializeField] private Transform _spawnTransform;

    private EHandDirection _direction = EHandDirection.Forward;


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
                transform.position += new Vector3(0f, 1.2f, 0f);
                _handObject.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                Instantiate(_VerticalArm, _spawnTransform.position, Quaternion.identity);

            }

            else if(_direction == EHandDirection.Down)
            {


            }

            else
            {
                transform.position += new Vector3(0.6f, 0.6f, 0f);
                _handObject.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                Instantiate(_SEArm, _spawnTransform.position, Quaternion.identity);
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
                transform.position += new Vector3(0f, -1.2f, 0f);
                _handObject.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                Instantiate(_VerticalArm, _spawnTransform.position, Quaternion.identity);
            }

            else
            {
                transform.position += new Vector3(0.6f, -0.6f, 0f);
                _handObject.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                Instantiate(_NEArm, _spawnTransform.position, Quaternion.identity);
            }

            _direction = EHandDirection.Down;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (_direction == EHandDirection.Up)
            {
                transform.position += new Vector3(0.6f, 0.6f, 0f);
                _handObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                Instantiate(_NWArm, _spawnTransform.position, Quaternion.identity);

            }
            else if(_direction == EHandDirection.Down)
            {
                transform.position += new Vector3(0.6f, -0.6f, 0f);
                _handObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                Instantiate(_SWArm, _spawnTransform.position, Quaternion.identity);

            }

            else
            {
                transform.position += new Vector3(1.2f, 0f, 0f);
                _handObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                Instantiate(_ForwardArm, _spawnTransform.position, Quaternion.identity);
            }


            _direction = EHandDirection.Forward;

        }

    }
}

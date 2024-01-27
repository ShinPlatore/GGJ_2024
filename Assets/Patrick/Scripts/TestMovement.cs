using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    [SerializeField] private Transform _ArmsStock = null;

    [SerializeField] private GameObject _handObject;
    [SerializeField] private GameObject _NEArm;
    [SerializeField] private GameObject _NWArm;
    [SerializeField] private GameObject _SEArm;
    [SerializeField] private GameObject _SWArm;

    [SerializeField] private GameObject _ForwardArm;
    [SerializeField] private GameObject _VerticalArm;

    [SerializeField] private Transform _spawnTransform;

    [SerializeField] private EHandDirection _direction = EHandDirection.Forward;

    private Vector3 _movePosition;
    private Vector3 _armStockPosition;

    [SerializeField] private float _bendSpeed = 2f;
    [SerializeField] private int _moveCount;

    // Start is called before the first frame update
    void Start()
    {
        _movePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {




        if (Input.GetKeyDown(KeyCode.W))
        {
            if(_moveCount < 5)
            {
                if (_direction == EHandDirection.Up)
                {
                    VerticalMove(true);
                    _moveCount++;
                }

                else if (_direction == EHandDirection.Down)
                {


                }

                else
                {
                    SEMove();
                    _moveCount++;

                }

                _direction = EHandDirection.Up;

            }
            
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (_moveCount > 0)
            {
                if (_direction == EHandDirection.Down)
                {
                    VerticalMove(false);
                    _moveCount--;
                }

                else
                {
                    NEMove();
                    _moveCount--;
                }
                _direction = EHandDirection.Down;

            }

                


        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (_direction == EHandDirection.Up)
            {
                NWMove();

            }
            else if(_direction == EHandDirection.Down)
            {
                SWMove();

            }

            else
            {
                ForwardMove();
            }


            _direction = EHandDirection.Forward;

        }

    }

    void VerticalMove(bool isUp)
    {
        if (isUp)
        {
            transform.position += new Vector3(0f, 1.2f, 0f);
            _handObject.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            GameObject instantiatePrefab = Instantiate(_VerticalArm, _spawnTransform.position, Quaternion.identity);
            instantiatePrefab.transform.SetParent(_ArmsStock);
        }
        else
        {
            transform.position += new Vector3(0f, -1.2f, 0f);
            _handObject.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            GameObject instantiatePrefab = Instantiate(_VerticalArm, _spawnTransform.position, Quaternion.identity);
            instantiatePrefab.transform.SetParent(_ArmsStock);
        }

    }

    void ForwardMove()
    {
        transform.position += new Vector3(1.2f, 0f, 0f);
        _handObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        GameObject instantiatePrefab = Instantiate(_ForwardArm, _spawnTransform.position, Quaternion.identity);
        instantiatePrefab.transform.SetParent(_ArmsStock);
    }

    void SEMove()
    {
        transform.position += new Vector3(0.6f, 0.6f, 0f);
        _handObject.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        GameObject instantiatePrefab = Instantiate(_SEArm, _spawnTransform.position, Quaternion.identity);
        instantiatePrefab.transform.SetParent(_ArmsStock);
    }

    void NEMove()
    {
        transform.position += new Vector3(0.6f, -0.6f, 0f);
        _handObject.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        GameObject instantiatePrefab = Instantiate(_NEArm, _spawnTransform.position, Quaternion.identity);
        instantiatePrefab.transform.SetParent(_ArmsStock);
    }

    void NWMove()
    {
        transform.position += new Vector3(0.6f, 0.6f, 0f);
        _handObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        GameObject instantiatePrefab = Instantiate(_NWArm, _spawnTransform.position, Quaternion.identity);
        instantiatePrefab.transform.SetParent(_ArmsStock);
    }

    void SWMove()
    {
        transform.position += new Vector3(0.6f, -0.6f, 0f);
        _handObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        GameObject instantiatePrefab = Instantiate(_SWArm, _spawnTransform.position, Quaternion.identity);
        instantiatePrefab.transform.SetParent(_ArmsStock);
    }


}

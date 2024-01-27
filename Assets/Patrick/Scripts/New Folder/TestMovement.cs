using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

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

    [SerializeField] private ObjectTemplate _objectAtReach;

    [SerializeField] private int _moveCount;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PunchAction();

        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if(_moveCount < 6)
            {
                if (_direction == EHandDirection.Up)
                {
                    VerticalMove(true);
                    _moveCount++;
                    _direction = EHandDirection.Up;
                }

                else if (_direction == EHandDirection.Down)
                {


                }

                else
                {
                    SEMove();
                    _moveCount++;
                    _direction = EHandDirection.Up;
                }



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
                    _direction = EHandDirection.Down;
                }

                else if (_direction == EHandDirection.Up)
                {


                }

                else
                {
                    NEMove();
                    _moveCount--;
                    _direction = EHandDirection.Down;
                }


            }

                


        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (_direction == EHandDirection.Up)
            {
                NWMove();
                _direction = EHandDirection.Forward;
            }
            else if(_direction == EHandDirection.Down)
            {
                SWMove();
                _direction = EHandDirection.Forward;
            }

            else
            {
                ForwardMove();
                _direction = EHandDirection.Forward;
            }


            

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

    private void PunchAction()
    {
        _objectAtReach.CollideFonction(this);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject);
        //_objectAtReach = other.gameObject.GetComponent<Rigidbody2D>();

        _objectAtReach = other.gameObject.GetComponent<ObjectTemplate>();



    }


}

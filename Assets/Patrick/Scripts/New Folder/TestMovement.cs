using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] private ObjectTemplate _objectAtReach;

    [SerializeField] private int _life = 3;
    [SerializeField] private int _moveCount;

    void Start()
    {


    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (_objectAtReach.ObjectType == EObjectType.Slapable)
            {
                PunchAction();

            }

        }

        if (Input.GetKeyDown(KeyCode.W) | Input.GetKeyDown(KeyCode.UpArrow))
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

        if (Input.GetKeyDown(KeyCode.Q) | Input.GetKeyDown(KeyCode.LeftArrow))
        {

        }

        if (Input.GetKeyDown(KeyCode.S) | Input.GetKeyDown(KeyCode.DownArrow))
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

        if (Input.GetKeyDown(KeyCode.D) | Input.GetKeyDown(KeyCode.RightArrow))
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
        _objectAtReach = other.gameObject.GetComponent<ObjectTemplate>();

        if( _objectAtReach != null )
        {
            if (_objectAtReach.ObjectType == EObjectType.Slapable)
            {


            }

            if (_objectAtReach.ObjectType == EObjectType.Obstacle)
            {
                HitObstacleEvent();
                _objectAtReach._hitCollider.enabled = false;

            }

            if (_objectAtReach.ObjectType == EObjectType.InteractObject)
            {
                HitInteractEvent();

            }

            if (_objectAtReach.ObjectType == EObjectType.EndObject)
            {


            }

        }



    }


    private void HitObstacleEvent()
    {
        _life--;
        if( _life == 0)
        {
            Debug.Log("You Lose");
        }

    }

    private void HitInteractEvent()
    {
        

    }

    private void GrabEndEvent()
    {
        //play grab hand anim

        //do transition to the knight scene

        //play the knight end anim, depending on the object


    }


}

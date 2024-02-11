using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;

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

    [SerializeField] private CinemachineImpulseSource _impulseSource;

    private Vector3 _respawnLocation = Vector3.zero;

    #region Life
    [SerializeField] private int _life = 3;
    [SerializeField] private Sprite _emptySprite = null;

    [SerializeField] private Image[] _currentLife = null;

    #endregion Life

    [SerializeField] private int _moveCount;
    [SerializeField] private GameObject _gameOver = null;
    [SerializeField] private ScrollingBackground _scrolling = null;
    [SerializeField] private LoopingBackground _looping = null;


    [SerializeField] private GameObject _fadeInSquare = null;
    [SerializeField] private bool _hasFinishedPlayAnimation = false;
    private float _fadeAnimationTimePlay = 1.95f;
    private string _loadedscene;

    public int MoveCount
    {
        get { return _moveCount; }
        set { _moveCount = value; }
    }

    public Vector3 RespawnLocation
    {
        get
        {
            return _respawnLocation;
        }
        set 
        { 
            _respawnLocation = value; 
        }
    }

    void Start()
    {
        transform.position = Manager.Instance.PlayerPosition;

    }

    void Update()
    {
        if (_hasFinishedPlayAnimation == true && _fadeAnimationTimePlay > 0)
        {
            _fadeInSquare.SetActive(true);
            _fadeAnimationTimePlay -= Time.deltaTime;
        }

        if (_fadeAnimationTimePlay <= 0 && _hasFinishedPlayAnimation == true)
        {
            SceneManager.LoadScene(_loadedscene);
        }

        if (Input.GetKey(KeyCode.Escape))
        {


        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (_objectAtReach != null)
            {
                if (_objectAtReach.ObjectType == EObjectType.Slapable)
                {
                    PunchAction();
                }
            }


        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if(_objectAtReach != null)
            {
                if (_objectAtReach.ObjectType == EObjectType.Slapable)
                {

                }
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

        if(_objectAtReach != null)
        {
            if (_objectAtReach.ObjectType == EObjectType.Slapable)
            {


            }

            if (_objectAtReach.ObjectType == EObjectType.Obstacle)
            {
                HitObstacleEvent();

            }

            if (_objectAtReach.ObjectType == EObjectType.InteractObject)
            {
                HitInteractEvent();

            }

            if (_objectAtReach.ObjectType == EObjectType.EndObject)
            {
                GrabEndEvent();

            }

        }
        


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_objectAtReach != null && _objectAtReach.GetType() == typeof(ObjectTemplate))
        {
            _objectAtReach = null;

        }

    }


        private void HitObstacleEvent()
    {
        _life--;
        if(_life >= 0)
        {
            _currentLife[_life].sprite = _emptySprite;
            CameraShakeManager._instance.CameraShake(_impulseSource);
            _objectAtReach._hitCollider.enabled = false;
        } 

        if( _life <= 0)
        {
            _scrolling.ScrollingSpeed = 0f;
            _looping.BackgroundSpeed = 0f;
            
            _gameOver.SetActive(true);
        }

    }

    private void HitInteractEvent()
    {
        _objectAtReach.CollideFonction(this);

    }

    private void GrabEndEvent()
    {

        //play grab hand anim

        //do transition to the knight scene
        _hasFinishedPlayAnimation = true;

        switch ( _objectAtReach.EndingObject )
        {
            case EEndingObject.BleachBottle:
                _loadedscene = "BleachEndingCinematicScene";
                break;

            case EEndingObject.Eel:
                _loadedscene = "EelEndingCinematicScene";
                break;

            case EEndingObject.Anvil:
                _loadedscene = "AnvilEndingCinematicScene";
                break;

            case EEndingObject.Beer:
                _loadedscene = "BeerEndingCinematicScene";
                break;

        }

        //play the knight end anim, depending on the object


    }


}

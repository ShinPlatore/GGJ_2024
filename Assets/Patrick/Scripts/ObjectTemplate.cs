using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTemplate : MonoBehaviour
{
    [SerializeField] private EObjectType _objectType = EObjectType.Slapable;
    [SerializeField] private EEndingObject _endingObject = EEndingObject.BleachBottle;
    [SerializeField] private AudioSource _hitSound;

    public Collider2D _hitCollider;

    #region warp
    [SerializeField] private Transform _exitWarp = null;
    [SerializeField] private EWarpPositions _positions = EWarpPositions.zero;
    private float _yPos;
    #endregion warp

    public EObjectType ObjectType
    {
        get { return _objectType; }

    }

    public EEndingObject EndingObject
    {
        get { return _endingObject; }

    }

    private void Awake()
    {
        SetExitWarpPosition();
        if (_exitWarp != null )
        {
            _exitWarp.transform.localPosition = new Vector3(_exitWarp.transform.localPosition.x, _yPos, 0f);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        _hitCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollideFonction(TestMovement character)
    {
        switch (_objectType)
        {
            case EObjectType.Slapable:
                PunchAction(character);
                break;

            case EObjectType.Obstacle:
                _hitSound.Play();
                break;

            case EObjectType.InteractObject:
                WarpEvent(character);
                break;

            case EObjectType.EndObject:
                _hitSound.Play();
                break;

        }

    }

    private void PunchAction(TestMovement character)
    {
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddForceAtPosition(new Vector3(Random.Range(100, 200), Random.Range(-250, 250), 0f), character.transform.position);
        _hitSound.Play();
    }

    private void WarpEvent(TestMovement character)
    {
        if (_exitWarp != null )
        {
            _hitSound.Play();
            character.gameObject.transform.position = _exitWarp.position;
        }


        switch (_positions)
        {
            case EWarpPositions.zero:
                character.MoveCount = 0;
                break;
            case EWarpPositions.une:
                character.MoveCount = 1;
                break;
            case EWarpPositions.deux:
                character.MoveCount = 2;
                break;
            case EWarpPositions.trois:
                character.MoveCount = 3;
                break;
            case EWarpPositions.quatre:
                character.MoveCount = 4;
                break;
            case EWarpPositions.cinq:
                character.MoveCount = 5;
                break;
            case EWarpPositions.six:
                character.MoveCount = 6;
                break;
        }

    }


    private void SetExitWarpPosition()
    {
        switch(_positions)
        {
            case EWarpPositions.zero:
                _yPos = -2.2216f;
                
            break;
            case EWarpPositions.une:
                _yPos = -1.0216f;
            break;
            case EWarpPositions.deux:
                _yPos = 0.1701395f;
            break;
            case EWarpPositions.trois:
                _yPos = 1.36428f;

                break;
            case EWarpPositions.quatre:
                _yPos = 2.56428f;


                break;
            case EWarpPositions.cinq:
                _yPos = 3.764279f;


                break;
            case EWarpPositions.six:
                _yPos = 4.964279f;


                break;
        }

    }

}

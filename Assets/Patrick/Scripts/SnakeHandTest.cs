using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHandTest : MonoBehaviour
{
    [SerializeField] private GameObject _handObject;
    [SerializeField] private SpriteRenderer _trail1 = null;
    [SerializeField] private SpriteRenderer _trail2 = null;
    [SerializeField] private SpriteRenderer _trail3 = null;


    [SerializeField] private Sprite _NESprite = null;
    [SerializeField] private Sprite _NWSprite = null;
    [SerializeField] private Sprite _SWSprite = null;
    [SerializeField] private Sprite _SESprite = null;
    [SerializeField] private Sprite _FSprite = null;
    [SerializeField] private Sprite _VSprite = null;

    [SerializeField] private EHandDirection _direction = EHandDirection.Forward;
    [SerializeField] private float _lifeTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_direction == EHandDirection.Down)
        {
            _lifeTimer += Time.deltaTime;

        }
        if (_lifeTimer > 1)
        {
            _trail1.sprite = _FSprite;
            _trail2.sprite = _SWSprite;
            _trail3.sprite = _NESprite;

            _lifeTimer = 0f;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (_direction == EHandDirection.Up)
            {
                VerticalMove(true);

            }

            else if (_direction == EHandDirection.Down)
            {


            }

            else
            {
                SEMove();

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
            chaineAction();
            



        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (_direction == EHandDirection.Up)
            {
                NWMove();

            }
            else if (_direction == EHandDirection.Down)
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

        }
        else
        {
            transform.position += new Vector3(0f, -1.2f, 0f);
            _handObject.transform.rotation = Quaternion.Euler(0f, 0f, -90f);

        }

    }

    void ForwardMove()
    {
        transform.position += new Vector3(1.2f, 0f, 0f);
        _handObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

    }

    void SEMove()
    {
        transform.position += new Vector3(0.6f, 0.6f, 0f);
        _handObject.transform.rotation = Quaternion.Euler(0f, 0f, 90f);

    }

    void NEMove()
    {
        transform.position += new Vector3(0.6f, -0.6f, 0f);
        _handObject.transform.rotation = Quaternion.Euler(0f, 0f, -90f);

    }

    void NWMove()
    {
        transform.position += new Vector3(0.6f, 0.6f, 0f);
        _handObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

    }

    void SWMove()
    {
        transform.position += new Vector3(0.6f, -0.6f, 0f);
        _handObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

    }

    void chaineAction()
    {
        if(_direction == EHandDirection.Down)
        {
            _handObject.transform.position = new Vector3( -0.64f, -0.64f, 0f);
            _handObject.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            _trail1.sprite = _NESprite;

        }
    }

}

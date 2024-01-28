using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightWalk : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private Vector3 _startPos = new Vector3(0,0,0);
    [SerializeField] private Vector3 _endPos = new Vector3(15,0,0);
    [SerializeField] private SpriteRenderer _knightSprite = null;
    
    private float _newPos = 3f;
    private bool _isOnRoof = false;

    void Update()
    {
        Vector3 currentPosition = transform.position;
        float horizontalMovement = _speed * Time.deltaTime;

        Debug.Log(_isOnRoof);

        if(!_isOnRoof)
        {
            currentPosition.y = 0;
            _knightSprite.flipX = false;
            _knightSprite.flipY = false;
            currentPosition.x += horizontalMovement;
        }
        else
        {
            currentPosition.y = _newPos;
            _knightSprite.flipX = true;
            _knightSprite.flipY = true;
            currentPosition.x -= horizontalMovement;
        }     

        transform.position = currentPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Start")
        {
            _isOnRoof = false;
        }
        if(other.tag == "End")
        {
            _isOnRoof = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed = 1f;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Rigidbody2D _characterRigidbody = null;
    [SerializeField] private Rigidbody2D _handRigidbody = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        // Movement
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        _characterRigidbody.velocity = new Vector2((_scrollSpeed + (_speed * moveHorizontal)), (0f + (_speed * moveVertical)));




    }
}

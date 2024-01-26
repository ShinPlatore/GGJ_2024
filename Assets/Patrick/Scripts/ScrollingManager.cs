using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _characterRigidbody = null; 
    [SerializeField] private float _scrollSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //_characterRigidbody.velocity = new Vector2(_scrollSpeed, _characterRigidbody.velocity.y);




    }

}

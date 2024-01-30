using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] private float _scrollingSpeed = 1f;

    public float ScrollingSpeed
    {
        get { return _scrollingSpeed; }
        set { _scrollingSpeed = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _scrollingSpeed += Time.fixedDeltaTime / 2500;
        transform.position += new Vector3(_scrollingSpeed * Time.deltaTime, 0, 0);
    }
}

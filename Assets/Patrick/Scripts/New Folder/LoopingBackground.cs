using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    [SerializeField] private float _backgroundSpeed = 1;
    [SerializeField] private Renderer _backgroundRenderer = null;

    public float BackgroundSpeed
    {
        get { return _backgroundSpeed; }
        set { _backgroundSpeed = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _backgroundRenderer.material.mainTextureOffset += new Vector2(_backgroundSpeed * Time.deltaTime, 0f);
    }
}
